using AdminGym.Domain.Entities;

namespace AdminGym.Application.Contracts.Persistence;
public interface IUserRepositoryAsync
{
    Task<User> GetByIdAsync(Guid userId);
    Task<IEnumerable<User>> GetAllAsync();
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(Guid userId);
    Task<User> GetByEmailAsync(string email);
    Task<bool> UserExistsAsync(Guid userId);
}
