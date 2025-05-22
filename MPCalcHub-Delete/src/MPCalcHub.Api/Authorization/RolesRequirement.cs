using Microsoft.AspNetCore.Authorization;
using MPCalcHub.Domain.Enums;

namespace MPCalcHub.Application.Authorization;

public class RolesRequirement(PermissionLevel permission) : IAuthorizationRequirement
{
    public PermissionLevel Permission { get; } = permission;
}