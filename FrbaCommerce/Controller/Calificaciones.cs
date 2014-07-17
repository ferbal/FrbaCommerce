using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FrbaCommerce.Controller
{
    class Calificaciones
    {
        //PERMITE INGRESAR LA CALIFICACION DE UNA COMPRA
        public static void IngresarCalificaciones(int idCompra,int calif, String detalle)
        {
            try
            {
                DAL.CalificacionesDAL califDAL = new FrbaCommerce.DAL.CalificacionesDAL();

                califDAL.IngresarCalificacion(idCompra,calif,detalle);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //OBTIENE EL HISTORIAL DE CALIFICACIONES REALIZADAS DE UN USUARIO
        public static DataTable HistorialCalificacionesPorUsuario(int usuario)
        {
            try
            {
                DAL.CalificacionesDAL califDAL = new FrbaCommerce.DAL.CalificacionesDAL();

                return califDAL.HistorialCalificacionesPorUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //OBTIENE EL HISTORIAL DE CALIFICACIONES RECIBIDAS POR UN USUARIO
        public static DataTable HistorialCalificacionesRecibidasPorUsuario(int usuario)
        {
            try
            {
                DAL.CalificacionesDAL califDAL = new FrbaCommerce.DAL.CalificacionesDAL();

                return califDAL.HistorialCalificacionesRecibidasPorUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
