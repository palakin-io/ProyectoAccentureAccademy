using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AccentureAccaBookStore.Models;

namespace AccentureAccaBookStore.Controllers
{
    public class BooksController : Controller
    {
        private AccentureAcademyBookstoreEntities db = new AccentureAcademyBookstoreEntities();

        // GET: Books
        public ActionResult Index()
        {
            var book = db.Book.Include(b => b.Genre).Include(b => b.Publisher).Include(b => b.Author);
            return View(book.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Book.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.Author_Id = new SelectList(db.Author, "Id", "AuthorName");
            ViewBag.Genre_Id = new SelectList(db.Genre, "Id", "Genero");
            ViewBag.Publisher_Id = new SelectList(db.Publisher, "Id", "Name");
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Author_Id,Descripcion,Publisher_Id,Genre_Id")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Book.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.Author_Id = new SelectList(db.Author, "Id", "AuthorName", book.Author_Id);
            ViewBag.Genre_Id = new SelectList(db.Genre, "Id", "Genero", book.Genre_Id);
            ViewBag.Publisher_Id = new SelectList(db.Publisher, "Id", "Name", book.Publisher_Id);
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Book.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            //ViewBag.Author_Id = new SelectList(db.Author, "Id", "AuthorName", book.Author.Id);
            ViewBag.Genre_Id = new SelectList(db.Genre, "Id", "Genero", book.Genre_Id);
            ViewBag.Publisher_Id = new SelectList(db.Publisher, "Id", "Name", book.Publisher_Id);
            return View(book);
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Descripcion,Publisher_Id,Genre_Id")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.Author_Id = new SelectList(db.Author, "Id", "AuthorName", book.Author.Id);
            ViewBag.Genre_Id = new SelectList(db.Genre, "Id", "Genero", book.Genre_Id);
            ViewBag.Publisher_Id = new SelectList(db.Publisher, "Id", "Name", book.Publisher_Id);
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Book.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Book.Find(id);
            db.Book.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
