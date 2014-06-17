using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.IO;

namespace FrbaCommerce.DAL
{
    public static class Conexion
    {
        private static SqlConnection conex = null;

        public static SqlConnection getConexion()
        {
            try
            {
                //"Data Source=localhost\\SQLSERVER2008;Initial Catalog=GD1C2014;Integrated Security=True"                
                if (conex == null) {
                    String str = DAL.Conexion.ObtenerCadenaConexion();
                    conex = new SqlConnection();
                    conex.ConnectionString = str;
                    conex.Open();                 
                }
                return conex;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private static String ObtenerCadenaConexion()
        {
            String str = String.Empty;

            StreamReader or = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\config.txt");
            str = or.ReadLine();

            if (!String.IsNullOrEmpty(str))
            {
                if (str.Substring(0, 9).CompareTo("Conexion=") == 0)
                {
                    str = str.Substring(9);
                    
                }
            }


            return str;
        }
    }
}
