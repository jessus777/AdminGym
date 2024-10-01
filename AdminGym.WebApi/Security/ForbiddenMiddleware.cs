using AdminGym.WebApi.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Net;

namespace AdminGym.WebApi.Security;

public sealed class ForbiddenMiddleware
{
    private readonly RequestDelegate _next;

    public ForbiddenMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        await _next(context);

        const int forbidden = (int)HttpStatusCode.Forbidden;

        if (context.Response.StatusCode == forbidden)
        {
            var culture = context.GetPreferredCulture();

            context.Response.ContentType = "application/problem+json";

            await context.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Status = (int)HttpStatusCode.Forbidden,
                Type = $"https://developer.mozilla.org/{culture}/docs/Web/HTTP/Status/{forbidden}",
                Title = "No Autorizado", //Strings.NoAutorizado,
                Detail = "No cuenta con permisos"//Strings.NoCuentaConPermisosParaRealizarAccion
            }); 
        }
    }
}