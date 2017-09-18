using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GeekBrainsWork1.DAL.Context;
using GeekBrainsWork1.Domain.Entities;
using System.Threading;
using GeekBrainsWork1.Code;

namespace GeekBrainsWork1.Controllers
{
    public class EmployeesController : Controller
    {
        private GeekBrainsWork1Context dbContext = new GeekBrainsWork1Context();

        // GET: Employees
        public ActionResult Index()
        {
            var employee = dbContext.Employee.Include(e => e.Position);
            return View(employee.ToList());
        }

        public ActionResult UserInfo()
        {
            if (Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                var userName = Thread.CurrentPrincipal.Identity.Name;
                return PartialView("_UserInfo", userName);
            }
            return PartialView("_UserInfo");
        }

        // GET: Employees/Details/5
        
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = dbContext.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        [AuthorizationModule(Roles = "administrator")]
        public ActionResult Create()
        {
            ViewBag.PositionId = new SelectList(dbContext.Position, "Id", "Name");
            return View();
        }

        // POST: Employees/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,SurName,Patronymie,Age,PositionId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                dbContext.Employee.Add(employee);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PositionId = new SelectList(dbContext.Position, "Id", "Name", employee.PositionId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        [AuthorizationModule(Roles = "administrator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = dbContext.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.PositionId = new SelectList(dbContext.Position, "Id", "Name", employee.PositionId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,SurName,Patronymie,Age,PositionId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(employee).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PositionId = new SelectList(dbContext.Position, "Id", "Name", employee.PositionId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        [AuthorizationModule(Roles = "administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = dbContext.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = dbContext.Employee.Find(id);
            dbContext.Employee.Remove(employee);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
