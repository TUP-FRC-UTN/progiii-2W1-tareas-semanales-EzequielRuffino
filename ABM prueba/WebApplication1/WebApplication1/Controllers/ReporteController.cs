using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.ViewsModels.Reportes;

namespace WebApplication1.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte
        public ActionResult Index()
        {
            InfoGralVM resultado = new InfoGralVM();
            return View(resultado);
        }
    }
}