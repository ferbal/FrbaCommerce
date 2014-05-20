using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace FrbaCommerce.DAL
{
    class ClientesDAL
    {
        public void InsertarCliente(Model.Clientes cliente)
        {

            SqlConnection conexion = DAL.Conexion.getConexion();
            SqlCommand commando = new SqlCommand("INSERT INTO Clientes (Nombre,Apellido,NroDocumento,CUIL,IdTipoDoc,Mail,Telefono,Calle,PisoNro,Depto,Localidad,CodigoPostal,FechaNacimiento)" +
                                                 "VALUES (@Nombre,@Apellido,@NroDocumento,@CUIL,@IdTipoDoc,@Mail,@Telefono,@Calle,@PisoNro,@Depto,@Localidad,@CodigoPostal,@FechaNacimiento)", conexion);
            commando.Parameters.Add("@Nombre", cliente.Nombre);
            commando.Parameters.Add("@Apellido", cliente.Apellido);
            commando.Parameters.Add("@NroDocumento", cliente.NroDocumento);
            commando.Parameters.Add("@CUIL", cliente.Cuil);
            commando.Parameters.Add("@IdTipoDoc", 1);//cliente.IdTipoDocumento);
            commando.Parameters.Add("@Mail", cliente.mail);
            commando.Parameters.Add("@Telefono", cliente.telefono);
            commando.Parameters.Add("@Calle", "");//cliente.Calle);
            commando.Parameters.Add("@PisoNro", "");// cliente.PisoNro);
            commando.Parameters.Add("@Depto", "");//cliente.Depto);
            commando.Parameters.Add("@Localidad", "");// cliente.Localidad);
            commando.Parameters.Add("@CodigoPostal", "");// cliente.CodigoPostal);
            commando.Parameters.Add("@FechaNacimiento", cliente.FechaNacimiento);

            int cant = commando.ExecuteNonQuery();
        }
    }
}
