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
            DataTable dt = new DataTable();

            SqlCommand comando = new SqlCommand(@"SELECT IdTipoDocumento, Descripcion
                                                  FROM TiposDocumentos",conexion);

            dt.TableName = "TiposDocumentos";

            dt.Load(comando.ExecuteReader());

            return dt;
        }
    }
}
