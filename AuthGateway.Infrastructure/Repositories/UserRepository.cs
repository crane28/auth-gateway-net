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

    public async Task<bool> AddAsync(Domain.Entities.User user, CancellationToken cancellationToken)
    {
        try
        {
            Infrastructure.Entities.User newUser = new Infrastructure.Entities.User()
            {
                Id = Guid.NewGuid(),
                Email = user.Email ?? string.Empty,
                Username = user.Username ?? string.Empty,
                Fullname = user.Fullname ?? string.Empty,
                PasswordHash = user.PasswordHash ?? string.Empty,
                StatusId = ParseDomainStatus(user.Status),
                FailedLoginCount = 0,
                LockedUntil = null,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _db.Users.AddAsync(newUser, cancellationToken);

            return await _db.SaveChangesAsync(cancellationToken) > 0;   
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        Infrastructure.Entities.User? user = await _db.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Email.ToLower() == email.ToLower(), cancellationToken);

        return user == null ? null : MapToDomain(user);
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        Infrastructure.Entities.User? user = await _db.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

        return user == null ? null : MapToDomain(user);
    }

    public async Task<User?> GetByUsernameAsync(string username, CancellationToken cancellationToken)
    {
        Infrastructure.Entities.User? user = await _db.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Username.ToLower() == username.ToLower(), cancellationToken);

        return user == null ? null : MapToDomain(user);
    }

    public async Task<bool> UpdateAsync(Guid id, Domain.Entities.User user, CancellationToken cancellationToken)
    {
        try
        {
            Infrastructure.Entities.User? existingUser = await _db.Users.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
            if (existingUser == null)
            {
                return false;
            }

            if (!string.IsNullOrEmpty(user.Email) && existingUser.Email != user.Email)
            {
                existingUser.Email = user.Email;
            }

            if (!string.IsNullOrEmpty(user.Username) && existingUser.Username != user.Username)
            {
                existingUser.Username = user.Username;
            }

            if (!string.IsNullOrEmpty(user.PasswordHash) && existingUser.PasswordHash != user.PasswordHash)
            {
                existingUser.PasswordHash = user.PasswordHash;
            }

            Guid newUserStatus = ParseDomainStatus(user.Status);
            if (user.Status != null && existingUser.StatusId != newUserStatus)
            {
                existingUser.StatusId = newUserStatus;
            }

            if (user.FailedLoginCount != null && existingUser.FailedLoginCount != user.FailedLoginCount)
            {
                existingUser.FailedLoginCount = user.FailedLoginCount.GetValueOrDefault();
            }

            existingUser.UpdatedAt = DateTime.UtcNow;

            return await _db.SaveChangesAsync(cancellationToken) > 0;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            // TODO: Implement soft delete
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
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

    public Guid ParseDomainStatus(Domain.Enums.UserStatus? userStatus)
    {
        return userStatus switch
        {
            Domain.Enums.UserStatus.Active => Infrastructure.Enums.UserStatus.Active,
            Domain.Enums.UserStatus.Inactive => Infrastructure.Enums.UserStatus.Inactive,
            Domain.Enums.UserStatus.Locked => Infrastructure.Enums.UserStatus.Locked,
            _ => throw new ArgumentOutOfRangeException(nameof(userStatus))
        };
    }

    // public Domain.Enums.UserStatus ParseInfrastructureStatus(Guid userStatus)
    // {
    //     return userStatus switch
    //     {
    //         Infrastructure.Enums.UserStatus.Active => Domain.Enums.UserStatus.Active,
    //         Infrastructure.Enums.UserStatus.Inactive => Domain.Enums.UserStatus.Inactive,
    //         Infrastructure.Enums.UserStatus.Locked => Domain.Enums.UserStatus.Locked,
    //         _ => throw new ArgumentOutOfRangeException(nameof(userStatus))
    //     };
    // }

    #endregion
}