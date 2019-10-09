using BEFOYS.Common.Convert;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace BEFOYS.Common.AppUser
{
    public static class AppUser
    {
        public static int UserID(this IIdentity identity)
        {
            var claimsIdentity = identity as ClaimsIdentity;
            return claimsIdentity.FindFirst(ClaimTypes.Sid).Value.ToInt();
        }
    }
}
