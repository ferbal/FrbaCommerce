using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FrbaCommerce.Controller
{
    class Rubros
    {
        //GENERA UN LISTADO DE LOS RUBROS EXISTENTES
        public static DataTable obtenerRubros()
        {
            try
            {
                DAL.RubrosDAL rubro = new FrbaCommerce.DAL.RubrosDAL();

                return rubro.obtenerRubros();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
