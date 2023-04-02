using MvcLibraryProject.Models;
using MvcLibraryProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace MvcLibraryProject.Controllers
{
    public class BookController : Controller
    {

        BookRepository repository = new BookRepository();
        CategoryRepository categoryRepository = new CategoryRepository();
        WriterRepository writerRepository = new WriterRepository();

        public ActionResult Index(string key)
        {
            var values = from x in repository.GetList() select x;

            if (!string.IsNullOrEmpty(key))
            {
                values = values.Where(x => x.BookName.Contains(key));
            }

            return View(values.ToList());
        }

        [HttpGet]
        public ActionResult AddBook()
        {
            List<SelectListItem> categories = (from x in categoryRepository.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();

            ViewBag.categories = categories;

            List<SelectListItem> writers = (from x in writerRepository.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.WriterName + " " + x.WriterSurname,
                                                   Value = x.WriterId.ToString()
                                               }).ToList();

            ViewBag.writers = writers;
            return View();
        }

        [HttpPost]
        public ActionResult AddBook(TblBook tblBook)
        {
            tblBook.BookStatus = true;
            repository.Add(tblBook);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteBook(int id)
        {
            var value = repository.GetById(id);
            value.BookStatus = false;
            repository.Update(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateBook(int id)
        {
            List<SelectListItem> categories = (from x in categoryRepository.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();

            ViewBag.categories = categories;

            List<SelectListItem> writers = (from x in writerRepository.GetList()
                                            select new SelectListItem
                                            {
                                                Text = x.WriterName + " " + x.WriterSurname,
                                                Value = x.WriterId.ToString()
                                            }).ToList();

            ViewBag.writers = writers;

            var value = repository.GetById(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateBook(TblBook tblBook)
        {
            tblBook.BookStatus = true;
            repository.Update(tblBook);
            return RedirectToAction("Index");
        }
    }
}