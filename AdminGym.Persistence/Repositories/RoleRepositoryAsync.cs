using AdminGym.Application.Contracts.Persistence;
using AdminGym.Domain.Entities;
using AdminGym.Persistence.DbContexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AdminGym.Persistence.Repositories;
public class RoleRepositoryAsync
    : IRoleRepositoryAsync
{
    private readonly ApplicationDbEFContext _context;
    private readonly RoleManager<Role> _roleManager;

    public RoleRepositoryAsync(
        ApplicationDbEFContext context,
        RoleManager<Role> roleManager
        )
    {
        _context = context;
        _roleManager = roleManager;
    }

    public async Task<Role?> CreateRoleAsync(Role role, CancellationToken cancellationToken)
    {
        var result = await _roleManager.CreateAsync(role);
        if (result?.Succeeded == true)
        {
            return  await _roleManager.FindByNameAsync(role.Name);
        }

        return null;
    }

    public async Task<Role?> ExistRoleAsync(string roleName, CancellationToken cancellationToken)
    {
        return await _roleManager.FindByNameAsync(roleName);
    }
}
