using System;
using System.Collections.Generic;
using System.Net;

namespace AuthGateway.Infrastructure.Entities;

public partial class AuditLog
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid ClientId { get; set; }

    public Guid EventTypeId { get; set; }

    public IPAddress IpAddress { get; set; } = null!;

    public string UserAgent { get; set; } = null!;

    public string Metadata { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}
