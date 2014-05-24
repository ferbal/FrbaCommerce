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
            commando.Parameters.Add("@Nombre", cliente.Nombre);
            commando.Parameters.Add("@Apellido", cliente.Apellido);
            commando.Parameters.Add("@NroDocumento", cliente.NroDocumento);
            commando.Parameters.Add("@CUIL", cliente.Cuil);
            commando.Parameters.Add("@IdTipoDoc", cliente.IdTipoDocumento);
            commando.Parameters.Add("@Mail", cliente.mail);
            commando.Parameters.Add("@Telefono", cliente.telefono);
            commando.Parameters.Add("@Calle", cliente.Calle);
            commando.Parameters.Add("@PisoNro",  cliente.PisoNro);
            commando.Parameters.Add("@Depto", cliente.Depto);
            commando.Parameters.Add("@Localidad", cliente.Localidad);
            commando.Parameters.Add("@CodigoPostal", cliente.CodigoPostal);
            commando.Parameters.Add("@FechaNacimiento", cliente.FechaNacimiento);

            commando.ExecuteNonQuery();                    
        }

        public int loadPorNroDoc(long nroDoc)
        {
            SqlConnection conexion = DAL.Conexion.getConexion();
            DataTable dt = new DataTable();
            
            SqlCommand comando = new SqlCommand(@"SELECT IdCliente
                                                  FROM Clientes
                                                  WHERE NroDocumento = @NroDocumento", conexion);
            comando.Parameters.Add("@NroDocumento",nroDoc);
            dt.Load(comando.ExecuteReader());
            
            return (int)dt.Rows[0][0];
        }
    }
}
