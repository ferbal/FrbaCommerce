using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FrbaCommerce.Controller
{
    class Publicaciones
    {
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

        public static DateTime calcularFechaFin(int visibilidad,String fechaInicio)
        {
            DateTime fechaFin;

            fechaFin = Convert.ToDateTime(fechaInicio).AddDays(30);// Agregar la cantidad de dias en la VISIBILIDAD!!!

            return fechaFin;
        }

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

        public static DataTable ListarPublicaciones(int codigo,String descrip, String vendedor, int tipoPub, int estado)
        {
            try
            {
                DAL.PublicacionesDAL pubDAL = new FrbaCommerce.DAL.PublicacionesDAL();
                
                return pubDAL.listarPublicaciones(codigo,descrip,vendedor,tipoPub,estado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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
    }
}
