using System;
using System.Collections.Generic;

namespace AuthGateway.Infrastructure.Entities;

public partial class SigningKey
{
    public Guid Id { get; set; }

    public string Kid { get; set; } = null!;

    public string Algorithm { get; set; } = null!;

    public string PublicKeyPem { get; set; } = null!;

    public string PrivateKeyPem { get; set; } = null!;

    public string IsActive { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? RetiredAt { get; set; }
}
