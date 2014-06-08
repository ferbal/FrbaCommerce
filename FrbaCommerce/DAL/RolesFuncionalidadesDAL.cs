using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FrbaCommerce.DAL
{
    class RolesFuncionalidadesDAL
    {
        public void InsertarFuncionalidadRol(int idRol,int idFunc)
        {
            try
            {
                SqlConnection conexion = DAL.Conexion.getConexion();
                SqlCommand comando = new SqlCommand(@"  INSERT INTO RolesFuncionalidades
                                                        (
                                                            idRol,
                                                            idFuncionalidad
                                                        )
                                                        VALUES
                                                        (
                                                            @idRol,
                                                            @idFuncionalidad
                                                        )",conexion);
                comando.Parameters.AddWithValue("@idRol",idRol);
                comando.Parameters.AddWithValue("@idFuncionalidad",idFunc);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarFuncionalidadDeRol(int idRol)
        {
            try
            {
                SqlConnection conexion = DAL.Conexion.getConexion();
                SqlCommand comando = new SqlCommand(@"  DELETE RolesFuncionalidades
                                                        WHERE idRol = @idRol",conexion);

                comando.Parameters.AddWithValue("@idRol",idRol);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ObtenerFuncionalidadesDeRol(int rol)
        {
            try
            {
                SqlConnection conexion = DAL.Conexion.getConexion();
                DataTable dt = new DataTable();
                SqlCommand comando = new SqlCommand(@"  SELECT F.Descripcion
                                                        FROM RolesFuncionalidades RF
                                                        INNER JOIN Funcionalidades F
                                                            ON F.idFuncionalidad = RF.idFuncionalidad
                                                        WHERE idRol = @idRol", conexion);

                comando.Parameters.AddWithValue("@idRol", rol);

                dt.Load(comando.ExecuteReader());

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
