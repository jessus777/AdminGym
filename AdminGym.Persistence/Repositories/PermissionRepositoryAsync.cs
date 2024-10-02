using AdminGym.Application.Contracts.Persistence;
using AdminGym.Domain.Entities;
using AdminGym.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace AdminGym.Persistence.Repositories
{
    public class PermissionRepositoryAsync
        : IPermissionRepositoryAsync
    {
        private readonly ApplicationDbEFContext _context;

        public PermissionRepositoryAsync(ApplicationDbEFContext context)
        {
            _context = context;
        }

        public async Task<Permission> CreatePermissionAsync(
            Permission permisson,
            CancellationToken cancellationToken
            )
        {
            var entityEntry = await _context.Permissions.AddAsync(permisson, cancellationToken);
            return entityEntry.Entity;
        }

        public async Task<IEnumerable<Permission>> GetAllPermissionAsync(
            CancellationToken cancellation
            )
        {
            return await _context.Permissions.ToListAsync(cancellation);
        }
    }
}
