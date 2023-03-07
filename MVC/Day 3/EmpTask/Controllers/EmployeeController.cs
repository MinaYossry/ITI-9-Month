using EmpTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmpTask.Controllers
{
    public class EmployeeController : Controller
    {

        EMPLOYEESEntities Context { get; set; } = new EMPLOYEESEntities();

        // GET: Employee
        public ActionResult Index(int? DeptID = null)
        {
            ViewBag.Depts = Context.Depts;
            List<Emp> emps;
            if (DeptID == null)
                emps = Context.Emps.ToList();
            else
                emps = Context.Emps.Where(e => e.dID == DeptID).ToList();
            return View(emps);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View(Context.Emps.Find(id));
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            ViewBag.Cities = Context.Cities;
            ViewBag.Depts = Context.Depts;

            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Emp E)
        {
            try
            {
                // TODO: Add insert logic here
                Context.Emps.Add(E);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Cities = Context.Cities;
            ViewBag.Depts = Context.Depts;

            return View(Context.Emps.Find(id));
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Emp E)
        {
            try
            {
                Emp SelectedEmp = Context.Emps.Find(id);

                SelectedEmp.EmpSalary = E.EmpSalary;
                SelectedEmp.EmpLname = E.EmpLname;
                SelectedEmp.EmpFname = E.EmpFname;
                SelectedEmp.dID = E.dID;
                SelectedEmp.CtyID = E.CtyID;
                SelectedEmp.EmpHDate = E.EmpHDate;

                Context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Context.Emps.Find(id));
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Context.Emps.Remove(Context.Emps.Find(id));
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
