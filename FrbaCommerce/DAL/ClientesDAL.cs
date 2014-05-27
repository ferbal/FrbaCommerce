using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace FrbaCommerce.DAL
{
    class ClientesDAL
    {
        public void InsertarCliente(Model.Clientes cliente)
        {
            SqlConnection conexion = DAL.Conexion.getConexion();

            try
            {
                SqlCommand commando = new SqlCommand(@"INSERT INTO Clientes 
                                                        (
                                                            Nombre,
                                                            Apellido,
                                                            NroDocumento,
                                                            CUIL,
                                                            IdTipoDoc,
                                                            Mail,
                                                            Telefono,
                                                            Calle,
                                                            PisoNro,
                                                            Depto,
                                                            Localidad,
                                                            CodigoPostal,
                                                            FechaNacimiento
                                                        )
                                                        VALUES 
                                                        (
                                                            @Nombre,
                                                            @Apellido,
                                                            @NroDocumento,
                                                            @CUIL,
                                                            @IdTipoDoc,
                                                            @Mail,
                                                            @Telefono,
                                                            @Calle,
                                                            @PisoNro,
                                                            @Depto,
                                                            @Localidad,
                                                            @CodigoPostal,
                                                            @FechaNacimiento
                                                        )", conexion);
                commando.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                commando.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                commando.Parameters.AddWithValue("@NroDocumento", cliente.NroDocumento);
                commando.Parameters.AddWithValue("@CUIL", cliente.Cuil);
                commando.Parameters.AddWithValue("@IdTipoDoc", cliente.IdTipoDocumento);
                commando.Parameters.AddWithValue("@Mail", cliente.mail);
                commando.Parameters.AddWithValue("@Telefono", cliente.telefono);
                commando.Parameters.AddWithValue("@Calle", cliente.Calle);
                commando.Parameters.AddWithValue("@PisoNro", cliente.PisoNro);
                commando.Parameters.AddWithValue("@Depto", cliente.Depto);
                commando.Parameters.AddWithValue("@Localidad", cliente.Localidad);
                commando.Parameters.AddWithValue("@CodigoPostal", cliente.CodigoPostal);
                commando.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);

                commando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int loadPorNroDoc(long nroDoc)
        {
            SqlConnection conexion = DAL.Conexion.getConexion();
            try
            {

                DataTable dt = new DataTable();

                SqlCommand comando = new SqlCommand(@"SELECT IdCliente
                                                  FROM Clientes
                                                  WHERE NroDocumento = @NroDocumento", conexion);
                comando.Parameters.AddWithValue("@NroDocumento", nroDoc);
                dt.Load(comando.ExecuteReader());

                return (int)dt.Rows[0][0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Boolean existeClientePorNroDoc(int nroDoc,int idTipoDoc)
        {
            SqlConnection conexion = DAL.Conexion.getConexion();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand comando = new SqlCommand(@"SELECT *                                                            
                                                        FROM Clientes
                                                        WHERE NroDocumento = @NroDocumento
                                                        AND IdTipoDocumento = @IdTipoDocumento", conexion);

                comando.Parameters.AddWithValue("@NroDocumento", nroDoc);
                comando.Parameters.AddWithValue("@IdTipoDocumento",idTipoDoc);
                dt.Load(comando.ExecuteReader());

                return (dt.Rows.Count>0);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
