using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FrbaCommerce.DAL
{
    class RubrosDAL
    {
        public DataTable obtenerRubros()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlConnection conexion = DAL.Conexion.getConexion();
                SqlCommand comando = new SqlCommand(@"  SELECT
                                                            IdRubro,
                                                            --Codigo,
                                                            Descripcion
                                                        FROM BAZINGUEANDO_EN_SLQ.Rubros", conexion);

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
