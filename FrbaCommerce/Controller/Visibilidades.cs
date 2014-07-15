using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FrbaCommerce.Controller
{
    class Visibilidades
    {
        public static DataTable ObtenerVisibilidades(int codigo,String descripcion)
        {
            try
            {
                DAL.VisibilidadesDAL visiDAL = new FrbaCommerce.DAL.VisibilidadesDAL();
                return visiDAL.ObtenerVisibilidades(codigo,descripcion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void InsertarVisibilidad(int codigo, String descripcion,int duracion,Double precioP, Double porcentajeVenta)
        {
            try
            {
                DAL.VisibilidadesDAL visiDAL = new FrbaCommerce.DAL.VisibilidadesDAL();
                visiDAL.InsertarVisibilidad(codigo,descripcion,duracion,precioP,porcentajeVenta/100,(int)Model.Visibilidad.Estados.Habilitado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ActualizarVisibilidad(int idVisibilidad,int codigo, String descripcion, int duracion, Double precioP, Double porcentajeVenta)
        {
            try
            {
                DAL.VisibilidadesDAL visiDAL = new FrbaCommerce.DAL.VisibilidadesDAL();
                visiDAL.ActualizarVisibilidad(codigo, descripcion, duracion, precioP, porcentajeVenta / 100, idVisibilidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void CambiarEstadoVisibilidad(int idVisibilidad, int estado)
        {
            try
            {
                DAL.VisibilidadesDAL visiDAL = new FrbaCommerce.DAL.VisibilidadesDAL();
                visiDAL.CambioEstado(idVisibilidad,estado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
