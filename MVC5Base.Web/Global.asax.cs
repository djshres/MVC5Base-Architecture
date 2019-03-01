using MVC5Base.Web.Models;
using System;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace MVC5Base.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            try
            {
                var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

                if (authCookie == null) return;
                var authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                if (authTicket == null) return;
                var serializer = new JavaScriptSerializer();

                var serializeModel =
                    serializer.Deserialize<CustomPrincipalSerializeModel>(authTicket.UserData);

                var newUser = new CustomPrincipal(authTicket.Name)
                {
                    Id = serializeModel.Id,
                    Name = serializeModel.Name,
                    RoleId = serializeModel.RoleId
                };

                HttpContext.Current.User = newUser;
            }
            catch (CryptographicException)
            {
                FormsAuthentication.SignOut();
            }

        }

    }
}
