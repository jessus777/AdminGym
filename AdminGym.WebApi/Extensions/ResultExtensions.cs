using AdminGym.Domain.Errors;
using AdminGym.WebApi.Resources;
using FluentResults;
using Microsoft.AspNetCore.Mvc;


namespace AdminGym.WebApi.Extensions;

public static class ResultExtensions
{
    public static IActionResult ToProblemDetails<TResult>(
        this Result<TResult> result,
        int? statusCode = null,
        string? title = null,
        string? detail = null,
        string? type = null
    ) => ToProblemDetails(result.ToResult(), statusCode, title, detail, type);

    public static IActionResult ToProblemDetails(
        this Result result,
        int? statusCode = null,
        string? title = null,
        string? detail = null,
        string? type = null
    )
    {
        if (result.IsSuccess || result.Errors.Count == 0)
            throw new InvalidOperationException(ResourceMessage.ErrorMessage);

        var firstError = result.Errors.FirstOrDefault();

        var finalStatusCode = statusCode;
        if (!statusCode.HasValue && (firstError?.IsDomainError() ?? false))
        {
            // Resolver código de estado a partir del tipo de error de dominio
            finalStatusCode = firstError.ToDomainError() switch
            {
                EntityNotFoundError => 404,
                EntityConflictError => 409,
                DuplicateEntityError => 409,
                _ => 500
            };
        }

        var problemDetails = new ProblemDetails
        {
            Status = finalStatusCode ?? StatusCodes.Status500InternalServerError,
            Type = type ?? $"https://httpstatuses.com/{statusCode}",
            Title = title ?? firstError?.Message,
            Detail = detail ?? firstError?.ToDomainError()?.Detail
        };

        if (result.Errors.Count != 0)
        {
            problemDetails.Extensions["errors"] = result.Errors.Select(e => new
            {
                ErrorMessage = e.Message,
                ErrorDetail = e is DomainError domainError ? domainError.Detail : null,
                e.Metadata
            });
        }

        return new ObjectResult(problemDetails);
    }
}
