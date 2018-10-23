using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Docentes.Models;

namespace Docentes.Controllers
{
    public class DocentesController : Controller
    {
        private DocentesContext db = new DocentesContext();
        private Random rnd = new Random();

        // GET: Docentes
        public ActionResult Index()
        {
            return View(db.Docentes.ToList());
        }

        // GET: Docentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Docente docente = db.Docentes.Find(id);
            if (docente == null)
            {
                return HttpNotFound();
            }
            return View(docente);
        }


            // GET: Docentes/Details/5
        public ActionResult Publicaciones(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Docente docente = db.Docentes.Find(id);

            if (docente == null)
            {
                return HttpNotFound();
            }

            ViewBag.Publicaciones = db.Publicacions.Where(x => x.DocenteId == id);
            docente.Publicaciones = db.Publicacions.Where(x => x.DocenteId == id).ToList();


            //context.Entry(student).Collection(s => s.StudentCourses).Load(); // loads Courses collection 

            //ViewBag.Publicaciones = docente.Publicaciones.ToList();
            return PartialView(docente);
        }

        public ActionResult Proyectos(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Docente docente = db.Docentes.Find(id);
            if (docente == null)
            {
                return HttpNotFound();
            }

            ViewBag.Proyectos = db.Proyectoes.Where(x => x.DocenteId == id);
            docente.Proyectos = db.Proyectoes.Where(x => x.DocenteId == id).ToList();

            return PartialView(docente);
        }


        // GET: Docentes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Docentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombres,Apellidos,Inss,Imagen")] Docente docente)
        {
            if (ModelState.IsValid)
            {

                HttpPostedFileBase fileUpload = Request.Files[0];
                if (fileUpload.ContentLength > 0)
                {
                    //var fileName = Path.GetFileName(fileUpload.FileName).Trim();
                    var fileExtension = Path.GetExtension(fileUpload.FileName);
                    var identificador = rnd.Next(1, 9999);
                    var fileName = $"{docente.GetHashCode()}{identificador}{fileExtension}";
                    var path = Path.Combine(Server.MapPath("~/Files/"), $"{docente.GetHashCode()}{identificador}{fileExtension}");
                    fileUpload.SaveAs(path);
                    docente.Imagen = fileName;
                }


                db.Docentes.Add(docente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(docente);
        }

        // GET: Docentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Docente docente = db.Docentes.Find(id);
            if (docente == null)
            {
                return HttpNotFound();
            }
            return View(docente);
        }

        // POST: Docentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombres,Apellidos,Inss,Imagen")] Docente docente)
        {
            if (ModelState.IsValid)
            {

                HttpPostedFileBase fileUpload = Request.Files[0];
                if (fileUpload.ContentLength > 0)
                {
                    //var fileName = Path.GetFileName(fileUpload.FileName).Trim();
                    var fileExtension = Path.GetExtension(fileUpload.FileName);
                    
                    var identificador = rnd.Next(1, 9999);
                    var fileName = $"{docente.GetHashCode()}{identificador}{fileExtension}";
                    var path = Path.Combine(Server.MapPath("~/Files/"), $"{docente.GetHashCode()}{identificador}{fileExtension}");
                    fileUpload.SaveAs(path);
                    docente.Imagen = fileName;
                }



                db.Entry(docente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(docente);
        }

        // GET: Docentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Docente docente = db.Docentes.Find(id);
            if (docente == null)
            {
                return HttpNotFound();
            }
            return View(docente);
        }

        // POST: Docentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Docente docente = db.Docentes.Find(id);
            db.Docentes.Remove(docente);
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
