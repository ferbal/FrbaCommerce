using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace FrbaCommerce.DAL
{
    class RolesDAL
    {
        public DataTable listarRolesHabilitados()
        {
            
            SqlConnection conexion = DAL.Conexion.getConexion();
            DataTable dt = new DataTable();
            try
            {

                SqlCommand comando = new SqlCommand(@"  SELECT 
                                                                R.IdRol,
                                                                R.Nombre,
                                                                Est.Descripcion Estado
                                                        FROM Roles R
                                                        INNER JOIN Estados Est
                                                            ON R.idEstado = Est.idEstado
                                                        WHERE R.IdEstado = @idEstado",conexion);

                comando.Parameters.AddWithValue("@idEstado",Model.Roles.Estados.Habilitado);

                dt.Load(comando.ExecuteReader());

                return dt;
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public DataTable listarRoles(String nombre)
        {

            SqlConnection conexion = DAL.Conexion.getConexion();
            DataTable dt = new DataTable();
            try
            {
                String where = String.Empty;
                if (!String.IsNullOrEmpty(nombre))
                    where = " WHERE Nombre LIKE '%" + nombre + "%'";

                SqlCommand comando = new SqlCommand(@"  SELECT 
                                                                R.IdRol,
                                                                R.Nombre,
                                                                Est.Descripcion Estado
                                                        FROM Roles R
                                                        INNER JOIN Estados Est
                                                            ON R.idEstado = Est.idEstado" + where, conexion);                

                dt.Load(comando.ExecuteReader());

                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertarRol(String nombre)
        {
            SqlConnection conexion = DAL.Conexion.getConexion();
            try
            {
                SqlCommand comando = new SqlCommand(@"INSERT INTO Roles
                                                        (
                                                            Nombre,
                                                            IdEstado
                                                        )
                                                        VALUES
                                                        (
                                                            @Nombre,
                                                            @Estado
                                                        )",conexion);

                comando.Parameters.AddWithValue("@Nombre",nombre);
                comando.Parameters.AddWithValue("@Estado",(int)Model.Roles.Estados.Habilitado);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizarRol(int id,String nombre)
        {
            SqlConnection conexion = DAL.Conexion.getConexion();
            try
            {
                SqlCommand comando = new SqlCommand(@"  UPDATE Roles
                                                        SET Nombre = @Nombre
                                                        WHERE idRol = @idRol",conexion);

                comando.Parameters.AddWithValue("@Nombre",nombre);
                comando.Parameters.AddWithValue("@idRol",id);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarRol(int id)
        {
            SqlConnection conexion = DAL.Conexion.getConexion();
            try
            {
                SqlCommand comando = new SqlCommand(@"  DELETE Roles
                                                        WHERE idRol = @idRol", conexion);

                comando.Parameters.AddWithValue("@idRol", id);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
