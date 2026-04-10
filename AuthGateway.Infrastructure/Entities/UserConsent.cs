using System;
using System.Collections.Generic;

namespace AuthGateway.Infrastructure.Entities;

public partial class UserConsent
{
    public Guid UserId { get; set; }

    public Guid ClientId { get; set; }

    public List<string> GrantedScopes { get; set; } = null!;

    public DateTime GrantedAt { get; set; }

    public DateTime? RevokedAt { get; set; }
}
