using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

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
                                                            Cantidad,
                                                            IdEstadoCompra
                                                        )
                                                        VALUES
                                                        (
                                                            @IdComprador,
                                                            @IdPublicacion,
                                                            @Fecha,
                                                            @Cantidad,
                                                            2
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

        public DataTable ListarComprasDesde(int vendedor)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlConnection conexion = DAL.Conexion.getConexion();
                SqlCommand comando = new SqlCommand(@"  EXEC BAZINGUEANDO_EN_SLQ.SP_ObtenerCompraDesde @IdUsuario", conexion);

                comando.Parameters.AddWithValue("@IdUsuario", vendedor);

                dt.Load(comando.ExecuteReader());

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ListarComprasHasta(int vendedor)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlConnection conexion = DAL.Conexion.getConexion();
                SqlCommand comando = new SqlCommand(@"EXEC BAZINGUEANDO_EN_SLQ.SP_ObtenerComprasHasta @IdUsuario", conexion);

                comando.Parameters.AddWithValue("@IdUsuario", vendedor);

                dt.Load(comando.ExecuteReader());

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       

        public DataTable ListarComprasAFacturar(int vendedor, int compraHasta)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlConnection conexion = DAL.Conexion.getConexion();
                SqlCommand comando = new SqlCommand(@"EXEC BAZINGUEANDO_EN_SLQ.SP_ListarComprasAFacturar
                                                        @IdUsuario,@CompraHasta", conexion);

                comando.Parameters.AddWithValue("@IdUsuario", vendedor);
                comando.Parameters.AddWithValue("@CompraHasta", compraHasta);

                dt.Load(comando.ExecuteReader());

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable CambiarEstadoComprasAFacturadas(int vendedor, int compraHasta)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlConnection conexion = DAL.Conexion.getConexion();
                SqlCommand comando = new SqlCommand(@"  UPDATE BAZINGUEANDO_EN_SLQ.Compras
                                                        SET IdEstadoCompra = 1
	                                                    FROM BAZINGUEANDO_EN_SLQ.Compras C
	                                                    INNER JOIN BAZINGUEANDO_EN_SLQ.Publicaciones P
		                                                    ON P.IdPublicacion = C.IdPublicacion
	                                                    INNER JOIN BAZINGUEANDO_EN_SLQ.Visibilidades V
		                                                    ON V.IdVisibilidad = P.IdVisibilidad
	                                                    WHERE	P.IdUsuario = @VENDEDOR
			                                                    AND C.IdCompra <= @COMPRA_HASTA
                                                                AND C.IdEstadoCompra = 2
	                                                    ORDER BY C.IdCompra
                                                        @IdUsuario,@CompraHasta", conexion);

                comando.Parameters.AddWithValue("@IdUsuario", vendedor);
                comando.Parameters.AddWithValue("@CompraHasta", compraHasta);

                dt.Load(comando.ExecuteReader());

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ObtenerGastosVisibilidad(int vendedor, int compraHasta)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlConnection conexion = DAL.Conexion.getConexion();
                SqlCommand comando = new SqlCommand(@"SELECT	MAX(V.Codigo) [CODIGO],
			                                                    MAX(V.Descripcion) [DESCRIPCION],
			                                                    MAX(V.PrecioPorPublicar) [PRECIO POR PUBLICAR]
	                                                    FROM BAZINGUEANDO_EN_SLQ.Compras C
	                                                    INNER JOIN BAZINGUEANDO_EN_SLQ.Publicaciones P
		                                                    ON P.IdPublicacion = C.IdPublicacion
	                                                    INNER JOIN BAZINGUEANDO_EN_SLQ.Visibilidades V
		                                                    ON V.IdVisibilidad = P.IdVisibilidad
	                                                    WHERE	P.IdUsuario = @VENDEDOR
			                                                    AND C.IdCompra <= @COMPRA_HASTA
                                                                AND C.IdEstadoCompra = 2
                                                                AND P.Facturada = 0
	                                                    GROUP BY P.IdPublicacion", conexion);

                comando.Parameters.AddWithValue("@VENDEDOR", vendedor);
                comando.Parameters.AddWithValue("@COMPRA_HASTA", compraHasta);

                dt.Load(comando.ExecuteReader());

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ObtenerComprasNoCalificadas(int IdUsuario)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlConnection conexion = DAL.Conexion.getConexion();
                SqlCommand comando = new SqlCommand(@"EXEC BAZINGUEANDO_EN_SLQ.SP_COMPRAS_A_CALIFICAR
                                                        @Usuario
                                                        ", conexion);

                comando.Parameters.AddWithValue("@Usuario", IdUsuario);

                dt.Load(comando.ExecuteReader());

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable HistorialComprasPorUsuario(int usuario)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlConnection conexion = DAL.Conexion.getConexion();
                SqlCommand comando = new SqlCommand(@"EXEC BAZINGUEANDO_EN_SLQ.SP_COMPRAS_USUARIO
                                                        @IdUsuario", conexion);

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
