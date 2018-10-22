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
    public class PublicacionesController : Controller
    {
        private DocentesContext db = new DocentesContext();

        // GET: Publicaciones
        public ActionResult Index()
        {
            var publicacions = db.Publicacions.Include(p => p.Docente).Include(p => p.Editorial).Include(p => p.Tipo);
            return View(publicacions.ToList());
        }

        // GET: Publicaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publicacion publicacion = db.Publicacions.Find(id);
            if (publicacion == null)
            {
                return HttpNotFound();
            }
            return View(publicacion);
        }

        // GET: Publicaciones/Create
        public ActionResult Create()
        {
            ViewBag.DocenteId = new SelectList(db.Docentes, "Id", "FullName");
            ViewBag.EditorialId = new SelectList(db.Editorials, "Id", "Nombre");
            ViewBag.TipoPublicacionId = new SelectList(db.TipoPublicacions, "Id", "Tipo");
            return View();
        }

        // POST: Publicaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titulo,Año,EditorialId,TipoPublicacionId,DocenteId")] Publicacion publicacion)
        {
            if (ModelState.IsValid)
            {
                db.Publicacions.Add(publicacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DocenteId = new SelectList(db.Docentes, "Id", "Nombres", publicacion.DocenteId);
            ViewBag.EditorialId = new SelectList(db.Editorials, "Id", "Nombre", publicacion.EditorialId);
            ViewBag.TipoPublicacionId = new SelectList(db.TipoPublicacions, "Id", "Tipo", publicacion.TipoPublicacionId);
            return View(publicacion);
        }

        // GET: Publicaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publicacion publicacion = db.Publicacions.Find(id);
            if (publicacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.DocenteId = new SelectList(db.Docentes, "Id", "Nombres", publicacion.DocenteId);
            ViewBag.EditorialId = new SelectList(db.Editorials, "Id", "Nombre", publicacion.EditorialId);
            ViewBag.TipoPublicacionId = new SelectList(db.TipoPublicacions, "Id", "Tipo", publicacion.TipoPublicacionId);
            return View(publicacion);
        }

        // POST: Publicaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,Año,EditorialId,TipoPublicacionId,DocenteId")] Publicacion publicacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publicacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DocenteId = new SelectList(db.Docentes, "Id", "Nombres", publicacion.DocenteId);
            ViewBag.EditorialId = new SelectList(db.Editorials, "Id", "Nombre", publicacion.EditorialId);
            ViewBag.TipoPublicacionId = new SelectList(db.TipoPublicacions, "Id", "Tipo", publicacion.TipoPublicacionId);
            return View(publicacion);
        }

        // GET: Publicaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Publicacion publicacion = db.Publicacions.Find(id);
            if (publicacion == null)
            {
                return HttpNotFound();
            }
            return View(publicacion);
        }

        // POST: Publicaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Publicacion publicacion = db.Publicacions.Find(id);
            db.Publicacions.Remove(publicacion);
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
