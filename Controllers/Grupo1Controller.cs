using SistemaGestionDeConfiguracionSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaGestionDeConfiguracionSoftware.Controllers
{
    public class Grupo1Controller : Controller
    {
        // GET: Grupo1
        private GRUPO ObjGrup = new GRUPO();
        private readonly PROYECTO ObjProy = new PROYECTO();
        // GET: Grupo
        public ActionResult Index(string Criterio)
        {
            if (Criterio == null || Criterio == "")
            {
                return View(ObjGrup.Listar());

            }
            else
            {
                return View(ObjGrup.Buscar(Criterio));

            }
        }
        public ActionResult Visualizar(int id)
        {
            return View(ObjGrup.Obtener(id));
        }


        public ActionResult Buscar(string Criterio)
        {
            return View(
                Criterio == null || Criterio == ""
                ? ObjGrup.Listar() // ? => if
                : ObjGrup.Buscar(Criterio)); // : => else)
        }
        public ActionResult AgregarEditar(int Id = 0)
        {
            ViewBag.Proyecto = ObjProy.Listar();
            return View(
                Id == 0
                ? new GRUPO() // ? => if
                : ObjGrup.Obtener(Id)); // : => else)
        }

        public ActionResult Guardar(GRUPO ObjGrup)
        {
            if (ModelState.IsValid)
            {
                ObjGrup.Guardar();
                return Redirect("~/Grupo");
            }
            else
            {
                return View("~/Views/Grupo/AgregarEditar.cshtml", ObjGrup);
            }
        }


        public ActionResult Eliminar(int id)
        {
            ObjGrup.ID_GRUPO = id;
            ObjGrup.Eliminar();
            return Redirect("~/Grupo");
        }
    }
}