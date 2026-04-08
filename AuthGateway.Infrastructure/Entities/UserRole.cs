using System;
using System.Collections.Generic;

namespace AuthGateway.Infrastructure.Entities;

public partial class UserRole
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid ApplicationId { get; set; }

    public DateTime CreatedAt { get; set; }

    public Guid? CreatedBy { get; set; }
}
