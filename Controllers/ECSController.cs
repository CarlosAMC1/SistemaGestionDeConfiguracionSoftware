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
    public class ECSController : Controller
    {
        private Model1 db = new Model1();

        // GET: ECS
        public ActionResult Index()
        {
            return View(db.ECS.ToList());
        }

        // GET: ECS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ECS eCS = db.ECS.Find(id);
            if (eCS == null)
            {
                return HttpNotFound();
            }
            return View(eCS);
        }

        // GET: ECS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ECS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ECS,DESCRIPCION")] ECS eCS)
        {
            if (ModelState.IsValid)
            {
                db.ECS.Add(eCS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eCS);
        }

        // GET: ECS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ECS eCS = db.ECS.Find(id);
            if (eCS == null)
            {
                return HttpNotFound();
            }
            return View(eCS);
        }

        // POST: ECS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ECS,DESCRIPCION")] ECS eCS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eCS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eCS);
        }

        // GET: ECS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ECS eCS = db.ECS.Find(id);
            if (eCS == null)
            {
                return HttpNotFound();
            }
            return View(eCS);
        }

        // POST: ECS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ECS eCS = db.ECS.Find(id);
            db.ECS.Remove(eCS);
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
