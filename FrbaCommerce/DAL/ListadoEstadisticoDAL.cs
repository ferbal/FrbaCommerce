using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace FrbaCommerce.DAL
{
    class ListadoEstadisticoDAL
    {

        public DataTable GenerarListado(String anio, int trimestre, String listado, String visibilidad)
        {

            SqlConnection conexion = DAL.Conexion.getConexion();
            DataTable dt = new DataTable();
            try
            {
                String fecha1 = String.Empty;
                String fecha2 = String.Empty;
                int visibilidadN = 0;

                if (trimestre == 1)
                {
                    fecha1 = "01-01-" + anio;
                    fecha2 = "31-03-" + anio; 
                }

                if (trimestre == 2)
                {
                    fecha1 = "01-04-" + anio;
                    fecha2 = "30-06-" + anio;
                }

                if (trimestre == 3)
                {
                    fecha1 = "01-07-" + anio;
                    fecha2 = "30-09-" + anio;
                }

                if (trimestre == 4)
                {
                    fecha1 = "01-10-" + anio;
                    fecha2 = "31-12-" + anio;
                }

                if (visibilidad == "Platino" )
                    visibilidadN = 1;

                if (visibilidad == "Oro")
                    visibilidadN = 2;

                if (visibilidad == "Plata")
                    visibilidadN = 3;

                if (visibilidad == "Bronce")
                    visibilidadN = 4;

                if (visibilidad == "Gratis")
                    visibilidadN = 5;

                
                SqlCommand comando;

                //por default
                //if (listado == "VENDEDORES CON MAYOR CANTIDAD DE PRODUCTOS NO VENDIDOS")
                //{
                comando = new SqlCommand(@" select TOP 5 
                                            U.login USUARIO,
                                            sum(P.Stock) PRODUCTOS_SIN_VENDER,
                                            P.IdVisibilidad VISIBILIDAD
                                            from BAZINGUEANDO_EN_SLQ.Publicaciones P 
                                            join BAZINGUEANDO_EN_SLQ.Usuarios U
                                            on U.idUsuario = P.IdUsuario
                                            join BAZINGUEANDO_EN_SLQ.Visibilidades V
                                            on  V.IdVisibilidad = P.IdVisibilidad
                                            where P.FechaInicio between CONVERT(DATETIME,'" + fecha1 +
                                            "') AND CONVERT(DATETIME,'" + fecha2 +
                                            "') AND V.IdVisibilidad = " + visibilidadN +
                                            " group by U.login, p.Stock, P.IdVisibilidad order by P.IdVisibilidad, SUM(P.Stock) DESC" 
                                   
                                                        , conexion);
                //}

                if (listado == "VENDEDORES CON MAYOR FACTURACION")
                {
                    comando = new SqlCommand(@"select TOP 5 U.login USUARIO, SUM(F.Total) FACTURACION
                                                            from BAZINGUEANDO_EN_SLQ.Facturas F
                                                            join BAZINGUEANDO_EN_SLQ.Usuarios U
                                                            on u.idUsuario = F.IdUsuario
                                                            where F.Fecha between CONVERT(DATETIME,'" + fecha1 + 
                                                            "') AND CONVERT(DATETIME,'" + fecha2 + 
                                                            "') group by U.login order by SUM(F.Total) desc"
                    , conexion);
                }

                if (listado == "VENDEDORES CON MAYORES CALIFICACIONES")
                {

                    comando = new SqlCommand(@"select TOP 5 
                                                        (select login 
                                                        from BAZINGUEANDO_EN_SLQ.Usuarios 
                                                        where idUsuario = P.IdUsuario) USUARIO,
                                                        SUM(ca.Calificacion) TOTAL_CALFICACIONES
                                                        from BAZINGUEANDO_EN_SLQ.Publicaciones P
                                                        join BAZINGUEANDO_EN_SLQ.Compras C
                                                        on C.IdPublicacion = P.IdPublicacion
                                                        join BAZINGUEANDO_EN_SLQ.Calificaciones Ca
                                                        on ca.IdCompra = c.IdCompra
                                                        where c.Fecha between CONVERT(DATETIME,'" + fecha1 + "') AND CONVERT(DATETIME,'" + fecha2 + 
                                                        "') group by P.idUsuario order by SUM(ca.Calificacion) desc"

                    , conexion);

                }

                if (listado == "CLIENTES CON MAYOR CANTIDAD DE PUBLICACIONES SIN CALIFICAR")
                {

                    comando = new SqlCommand(@"SELECT TOP 5
                                               (select login
                                               from BAZINGUEANDO_EN_SLQ.Usuarios U
                                                where idUsuario = COMP.IdUsrComprador 
                                                and idTipoPersona = 1) USUARIO,
                                                COMP.IdUsrComprador, COUNT(*) PUBLICACIONES_SIN_CALIFICAR
                                                FROM BAZINGUEANDO_EN_SLQ.Compras COMP
                                                LEFT JOIN BAZINGUEANDO_EN_SLQ.Calificaciones CALIF
                                                ON COMP.IDCOMPRA = CALIF.IDCOMPRA
                                                WHERE CALIF.IDCALIFICACION IS NULL
                                                AND COMP.Fecha between CONVERT(DATETIME,'" + fecha1 +
                                                "') AND CONVERT(DATETIME,'" + fecha2 + 
                                                "') GROUP BY COMP.IdUsrComprador ORDER BY COUNT(*) DESC"

                    , conexion);
                }

                dt.Load(comando.ExecuteReader());



                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable obtenerAnios()
        {
            SqlConnection conexion = DAL.Conexion.getConexion();
            try
            {

                DataTable dt = new DataTable();

                SqlCommand comando = new SqlCommand(@"SELECT DISTINCT CAST(YEAR(FechaFin) AS VARCHAR(4)) AÑO 
                                                      FROM BAZINGUEANDO_EN_SLQ.Publicaciones", conexion);

                dt.TableName = "Publicaciones";

                dt.Load(comando.ExecuteReader());

                DataRow row = dt.NewRow();
                row["AÑO"] = ""; //insert a blank row
                dt.Rows.InsertAt(row, 0); //insert new to to index 0 (on top)

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable obtenerVisibilidades()
        {
            SqlConnection conexion = DAL.Conexion.getConexion();
            try
            {

                DataTable dt = new DataTable();

                SqlCommand comando = new SqlCommand(@"SELECT Descripcion
                                                      from BAZINGUEANDO_EN_SLQ.Visibilidades", conexion);

                dt.TableName = "Visibilidades";

                dt.Load(comando.ExecuteReader());

                DataRow row = dt.NewRow();
                row["Descripcion"] = ""; //insert a blank row
                dt.Rows.InsertAt(row, 0); //insert new to to index 0 (on top)

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
