using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FrbaCommerce.DAL
{
    class VisibilidadesDAL
    {
        public DataTable ObtenerVisibilidades(int codigo,String descripcion)
        {
            try
            {
                String where = String.Empty;

                if (codigo!=-1)
                    where = where + " AND V.Codigo = " + codigo.ToString();

                if (!String.IsNullOrEmpty(descripcion))
                    where = where + " AND V.Descripcion LIKE '%" + descripcion + "%'";

                if (!String.IsNullOrEmpty(where))
                    where = "WHERE " + where.Substring(4);

                DataTable dt = new DataTable();
                SqlConnection conexion = DAL.Conexion.getConexion();
                SqlCommand comando = new SqlCommand(@"SELECT    V.IdVisibilidad,
                                                                V.Codigo,
                                                                V.Descripcion,
                                                                V.Duracion,
                                                                V.PrecioPorPublicar [Precio por Publicar],
                                                                V.PorcentajeVenta [Porcentaje de Venta],
                                                                V.IdEstado,
                                                                E.Descripcion [Estado]
                                                        FROM BAZINGUEANDO_EN_SLQ.Visibilidades V
                                                        INNER JOIN BAZINGUEANDO_EN_SLQ.Estados E
                                                            ON V.IdEstado = E.IdEstado "
                                                        + where,conexion);

                dt.Load(comando.ExecuteReader());

                return dt;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ListarVisibilidadesHabilitados()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlConnection conexion = DAL.Conexion.getConexion();
                SqlCommand comando = new SqlCommand(@"SELECT    IdVisibilidad,
                                                                Descripcion
                                                        FROM BAZINGUEANDO_EN_SLQ.Visibilidades
                                                        WHERE IdEstado <> 2
                                                        ", conexion);

                dt.Load(comando.ExecuteReader());

                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertarVisibilidad(int codigo, String descripcion,int duracion, Double precioP, Double porcentajeVenta, int estado)
        {
            try
            {
      
                SqlConnection conexion = DAL.Conexion.getConexion();
                SqlCommand comando = new SqlCommand(@"INSERT INTO BAZINGUEANDO_EN_SLQ.Visibilidades
                                                            (
                                                                Codigo,
                                                                Descripcion,
                                                                Duracion,
                                                                PrecioPorPublicar,
                                                                PorcentajeVenta,
                                                                IdEstado
                                                            )
                                                            VALUES
                                                            (
                                                                @CODIGO,
                                                                @DESCRIPCION,
                                                                @DURACION,
                                                                @PRECIO_PUBLICAR,
                                                                @PORCENTAJE_VENTA,
                                                                @IDESTADO
                                                            )", conexion);

                comando.Parameters.AddWithValue("@CODIGO",codigo);
                comando.Parameters.AddWithValue("@DESCRIPCION",descripcion);
                comando.Parameters.AddWithValue("@DURACION",duracion);
                comando.Parameters.AddWithValue("@PRECIO_PUBLICAR",precioP);
                comando.Parameters.AddWithValue("@PORCENTAJE_VENTA",porcentajeVenta);
                comando.Parameters.AddWithValue("@IDESTADO",estado);

                comando.ExecuteNonQuery();                

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizarVisibilidad(int codigo, String descripcion, int duracion, Double precioP, Double porcentajeVenta, int idVisibilidad)
        {
            try
            {

                SqlConnection conexion = DAL.Conexion.getConexion();
                SqlCommand comando = new SqlCommand(@"  UPDATE BAZINGUEANDO_EN_SLQ.Visibilidades    
                                                        SET Codigo = @CODIGO,
                                                            Descripcion = @DESCRIPCION,
                                                            Duracion = @DURACION,
                                                            PrecioPorPublicar = @PRECIO_PUBLICAR,
                                                            PorcentajeVenta = @PORCENTAJE_VENTA                                                            
                                                         WHERE IdVisibilidad = @ID", conexion);

                comando.Parameters.AddWithValue("@CODIGO", codigo);
                comando.Parameters.AddWithValue("@DESCRIPCION", descripcion);
                comando.Parameters.AddWithValue("@DURACION", duracion);
                comando.Parameters.AddWithValue("@PRECIO_PUBLICAR", precioP);
                comando.Parameters.AddWithValue("@PORCENTAJE_VENTA", porcentajeVenta);
                comando.Parameters.AddWithValue("@ID", idVisibilidad);

                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CambioEstado(int idVisibilidad,int estado)
        {
            try
            {

                SqlConnection conexion = DAL.Conexion.getConexion();
                SqlCommand comando = new SqlCommand(@"  UPDATE BAZINGUEANDO_EN_SLQ.Visibilidades
                                                        SET IdEstado = @ESTADO
                                                        WHERE IdVisibilidad = @ID", conexion);
                               
                comando.Parameters.AddWithValue("@ESTADO", estado);
                comando.Parameters.AddWithValue("@ID", idVisibilidad);

                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
