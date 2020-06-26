using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using WebApplication1.ViewsModels;

namespace WebApplication1.AccesoDatos
{
    public class AD_Reportes
    {
        public static List<SexoItemsVM> ObtenerCantidadPersonasPorSexo()// es estatico para no instanciar, hacer new
        {
            List<SexoItemsVM> resultado = new List<SexoItemsVM>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();//nos conectamos a la cadena de conexion

            SqlConnection cn = new SqlConnection(cadenaConexion);//creamos conexion a sql y le agregamos la cadena de conexion para q sepa a que motor de base de datos apuntar

            try
            {
                SqlCommand cmd = new SqlCommand(); //establecemos un comando q le vamos a setear lo de abajo
                string consulta = @"SELECT s.Nombre AS 'Sexo', COUNT(*) AS 'Cantidad'
                    FROM sexos s
                    JOIN personas p ON p.IdSexo=s.Id
                    GROUP BY s.Nombre";
                    
                    
                cmd.Parameters.Clear();//limpiamos los parametros del comando

                cmd.CommandType = System.Data.CommandType.Text;//aca decimos que le vamos a escribir
                cmd.CommandText = consulta;//y la va a guardar en la variante consulta con los datos q ahi entratian nombre, apellido

                cn.Open(); //abrimos conexion
                cmd.Connection = cn;//laa conexion va a ser cn

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null) //si el datareader no es null
                {
                    while (dr.Read())
                    {
                       SexoItemsVM aux = new SexoItemsVM();

                        aux.Nombre = dr["Sexo"].ToString();
                        aux.Cantidad = int.Parse(dr["Cantidad"].ToString());

                        resultado.Add(aux);
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally//esto se lo agregamos al try catch, independientemente si fue exitosa o no la consulta, esta se debe cerrar
            {

                cn.Close();

            }
            return resultado;
        }


        public static List<PersonaItemVM> ObtenerReportePersona()
        {
            List<PersonaItemVM> resultado = new List<PersonaItemVM>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();//nos conectamos a la cadena de conexion

            SqlConnection cn = new SqlConnection(cadenaConexion);//creamos conexion a sql y le agregamos la cadena de conexion para q sepa a que motor de base de datos apuntar

            try
            {
                SqlCommand cmd = new SqlCommand(); //establecemos un comando q le vamos a setear lo de abajo
                string consulta = @"SELECT p.Id, p.Nombre, p.Apellido, p.Edad, p.Telefono, s.Nombre AS 'Sexo'
                                    FROM personas p
                                    INNER JOIN sexos s ON p.IdSexo = S.id";

                cmd.Parameters.Clear();//limpiamos los parametros del comando

                cmd.CommandType = System.Data.CommandType.Text;//aca decimos que le vamos a escribir
                cmd.CommandText = consulta;//y la va a guardar en la variante consulta con los datos q ahi entratian nombre, apellido

                cn.Open(); //abrimos conexion
                cmd.Connection = cn;//laa conexion va a ser cn

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null) //si el datareader no es null
                {
                    while (dr.Read())
                    {
                        PersonaItemVM aux = new PersonaItemVM();
                        aux.Id = int.Parse(dr["Id"].ToString());
                        aux.Nombre = dr["Nombre"].ToString();
                        aux.Apellido = dr["Apellido"].ToString();
                        aux.Telefono = dr["Telefono"].ToString();
                        aux.Edad = int.Parse(dr["Edad"].ToString());
                        aux.SexoNombre= dr["Sexo"].ToString();

                        resultado.Add(aux);
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            finally//esto se lo agregamos al try catch, independientemente si fue exitosa o no la consulta, esta se debe cerrar
            {

                cn.Close();

            }
            return resultado;
        }






















    }
}