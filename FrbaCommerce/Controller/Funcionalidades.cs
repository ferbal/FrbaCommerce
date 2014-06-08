using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FrbaCommerce.Controller
{
    class Funcionalidades
    {
        public static DataTable CargarListadoFuncionalidades()
        {
            try
            {
                DAL.FuncionalidadesDAL funcDAL = new FrbaCommerce.DAL.FuncionalidadesDAL();
                
                return funcDAL.ListarFuncionalidades();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
