using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FrbaCommerce.Controller
{
    class Publicaciones
    {
        //GENERA UNA PUBLICACION NUEVA
        public static void IngresarPublicacionNueva(int tipoPubli,int cod,int rubro,int visibilidad,DateTime fechaInicio,DateTime fechaFin,String descripcion,int stock, Double precio, int idUsuario,Boolean preguntas)
        {
            try
            {
                
                DAL.PublicacionesDAL publiDAL = new FrbaCommerce.DAL.PublicacionesDAL();

                publiDAL.InsertarPublicacion(tipoPubli,cod,rubro,visibilidad,(int)Model.Publicaciones.Estados.Borrador,fechaInicio,fechaFin,descripcion,stock,precio,idUsuario,preguntas);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //ACTUALIZA LOS DATOS DE UNA PUBLICACION EXISTENTE
        public static void ActualizarPublicacion(int idPublicacion,int tipoPubli, int cod, int rubro, int visibilidad, DateTime fechaInicio, DateTime fechaFin, String desc, int stock, Double precio, int idUsuario, bool preguntas)
        {
            try
            {
                DAL.PublicacionesDAL publiDAL = new FrbaCommerce.DAL.PublicacionesDAL();

                publiDAL.ActualizarPublicacion(idPublicacion,tipoPubli,cod,rubro,visibilidad,fechaInicio,fechaFin,desc,stock,precio,idUsuario,preguntas);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //CALCULA LA FECHA DE FINALIZACION DE LA PUBLICACION EN FUNCION DE LA FECHA DE INICIO
        //Y LA DURACION DE LA VISIBILIDAD
        public static DateTime calcularFechaFin(int visibilidad,String fechaInicio)
        {
            DateTime fechaFin;
            try
            {
                DAL.VisibilidadesDAL vDAL = new FrbaCommerce.DAL.VisibilidadesDAL();

                fechaFin = Convert.ToDateTime(fechaInicio).AddDays(vDAL.CalcularVigenciaPublicacion(visibilidad));

                return fechaFin;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //OBTIENE EL ULTIMO CODIGO DE PUBLICACION
        public static int UltimoCodigo()
        {
            try
            {
                DAL.PublicacionesDAL publi = new FrbaCommerce.DAL.PublicacionesDAL();
                
                DataTable dt = publi.obtenerUltimoCodigo();
                if (dt.Rows.Count == 0)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(dt.Rows[0].ItemArray[0]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        //GENERA UN LISTADO DE PUBLICACIONES
        public static DataTable ListarPublicaciones(int desde,int codigo,String descrip, String vendedor, int tipoPub, int estado)
        {
            try
            {
                DAL.PublicacionesDAL pubDAL = new FrbaCommerce.DAL.PublicacionesDAL();
                
                return pubDAL.listarPublicacionesPaginadas(desde,codigo,descrip,vendedor,tipoPub,estado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //ACTUALIZA UNA PUBLICACION PARTICULAR A UN ESTADO PASADO POR PARAMETRO
        public static void ActualizarEstado(int estado, int publicacion)
        {
            try
            {
                DAL.PublicacionesDAL pubDAL = new FrbaCommerce.DAL.PublicacionesDAL();

                pubDAL.ActualizarEstado(estado,publicacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //AL FINALIZAR UNA PUBLICACION, SELECCIONA LA OFERTA GANADORA Y GENERA LA COMPRA CORRESPONDIENTE
        public static void ConvertirOfertasEnCompras(int publicacion)
        {
            try
            {
                DAL.PublicacionesDAL pubDAL = new FrbaCommerce.DAL.PublicacionesDAL();

                pubDAL.ConvertirOfertasEnCompras(publicacion,Controller.Validaciones.ObtenerFechaSistema());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //GENERA UNA LISTA DE LOS ESTADOS DE LA PUBLICACION
        public static DataTable ObtenerListaEstados()
        {
            try
            {
                DAL.PublicacionesDAL pubDAL = new FrbaCommerce.DAL.PublicacionesDAL();

                return pubDAL.ListarEstados();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //OBTIENE LA CANTIDAD DE PUBLICACIONES EXISTENTES
        public static int CantidadDePublicaciones()
        {
            try
            {
                DAL.PublicacionesDAL pubDAL = new FrbaCommerce.DAL.PublicacionesDAL();

                return pubDAL.obtenerCantidadPublicaciones();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //OBTIENE UN LISTADO DE PUBLICACIONES PARA COMPRAR/OFERTAR
        public static DataTable CargarParaCompra(int desde, int rubro,String descripcion)
        {
            try
            {
                DAL.PublicacionesDAL pubDAL = new FrbaCommerce.DAL.PublicacionesDAL();

                return pubDAL.ListarParaCompraOferta(desde*10,rubro,descripcion);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //OBTIENE LA CANTIDAD DE UBLICACIONES PARA COMPRAR/OFERTAR
        public static int CantidadPublicacionesParaComprarOFertar(int rubro,String descripcion)
        {
            try
            {
                DAL.PublicacionesDAL pubDAL = new FrbaCommerce.DAL.PublicacionesDAL();

                return pubDAL.CantidadPublicacionesParaCompraOferta(rubro,descripcion);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //CARGA UNA PUBLICACION POR IDPUBLICACION
        public static Model.Publicaciones LoadById(int idPublicacion)
        {
            try
            {
                DAL.PublicacionesDAL pubDAL = new FrbaCommerce.DAL.PublicacionesDAL();

                DataTable dt = pubDAL.LoadById(idPublicacion);

                Model.Publicaciones p = new FrbaCommerce.Model.Publicaciones();
                p.IdPublicacion = Convert.ToInt32(dt.Rows[0]["IdPublicacion"]);
                p.CodPublicacion = Convert.ToInt32(dt.Rows[0]["CodPublicacion"]);
                p.Descripcion = dt.Rows[0]["Descripcion"].ToString();
                p.IdTipoPublicacion = Convert.ToInt32(dt.Rows[0]["IdTipoPublicacion"]);
                p.IdVisibilidad = Convert.ToInt32(dt.Rows[0]["IdVisibilidad"]);
                p.IdEstado = Convert.ToInt32(dt.Rows[0]["IdEstado"]);
                p.FechaInicio = Convert.ToDateTime(dt.Rows[0]["FechaInicio"]);
                p.FechaFin = Convert.ToDateTime(dt.Rows[0]["FechaFin"]);
                p.Stock = Convert.ToInt32(dt.Rows[0]["Stock"]);
                p.Precio = Convert.ToDouble(dt.Rows[0]["Precio"]);
                p.IdRubro = Convert.ToInt32(dt.Rows[0]["IdRubro"]);
                p.IdUsuario = Convert.ToInt32(dt.Rows[0]["IdUsuario"]);
                p.PermiteRealizarPreguntas = Convert.ToBoolean(dt.Rows[0]["PermiteRealizarPreguntas"]);

                return p;           
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
