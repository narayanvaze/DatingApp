using System.Security.Claims;

namespace API.Extensions
{
    public static class ClaimsPrincipalExtensions  
    {  
        public static string GetUsername(this ClaimsPrincipal User)  
        {  
            var claim = User.FindFirst(ClaimTypes.Name)?.Value;
            return claim;
        }  

        public static int GetUserId(this ClaimsPrincipal user)
        {
            return int.Parse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }
    }  
}