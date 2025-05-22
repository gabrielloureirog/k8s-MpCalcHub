using Microsoft.AspNetCore.Authorization;
using MPCalcHub.Application.Authorization;
using MPCalcHub.Domain.Enums;

namespace MPCalcHub.Infrastructure.Security;

public static class AuthorizationOptionsExtensions
{
    public static AuthorizationOptions AddPolicyWithPermission(this AuthorizationOptions options, string policyName, PermissionLevel permission)
    {
        options.AddPolicy(policyName, policy => policy.Requirements.Add(new RolesRequirement(permission)));
        return options;
    }
}