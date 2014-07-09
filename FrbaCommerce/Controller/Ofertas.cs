using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Controller
{
    class Ofertas
    {
        public static void GenerarOferta(int ofertante, int publicacion, DateTime fecha, Double monto)
        {
            try
            {
                DAL.OfertasDAL ofDAL = new FrbaCommerce.DAL.OfertasDAL();

                ofDAL.InsertarOferta(ofertante,publicacion,fecha,monto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
