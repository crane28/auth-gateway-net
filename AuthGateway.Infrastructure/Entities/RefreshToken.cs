using System;
using System.Collections.Generic;
using System.Net;

namespace AuthGateway.Infrastructure.Entities;

public partial class RefreshToken
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid ClientId { get; set; }

    public string TokenHash { get; set; } = null!;

    public List<string> Scopes { get; set; } = null!;

    public Guid FamilyId { get; set; }

    public Guid ReplacedById { get; set; }

    public DateTime ExpiresAt { get; set; }

    public DateTime? RevokedAt { get; set; }

    public IPAddress IpAddress { get; set; } = null!;

    public string UserAgent { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}
