using AdminGym.Application.Contracts.Infrastructure;
using AdminGym.Application.Contracts.Persistence;
using AdminGym.Application.Features.UserManagement.Dtos;
using AdminGym.Domain.Entities;
using AdminGym.Persistence.DbContexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

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
    }
}
