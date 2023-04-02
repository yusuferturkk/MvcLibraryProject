using MvcLibraryProject.Models;
using MvcLibraryProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibraryProject.Controllers
{
    public class EmployeeController : Controller
    {

        EmployeeRepository repository = new EmployeeRepository();

        public ActionResult Index()
        {
            var values = repository.GetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(TblEmployee tblEmployee)
        {
            repository.Add(tblEmployee);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteEmployee(int id)
        {
            var value = repository.GetById(id);
            repository.Delete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateEmployee(int id)
        {
            var value = repository.GetById(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateEmployee(TblEmployee tblEmployee)
        {
            repository.Update(tblEmployee);
            return RedirectToAction("Index");
        }
    }
}