using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FrbaCommerce.Controller
{
    class Calificaciones
    {
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
