using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace FrbaCommerce.DAL
{
    public static class Conexion
    {
        private static SqlConnection conex = null;

        public static SqlConnection getConexion()
        {
            try
            {
                if (conex == null) {
                    conex = new SqlConnection("Data Source=localhost\\SQLSERVER2008;Initial Catalog=GD1C2014;Integrated Security=True");
                    conex.Open();                 
                }
                return conex;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
