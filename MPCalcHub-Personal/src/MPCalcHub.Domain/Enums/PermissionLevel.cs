namespace MPCalcHub.Domain.Enums;

[Flags]
public enum PermissionLevel
{
    SuperUser = 1,
    User = 2,
    Moderator = 4,
    Guest = 8,
    Banned = 16
}