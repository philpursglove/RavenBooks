using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RavenBooks.Models;

namespace RavenBooks.Controllers
{
    public class BookController : RavenController
    {
        //
        // GET: /Book/

        public ActionResult Index()
        {
            return View(RavenSession.Query<Book>().ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                RavenSession.Store(book);
                RavenSession.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(book);
        }

        public ActionResult Edit(int id)
        {
            Book book = RavenSession.Load<Book>(id);

            return View(book);
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                RavenSession.Store(book);
                RavenSession.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(book);
        }

        public ActionResult Show(int id)
        {
            return View(RavenSession.Load<Book>(id));
        }

        public ActionResult Delete(int id)
        {
            Book book = RavenSession.Load<Book>(id);

            return View(book);
        }

        [HttpPost]
        public ActionResult Delete(Book book)
        {
            int id = book.Id;
            Book bookToDelete = RavenSession.Load<Book>(id);
            RavenSession.Delete(bookToDelete);
            RavenSession.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
