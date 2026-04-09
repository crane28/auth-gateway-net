using AuthGateway.Domain.Enums;

namespace AuthGateway.Domain.Entities;

public class User
{
    #region Properties

    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string Fullname { get; set; }
    public string PasswordHash { get; set; }
    public UserStatus status { get; set; }
    public int FailedLoginCount { get; set; }
    public DateTime? LockedUntil { get; set; }

    #endregion
}