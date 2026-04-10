using System;
using System.Collections.Generic;

namespace AuthGateway.Infrastructure.Entities;

public partial class AuthorizationCode
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid ClientId { get; set; }

    public string CodeHash { get; set; } = null!;

    public string CodeChallenge { get; set; } = null!;

    public string RedirectUri { get; set; } = null!;

    public List<string> Scopes { get; set; } = null!;

    public string Nonce { get; set; } = null!;

    public DateTime ExpiresAt { get; set; }

    public DateTime? UsedAt { get; set; }
}
