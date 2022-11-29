using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaGestionDeConfiguracionSoftware.Models;

namespace SistemaGestionDeConfiguracionSoftware.Controllers
{
    public class TAREAsController : Controller
    {
        private Model1 db = new Model1();

        // GET: TAREAs
        public ActionResult Index()
        {
            return View(db.TAREA.ToList());
        }

        // GET: TAREAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAREA tAREA = db.TAREA.Find(id);
            if (tAREA == null)
            {
                return HttpNotFound();
            }
            return View(tAREA);
        }

        // GET: TAREAs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TAREAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TAREA,NOMBRE,JUSTIFICACION,CODIGO")] TAREA tAREA)
        {
            if (ModelState.IsValid)
            {
                db.TAREA.Add(tAREA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tAREA);
        }

        // GET: TAREAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAREA tAREA = db.TAREA.Find(id);
            if (tAREA == null)
            {
                return HttpNotFound();
            }
            return View(tAREA);
        }

        // POST: TAREAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TAREA,NOMBRE,JUSTIFICACION,CODIGO")] TAREA tAREA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tAREA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tAREA);
        }

        // GET: TAREAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAREA tAREA = db.TAREA.Find(id);
            if (tAREA == null)
            {
                return HttpNotFound();
            }
            return View(tAREA);
        }

        // POST: TAREAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TAREA tAREA = db.TAREA.Find(id);
            db.TAREA.Remove(tAREA);
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
