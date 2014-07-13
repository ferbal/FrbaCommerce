using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FrbaCommerce.DAL
{
    class CalificacionesDAL
    {
        public void IngresarCalificacion(int idCompra,int calif,String detalle)
        {
            try
            {
                SqlConnection conexion = DAL.Conexion.getConexion();
                SqlCommand comando = new SqlCommand(@"EXEC BAZINGUEANDO_EN_SLQ.SP_INGRESAR_CALIFICACIONES
                                                        @COMPRA,@CALIF,@DETALLE",conexion);
                comando.Parameters.AddWithValue("@COMPRA",idCompra);
                comando.Parameters.AddWithValue("@CALIF",calif);
                comando.Parameters.AddWithValue("@DETALLE",detalle);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
