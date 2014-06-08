using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FrbaCommerce.Controller
{
    class Publicaciones
    {
        public static void IngresarPublicacionNueva(int tipoPubli,int visibilidad,Double valor,DateTime fechaInicio,DateTime fechaFin,String descripcion,int stock, Double precio, int idUsuario,Boolean preguntas)
        {
            try
            {
                
                DAL.PublicacionesDAL publiDAL = new FrbaCommerce.DAL.PublicacionesDAL();

                publiDAL.InsertarPublicacion(tipoPubli,visibilidad,valor,(int)Model.Publicaciones.Estados.Borrador,fechaInicio,fechaFin,descripcion,stock,precio,idUsuario,preguntas);

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
    }
}
