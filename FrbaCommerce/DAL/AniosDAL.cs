using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

//BORRAR ESTA CLASE

namespace FrbaCommerce.DAL
{
    class AniosDAL
    {
        public DataTable obtenerAnios()
        {
            SqlConnection conexion = DAL.Conexion.getConexion();
            try
            {

                DataTable dt = new DataTable();


                SqlCommand comando = new SqlCommand(@"SELECT DISTINCT YEAR(FechaFin) AÑO 
                                                      FROM BAZINGUEANDO_EN_SLQ.Publicaciones", conexion);
                
                dt.TableName = "Publicaciones";

                dt.Load(comando.ExecuteReader());

                DataRow row = dt.NewRow();
                row["AÑO"] = ""; //insert a blank row
                dt.Rows.InsertAt(row, 0); //insert new to to index 0 (on top)

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
