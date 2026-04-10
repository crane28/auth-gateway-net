using System;
using System.Collections.Generic;

namespace AuthGateway.Infrastructure.Entities;

public partial class OauthClient
{
    public Guid Id { get; set; }

    public string ClientId { get; set; } = null!;

    public string ClientSecretHash { get; set; } = null!;

    public string ClientType { get; set; } = null!;

    public string Name { get; set; } = null!;

    public List<string> AllowedGrantTypes { get; set; } = null!;

    public List<string> AllowedScopes { get; set; } = null!;

    public List<string> RedirectUris { get; set; } = null!;

    public List<string> PostLogoutRedirectUris { get; set; } = null!;

    public bool RequiredPkce { get; set; }

    public bool RequiredConsent { get; set; }

    public int AccessTokenLifetimeInSec { get; set; }

    public int RefreshTokenLifetimeInSec { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTime UpdatedAt { get; set; }

    public Guid UpdatedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public Guid? DeletedBy { get; set; }
}
