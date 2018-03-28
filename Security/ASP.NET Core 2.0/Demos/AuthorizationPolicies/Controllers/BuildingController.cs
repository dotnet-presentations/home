using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AuthorizationPolicies.Controllers
{
    [Authorize(Policy = AuthorizationPolicies.MicrosoftBadge)]
    public class BuildingController : Controller
    {
        IAuthorizationService _authorizationService;

        public BuildingController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public async Task<IActionResult> Room(string building, string room)
        {
            var requirement = new BuildingEntryRequirement { Building = building };
            var resource = new Room { Number = room };

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, resource, requirement);
            if (authorizationResult.Succeeded)
            {
                return View();
            }
            else
            {
                return new ForbidResult();
            }
        }
    }
}