using MVC5Base.Helper;
using MVC5Base.ViewModels;
using MVC5Base.Web.Models;
using System.Web.Mvc;

namespace MVC5Base.Web.Areas.Admin.Controllers
{
    [AuthorizeAdmin]
    public class StudentController : Controller
    {
        private readonly DbHelper _dbHelper;

        public StudentController()
        {
            _dbHelper = new DbHelper();
        }
        public ActionResult Index()
        {
            var list = _dbHelper.GetStudents();

            return View(list);
        }

        public ActionResult Create()
        {
            var model = new StudentRegisterViewModel();

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(StudentRegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.ErrorMessage = "Enter all the required fields in corrent format.";
                return View(model);
            }

            if (_dbHelper.IsUsernameExists(model.Username))
            {
                model.ErrorMessage = "Username already exists. Please choose another username.";
                return View(model);
            }

            if (_dbHelper.AddStudent(model.Name, model.Address, model.Age, model.Email, model.Username, model.Password))
                return RedirectToAction("Index");

            model.ErrorMessage = "Failed to add new student.";
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var model = _dbHelper.GetStudentById(id); //MvcApplication.Students.FirstOrDefault(x => x.Id == id);

            if (model == null)
                return RedirectToAction("Index");

            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(StudentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.ErrorMessage = "Enter all the required fields in corrent format.";
                return View(model);
            }

            if (_dbHelper.EditStudent(model.Id, model.Name, model.Address, model.Age, model.Email))
                return RedirectToAction("Index");

            model.ErrorMessage = "Failed to update stuent record.";
            return View(model);
        }

        //public ActionResult Delete(int id)
        //{
        //    //var objStudent = MvcApplication.Students.FirstOrDefault(x => x.Id == id);
        //    //if (objStudent == null)
        //    //    return RedirectToAction("Index");

        //    //MvcApplication.Students.Remove(objStudent);

        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            _dbHelper.Dispose();
            base.Dispose(disposing);
        }
    }
}