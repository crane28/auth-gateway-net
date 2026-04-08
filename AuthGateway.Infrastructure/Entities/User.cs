using System;
using System.Collections.Generic;

namespace AuthGateway.Infrastructure.Entities;

public partial class User
{
    public Guid Id { get; set; }

    public string Email { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Fullname { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public Guid StatusId { get; set; }

    public int FailedLoginCount { get; set; }

    public DateTime? LockedUntil { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
