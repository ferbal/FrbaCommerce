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
                                                                IdRol,
                                                                Nombre,
                                                                IdEstado 
                                                        FROM Roles
                                                        WHERE IdEstado = @idEstado",conexion);

                comando.Parameters.AddWithValue("@idEstado",Model.Roles.Estados.Habilitado);

                dt.Load(comando.ExecuteReader());

                return dt;
                
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
    }
}
