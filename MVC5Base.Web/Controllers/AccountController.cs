using MVC5Base.Helper;
using MVC5Base.ViewModels;
using MVC5Base.Web.Models;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace MVC5Base.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly DbHelper _dbHelper;

        public AccountController()
        {
            _dbHelper = new DbHelper();
        }

        [AllowAnonymous]
        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public ActionResult Login()
        {
            var model = new LoginViewModel();
            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.ErrorMessage = "Enter all the required fields in correct format.";
                return View(model);
            }

            var personInfo = _dbHelper.GetUser(model.Username, model.Password);

            if (personInfo == null)
            {
                model.ErrorMessage = "Invalid username or password.";
                return View(model);
            }

            var serializeModel = new CustomPrincipalSerializeModel
            {
                Id = personInfo.Id,
                RoleId = personInfo.RoleId,
                Name = personInfo.Username
            };

            var userData = new JavaScriptSerializer().Serialize(serializeModel);
            var authTicket = new FormsAuthenticationTicket(1, model.Id.ToString(), DateTime.Now, DateTime.Now.AddMinutes(30), false, userData);
            var encTicket = FormsAuthentication.Encrypt(authTicket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket)
            {
                Expires = DateTime.Now.AddMinutes(30)
            };
            Response.Cookies.Add(cookie);

            if (personInfo.RoleId == 1)
                return RedirectToAction("Index", "Home", new { Area = "Admin" });

            return RedirectToAction("Index", "Profile", new { Area = "Students" });
        }

        public ActionResult Logout()
        {
            var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null) return RedirectToAction("Login", "Account");

            authCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(authCookie);
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        protected override void Dispose(bool disposing)
        {
            _dbHelper.Dispose();
            base.Dispose(disposing);
        }
    }
}