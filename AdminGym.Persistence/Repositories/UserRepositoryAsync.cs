using AdminGym.Application.Contracts.Persistence;
using AdminGym.Domain.Entities;
using AdminGym.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace AdminGym.Persistence.Repositories;
public class UserRepositoryAsync
    : IUserRepositoryAsync
{
    private readonly ApplicationDbEFContext _context;

    public UserRepositoryAsync(ApplicationDbEFContext context)
    {
        _context = context;
    }

    public async Task AddAsync(User user)
    {
        await _context.AddAsync(user);
    }

    public async Task DeleteAsync(Guid userId)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user != null)
        {
            _context.Users.Remove(user);
        }
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .ToListAsync();
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .SingleOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User?> GetByIdAsync(Guid userId)
    {
        return await _context.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .SingleOrDefaultAsync(u => u.Id == userId);
    }

    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await Task.CompletedTask; // Task.CompletedTask for EF Core
    }

    public async Task<bool> UserExistsAsync(Guid userId)
    {
        return await _context.Users.AnyAsync(u => u.Id == userId);
    }
}
