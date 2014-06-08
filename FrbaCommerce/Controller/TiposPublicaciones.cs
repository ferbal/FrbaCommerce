using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FrbaCommerce.Controller
{
    class TiposPublicaciones
    {
        public static DataTable obtenerTiposPublicaciones()
        {
            try
            {
                DAL.TiposPublicacionesDAL tp = new FrbaCommerce.DAL.TiposPublicacionesDAL();

                return tp.listarTiposPublicaciones();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
