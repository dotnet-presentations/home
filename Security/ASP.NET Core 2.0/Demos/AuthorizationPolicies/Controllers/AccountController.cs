using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace AuthorizationPolicies.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SelectUser(string user, string issuer, bool temporaryBadge=false, string returnUrl = null)
        {

            var claims = new List<Claim>
            {
                new Claim(CustomClaims.Account, user.ToUpperInvariant(), ClaimValueTypes.String, issuer)
            };

            switch (user.ToLowerInvariant())
            {
                case "andrew":
                    claims.Add(new Claim(ClaimTypes.Name, "Andrew Stanton-Nurse", ClaimValueTypes.String, issuer));
                    claims.Add(new Claim(CustomClaims.BadgeId, "911", ClaimValueTypes.String, issuer));
                    break;
                case "barry":
                    claims.Add(new Claim(ClaimTypes.Name, "Barry Dorrans", ClaimValueTypes.String, issuer));
                    claims.Add(new Claim(CustomClaims.BadgeId, "999", ClaimValueTypes.String, issuer));
                    break;
                case "david":
                    claims.Add(new Claim(ClaimTypes.Name, "David Fowler", ClaimValueTypes.String, issuer));
                    claims.Add(new Claim(CustomClaims.BadgeId, "911", ClaimValueTypes.String, issuer));
                    break;
                default:
                    break;
            }

            if (temporaryBadge)
            {
                claims.Add(new Claim(CustomClaims.AccessExpiresOn, DateTime.Today.AddDays(-1).ToString("s"), ClaimValueTypes.Date, issuer));
            }
            else
            {
                claims.Add(new Claim(CustomClaims.AccessExpiresOn, DateTime.MaxValue.ToString("s"), ClaimValueTypes.Date, issuer));
            }

            var userIdentity = new ClaimsIdentity("BadgeAccess");
            userIdentity.AddClaims(claims);
            var userPrincipal = new ClaimsPrincipal(userIdentity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme, 
                userPrincipal,
                new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                    IsPersistent = false,
                    AllowRefresh = false
                });

            return RedirectToLocal(returnUrl);
        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToLocal("/");
        }

        public IActionResult Forbidden()
        {
            return View();
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}