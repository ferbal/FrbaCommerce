using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FrbaCommerce.DAL
{
    class FuncionalidadesDAL
    {
        public DataTable ListarFuncionalidades()
        {
            SqlConnection conexion = DAL.Conexion.getConexion();
            try
            {
                DataTable dt = new DataTable();
                SqlCommand comando = new SqlCommand(@"  SELECT  IdFuncionalidad,
                                                                Descripcion
                                                        FROM BAZINGUEANDO_EN_SLQ.Funcionalidades", conexion);

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
