using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Docentes.Models;

namespace Docentes.Controllers
{
    public class EditorialesController : Controller
    {
        private DocentesContext db = new DocentesContext();

        // GET: Editoriales
        public ActionResult Index()
        {
            return View(db.Editorials.ToList());
        }

        // GET: Editoriales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Editorial editorial = db.Editorials.Find(id);
            if (editorial == null)
            {
                return HttpNotFound();
            }
            return View(editorial);
        }

        // GET: Editoriales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Editoriales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre")] Editorial editorial)
        {
            if (ModelState.IsValid)
            {
                db.Editorials.Add(editorial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(editorial);
        }

        // GET: Editoriales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Editorial editorial = db.Editorials.Find(id);
            if (editorial == null)
            {
                return HttpNotFound();
            }
            return View(editorial);
        }

        // POST: Editoriales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre")] Editorial editorial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(editorial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(editorial);
        }

        // GET: Editoriales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Editorial editorial = db.Editorials.Find(id);
            if (editorial == null)
            {
                return HttpNotFound();
            }
            return View(editorial);
        }

        // POST: Editoriales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Editorial editorial = db.Editorials.Find(id);
            db.Editorials.Remove(editorial);
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
