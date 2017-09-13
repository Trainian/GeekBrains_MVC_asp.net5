using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeekBrainsWork1.Controllers
{
    using GeekBrainsWork1.Code;
    using GeekBrainsWork1.Content;
    using GeekBrainsWork1.Models;
    using static GeekBrainsWork1.Content.AuthorizationModule;

    public class DefaultController : Controller
    {

        // GET: Default
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            return View(EmployeeAndUser.GetList());
        }

        [HttpGet]
        [MyAuthorize(Roles = CustomRoles.Administrator)]
        public ActionResult PeopleInfo(int id)
        {
            return View("Employee", EmployeeAndUser.GetById(id));
        }        

        [HttpGet]
        [MyAuthorize(Roles = CustomRoles.Administrator)]
        public ActionResult CreateEmployee()
        {
            return View("Employee", new Employee());
        }

        [HttpPost]
        [MyAuthorize(Roles = CustomRoles.Administrator)]
        public ActionResult CreateEmployee (Employee employee)
        {
            if (!ModelState.IsValid)
                return View("Employee", employee);
            EmployeeAndUser.EditOrAdd(employee);
            return RedirectToAction("Index");
        }

        [MyAuthorize(Roles = CustomRoles.Administrator)]
        public ActionResult DeleteEmployee (int id)
        {
            EmployeeAndUser.Delete(id);
            return RedirectToAction("Index");
        }
    }
}