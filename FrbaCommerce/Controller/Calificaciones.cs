using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
