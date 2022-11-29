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
    public class CronogramaController : Controller
    {
        private Model1 db = new Model1();

        // GET: Cronograma
        public ActionResult Index()
        {
            var cRONOGRAMA = db.CRONOGRAMA.Include(c => c.ETAPA).Include(c => c.METODOLOGIA);
            return View(cRONOGRAMA.ToList());
        }

        // GET: Cronograma/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CRONOGRAMA cRONOGRAMA = db.CRONOGRAMA.Find(id);
            if (cRONOGRAMA == null)
            {
                return HttpNotFound();
            }
            return View(cRONOGRAMA);
        }

        // GET: Cronograma/Create
        public ActionResult Create()
        {
            ViewBag.ID_FASE = new SelectList(db.ETAPA, "ID_ETAPA", "NOMBRE");
            ViewBag.ID_METODOLOGIA = new SelectList(db.METODOLOGIA, "ID_METODOLOGIA", "DESCRIPCION");
            return View();
        }

        // POST: Cronograma/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_CRONOGRAMA,ID_PROYECTO,PORCENTAJE_AVANCE,FECHA_INICIO,FECHA_FIN,TAREA_FINALIZADA,TAREA_ENPROCESO,TAREA_ABIERTA,ID_METODOLOGIA,ID_FASE,VERSION_ACTUAL,ECS,ID_MIEMBRO")] CRONOGRAMA cRONOGRAMA)
        {
            if (ModelState.IsValid)
            {
                db.CRONOGRAMA.Add(cRONOGRAMA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_FASE = new SelectList(db.ETAPA, "ID_ETAPA", "NOMBRE", cRONOGRAMA.ID_FASE);
            ViewBag.ID_METODOLOGIA = new SelectList(db.METODOLOGIA, "ID_METODOLOGIA", "DESCRIPCION", cRONOGRAMA.ID_METODOLOGIA);
            return View(cRONOGRAMA);
        }

        // GET: Cronograma/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CRONOGRAMA cRONOGRAMA = db.CRONOGRAMA.Find(id);
            if (cRONOGRAMA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_FASE = new SelectList(db.ETAPA, "ID_ETAPA", "NOMBRE", cRONOGRAMA.ID_FASE);
            ViewBag.ID_METODOLOGIA = new SelectList(db.METODOLOGIA, "ID_METODOLOGIA", "DESCRIPCION", cRONOGRAMA.ID_METODOLOGIA);
            return View(cRONOGRAMA);
        }

        // POST: Cronograma/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_CRONOGRAMA,ID_PROYECTO,PORCENTAJE_AVANCE,FECHA_INICIO,FECHA_FIN,TAREA_FINALIZADA,TAREA_ENPROCESO,TAREA_ABIERTA,ID_METODOLOGIA,ID_FASE,VERSION_ACTUAL,ECS,ID_MIEMBRO")] CRONOGRAMA cRONOGRAMA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cRONOGRAMA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_FASE = new SelectList(db.ETAPA, "ID_ETAPA", "NOMBRE", cRONOGRAMA.ID_FASE);
            ViewBag.ID_METODOLOGIA = new SelectList(db.METODOLOGIA, "ID_METODOLOGIA", "DESCRIPCION", cRONOGRAMA.ID_METODOLOGIA);
            return View(cRONOGRAMA);
        }

        // GET: Cronograma/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CRONOGRAMA cRONOGRAMA = db.CRONOGRAMA.Find(id);
            if (cRONOGRAMA == null)
            {
                return HttpNotFound();
            }
            return View(cRONOGRAMA);
        }

        // POST: Cronograma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CRONOGRAMA cRONOGRAMA = db.CRONOGRAMA.Find(id);
            db.CRONOGRAMA.Remove(cRONOGRAMA);
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
