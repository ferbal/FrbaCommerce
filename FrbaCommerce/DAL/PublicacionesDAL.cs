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
        public void InsertarPublicacion(int tipoPubli,int cod,int rubro,int visibilidad,int estado,DateTime fechaInicio,DateTime fechaFin, String descripcion, int stock, Double precio,int idUsuario,Boolean preguntas)
        {
            try
            {
                SqlConnection conexion = DAL.Conexion.getConexion();
                SqlCommand comando = new SqlCommand(@"  INSERT INTO Publicaciones
                                                        (
                                                            IdTipoPublicacion,
                                                            CodPublicacion,
                                                            IdVisibilidad,                                                            
                                                            IdEstado,
                                                            FechaInicio,
                                                            FechaFin,
                                                            Descripcion,
                                                            Stock,
                                                            Precio,
                                                            IdRubro,
                                                            IdUsuario,
                                                            PermiteRealizarPreguntas
                                                        )
                                                        VALUES
                                                        (
                                                            @IdTipoPublicacion,
                                                            @CodPublicacion,
                                                            @IdVisibilidad,
                                                            @IdEstado,
                                                            @FechaInicio,
                                                            @FechaFin,
                                                            @Descripcion,
                                                            @Stock,                                    
                                                            @Precio,
                                                            @IdRubro,
                                                            @IdUsuario,
                                                            @PermiteRealizarPreguntas
                                                        )", conexion);

                comando.Parameters.AddWithValue("@IdTipoPublicacion",tipoPubli);
                comando.Parameters.AddWithValue("@CodPublicacion", cod);
                comando.Parameters.AddWithValue("@IdVisibilidad",visibilidad);                
                comando.Parameters.AddWithValue("@IdEstado",estado);
                comando.Parameters.AddWithValue("@FechaInicio",fechaInicio);
                comando.Parameters.AddWithValue("@FechaFin",fechaFin);
                comando.Parameters.AddWithValue("@Descripcion",descripcion);
                comando.Parameters.AddWithValue("@Stock",stock);
                comando.Parameters.AddWithValue("@Precio",precio);
                comando.Parameters.AddWithValue("@IdRubro", rubro);
                comando.Parameters.AddWithValue("@IdUsuario",idUsuario);
                comando.Parameters.AddWithValue("@PermiteRealizarPreguntas",preguntas);

                comando.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }            
        }

        public void ActualizarPublicacion(int idPublicacion,int tipoPubli, int cod, int rubro, int visibilidad, DateTime fechaInicio, DateTime fechaFin, String descripcion, int stock, Double precio, int idUsuario, Boolean preguntas)
        {
            try
            {
                SqlConnection conexion = DAL.Conexion.getConexion();
                SqlCommand comando = new SqlCommand(@"  UPDATE Publicaciones
                                                        SET
                                                            IdTipoPublicacion = @IdTipoPublicacion,
                                                            CodPublicacion = @CodPublicacion,
                                                            IdVisibilidad = @IdVisibilidad,                                                            
                                                            FechaInicio = @FechaInicio,
                                                            FechaFin = @FechaFin,
                                                            Descripcion = @Descripcion,
                                                            Stock = @Stock,
                                                            Precio = @Precio,
                                                            IdRubro = @IdRubro,
                                                            IdUsuario = @IdUsuario,
                                                            PermiteRealizarPreguntas = @Preguntas
                                                        WHERE IdPublicacion = @IdPublicacion", conexion);

                comando.Parameters.AddWithValue("@IdPublicacion", idPublicacion);
                comando.Parameters.AddWithValue("@IdTipoPublicacion", tipoPubli);
                comando.Parameters.AddWithValue("@CodPublicacion", cod);
                comando.Parameters.AddWithValue("@IdVisibilidad", visibilidad);
                comando.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                comando.Parameters.AddWithValue("@FechaFin", fechaFin);
                comando.Parameters.AddWithValue("@Descripcion", descripcion);
                comando.Parameters.AddWithValue("@Stock", stock);
                comando.Parameters.AddWithValue("@Precio", precio);
                comando.Parameters.AddWithValue("@IdRubro", rubro);
                comando.Parameters.AddWithValue("@IdUsuario", idUsuario);
                comando.Parameters.AddWithValue("@Preguntas", preguntas);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
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
                SqlCommand comando = new SqlCommand(@"   SELECT MAX(CodPublicacion)
                                                            FROM Publicaciones
                                                            GROUP BY CodPublicacion",conexion);
                dt.Load(comando.ExecuteReader());

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable listarPublicaciones(int codigo, String descripcion, String vendedor, int tipoPub, int estado)
        {
            try
            {
                String where = String.Empty;
                DataTable dt = new DataTable();
                SqlConnection conexion = DAL.Conexion.getConexion();
                
                if(codigo != -1)
                    where = " AND CodPublicacion = " + codigo.ToString();

                if (!String.IsNullOrEmpty(descripcion))
                    where = where + " AND PUB.Descripcion LIKE '%" + descripcion + "%'";

                if(!String.IsNullOrEmpty(vendedor))
                    where = where + " AND USR.Login LIKE '%" + vendedor + "%'";

                if (tipoPub != -1)
                    where = where + " AND PUB.IdTipoPublicacion = " + tipoPub.ToString();

                if (estado != -1)
                    where = where + " AND PUB.IdEstado = " + estado.ToString();

                if (!String.IsNullOrEmpty(where))
                    where = "WHERE " + where.Substring(4);

                SqlCommand comando = new SqlCommand(@"  SELECT  IdPublicacion,
                                                                CodPublicacion Codigo,
                                                                PUB.IdVisibilidad,
                                                                V.Descripcion Visibilidad,
                                                                PUB.IdTipoPublicacion,
                                                                TP.Descripcion [Tipo Publicacion],
                                                                PUB.IdEstado,
                                                                EST.Descripcion Estado,
                                                                PUB.FechaInicio [Fecha Inicio],
                                                                PUB.FechaFin [Fecha Fin],
                                                                PUB.Descripcion,
                                                                PUB.Stock,
                                                                PUB.Precio,
                                                                PUB.IdRubro,
                                                                RUB.Descripcion Rubro,
                                                                PUB.IdUsuario,
                                                                PUB.PermiteRealizarPreguntas
                                                        FROM Publicaciones PUB
                                                        INNER JOIN TiposPublicaciones TP
                                                            ON PUB.IdTipoPublicacion = TP.IdTipoPublicacion
                                                        INNER JOIN Estados EST
                                                            ON PUB.IdEstado = EST.IdEstado
                                                        INNER JOIN Rubros RUB
                                                            ON RUB.IdRubro = PUB.IdRubro
                                                        INNER JOIN Visibilidades V
                                                            ON V.IdVisibilidad = PUB.IdVisibilidad
                                                        INNER JOIN Usuarios USR
                                                            ON USR.IdUsuario = PUB.IdUsuario
                                                        " + where,conexion);                

                dt.Load(comando.ExecuteReader());

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizarEstado(int estado,int publicacion)
        {
            try
            {
                SqlConnection conexion = DAL.Conexion.getConexion();
                SqlCommand comando = new SqlCommand(@"  UPDATE Publicaciones
                                                        SET IdEstado = @IdEstado
                                                        WHERE IdPublicacion = @IdPublicacion",conexion);

                comando.Parameters.AddWithValue("@IdEstado",estado);
                comando.Parameters.AddWithValue("@IdPublicacion",publicacion);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ListarEstados()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlConnection conexion = DAL.Conexion.getConexion();
                SqlCommand comando = new SqlCommand(@"  SELECT IdEstado,Descripcion
                                                        FROM Estados
                                                        WHERE IdEstado IN (4,5,6,7)", conexion);

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
