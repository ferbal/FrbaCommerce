using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FrbaCommerce.DAL
{
    class PublicacionesDAL
    {
        public void InsertarPublicacion(int tipoPubli,int visibilidad,Double valor,int estado,DateTime fechaInicio,DateTime fechaFin, String descripcion, int stock, Double precio,int idUsuario,Boolean preguntas)
        {
            try
            {
                SqlConnection conexion = DAL.Conexion.getConexion();
                SqlCommand comando = new SqlCommand(@"  INSERT INTO Publicaciones
                                                        (
                                                            IdTipoPublicacion,
                                                            IdVisibilidad,
                                                            Valor,
                                                            IdEstado,
                                                            FechaInicio,
                                                            FechaFin,
                                                            Descripcion,
                                                            Stock,
                                                            Precio,
                                                            IdUsuario,
                                                            PermiteRealizarPreguntas
                                                        )
                                                        VALUES
                                                        (
                                                            @IdTipoPublicacion,
                                                            @IdVisibilidad,
                                                            @Valor,
                                                            @IdEstado,
                                                            @FechaInicio,
                                                            @FechaFin,
                                                            @Descripcion,
                                                            @Stock,
                                                            @Precio,
                                                            @IdUsuario,
                                                            @PermiteRealizarPreguntas
                                                        )", conexion);

                comando.Parameters.AddWithValue("@IdTipoPublicacion",tipoPubli);
                comando.Parameters.AddWithValue("@IdVisibilidad",visibilidad);
                comando.Parameters.AddWithValue("@Valor",valor);
                comando.Parameters.AddWithValue("@IdEstado",estado);
                comando.Parameters.AddWithValue("@FechaInicio",fechaInicio);
                comando.Parameters.AddWithValue("@FechaFin",fechaFin);
                comando.Parameters.AddWithValue("@Descripcion",descripcion);
                comando.Parameters.AddWithValue("@Stock",stock);
                comando.Parameters.AddWithValue("@Precio",precio);
                comando.Parameters.AddWithValue("@IdUsuario",idUsuario);
                comando.Parameters.AddWithValue("@PermiteRealizarPreguntas",preguntas);

                comando.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }            
        }

        public DataTable obtenerUltimoCodigo()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlConnection conexion = DAL.Conexion.getConexion();
                SqlCommand comando = new SqlCommand(@"   SELECT MAX(IdPublicacion)
                                                            FROM Publicaciones
                                                            GROUP BY IdPublicacion",conexion);
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
