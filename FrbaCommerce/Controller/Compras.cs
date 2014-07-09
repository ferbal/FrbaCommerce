using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Controller
{
    class Compras
    {
        public static void GenerarCompra(int comprador,int publicacion, DateTime fecha,int cant)
        {
            try
            {
                DAL.ComprasDAL cmpDAL = new FrbaCommerce.DAL.ComprasDAL();

                cmpDAL.InsertarCompra(comprador,publicacion,fecha,cant);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
