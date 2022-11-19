using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static SistemaGestionDeConfiguracionSoftware.Filtros.AdminFilters;

namespace SistemaGestionDeConfiguracionSoftware.Controllers
{

    public class DefaultController : Controller
    {
        // GET: Default
   
        public ActionResult Index()
        {

            return View();
        }
    }
}