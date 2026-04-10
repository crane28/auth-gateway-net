using AuthGateway.Domain.Entities;
using AuthGateway.Domain.Interfaces.Repositories;
using AuthGateway.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AuthGateway.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AuthGatewayContext _db;

    public UserRepository(AuthGatewayContext db)
    {
        _db = db;
    }

    #region Data Access Methods

    public bool Insert(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        Infrastructure.Entities.User? user = await _db.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(o => EF.Functions.ILike(o.Email, email));

        return user == null ? null : MapToDomain(user);
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        Infrastructure.Entities.User? user = await _db.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Id == id);

        return user == null ? null : MapToDomain(user);
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        Infrastructure.Entities.User? user = await _db.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(o => EF.Functions.ILike(o.Username, username));

        return user == null ? null : MapToDomain(user);
    }

    public bool Update(string id, User user)
    {
        throw new NotImplementedException();
    }

    public bool Delete(string id)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Helper Methods

    public Domain.Entities.User MapToDomain(Infrastructure.Entities.User user)
    {
        return new Domain.Entities.User()
        {
            Id = user.Id,
            Email = user.Email,
            Username = user.Username,
            Fullname = user.Fullname,
            PasswordHash = user.PasswordHash,
            FailedLoginCount = user.FailedLoginCount,
            LockedUntil = user.LockedUntil
        };
    }

    #endregion
}