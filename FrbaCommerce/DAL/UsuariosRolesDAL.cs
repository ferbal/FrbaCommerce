using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace FrbaCommerce.DAL
{
    class UsuariosRolesDAL
    {
        public void insertarRolDeUsuario(int idUsuario, int idRol)
        {
            SqlConnection conexion = DAL.Conexion.getConexion();
            try
            {
                SqlCommand comando = new SqlCommand(@"INSERT INTO UsuariosRoles
                                                        (
                                                            IdUsuario,
                                                            IdRol
                                                        )
                                                        VALUES
                                                        (
                                                            @Usuario,
                                                            @Rol
                                                        )", conexion);

                comando.Parameters.AddWithValue("@Usuario", idUsuario);
                comando.Parameters.AddWithValue("@Rol", idRol);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable listarRolesPorUsuario(int idUsuario)
        {
            SqlConnection conexion = DAL.Conexion.getConexion();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand comando = new SqlCommand(@"  SELECT  R.idRol,
                                                                R.Nombre
                                                        FROM Roles R
                                                        INNER JOIN UsuariosRoles UR
                                                            ON UR.idRol = R.idRol
                                                        WHERE UR.idUsuario = @idUsuario
                                                            AND R.idEstado = @idEstado",conexion);

                comando.Parameters.AddWithValue("@idUsuario",idUsuario);
                comando.Parameters.AddWithValue("@idEstado",Model.Roles.Estados.Habilitado);

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
