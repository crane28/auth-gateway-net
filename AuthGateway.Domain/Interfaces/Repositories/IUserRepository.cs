using AuthGateway.Domain.Entities;

namespace AuthGateway.Domain.Interfaces.Repositories;

public interface IUserRepository
{
    Task<bool> AddAsync(User user, CancellationToken ct);
    Task<User?> GetByIdAsync(Guid id, CancellationToken ct);
    Task<User?> GetByEmailAsync(string email, CancellationToken ct);
    Task<User?> GetByUsernameAsync(string username, CancellationToken ct);
    Task<bool> UpdateAsync(Guid id, User user, CancellationToken ct);
    Task<bool> DeleteAsync(Guid id, CancellationToken ct);
}