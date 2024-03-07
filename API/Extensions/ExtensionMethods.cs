using System.Security.Claims;

namespace API.Extensions
{
    public static class ExtensionMethods  
    {  
        public static string GetUsername(this ClaimsPrincipal User)  
        {  
            var claim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return claim;
        }  
    }  
}