using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace FrbaCommerce.DAL
{
    class TiposDocumentosDAL
    {
        public DataTable obtenerTiposDocumentos()
        {
            SqlConnection conexion = DAL.Conexion.getConexion();
            try
            {

                DataTable dt = new DataTable();
                

                SqlCommand comando = new SqlCommand(@"SELECT IdTipoDocumento, Descripcion
                                                  FROM BAZINGUEANDO_EN_SLQ.TiposDocumentos", conexion);
                
                dt.TableName = "TiposDocumentos";

                dt.Load(comando.ExecuteReader());

                DataRow row = dt.NewRow();
                row["Descripcion"] = ""; //insert a blank row
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
