using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;

namespace AuthorizationPolicies
{
    public class RoomEntryAuthorizationHandler : AuthorizationHandler<BuildingEntryRequirement, Room>
    {
        IRoomAccess _repository;

        public RoomEntryAuthorizationHandler(IRoomAccess repository)
        {
            _repository = repository;
        }

        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            BuildingEntryRequirement requirement,
            Room room)
        {
            var badgeDetails = context.User.Claims.FirstOrDefault(c => c.Type == CustomClaims.BadgeId && c.Issuer == Issuer.Microsoft);

            if (badgeDetails != null)
            {
                if (_repository.CanEnter(requirement.Building, room.Number, badgeDetails.Value))
                {
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;
        }
    }
}
