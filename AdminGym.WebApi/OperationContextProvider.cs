using AdminGym.Application.Contracts.Infrastructure;
using AdminGym.Domain.Common;
using Microsoft.VisualBasic;
using System.Security.Authentication;

namespace AdminGym.WebApi;

public sealed class OperationContextProvider 
    //: IOperationContextProvider
{
    private OperationContext? _operationContext;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILogger<OperationContextProvider> _logger;

    public OperationContextProvider(IHttpContextAccessor httpContextAccessor, ILogger<OperationContextProvider> logger)
    {
        _httpContextAccessor = httpContextAccessor;
        _logger = logger;
    }

    //private OperationContext? TryResolveOperationContext()
    //{
    //    try
    //    {
    //        return ResolveOperationContext();
    //    }
    //    catch (Exception exception)
    //    {
    //        _logger.LogWarning(exception, "No se pudo resolver el contexto de operación");
    //        return null;
    //    }
    //}

    //private OperationContext ResolveOperationContext()
    //{
    //    var httpContext = _httpContextAccessor.HttpContext;
    //    if (httpContext is null)
    //        throw new InvalidOperationException(Strings.ContextoOperacionNoValido);

    //    // Cada cuenta de servicio representa la aplicación cliente de esta API.
    //    // La aplicación cliente debe proporcionar su API Key en cada petición.
    //    // La API Key está asociada a la cuenta de servicio.
    //    var idCuentaServicio = httpContext.User.GetIdCuentaServicioOrDefault();
    //    if (string.IsNullOrEmpty(idCuentaServicio))
    //        throw new AuthenticationException(Strings.ApiKeyNoValido);

    //    // La cuenta de usuario representa al usuario autenticado en la aplicación cliente.
    //    // La cuenta de usuario se obtiene a partir de un access token que debe incluirse en cada petición.
    //    var idCuentaUsuario = httpContext.User.GetIdCuentaUsuarioOrDefault();
    //    if (string.IsNullOrEmpty(idCuentaUsuario))
    //        throw new AuthenticationException(Strings.TokenAccesoNoValido);

    //    var idUsuario = httpContext.User.GetIdUsuarioOrDefault();
    //    if (string.IsNullOrEmpty(idUsuario))
    //        throw new AuthenticationException(Strings.TokenAccesoNoValido);

    //    httpContext.Items.TryGetValue("Accion", out var accion);

    //    return new OperationContext(idCuentaServicio, idCuentaUsuario, idUsuario, accion?.ToString());
    //}

    //public void SetContext(OperationContext operationContext)
    //{
    //    _operationContext = TryResolveOperationContext();

    //    if (_operationContext is not null)
    //        throw new InvalidOperationException(Strings.ContextoOperacionYaEstablecido);

    //    _operationContext = operationContext;
    //}

    //public OperationContext GetContext()
    //{
    //    if (_operationContext is not null)
    //        return _operationContext;

    //    _operationContext = ResolveOperationContext();

    //    return _operationContext;
    //}
}
