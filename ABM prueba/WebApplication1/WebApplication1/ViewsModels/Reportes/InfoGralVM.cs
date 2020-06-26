using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewsModels.Reportes
{
    public class InfoGralVM
    {
        public List<SexoItemsVM> listaSexos { get; set; }
        public List<PersonaItemVM> listaPersona { get; set; }


        public void CargarVariables()
        {

            listaSexos = AccesoDatos.AD_Reportes.ObtenerCantidadPersonasPorSexo();
            listaPersona = AccesoDatos.AD_Reportes.ObtenerReportePersona();
        }

        public InfoGralVM()
        {
            listaSexos = new List<SexoItemsVM>();
            listaPersona = new List<PersonaItemVM>();
            CargarVariables();
        }

    }
}