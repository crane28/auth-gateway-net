using System;
using System.Collections.Generic;

namespace AuthGateway.Infrastructure.Entities;

public partial class Application
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string SecretHash { get; set; } = null!;

    public List<string> AllowedCallbackUrls { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
