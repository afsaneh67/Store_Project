using System.Security.Claims;

namespace Web.Extensions
{
    public static class ClaimPrincipleExtension
    {
        public static string? GetUserId(this ClaimsPrincipal principle)
        {
            return principle.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
        public static string? GetPhoneNumber(this ClaimsPrincipal principle)
        {
            return principle.FindFirst("PhoneNumber")?.Value;
        }
    }
}
