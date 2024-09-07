

using AdminGym.Domain.Resources;

namespace AdminGym.Domain.Errors;
public sealed class DuplicateEntityError : DomainError
{
    public DuplicateEntityError(object identifier)
    {
        Identifier = identifier;
        Message = StringErrors.TipoErrorNoValido;
        Detail = string.Format(StringErrors.TipoErrorNoValido, identifier);
    }

    public object Identifier { get; }
}
