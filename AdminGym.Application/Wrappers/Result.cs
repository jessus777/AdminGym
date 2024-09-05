namespace AdminGym.Application.Wrappers;
public class Result<T>
{
    public T Value { get; private set; }
    public bool IsSuccess { get; private set; }
    public List<string> Errors { get; private set; } = [];

    public static Result<T> Success(T value)
    {
        return new Result<T> { IsSuccess = true, Value = value };
    }

    public static Result<T> Failure(List<string> errors)
    {
        return new Result<T> { IsSuccess = false, Errors = errors };
    }
}
