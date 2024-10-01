﻿using AdminGym.Domain.Exceptions;
using AdminGym.WebApi.Extensions;
using AdminGym.WebApi.Resources;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;

namespace AdminGym.WebApi.Exceptions;

public sealed class ExceptionHandler : IExceptionHandler
{
    private readonly IHostEnvironment _environment;

    public ExceptionHandler(IHostEnvironment environment)
    {
        _environment = environment;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var culture = httpContext.GetPreferredCulture();
        var status = exception switch
        {
            AuthenticationException => StatusCodes.Status401Unauthorized,
            ValidationException => StatusCodes.Status400BadRequest,
            ExternalServiceException => StatusCodes.Status503ServiceUnavailable,
            _ => StatusCodes.Status500InternalServerError
        };
        var title = exception switch
        {
            AuthenticationException => ResourceMessage.ErrorAutenticacion,
            ValidationException => ResourceMessage.ErrorValidacion,
            ExternalServiceException => ResourceMessage.ErrorServicioExterno,
            _ => null
        };

        // Incluir detalles de excepciones en ambientes NO productivos
        var includeDetails = !_environment.IsProduction();

        var activity = System.Diagnostics.Activity.Current;

        var problemDetails = new ProblemDetails
        {
            Status = status,
            Type = $"https://developer.mozilla.org/{culture}/docs/Web/HTTP/Status/{status}",
            Title = includeDetails ? title ?? exception.GetType().Name : ResourceMessage.ErrorInternoServidor,
            Detail = includeDetails ? exception.Message : null,
            Extensions =
            {
                {"traceId", activity?.Id ?? httpContext.TraceIdentifier}
            }
        };

        if (exception is ValidationException validationException)
            problemDetails.Extensions.Add("errors", validationException.Errors);

        if (includeDetails)
            problemDetails.Extensions.Add("stackTrace", exception.ToString());

        httpContext.Response.StatusCode = status;
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
        return true;
    }
}