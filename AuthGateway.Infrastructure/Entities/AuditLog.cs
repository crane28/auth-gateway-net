using System;
using System.Collections.Generic;
using System.Net;

namespace AuthGateway.Infrastructure.Entities;

public partial class AuditLog
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid ApplicationId { get; set; }

    public string EventType { get; set; } = null!;

    public IPAddress IpAddress { get; set; } = null!;

    public string UserAgent { get; set; } = null!;

    public string Metadata { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}
