using System;
using System.Collections.Generic;

namespace AuthGateway.Infrastructure.Entities;

public partial class EventType
{
    public Guid Id { get; set; }

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;
}
