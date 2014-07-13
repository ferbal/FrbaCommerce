using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FrbaCommerce.DAL
{
    class FormaPagoDAL
    {
        public DataTable ObtenerFormasPago()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlConnection conexion = DAL.Conexion.getConexion();
                SqlCommand comando = new SqlCommand(@"SELECT 
                                                            IdFormaPago,
                                                            Descripcion
                                                      FROM BAZINGUEANDO_EN_SLQ.FormasPago",conexion);
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
