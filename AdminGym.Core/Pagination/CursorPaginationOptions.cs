namespace AdminGym.Domain.Pagination;
public abstract class CursorPaginationOptions<TCursor>
    : PaginationOptions
{

    public CursorPaginationOptions(TCursor cursor, long? pageZise = null)
        : base(pageZise)
    {
        Cursor = cursor;
    }
    public TCursor Cursor { get; }
}
