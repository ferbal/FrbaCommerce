using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace FrbaCommerce.DAL
{
    class TiposPersonasDAL
    {
        public DataTable obtenerTiposPersonas()
        {
            SqlConnection cn = DAL.Conexion.getConexion();
            try
            {
                SqlCommand commando = new SqlCommand("SELECT idTipoPersona, Descripcion FROM TiposPersonas", cn);
                DataTable dt = new DataTable();
                dt.TableName = "TiposPersonas";
                dt.Load(commando.ExecuteReader());

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
