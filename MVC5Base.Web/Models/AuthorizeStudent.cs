using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC5Base.Web.Models
{
    public class AuthorizeStudent : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!httpContext.User.Identity.IsAuthenticated) return false;
            return ((CustomPrincipal)httpContext.User).RoleId == 2;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (AuthorizeCore(filterContext.HttpContext))
            {
                base.OnAuthorization(filterContext);
                return;
            }
            HandleUnauthorizedRequest(filterContext);

        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result =
                new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Account", action = "Login", area = "" }));


        }
    }
}