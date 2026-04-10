using AuthGateway.Domain.Entities;

namespace AuthGateway.Domain.Interfaces.Repositories;

public interface IUserRepository
{
    bool Insert(User user);
    Task<User?> GetByIdAsync(Guid id);
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByUsernameAsync(string username);
    bool Update(string id, User user);
    bool Delete(string id);
}