using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Data;

namespace FrbaCommerce.Controller
{
    class RolesFuncionalidades
    {
        public static Dictionary<String, bool> getFuncionalidadesDisponibles(int usr,int rol)
        {
            Dictionary<String, bool> dic = new Dictionary<string, bool>();
            DAL.RolesFuncionalidadesDAL rfDAL = new FrbaCommerce.DAL.RolesFuncionalidadesDAL();
            //RolesFuncionalidades rf = new RolesFuncionalidades();
            DAL.FuncionalidadesDAL funcDAL = new FrbaCommerce.DAL.FuncionalidadesDAL();

            DataTable dt = funcDAL.ListarFuncionalidades();

            foreach (DataRow dr in dt.Rows)
            {
                dic.Add(dr.ItemArray[1].ToString(), false);
            }

            dt = rfDAL.ObtenerFuncionalidadesDeRol(rol);

            foreach (DataRow dr in dt.Rows)
            {
                dic[dr.ItemArray[0].ToString()] = true;
            }
            
            return dic;
        }

        private Dictionary<String, bool> armarDiccionario()
        {
            Dictionary<String, bool> dic = new Dictionary<string, bool>();
            

            return dic;
        }

        public static DataTable ObtenerFuncionalidadesDeRol(int rol)
        {
            try
            {
                DAL.RolesFuncionalidadesDAL rfDAL = new FrbaCommerce.DAL.RolesFuncionalidadesDAL();

                return rfDAL.ObtenerFuncionalidadesDeRol(rol);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
