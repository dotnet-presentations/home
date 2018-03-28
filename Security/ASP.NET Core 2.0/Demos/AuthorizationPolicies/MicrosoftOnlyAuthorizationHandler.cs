using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;

namespace AuthorizationPolicies
{
    public class MicrosoftOnlyAuthorizationHandler : AuthorizationHandler<MicrosoftOnlyRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MicrosoftOnlyRequirement requirement)
        {
            var isMicrosoftBadge = context.User.Claims.Any(c => c.Type == CustomClaims.BadgeId && c.Issuer == Issuer.Microsoft);

            if (isMicrosoftBadge)
            {
                var expiresOn = DateTime.MaxValue;

                if (context.User.Claims.Any(c => c.Type == CustomClaims.AccessExpiresOn && c.Issuer == Issuer.Microsoft))
                {
                    expiresOn = DateTime.Parse(
                        context.User.Claims.First(c => c.Type == CustomClaims.AccessExpiresOn && c.Issuer == Issuer.Microsoft).Value);
                }

                if (expiresOn > DateTime.Now)
                {
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;
        }
    }
}
