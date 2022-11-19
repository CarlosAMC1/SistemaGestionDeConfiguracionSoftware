using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaGestionDeConfiguracionSoftware.Models;
using static SistemaGestionDeConfiguracionSoftware.Filtros.AdminFilters;
namespace SistemaGestionDeConfiguracionSoftware.Controllers
{
    public class EtapaController : Controller
    {

        // GET: Etapa
        ETAPA etapa = new ETAPA();
        METODOLOGIA metodologia = new METODOLOGIA();

        public ActionResult Index()
        {
            ViewBag.Metodologia = metodologia.ListarTodo();
            return View(etapa.ListarTodo());
         
        }
        public ActionResult Guardar(ETAPA etapa)
        {
            if (ModelState.IsValid)
            {
                etapa.Guardar();
                return Redirect("~/Etapa/Index");
            }
            else
            {
                return View("~/Etapa/Index");
            }
        }

        public ActionResult EditEta(int id = 0)
        {
            ViewBag.Metodologia = metodologia.ListarTodo();
            return View(id == 0 ? new ETAPA() : etapa.ObtenerEtapa(id));
        }

        public ActionResult Eliminar(int id)
        {
            etapa.ID_ETAPA = id;
            etapa.Eliminar();
            return Redirect("~/Etapa/Index");
        }

        public ActionResult Habilitar(int id)
        {
            etapa.ID_ETAPA = id;
            etapa.Habilitar();
            return Redirect("~/Etapa/Index");
        }
    }
}