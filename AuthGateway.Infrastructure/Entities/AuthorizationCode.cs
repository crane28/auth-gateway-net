using System;
using System.Collections.Generic;

namespace AuthGateway.Infrastructure.Entities;

public partial class AuthorizationCode
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid ApplicationId { get; set; }

    public string Code { get; set; } = null!;

    public bool IsUsed { get; set; }

    public DateTime? UsedAt { get; set; }

    public DateTime? ExpiresAt { get; set; }

    public DateTime CreatedAt { get; set; }
}
