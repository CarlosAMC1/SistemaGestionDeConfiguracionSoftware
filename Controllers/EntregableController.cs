using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaGestionDeConfiguracionSoftware.Models;
using static SistemaGestionDeConfiguracionSoftware.Filtros.AdminFilters;


namespace SistemaGestionDeConfiguracionSoftware.Controllers
{
    public class EntregableController : Controller
    {
        ENTREGABLE clsEntregable = new ENTREGABLE();
        ETAPA clsEtapa = new ETAPA();
        // GET: Entregable
        public ActionResult Index()
        {
            ViewBag.Entregable = clsEtapa.ListarTodo();
            return View(clsEntregable.ListarTodo());

        }
        public ActionResult Guardar(ETAPA etapa)
        {
            if (ModelState.IsValid)
            {
                etapa.Guardar();
                return Redirect("~/Entregable/Index");
            }
            else
            {
                return View("~/Entregable/Index");
            }
        }

        public ActionResult EditEnt(int id = 0)
        {
            ViewBag.Entregable = clsEtapa.ListarTodo();
            return View(id == 0 ? new ENTREGABLE() : clsEntregable.ObtenerEntregable(id));
        }

        public ActionResult Eliminar(int id)
        {
            clsEntregable.ID_ENTREGABLE = id;
            clsEntregable.Eliminar();
            return Redirect("~/Entregable/Index");
        }

        public ActionResult Habilitar(int id)
        {
            clsEntregable.ID_ENTREGABLE = id;
            clsEntregable.Habilitar();
            return Redirect("~/Entregable/Index");
        }
    }
} 