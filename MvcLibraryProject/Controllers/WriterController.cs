using MvcLibraryProject.Models;
using MvcLibraryProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcLibraryProject.Controllers
{
    public class WriterController : Controller
    {

        WriterRepository repository = new WriterRepository();

        public ActionResult Index()
        {
            var values = repository.GetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(TblWriter tblWriter)
        {
            repository.Add(tblWriter);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteWriter(int id)
        {
            var value = repository.GetById(id);
            repository.Delete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateWriter(int id)
        {
            var value = repository.GetById(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateWriter(TblWriter tblWriter)
        {
            repository.Update(tblWriter);
            return RedirectToAction("Index");
        }
    }
}