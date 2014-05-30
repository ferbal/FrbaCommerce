using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

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
                                                        )",conexion);

                comando.Parameters.AddWithValue("@Usuario",idUsuario);
                comando.Parameters.AddWithValue("@Rol", idRol);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
