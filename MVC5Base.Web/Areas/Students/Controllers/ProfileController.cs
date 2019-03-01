using MVC5Base.Helper;
using MVC5Base.ViewModels;
using MVC5Base.Web.Models;
using System.Web.Mvc;

namespace MVC5Base.Web.Areas.Students.Controllers
{
    [AuthorizeStudent]
    public class ProfileController : BaseController
    {
        private readonly DbHelper _dbHelper;

        public ProfileController()
        {
            _dbHelper = new DbHelper();
        }

        public ActionResult Index()
        {
            var model = _dbHelper.GetStudentByUserId(UserInfo.Id);

            if (model == null)

                return RedirectToAction("Login", "Account");


            return View(model);
        }

        public ActionResult Edit()
        {
            var model = _dbHelper.GetStudentByUserId(UserInfo.Id);

            if (model == null)
                return RedirectToAction("Login", "Account");

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(StudentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.ErrorMessage = "Enter all the required fields in correct format.";
                return View(model);
            }

            if (_dbHelper.EditStudent(model.Id, model.Name, model.Address, model.Age, model.Email))
                return RedirectToAction("Index");

            model.ErrorMessage = "Failed to update profile info.";
            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            _dbHelper.Dispose();
            base.Dispose(disposing);
        }
    }
}