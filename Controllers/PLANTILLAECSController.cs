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
    public class PLANTILLAECSController : Controller
    {
        private Model1 db = new Model1();

        // GET: PLANTILLAECS
        public ActionResult Index()
        {
            var pLANTILLAECS = db.PLANTILLAECS.Include(p => p.ECS).Include(p => p.ETAPA).Include(p => p.METODOLOGIA).Include(p => p.MIEMBRO);
            return View(pLANTILLAECS.ToList());
        }

        // GET: PLANTILLAECS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PLANTILLAECS pLANTILLAECS = db.PLANTILLAECS.Find(id);
            if (pLANTILLAECS == null)
            {
                return HttpNotFound();
            }
            return View(pLANTILLAECS);
        }

        // GET: PLANTILLAECS/Create
        public ActionResult Create()
        {
            ViewBag.ID_ECS = new SelectList(db.ECS, "ID_ECS", "DESCRIPCION");
            ViewBag.ID_FASE = new SelectList(db.ETAPA, "ID_ETAPA", "DESCRIPCION");
            ViewBag.ID_METODOLOGIA = new SelectList(db.METODOLOGIA, "ID_METODOLOGIA", "DESCRIPCION");
            ViewBag.ID_MIEMBRO = new SelectList(db.MIEMBRO, "ID_MIEMBRO", "NOMBRE");
            return View();
        }

        // POST: PLANTILLAECS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PLANTILLAECS,ID_PROYECTO,PORCENTAJE_AVANCE,FECHA_INICIO,FECHA_FIN,TAREA_FINALIZADA,TAREA_ENPROCESO,TAREA_ABIERTA,ID_METODOLOGIA,ID_FASE,VERSION_ACTUAL,ID_ECS,ID_MIEMBRO")] PLANTILLAECS pLANTILLAECS)
        {
            if (ModelState.IsValid)
            {
                db.PLANTILLAECS.Add(pLANTILLAECS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ECS = new SelectList(db.ECS, "ID_ECS", "DESCRIPCION", pLANTILLAECS.ID_ECS);
            ViewBag.ID_FASE = new SelectList(db.ETAPA, "ID_ETAPA", "DESCRIPCION", pLANTILLAECS.ID_FASE);
            ViewBag.ID_METODOLOGIA = new SelectList(db.METODOLOGIA, "ID_METODOLOGIA", "DESCRIPCION", pLANTILLAECS.ID_METODOLOGIA);
            ViewBag.ID_MIEMBRO = new SelectList(db.MIEMBRO, "ID_MIEMBRO", "NOMBRE", pLANTILLAECS.ID_MIEMBRO);
            return View(pLANTILLAECS);
        }

        // GET: PLANTILLAECS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PLANTILLAECS pLANTILLAECS = db.PLANTILLAECS.Find(id);
            if (pLANTILLAECS == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ECS = new SelectList(db.ECS, "ID_ECS", "DESCRIPCION", pLANTILLAECS.ID_ECS);
            ViewBag.ID_FASE = new SelectList(db.ETAPA, "ID_ETAPA", "DESCRIPCION", pLANTILLAECS.ID_FASE);
            ViewBag.ID_METODOLOGIA = new SelectList(db.METODOLOGIA, "ID_METODOLOGIA", "DESCRIPCION", pLANTILLAECS.ID_METODOLOGIA);
            ViewBag.ID_MIEMBRO = new SelectList(db.MIEMBRO, "ID_MIEMBRO", "NOMBRE", pLANTILLAECS.ID_MIEMBRO);
            return View(pLANTILLAECS);
        }

        // POST: PLANTILLAECS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PLANTILLAECS,ID_PROYECTO,PORCENTAJE_AVANCE,FECHA_INICIO,FECHA_FIN,TAREA_FINALIZADA,TAREA_ENPROCESO,TAREA_ABIERTA,ID_METODOLOGIA,ID_FASE,VERSION_ACTUAL,ID_ECS,ID_MIEMBRO")] PLANTILLAECS pLANTILLAECS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pLANTILLAECS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ECS = new SelectList(db.ECS, "ID_ECS", "DESCRIPCION", pLANTILLAECS.ID_ECS);
            ViewBag.ID_FASE = new SelectList(db.ETAPA, "ID_ETAPA", "DESCRIPCION", pLANTILLAECS.ID_FASE);
            ViewBag.ID_METODOLOGIA = new SelectList(db.METODOLOGIA, "ID_METODOLOGIA", "DESCRIPCION", pLANTILLAECS.ID_METODOLOGIA);
            ViewBag.ID_MIEMBRO = new SelectList(db.MIEMBRO, "ID_MIEMBRO", "NOMBRE", pLANTILLAECS.ID_MIEMBRO);
            return View(pLANTILLAECS);
        }

        // GET: PLANTILLAECS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PLANTILLAECS pLANTILLAECS = db.PLANTILLAECS.Find(id);
            if (pLANTILLAECS == null)
            {
                return HttpNotFound();
            }
            return View(pLANTILLAECS);
        }

        // POST: PLANTILLAECS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PLANTILLAECS pLANTILLAECS = db.PLANTILLAECS.Find(id);
            db.PLANTILLAECS.Remove(pLANTILLAECS);
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
