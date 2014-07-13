using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;

namespace FrbaCommerce.Controller
{
    class FacturarPublicaciones
    {
        public static void GenerarFactura(int vendedor,int compraHasta,int formaPago,String nroTarj,DateTime fechaVenc,int codSeg,String titular)
        {
            try
            {
                DAL.FacturarPublicaciones factDAL = new FrbaCommerce.DAL.FacturarPublicaciones();

                factDAL.GenerarFactura(vendedor, compraHasta, formaPago, nroTarj, fechaVenc, codSeg, titular);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
