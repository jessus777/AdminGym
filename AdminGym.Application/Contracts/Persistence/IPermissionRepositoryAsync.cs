using AdminGym.Domain.Entities;

namespace AdminGym.Application.Contracts.Persistence;
public interface IPermissionRepositoryAsync
{
    Task<Permission> CreatePermissionAsync(
        Permission permisson,
        CancellationToken cancellation
        );
    Task<IEnumerable<Permission>> GetAllPermissionAsync(
        CancellationToken cancellation
        );
}
