using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Base.Web.Areas.Students.Controllers
{
    public class HomeController : Controller
    {
        // GET: Students/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}