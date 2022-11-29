using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaGestionDeConfiguracionSoftware.Models;


namespace SistemaGestionDeConfiguracionSoftware.Controllers
{
    public class MiembroController : Controller
    {

        USUARIO usuario = new USUARIO();
        PROYECTO proyecto = new PROYECTO();
        MIEMBRO miembro = new MIEMBRO();
        GRUPO grupo = new GRUPO();
        TIPO_USUARIO tipousuario = new TIPO_USUARIO();


        // GET: Miembro
        public ActionResult Index()
        {
            ViewBag.Usuario = usuario.ListarTodo();
            ViewBag.Proyecto = proyecto.ListarTodo();
            ViewBag.Grupo = grupo.Listar();
            ViewBag.TipoUsuario = tipousuario.Listar();
            return View(miembro.ListarTodo());
        }


        public ActionResult Guardar(MIEMBRO miembro)

        {
            if (ModelState.IsValid)
            {
                miembro.Guardar();
                return Redirect("~/Miembro/Index");
            }
            else
            {
                return View("~/Miembro/Index");
            }
        }

        public ActionResult EditPro(int id = 0)
        {
            ViewBag.Usuario = usuario.ListarTodo();
            ViewBag.Proyecto = proyecto.ListarTodo();
            ViewBag.Grupo = grupo.Listar();
            ViewBag.TipoUsuario = tipousuario.Listar();
            return View(id == 0 ? new MIEMBRO() : miembro.ObtenerMiembro(id));
        }

        public ActionResult Eliminar(int id)
        {
            proyecto.ID_PROYECTO = id;
            proyecto.Eliminar();
            return Redirect("~/Miembro/Index");
        }
    }
}