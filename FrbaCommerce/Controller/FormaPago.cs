using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FrbaCommerce.Controller
{
    class FormaPago
    {
        public static DataTable ObtenerFormasPago()
        {
            try
            {
                DAL.FormaPagoDAL fpDAL = new FrbaCommerce.DAL.FormaPagoDAL();

                return fpDAL.ObtenerFormasPago();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
