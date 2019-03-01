using MVC5Base.Web.Models;
using System.Web.Mvc;

namespace MVC5Base.Web.Areas.Students
{
    public class BaseController : Controller
    {
        public CustomPrincipal UserInfo => HttpContext.User as CustomPrincipal;
    }
}