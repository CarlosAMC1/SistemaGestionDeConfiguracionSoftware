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
    public class MiembroController : Controller
    {
        private Model1 db = new Model1();

        // GET: Miembro
        public ActionResult Index()
        {
            var mIEMBRO = db.MIEMBRO.Include(m => m.PROYECTO);
            return View(mIEMBRO.ToList());
        }

        // GET: Miembro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MIEMBRO mIEMBRO = db.MIEMBRO.Find(id);
            if (mIEMBRO == null)
            {
                return HttpNotFound();
            }
            return View(mIEMBRO);
        }

        // GET: Miembro/Create
        public ActionResult Create()
        {
            ViewBag.ID_PROYECTO = new SelectList(db.PROYECTO, "ID_PROYECTO", "NOMBRE");
            return View();
        }

        // POST: Miembro/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_MIEMBRO,ID_PROYECTO,NOMBRE,ROL,RESPONSABILIDAD")] MIEMBRO mIEMBRO)
        {
            if (ModelState.IsValid)
            {
                db.MIEMBRO.Add(mIEMBRO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PROYECTO = new SelectList(db.PROYECTO, "ID_PROYECTO", "NOMBRE", mIEMBRO.ID_PROYECTO);
            return View(mIEMBRO);
        }

        // GET: Miembro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MIEMBRO mIEMBRO = db.MIEMBRO.Find(id);
            if (mIEMBRO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PROYECTO = new SelectList(db.PROYECTO, "ID_PROYECTO", "NOMBRE", mIEMBRO.ID_PROYECTO);
            return View(mIEMBRO);
        }

        // POST: Miembro/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_MIEMBRO,ID_PROYECTO,NOMBRE,ROL,RESPONSABILIDAD")] MIEMBRO mIEMBRO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mIEMBRO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PROYECTO = new SelectList(db.PROYECTO, "ID_PROYECTO", "NOMBRE", mIEMBRO.ID_PROYECTO);
            return View(mIEMBRO);
        }

        // GET: Miembro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MIEMBRO mIEMBRO = db.MIEMBRO.Find(id);
            if (mIEMBRO == null)
            {
                return HttpNotFound();
            }
            return View(mIEMBRO);
        }

        // POST: Miembro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MIEMBRO mIEMBRO = db.MIEMBRO.Find(id);
            db.MIEMBRO.Remove(mIEMBRO);
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
