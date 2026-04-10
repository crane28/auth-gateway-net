namespace AuthGateway.Infrastructure.Enums;

public static class UserStatus
{
    public static Guid Active = Guid.Parse("7d5f1573-59c7-4d32-83a8-deb5581d6211");
    public static Guid Inactive = Guid.Parse("0b9e249b-89ee-4f24-abd8-4bbffb4f5afc");
    public static Guid Locked = Guid.Parse("5cf3b7bb-c054-47b0-bf89-67b3a786a2fe");
}