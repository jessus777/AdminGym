namespace AdminGym.Application.Contracts.Persistence
{
    public interface IUserManagmentUnitOfWork
        : IUnitOfWork
    {
        IUserRepositoryAsync UserRepository { get; }
        IPermissionRepositoryAsync PermissionRepository { get; }
    }
}
