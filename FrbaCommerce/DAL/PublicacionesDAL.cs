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
                SqlCommand comando = new SqlCommand(@"  INSERT INTO BAZINGUEANDO_EN_SLQ.Publicaciones
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
                SqlCommand comando = new SqlCommand(@"  UPDATE BAZINGUEANDO_EN_SLQ.Publicaciones
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
                SqlCommand comando = new SqlCommand(@"  SELECT MAX(CodPublicacion)
                                                        FROM BAZINGUEANDO_EN_SLQ.Publicaciones
                                                    ", conexion);
                dt.Load(comando.ExecuteReader());

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int obtenerCantidadPublicaciones()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlConnection conexion = DAL.Conexion.getConexion();
                SqlCommand comando = new SqlCommand(@"   SELECT COUNT(*)
                                                         FROM BAZINGUEANDO_EN_SLQ.Publicaciones"
                                                        , conexion);
                dt.Load(comando.ExecuteReader());

                return Convert.ToInt32(dt.Rows[0][0]);
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
                                                        FROM BAZINGUEANDO_EN_SLQ.Publicaciones PUB
                                                        INNER JOIN BAZINGUEANDO_EN_SLQ.TiposPublicaciones TP
                                                            ON PUB.IdTipoPublicacion = TP.IdTipoPublicacion
                                                        INNER JOIN BAZINGUEANDO_EN_SLQ.EstadosPublicacion EST
                                                            ON PUB.IdEstado = EST.IdEstadoPublicacion
                                                        INNER JOIN BAZINGUEANDO_EN_SLQ.Rubros RUB
                                                            ON RUB.IdRubro = PUB.IdRubro
                                                        INNER JOIN BAZINGUEANDO_EN_SLQ.Visibilidades V
                                                            ON V.IdVisibilidad = PUB.IdVisibilidad
                                                        INNER JOIN BAZINGUEANDO_EN_SLQ.Usuarios USR
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

        public DataTable listarPublicacionesPaginadas(int pDesde,int codigo, String descripcion, String vendedor, int tipoPub, int estado)
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

                if (pDesde != null)
                    where = where + " AND PUB.IdPublicacion NOT IN (SELECT TOP " + pDesde.ToString()
                                    + " IdPublicacion FROM BAZINGUEANDO_EN_SLQ.Publicaciones)";
               

                if (!String.IsNullOrEmpty(where))
                    where = "WHERE " + where.Substring(4);
                
                SqlCommand comando = new SqlCommand(@"  SELECT  TOP 10
                                                                IdPublicacion,
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
                                                        FROM BAZINGUEANDO_EN_SLQ.Publicaciones PUB
                                                        INNER JOIN BAZINGUEANDO_EN_SLQ.TiposPublicaciones TP
                                                            ON PUB.IdTipoPublicacion = TP.IdTipoPublicacion
                                                        INNER JOIN BAZINGUEANDO_EN_SLQ.EstadosPublicacion EST
                                                            ON PUB.IdEstado = EST.IdEstadoPublicacion
                                                        INNER JOIN BAZINGUEANDO_EN_SLQ.Rubros RUB
                                                            ON RUB.IdRubro = PUB.IdRubro
                                                        INNER JOIN BAZINGUEANDO_EN_SLQ.Visibilidades V
                                                            ON V.IdVisibilidad = PUB.IdVisibilidad
                                                        INNER JOIN BAZINGUEANDO_EN_SLQ.Usuarios USR
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
                SqlCommand comando = new SqlCommand(@"  UPDATE BAZINGUEANDO_EN_SLQ.Publicaciones
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
                SqlCommand comando = new SqlCommand(@"  SELECT IdEstadoPublicacion,Descripcion
                                                        FROM BAZINGUEANDO_EN_SLQ.EstadosPublicacion", conexion);

                dt.Load(comando.ExecuteReader());

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ListarParaCompraOferta(int desde, int rubro, String descripcion,int codigo)
        {
            try
            {
                String where = String.Empty;
               
                DataTable dt = new DataTable();
                SqlConnection conexion = DAL.Conexion.getConexion();
                if (codigo != -1)
                    where = where + " AND PUB.CodPublicacion = " + codigo.ToString();
                if (rubro != -1)
                    where = where + " AND PUB.IdRubro = " + rubro.ToString();

                if (!String.IsNullOrEmpty(descripcion))
                    where = where + " AND PUB.Descripcion LIKE '%" + descripcion + "%'";

                if (desde != 0)
                    where = where + @" AND PUB.IdPublicacion NOT IN (SELECT TOP " + desde +
                                                                        @" IdPublicacion
                                                                FROM BAZINGUEANDO_EN_SLQ.Publicaciones PUB
                                                        INNER JOIN BAZINGUEANDO_EN_SLQ.EstadosPublicacion EP
	                                                        ON PUB.IdEstado = EP.IdEstadoPublicacion
                                                        INNER JOIN BAZINGUEANDO_EN_SLQ.Visibilidades V
	                                                        ON PUB.IdVisibilidad = V.IdVisibilidad
                                                        WHERE	PUB.IdEstado = 2
                                                                AND FechaInicio <= @FechaActual
		                                                        AND FechaFin >= @FechaActual                                                            
		                                                        AND ((PUB.IdTipoPublicacion = 1 AND PUB.Stock>0) OR PUB.IdTipoPublicacion = 2)"
                                                        + where + @"
                                                        ORDER BY    V.PrecioPorPublicar DESC,
                                                                    PUB.FechaInicio ASC, 
                                                                    PUB.FechaFin ASC, 
                                                                    PUB.CodPublicacion ASC)";

                SqlCommand comando = new SqlCommand(@"  
                                                        SELECT TOP 10	
                                                                PUB.IdPublicacion,
		                                                        PUB.CodPublicacion [Codigo Publicacion],
                                                                TP.Descripcion [Tipo Publicacion],
		                                                        PUB.Descripcion [Publicacion],
		                                                        V.Descripcion [Visibilidad],
		                                                        PUB.FechaInicio [Fecha Inicio],
		                                                        PUB.FechaFin [Fecha Fin],
		                                                        EP.Descripcion [Estado]
                                                        FROM BAZINGUEANDO_EN_SLQ.Publicaciones PUB
                                                        INNER JOIN BAZINGUEANDO_EN_SLQ.EstadosPublicacion EP
	                                                        ON PUB.IdEstado = EP.IdEstadoPublicacion
                                                        INNER JOIN BAZINGUEANDO_EN_SLQ.Visibilidades V
	                                                        ON PUB.IdVisibilidad = V.IdVisibilidad
                                                        INNER JOIN BAZINGUEANDO_EN_SLQ.TiposPublicaciones TP
                                                            ON TP.IdTipoPublicacion = PUB.IdTipoPublicacion
                                                        WHERE	PUB.IdEstado = 2
                                                                AND FechaInicio <= @FechaActual
		                                                        AND FechaFin >= @FechaActual                                                                
		                                                        AND ((PUB.IdTipoPublicacion = 1 AND PUB.Stock>0) OR PUB.IdTipoPublicacion = 2)
                                                        " + where +@"
                                                        ORDER BY    V.PrecioPorPublicar DESC,
                                                                    PUB.FechaInicio ASC, 
                                                                    PUB.FechaFin ASC, 
                                                                    PUB.CodPublicacion ASC
                                                        ", conexion);

                comando.Parameters.AddWithValue("@FechaActual",Controller.Validaciones.ObtenerFechaSistema());

                dt.Load(comando.ExecuteReader());

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CantidadPublicacionesParaCompraOferta(int rubro,String descripcion)
        {
            try
            {
                String where = String.Empty;
                DataTable dt = new DataTable();
                SqlConnection conexion = DAL.Conexion.getConexion();

                if (!String.IsNullOrEmpty(descripcion))
                    where = where + " AND PUB.Descripcion LIKE '%" + descripcion + "%'";

                if (rubro != -1)
                    where = where + " AND PUB.IdRubro = " + rubro.ToString();

                SqlCommand comando = new SqlCommand(@"  
                                                        SELECT COUNT(*)
                                                        FROM BAZINGUEANDO_EN_SLQ.Publicaciones PUB
                                                        INNER JOIN BAZINGUEANDO_EN_SLQ.EstadosPublicacion EP
	                                                        ON PUB.IdEstado = EP.IdEstadoPublicacion
                                                        INNER JOIN BAZINGUEANDO_EN_SLQ.Visibilidades V
	                                                        ON PUB.IdVisibilidad = V.IdVisibilidad
                                                        WHERE	PUB.IdEstado = 2
                                                                AND FechaInicio <= @FechaActual
		                                                        AND FechaFin >= @FechaActual
		                                                        AND (PUB.IdTipoPublicacion = 1 AND PUB.Stock>0)                  
                                                        " + where, conexion);

                comando.Parameters.AddWithValue("@FechaActual", Controller.Validaciones.ObtenerFechaSistema());

                dt.Load(comando.ExecuteReader());

                return Convert.ToInt32(dt.Rows[0][0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable LoadById(int publicacion)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlConnection conex = DAL.Conexion.getConexion();

                SqlCommand comando = new SqlCommand(@"  SELECT *
                                                        FROM BAZINGUEANDO_EN_SLQ.Publicaciones
                                                        WHERE idPublicacion = @idPublicacion",conex);

                comando.Parameters.AddWithValue("@idPublicacion",publicacion);

                dt.Load(comando.ExecuteReader());

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ConvertirOfertasEnCompras(int publicacion, DateTime fecha)
        {
            try
            {
                SqlConnection conexion = DAL.Conexion.getConexion();
                SqlCommand comando = new SqlCommand(@"  EXEC BAZINGUEANDO_EN_SLQ.SP_CONVERTIR_OFERTA_EN_COMPRA
                                                        @PUBLICACION,@FECHA", conexion);

                comando.Parameters.AddWithValue("@FECHA", fecha);
                comando.Parameters.AddWithValue("@PUBLICACION", publicacion);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
