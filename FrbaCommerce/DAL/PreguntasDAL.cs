using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FrbaCommerce.DAL
{
    class PreguntasDAL
    {
        public DataTable ObtenerPreguntasSinRespuestas(int usuario)
        {
            try
            {
                DataTable dt = new DataTable();
                
                SqlConnection conexion = DAL.Conexion.getConexion();

                SqlCommand comando = new SqlCommand(@"EXEC BAZINGUEANDO_EN_SLQ.SP_RESPONDER_PREGUNTAS_USUARIO
                                                        @USUARIO", conexion);
                
                comando.Parameters.AddWithValue("@USUARIO",usuario);
                
                dt.Load(comando.ExecuteReader());

                return dt;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ObtenerPreguntasConRespuestas(int usuario)
        {
            try
            {
                DataTable dt = new DataTable();

                SqlConnection conexion = DAL.Conexion.getConexion();

                SqlCommand comando = new SqlCommand(@"EXEC BAZINGUEANDO_EN_SLQ.SP_RESPUESTAS_USUARIO 
                                                        @USUARIO", conexion);

                comando.Parameters.AddWithValue("@USUARIO",usuario);

                dt.Load(comando.ExecuteReader());

                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void IngresarNuevaPregunta(int usuario,int publicacion,String pregunta,DateTime fecha)
        {
            try
            {                
                SqlConnection conexion = DAL.Conexion.getConexion();

                SqlCommand comando = new SqlCommand(@"INSERT INTO BAZINGUEANDO_EN_SLQ.Preguntas
                                                        (
                                                            IdPublicacion,
                                                            IdUsuario,
                                                            Descripcion,
                                                            Fecha
                                                        )
                                                        VALUES
                                                        (
                                                            @PUBLICACION,
                                                            @USUARIO,
                                                            @PREGUNTA,
                                                            @FECHA
                                                        )", conexion);

                comando.Parameters.AddWithValue("@USUARIO", usuario);
                comando.Parameters.AddWithValue("@PUBLICACION", publicacion);
                comando.Parameters.AddWithValue("@PREGUNTA", pregunta);
                comando.Parameters.AddWithValue("@FECHA", fecha);

                comando.ExecuteNonQuery();                

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
