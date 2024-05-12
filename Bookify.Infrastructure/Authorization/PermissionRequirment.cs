using Microsoft.AspNetCore.Authorization;

namespace Bookify.Infrastructure.Authorization;

internal sealed class PermissionRequirment : IAuthorizationRequirement
{
    public PermissionRequirment(string permissions) 
        => Permission = permissions;
    
    public string Permission { get; }
}
