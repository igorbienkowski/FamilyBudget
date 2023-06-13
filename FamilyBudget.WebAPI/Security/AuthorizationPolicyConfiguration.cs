using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace FamilyBudget.WebAPI.Security;

public class AuthorizationPolicyConfiguration
{
    public static void Configure(AuthorizationOptions options)
    {
        options.AddPolicy("UserRolePolicy", policy =>
        {
            policy.RequireAuthenticatedUser();
            policy.RequireClaim(ClaimTypes.Role, "user");
        });
    }
}