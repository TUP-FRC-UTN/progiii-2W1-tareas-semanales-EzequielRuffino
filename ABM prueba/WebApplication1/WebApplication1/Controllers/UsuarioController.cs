using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UsuarioController : Controller
    {
        //Hay 2 tipo de peticiones la GET se dispara cuando quiero ver una vista, y la POST se dispara cuando envio datos

        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        //vamos a crear un metodo publico que me devuelva un accionresult que me va a devolver una vista o me va a direccionar a una
        public ActionResult Login()
        {
            return View(); // retornamos a la vista Login
        }

        [HttpPost]
        public ActionResult Login(Usuario modelo) //este metodo debe recibir un atributo
        {
            if(ModelState.IsValid)//validacion del lado del servidor
            {
                return RedirectToAction("Principal", "Home");//redireccionamos a una nueva vista pero debenos poner el nombre y quien la tiene

            }
            else
            {
                return View(modelo);//esto sirve para q no se borre todo el contenido en caso de q este mal un dato
            }
            //return RedirectToAction("Principal", "Home");//redireccionamos a una nueva vista pero debenos poner el nombre y quien la tiene
        }

        public ActionResult Login2()
        {
            return View(); // retornamos a la vista Login
        }
    }
}