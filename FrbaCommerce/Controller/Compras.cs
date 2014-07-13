using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

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

        public static DataTable ArmarListaCompraHasta(int vendedor)
        {
            try
            {
                DAL.ComprasDAL cmpDAL = new FrbaCommerce.DAL.ComprasDAL();

                return cmpDAL.ListarComprasHasta(vendedor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable ArmarListaCompraDesde(int vendedor)
        {
            try
            {
                DAL.ComprasDAL cmpDAL = new FrbaCommerce.DAL.ComprasDAL();

                return cmpDAL.ListarComprasDesde(vendedor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable ArmarListaComprasAFacturar(int vendedor, int compraHasta)
        {
            try
            {
                DAL.ComprasDAL cmpDAL = new FrbaCommerce.DAL.ComprasDAL();

                return cmpDAL.ListarComprasAFacturar(vendedor,compraHasta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ActualizarComprasAFacturadas(int vendedor, int compraHasta)
        {
            try
            {
                DAL.ComprasDAL cmpDAL = new FrbaCommerce.DAL.ComprasDAL();

                cmpDAL.CambiarEstadoComprasAFacturadas(vendedor, compraHasta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable ObtenerGastosPorVisibilidad(int vendedor, int compraHasta)
        {
            try
            {
                DAL.ComprasDAL cmpDAL = new FrbaCommerce.DAL.ComprasDAL();

                return cmpDAL.ObtenerGastosVisibilidad(vendedor, compraHasta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
