using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FrbaCommerce.DAL
{
    class RespuestasDAL
    {
        public void GenerarRespuesta(int idPregunta,String descripcion,DateTime fecha)
        {
            try
            {
                
                SqlConnection conexion = DAL.Conexion.getConexion();

                SqlCommand comando = new SqlCommand(@"INSERT INTO BAZINGUEANDO_EN_SLQ.Respuestas
                                                        (
                                                            IdPregunta,
                                                            Descripcion,
                                                            Fecha
                                                        )
                                                        VALUE
                                                        (
                                                            @IdPersona,
                                                            @Descripcion,
                                                            @Fecha
                                                        )", conexion);

                comando.Parameters.AddWithValue("@IdPregunta",idPregunta);
                comando.Parameters.AddWithValue("@Descripcion", descripcion);
                comando.Parameters.AddWithValue("@Fecha", fecha);

                comando.ExecuteNonQuery();              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
