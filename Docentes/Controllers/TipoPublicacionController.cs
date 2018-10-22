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
    public class TipoPublicacionController : Controller
    {
        private DocentesContext db = new DocentesContext();

        // GET: TipoPublicacion
        public ActionResult Index()
        {
            return View(db.TipoPublicacions.ToList());
        }

        // GET: TipoPublicacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPublicacion tipoPublicacion = db.TipoPublicacions.Find(id);
            if (tipoPublicacion == null)
            {
                return HttpNotFound();
            }
            return View(tipoPublicacion);
        }

        // GET: TipoPublicacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoPublicacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tipo")] TipoPublicacion tipoPublicacion)
        {
            if (ModelState.IsValid)
            {
                db.TipoPublicacions.Add(tipoPublicacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoPublicacion);
        }

        // GET: TipoPublicacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPublicacion tipoPublicacion = db.TipoPublicacions.Find(id);
            if (tipoPublicacion == null)
            {
                return HttpNotFound();
            }
            return View(tipoPublicacion);
        }

        // POST: TipoPublicacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tipo")] TipoPublicacion tipoPublicacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoPublicacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoPublicacion);
        }

        // GET: TipoPublicacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPublicacion tipoPublicacion = db.TipoPublicacions.Find(id);
            if (tipoPublicacion == null)
            {
                return HttpNotFound();
            }
            return View(tipoPublicacion);
        }

        // POST: TipoPublicacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoPublicacion tipoPublicacion = db.TipoPublicacions.Find(id);
            db.TipoPublicacions.Remove(tipoPublicacion);
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
