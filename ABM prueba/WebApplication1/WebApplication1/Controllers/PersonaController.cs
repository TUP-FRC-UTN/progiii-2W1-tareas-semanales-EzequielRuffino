using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.AccesoDatos;
using WebApplication1.Models;
using WebApplication1.ViewsModels;

namespace WebApplication1.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona

        public ActionResult EliminarPersona(int idPersona)
        {
            Persona resultado = AD_Personas.ObtenerPersona(idPersona);//no se le pone new ad_.... porque el metodo es estatico
            return View(resultado);
        }

        [HttpPost]
        public ActionResult EliminarPersona(Persona model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AD_Personas.EliminarPersona(model);
                if (resultado)
                {
                    return RedirectToAction("ListadoPersona", "Persona");
                }
                else
                {

                    return View(model);
                }
            }
            return View();
        }

        public ActionResult DatosPersona(int idPersona)
        {
            List<SexoItemsVM> listaSexos = AD_Personas.ObtenerListaSexos();
            List<SelectListItem> itemsCombo = listaSexos.ConvertAll(d =>
            {


                return new SelectListItem()
                {
                    Text = d.Nombre,
                    Value = d.IdSexo.ToString(),
                    Selected = false
                };
            });


            Persona resultado = AD_Personas.ObtenerPersona(idPersona);//no se le pone new ad_.... porque el metodo es estatico

            foreach (var item in itemsCombo)
            {

                if (item.Value.Equals(resultado.IdSexo.ToString()))
                {
                    item.Selected = true;
                    break;
                }

            }
            ViewBag.items = itemsCombo;

            ViewBag.Nombre = resultado.Nombre + " " + resultado.Apellido;
            return View(resultado);
        } 

        [HttpPost]
        public ActionResult DatosPersona(Persona model)
        {
            if (ModelState.IsValid)
            {
                bool resultado = AD_Personas.actualizarDatosPersona(model);
                if (resultado)
                {
                    return RedirectToAction("ListadoPersona", "Persona");
                }
                else
                {

                    return View(model);
                }
            }
                return View();
        }
        public ActionResult AltaPersona()
        {
            List<SexoItemsVM> listaSexos = AD_Personas.ObtenerListaSexos();
            List<SelectListItem> items = listaSexos.ConvertAll(d =>
            {


                return new SelectListItem()
                {
                    Text = d.Nombre,
                    Value = d.IdSexo.ToString(),
                    Selected = false
                };
            });

            ViewBag.items = items;

            return View();
        }

        [HttpPost]
        public ActionResult AltaPersona(Persona model)
        {
            if(ModelState.IsValid)
            {
                bool resultado = AD_Personas.InsertarNuevaPersona(model);
                if (resultado)
                {
                   return RedirectToAction("ListadoPersona", "Persona");
                }
                else
                {

                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
            
        }


        public ActionResult ListadoPersona()
        {
            List<Persona> lista = AD_Personas.ObtenerListaPersona();
            return View(lista);
        }



    }
}