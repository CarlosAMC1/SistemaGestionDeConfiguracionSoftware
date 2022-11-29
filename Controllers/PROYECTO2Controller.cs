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
    public class PROYECTO2Controller : Controller
    {
        private Model1 db = new Model1();

        // GET: PROYECTO2
        public ActionResult Index()
        {
            var pROYECTO = db.PROYECTO.Include(p => p.METODOLOGIA).Include(p => p.USUARIO).Include(p => p.USUARIO1);
            return View(pROYECTO.ToList());
        }

        // GET: PROYECTO2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROYECTO pROYECTO = db.PROYECTO.Find(id);
            if (pROYECTO == null)
            {
                return HttpNotFound();
            }
            return View(pROYECTO);
        }

        // GET: PROYECTO2/Create
        public ActionResult Create()
        {
            ViewBag.ID_METODOLOGIA = new SelectList(db.METODOLOGIA, "ID_METODOLOGIA", "DESCRIPCION");
            ViewBag.ID_JEFEPROYECTO = new SelectList(db.USUARIO, "ID_USUARIO", "NOMBRE");
            ViewBag.ID_CLIENTE = new SelectList(db.USUARIO, "ID_USUARIO", "NOMBRE");
            return View();
        }

        // POST: PROYECTO2/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PROYECTO,NOMBRE,DESCRIPCION,ID_CLIENTE,ID_METODOLOGIA,ESTADO,ID_JEFEPROYECTO,FECHA_INICIO,FECHA_FIN")] PROYECTO pROYECTO)
        {
            if (ModelState.IsValid)
            {
                db.PROYECTO.Add(pROYECTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_METODOLOGIA = new SelectList(db.METODOLOGIA, "ID_METODOLOGIA", "DESCRIPCION", pROYECTO.ID_METODOLOGIA);
            ViewBag.ID_JEFEPROYECTO = new SelectList(db.USUARIO, "ID_USUARIO", "NOMBRE", pROYECTO.ID_JEFEPROYECTO);
            ViewBag.ID_CLIENTE = new SelectList(db.USUARIO, "ID_USUARIO", "NOMBRE", pROYECTO.ID_CLIENTE);
            return View(pROYECTO);
        }

        // GET: PROYECTO2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROYECTO pROYECTO = db.PROYECTO.Find(id);
            if (pROYECTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_METODOLOGIA = new SelectList(db.METODOLOGIA, "ID_METODOLOGIA", "DESCRIPCION", pROYECTO.ID_METODOLOGIA);
            ViewBag.ID_JEFEPROYECTO = new SelectList(db.USUARIO, "ID_USUARIO", "NOMBRE", pROYECTO.ID_JEFEPROYECTO);
            ViewBag.ID_CLIENTE = new SelectList(db.USUARIO, "ID_USUARIO", "NOMBRE", pROYECTO.ID_CLIENTE);
            return View(pROYECTO);
        }

        // POST: PROYECTO2/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PROYECTO,NOMBRE,DESCRIPCION,ID_CLIENTE,ID_METODOLOGIA,ESTADO,ID_JEFEPROYECTO,FECHA_INICIO,FECHA_FIN")] PROYECTO pROYECTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pROYECTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_METODOLOGIA = new SelectList(db.METODOLOGIA, "ID_METODOLOGIA", "DESCRIPCION", pROYECTO.ID_METODOLOGIA);
            ViewBag.ID_JEFEPROYECTO = new SelectList(db.USUARIO, "ID_USUARIO", "NOMBRE", pROYECTO.ID_JEFEPROYECTO);
            ViewBag.ID_CLIENTE = new SelectList(db.USUARIO, "ID_USUARIO", "NOMBRE", pROYECTO.ID_CLIENTE);
            return View(pROYECTO);
        }

        // GET: PROYECTO2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROYECTO pROYECTO = db.PROYECTO.Find(id);
            if (pROYECTO == null)
            {
                return HttpNotFound();
            }
            return View(pROYECTO);
        }

        // POST: PROYECTO2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PROYECTO pROYECTO = db.PROYECTO.Find(id);
            db.PROYECTO.Remove(pROYECTO);
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
