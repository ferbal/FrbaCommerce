using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace FrbaCommerce.DAL
{
    class ComprasDAL
    {
        public void InsertarCompra(int comprador,int publicacion, DateTime fecha,int cantidad)
        {
            try
            {
                SqlConnection conexion = DAL.Conexion.getConexion();
                SqlCommand comando = new SqlCommand(@"INSERT INTO BAZINGUEANDO_EN_SLQ.Compras
                                                        (
                                                            IdUsrComprador,
                                                            IdPublicacion,
                                                            Fecha,
                                                            Cantidad
                                                        )
                                                        VALUES
                                                        (
                                                            @IdComprador,
                                                            @IdPublicacion,
                                                            @Fecha,
                                                            @Cantidad
                                                        )",conexion);
                
                comando.Parameters.AddWithValue("@IdComprador",comprador);
                comando.Parameters.AddWithValue("@IdPublicacion",publicacion);
                comando.Parameters.AddWithValue("@Fecha",fecha);
                comando.Parameters.AddWithValue("@Cantidad",cantidad);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
