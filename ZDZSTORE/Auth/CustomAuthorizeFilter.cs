namespace ZDZSTORE.Auth
{
    public class CustomAuthorizeFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity?.IsAuthenticated ?? false)
            {
                context.Result = new UnauthorizedObjectResult("Access denied");
            }
        }
    }
}