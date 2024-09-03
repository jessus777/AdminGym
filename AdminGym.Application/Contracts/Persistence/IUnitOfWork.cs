namespace AdminGym.Application.Contracts.Persistence;
public interface IUnitOfWork
    : IDisposable
{
    IUserRepositoryAsync UserRepository { get; }

    Task<int> SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}
