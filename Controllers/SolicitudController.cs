using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaGestionDeConfiguracionSoftware.Models;

namespace SistemaGestionDeConfiguracionSoftware.Controllers
{
    public class SolicitudController : Controller
    {
        private SOLICITUDCAMBIO objSC = new SOLICITUDCAMBIO();
        PROYECTO proyecto = new PROYECTO();
        USUARIO usuario = new USUARIO();

        // GET: Solicitud
        public ActionResult Index()
        {
            ViewBag.Usuario = usuario.ListarTodo();
            ViewBag.Proyecto = proyecto.Listar1();


            return View(objSC.Listar());
          
        }

        public ActionResult Agregar(int id = 0)
        {
            ViewBag.TipoSolicitud = objSC.Listar();//llenar combobox de proyecto


            return View(id == 0 ? new SOLICITUDCAMBIO() : objSC.Obtener(id));
        }

        public ActionResult Guardar(SOLICITUDCAMBIO model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/Solicitud/index");
            }
            else
            {
                return View("~/Solicitud/Agregar");
            }
        }
    }
}