using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FrbaCommerce.Controller
{
    class Ofertas
    {
        //GENERA UNA OFERTA
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
        //GENERA EL HISTORIAL DE OFERTAS POR USUARIO
        public static DataTable HistorialOfertasPorUsuario(int usuario)
        {
            try
            {
                DAL.OfertasDAL ofDAL = new FrbaCommerce.DAL.OfertasDAL();

                return ofDAL.HistorialOfertasPorUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
