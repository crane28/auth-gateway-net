using System;
using System.Collections.Generic;

namespace AuthGateway.Infrastructure.Entities;

public partial class Role
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool IsSystem { get; set; }
}
