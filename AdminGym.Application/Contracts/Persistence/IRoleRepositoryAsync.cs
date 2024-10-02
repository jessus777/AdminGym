using AdminGym.Domain.Entities;

namespace AdminGym.Application.Contracts.Persistence
{
    public interface IRoleRepositoryAsync
    {
        Task<Role?> CreateRoleAsync(Role role, CancellationToken cancellationToken);

        Task<Role?> ExistRoleAsync(string roleName, CancellationToken cancellationToken);

    }
}
