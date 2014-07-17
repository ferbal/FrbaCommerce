using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FrbaCommerce.Controller
{
    class Compras
    {
        //GENERA UNA COMPRA
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

        //GENERA UNA LISTA DE TODAS LAS COMPRAS DE UN CLIENTE QUE NO FUERON FACTURADAS
        //ES UNA LISTA DE LOS ID DE LA COMPRA
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
        //DEVUELVE LA COMPRA MAS VIEJA QUE NO FUE FACTURADA (DE UN CLIENTE)
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

        //GENERA UNA LISTA DE TODAS LAS COMPRAS DEL CLIENTE QUE NO FUERON FACTURADAS.        
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
        //ACTUALIZA EL ESTADO DE LAS COMPRAS FACTURADAS A "FACTURADAS"
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
        //GENERA UN LISTADO DE LOS GASTOS DE VISIBILIDAD POR CADA PUBLICACION QUE SE ENCUENTRE
        //EN LA LISTA DE LAS COMPRAS A FACTURAR
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
        //GENERA UN LISTADO DE LAS COMPRAS QUE NO FUERON CALIFICADAS POR USUARIO
        public static DataTable ObtenerComprasNoCalificadas(int idUsuario)
        {
            try
            {
                DAL.ComprasDAL cmpDAL = new FrbaCommerce.DAL.ComprasDAL();

                return cmpDAL.ObtenerComprasNoCalificadas(idUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //GENERA UN HISTORIAL DE COMPRAS POR USUARIO
        public static DataTable HistorialComprasPorUsuario(int usuario)
        {
            try
            {
                DAL.ComprasDAL cmpDAL = new FrbaCommerce.DAL.ComprasDAL();

                return cmpDAL.HistorialComprasPorUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
