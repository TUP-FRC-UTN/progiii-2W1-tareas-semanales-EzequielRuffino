using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using WebApplication1.ViewsModels;

namespace WebApplication1.AccesoDatos
{
    public class AD_Personas
    {
        public static bool InsertarNuevaPersona(Persona per)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();//nos conectamos a la cadena de conexion

            SqlConnection cn = new SqlConnection(cadenaConexion);//creamos conexion a sql y le agregamos la cadena de conexion para q sepa a que motor de base de datos apuntar

            try
            {
                SqlCommand cmd = new SqlCommand(); //establecemos un comando q le vamos a setear lo de abajo
                string consulta = "INSERT INTO personas VALUES(@nombre,@apellido,@edad,@telefono,@idsexo)";
                cmd.Parameters.Clear();//limpiamos los parametros del comando

                //agragamos nuevos parametros
                cmd.Parameters.AddWithValue("@nombre", per.Nombre);
                cmd.Parameters.AddWithValue("@apellido", per.Apellido);
                cmd.Parameters.AddWithValue("@edad", per.Edad);
                cmd.Parameters.AddWithValue("@telefono", per.Telefono);
                cmd.Parameters.AddWithValue("@idsexo", per.IdSexo);

                cmd.CommandType = System.Data.CommandType.Text;//aca decimos que le vamos a escribir
                cmd.CommandText = consulta;//y la va a guardar en la variante consulta con los datos q ahi entratian nombre, apellido

                cn.Open(); //abrimos conexion
                cmd.Connection = cn;//laa conexion va a ser cn
                cmd.ExecuteNonQuery();//executa la sentencia sql
                resultado = true;//si no hubo problemas deberia dar true

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

        public static List<Persona> ObtenerListaPersona()
        {
            List<Persona> resultado = new List<Persona>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();//nos conectamos a la cadena de conexion

            SqlConnection cn = new SqlConnection(cadenaConexion);//creamos conexion a sql y le agregamos la cadena de conexion para q sepa a que motor de base de datos apuntar

            try
            {
                SqlCommand cmd = new SqlCommand(); //establecemos un comando q le vamos a setear lo de abajo
                string consulta = "SELECT * FROM personas";
                cmd.Parameters.Clear();//limpiamos los parametros del comando

                cmd.CommandType = System.Data.CommandType.Text;//aca decimos que le vamos a escribir
                cmd.CommandText = consulta;//y la va a guardar en la variante consulta con los datos q ahi entratian nombre, apellido

                cn.Open(); //abrimos conexion
                cmd.Connection = cn;//laa conexion va a ser cn

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr!=null) //si el datareader no es null
                {
                    while (dr.Read())
                    {
                        Persona aux = new Persona();
                        aux.Id = int.Parse(dr["Id"].ToString());
                        aux.Nombre = dr["Nombre"].ToString();
                        aux.Apellido = dr["Apellido"].ToString();
                        aux.Telefono = dr["Telefono"].ToString();
                        aux.Edad = int.Parse(dr["Edad"].ToString());

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


        public static Persona ObtenerPersona(int idPersona)
        {
            Persona resultado = new Persona();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();//nos conectamos a la cadena de conexion

            SqlConnection cn = new SqlConnection(cadenaConexion);//creamos conexion a sql y le agregamos la cadena de conexion para q sepa a que motor de base de datos apuntar

            try
            {
                SqlCommand cmd = new SqlCommand(); //establecemos un comando q le vamos a setear lo de abajo
                string consulta = "SELECT * FROM personas WHERE id = @id";//simpre trabajar con parametros@id
                cmd.Parameters.Clear();//limpiamos los parametros del comando
                cmd.Parameters.AddWithValue("@id", idPersona);//Parametro

                cmd.CommandType = System.Data.CommandType.Text;//aca decimos que le vamos a escribir
                cmd.CommandText = consulta;//y la va a guardar en la variante consulta con los datos q ahi entratian nombre, apellido

                cn.Open(); //abrimos conexion
                cmd.Connection = cn;//laa conexion va a ser cn

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null) //si el datareader no es null
                {
                    while (dr.Read())
                    {
                        
                        resultado.Id = int.Parse(dr["Id"].ToString());
                        resultado.Nombre = dr["Nombre"].ToString();
                        resultado.Apellido = dr["Apellido"].ToString();
                        resultado.Telefono = dr["Telefono"].ToString();
                        resultado.Edad = int.Parse(dr["Edad"].ToString());
                        resultado.IdSexo = int.Parse(dr["IdSexo"].ToString());                  
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


        public static bool actualizarDatosPersona(Persona per)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();//nos conectamos a la cadena de conexion

            SqlConnection cn = new SqlConnection(cadenaConexion);//creamos conexion a sql y le agregamos la cadena de conexion para q sepa a que motor de base de datos apuntar

            try
            {
                SqlCommand cmd = new SqlCommand(); //establecemos un comando q le vamos a setear lo de abajo
                string consulta = "UPDATE personas set Nombre=@nombre, Apellido=@apellido, Edad=@edad, Telefono=@telefono, IdSexo=@idsexo WHERE id=@id";
                cmd.Parameters.Clear();//limpiamos los parametros del comando

                //agragamos nuevos parametros
                cmd.Parameters.AddWithValue("@nombre", per.Nombre);
                cmd.Parameters.AddWithValue("@apellido", per.Apellido);
                cmd.Parameters.AddWithValue("@edad", per.Edad);
                cmd.Parameters.AddWithValue("@telefono", per.Telefono);
                cmd.Parameters.AddWithValue("@id", per.Id);
                cmd.Parameters.AddWithValue("@idsexo", per.IdSexo);

                cmd.CommandType = System.Data.CommandType.Text;//aca decimos que le vamos a escribir
                cmd.CommandText = consulta;//y la va a guardar en la variante consulta con los datos q ahi entratian nombre, apellido

                cn.Open(); //abrimos conexion
                cmd.Connection = cn;//laa conexion va a ser cn
                cmd.ExecuteNonQuery();//executa la sentencia sql
                resultado = true;//si no hubo problemas deberia dar true

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


        public static bool EliminarPersona(Persona per)
        {
            bool resultado = false;
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();//nos conectamos a la cadena de conexion

            SqlConnection cn = new SqlConnection(cadenaConexion);//creamos conexion a sql y le agregamos la cadena de conexion para q sepa a que motor de base de datos apuntar

            try
            {
                SqlCommand cmd = new SqlCommand(); //establecemos un comando q le vamos a setear lo de abajo
                string consulta = "DELETE FROM personas WHERE Id=@id";
                cmd.Parameters.Clear();//limpiamos los parametros del comando

                //agragamos nuevos parametros
                cmd.Parameters.AddWithValue("@id", per.Id);

                cmd.CommandType = System.Data.CommandType.Text;//aca decimos que le vamos a escribir
                cmd.CommandText = consulta;//y la va a guardar en la variante consulta con los datos q ahi entratian nombre, apellido

                cn.Open(); //abrimos conexion
                cmd.Connection = cn;//laa conexion va a ser cn
                cmd.ExecuteNonQuery();//executa la sentencia sql
                resultado = true;//si no hubo problemas deberia dar true

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

        public static List<SexoItemsVM> ObtenerListaSexos()
        {
            List<SexoItemsVM> resultado = new List<SexoItemsVM>();
            string cadenaConexion = System.Configuration.ConfigurationManager.AppSettings["CadenaBD"].ToString();//nos conectamos a la cadena de conexion

            SqlConnection cn = new SqlConnection(cadenaConexion);//creamos conexion a sql y le agregamos la cadena de conexion para q sepa a que motor de base de datos apuntar

            try
            {
                SqlCommand cmd = new SqlCommand(); //establecemos un comando q le vamos a setear lo de abajo
                string consulta = "SELECT * FROM sexos";
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
                        aux.IdSexo = int.Parse(dr["Id"].ToString());
                        aux.Nombre = dr["Nombre"].ToString();


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