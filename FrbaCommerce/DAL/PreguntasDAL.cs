using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FrbaCommerce.DAL
{
    class PreguntasDAL
    {
        public DataTable ObtenerPreguntasSinRespuestas(int usuario)
        {
            try
            {
                DataTable dt = new DataTable();
                
                SqlConnection conexion = DAL.Conexion.getConexion();

                SqlCommand comando = new SqlCommand(@"",conexion);

                dt.Load(comando.ExecuteReader());

                return dt;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ObtenerPreguntasConRespuestas(int usuario)
        {
            try
            {
                DataTable dt = new DataTable();

                SqlConnection conexion = DAL.Conexion.getConexion();

                SqlCommand comando = new SqlCommand(@"", conexion);

                dt.Load(comando.ExecuteReader());

                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       
    }
}
