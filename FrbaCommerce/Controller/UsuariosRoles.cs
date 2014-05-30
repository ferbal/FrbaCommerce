using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace FrbaCommerce.Controller
{
    class UsuariosRoles
    {
        public static List<Model.Roles> obtenerRoles(int idUsuario)
        {            
            try
            {
                DAL.UsuariosRolesDAL urDAL = new FrbaCommerce.DAL.UsuariosRolesDAL();                

                List<Model.Roles> lista = new List<FrbaCommerce.Model.Roles>();

                DataTable dt = urDAL.listarRolesPorUsuario(idUsuario);
                
                foreach(DataRow dtRow in dt.Rows){
                    
                    Model.Roles rol = new Model.Roles();
                    
                    rol.IdRole = (int) dtRow.ItemArray[0];
                    rol.Nombre = Convert.ToString(dtRow.ItemArray[1]);
                    
                    lista.Add(rol);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
