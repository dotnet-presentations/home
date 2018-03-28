using Microsoft.AspNetCore.Authorization;

namespace AuthorizationPolicies
{

    public class BuildingEntryRequirement : IAuthorizationRequirement
    {
        public string Building { get; set; }
    }
}
