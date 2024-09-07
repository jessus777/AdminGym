using AdminGym.Domain.Resources;

namespace AdminGym.Domain.Errors;
public sealed class EntityConflictError : DomainError
{
    public EntityConflictError(object identifier, string detail)
    {
        Identifier = identifier;
        Message = StringErrors.TipoErrorNoValido;
        Detail = detail;
    }

    public object Identifier { get; }
}
