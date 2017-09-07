namespace GeekBrainsWork1.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Security;
    using System.Threading;

    using GeekBrainsWork1.Code;
    using GeekBrainsWork1.DAL.Context;

    using static Code.AuthorizationModule;
    using System.Collections.Generic;

    public class DefaultController : Controller
    {
        [HttpGet]
        public ActionResult UserInfo()
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                var userName = Thread.CurrentPrincipal.Identity.Name;
                return this.PartialView("_UserInfo", userName);
            }

            return this.PartialView("_UserInfo", "anonymous");
        }

        // GET: Default
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            var dbContext = new GeekBrainsWork1Context();
            var user = dbContext.User.ToList();

            return this.View(user);
        }

        [HttpGet]
        [MyAuthorize(Roles = CustomRoles.Administrator)]
        public ActionResult PeopleInfo(int id)
        {
            return this.View("Employee", EmployeeAndUser.GetById(id));
        }        

        [HttpGet]
        [MyAuthorize(Roles = CustomRoles.Administrator)]
        public ActionResult CreateEmployee()
        {
            return this.View("Employee", new Employee());
        }

        [HttpPost]
        [MyAuthorize(Roles = CustomRoles.Administrator)]
        public ActionResult CreateEmployee(Employee employee)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("Employee", employee);
            }

            EmployeeAndUser.EditOrAdd(employee);
            return this.RedirectToAction("Index");
        }

        [MyAuthorize(Roles = CustomRoles.Administrator)]
        public ActionResult DeleteEmployee(int id)
        {
            EmployeeAndUser.Delete(id);
            return this.RedirectToAction("Index");
        }
    }
}