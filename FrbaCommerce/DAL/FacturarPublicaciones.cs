using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace FrbaCommerce.DAL
{
    class FacturarPublicaciones
    {
        public void GenerarFactura(int vendedor, int compraHasta, int formaPago, String nroTarj, DateTime fechaVenc, int codSeg, String titular)
        {
            try
            {
                SqlConnection conexion = DAL.Conexion.getConexion();
                SqlCommand comando = new SqlCommand(@"EXEC BAZINGUEANDO_EN_SLQ.SP_GENERAR_FACTURA
                                                        @VENDEDOR,
                                                        @COMPRA_HASTA,
                                                        @FECHA,
                                                        @FORMA_PAGO,
                                                        @NRO_TARJ,
                                                        @FECHA_VENC,
                                                        @COD_SEG,
                                                        @TITULAR", conexion);
                comando.Parameters.AddWithValue("@VENDEDOR",vendedor);
                comando.Parameters.AddWithValue("@COMPRA_HASTA",compraHasta);
                comando.Parameters.AddWithValue("@FORMA_PAGO",formaPago);
                comando.Parameters.AddWithValue("@FECHA",Controller.Validaciones.ObtenerFechaSistema());
                comando.Parameters.AddWithValue("@NRO_TARJ",nroTarj);
                comando.Parameters.AddWithValue("@FECHA_VENC",fechaVenc);
                comando.Parameters.AddWithValue("@COD_SEG",codSeg);
                comando.Parameters.AddWithValue("@TITULAR",titular);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
