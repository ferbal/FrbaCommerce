using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace FrbaCommerce.DAL
{
    class OfertasDAL
    {
        public void InsertarOferta(int ofertante, int publicacion, DateTime fecha, Double monto)
        {
            try
            {
                SqlConnection conexion = DAL.Conexion.getConexion();
                SqlCommand comando = new SqlCommand(@"INSERT INTO BAZINGUEANDO_EN_SLQ.Ofertas
                                                        (
                                                            IdUsrOfertante,
                                                            IdPublicacion,
                                                            Oferta_Fecha,
                                                            Oferta_Monto
                                                        )
                                                        VALUES
                                                        (
                                                            @IdOfertante,
                                                            @IdPublicacion,
                                                            @Fecha,
                                                            @Monto
                                                        )", conexion);

                comando.Parameters.AddWithValue("@IdOfertante", ofertante);
                comando.Parameters.AddWithValue("@IdPublicacion", publicacion);
                comando.Parameters.AddWithValue("@Fecha", fecha);
                comando.Parameters.AddWithValue("@Monto", monto);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable HistorialOfertasPorUsuario(int usuario)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlConnection conexion = DAL.Conexion.getConexion();
                SqlCommand comando = new SqlCommand(@"EXEC BAZINGUEANDO_EN_SLQ.SP_OFERTAS_USUARIO @IdUsuario", conexion);

                comando.Parameters.AddWithValue("@IdUsuario", usuario);                

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
