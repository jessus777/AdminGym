using AdminGym.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace AdminGym.Application.Contracts.Persistence;
public interface IUserRepositoryAsync
{
    Task<IdentityResult> CreateUserAsync(User user, string password);
    Task<User> GetByIdAsync(Guid userId);
    Task<IEnumerable<User>> GetAllAsync();
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(Guid userId);
    Task<User> GetByEmailAsync(string email);
    Task<bool> UserExistsAsync(Guid userId);
    Task<bool> UserExistsByEmailAsync(string email);
    Task<bool> UserExistsByUserNameAsync(string userName);
}
