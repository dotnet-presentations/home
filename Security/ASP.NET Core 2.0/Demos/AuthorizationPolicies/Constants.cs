using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationPolicies
{
    public static class CustomClaims
    {
        public const string Account = "login";
        public const string AccessExpiresOn = "access.expires.on";
        public const string BadgeId = "badge.identifier";
    }

    public static class Issuer
    {
        public const string Microsoft = "urn:microsoft";
        public const string Contoso = "urn:contoso";
    }

    public static class AuthorizationPolicies
    {
        public const string MicrosoftBadge = "MicrosoftBadge";
    }
}
