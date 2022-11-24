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
    public class SolicitudCambioController : Controller
    {
        private Model1 db = new Model1();

        // GET: SolicitudCambio
        public ActionResult Index()
        {
            var sOLICITUDCAMBIO = db.SOLICITUDCAMBIO.Include(s => s.MIEMBRO);
            return View(sOLICITUDCAMBIO.ToList());
        }

        // GET: SolicitudCambio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOLICITUDCAMBIO sOLICITUDCAMBIO = db.SOLICITUDCAMBIO.Find(id);
            if (sOLICITUDCAMBIO == null)
            {
                return HttpNotFound();
            }
            return View(sOLICITUDCAMBIO);
        }

        // GET: SolicitudCambio/Create
        public ActionResult Create()
        {
            ViewBag.ID_MIEMBRO = new SelectList(db.MIEMBRO, "ID_MIEMBRO", "NOMBRE");
            return View();
        }

        // POST: SolicitudCambio/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SOLICITUD,FECHA_INICIO,FECHA_FIN,DESCRIPCION,TIPO_CAMBIO,ID_MIEMBRO")] SOLICITUDCAMBIO sOLICITUDCAMBIO)
        {
            if (ModelState.IsValid)
            {
                db.SOLICITUDCAMBIO.Add(sOLICITUDCAMBIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_MIEMBRO = new SelectList(db.MIEMBRO, "ID_MIEMBRO", "NOMBRE", sOLICITUDCAMBIO.ID_MIEMBRO);
            return View(sOLICITUDCAMBIO);
        }

        // GET: SolicitudCambio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOLICITUDCAMBIO sOLICITUDCAMBIO = db.SOLICITUDCAMBIO.Find(id);
            if (sOLICITUDCAMBIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_MIEMBRO = new SelectList(db.MIEMBRO, "ID_MIEMBRO", "NOMBRE", sOLICITUDCAMBIO.ID_MIEMBRO);
            return View(sOLICITUDCAMBIO);
        }

        // POST: SolicitudCambio/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SOLICITUD,FECHA_INICIO,FECHA_FIN,DESCRIPCION,TIPO_CAMBIO,ID_MIEMBRO")] SOLICITUDCAMBIO sOLICITUDCAMBIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sOLICITUDCAMBIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_MIEMBRO = new SelectList(db.MIEMBRO, "ID_MIEMBRO", "NOMBRE", sOLICITUDCAMBIO.ID_MIEMBRO);
            return View(sOLICITUDCAMBIO);
        }

        // GET: SolicitudCambio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOLICITUDCAMBIO sOLICITUDCAMBIO = db.SOLICITUDCAMBIO.Find(id);
            if (sOLICITUDCAMBIO == null)
            {
                return HttpNotFound();
            }
            return View(sOLICITUDCAMBIO);
        }

        // POST: SolicitudCambio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SOLICITUDCAMBIO sOLICITUDCAMBIO = db.SOLICITUDCAMBIO.Find(id);
            db.SOLICITUDCAMBIO.Remove(sOLICITUDCAMBIO);
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
