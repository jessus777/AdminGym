using AdminGym.Domain.Resources;
using FluentResults;
using Toolkit.Text;


namespace AdminGym.Domain.Errors;
public abstract class DomainError
    : Error
{
    private static readonly Dictionary<Type, string> ErrorCodes = new();

    protected DomainError()
    {
        Code = ResolveCode(GetType());
    }

    public string Code { get; }
    public string? Detail { get; protected set; }

    private static string ResolveCode(Type errorType)
    {
        if (!errorType.IsDomainError())
            throw new ArgumentException(string.Format(StringErrors.TipoErrorNoValido, errorType.Name), nameof(errorType));

        if (ErrorCodes.TryGetValue(errorType, out var errorCode))
            return errorCode;

        errorCode = errorType.Name;
        const string suffix = "Error";
        var suffixIndex = errorCode.IndexOf(suffix, StringComparison.Ordinal);
        if (suffixIndex >= 0)
            errorCode = errorCode[..suffixIndex];

        errorCode = errorCode.ApplyConvention(CaseConvention.LowerSnakeCase);
        ErrorCodes[errorType] = errorCode;
        return errorCode;
    }

    public static Result EntityNotFound(object identifier)
        => Result.Fail(new EntityNotFoundError(identifier));

    public static Result DuplicateEntity(object identifier)
        => Result.Fail(new DuplicateEntityError(identifier));

    public static Result EntityConflict(object identifier, string detail)
        => Result.Fail(new EntityConflictError(identifier, detail));
}
