using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FrbaCommerce.Controller
{
    class Visibilidades
    {
        //GENERA UN LISTADO DE VISIBILIDADES
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
        //SE GENERA UN LISTADO DE VISIBILIDADES HABILITADAS
        public static DataTable ListarVisibilidadesHabilitadas()
        {
            try
            {
                DAL.VisibilidadesDAL visiDAL = new FrbaCommerce.DAL.VisibilidadesDAL();
                return visiDAL.ListarVisibilidadesHabilitados();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //INGRESA UNA NUEVA VISIBILIDAD
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
        //ACTUALIZA UNA VISIBILIDAD EXISTENTE
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
        //CAMBIA EL ESTADO DE UNA VISIBILIDAD
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
