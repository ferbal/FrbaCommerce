using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Controller
{
    class Cientes
    {
        public static int ingresarClienteNuevo(String nombre,String apellido,int tipoDoc, int nroDoc,String nroCuil,String mail,DateTime fecha,String telefono,String calle,int pisoNro,Char depto, int codPost,String localidad)
        {
            try
            {                
                Model.Clientes cli = new FrbaCommerce.Model.Clientes(nombre, apellido, tipoDoc, nroDoc, nroCuil, mail, fecha, telefono, calle, pisoNro, depto, codPost, localidad);
                DAL.ClientesDAL cliDAL = new FrbaCommerce.DAL.ClientesDAL();

                cliDAL.InsertarCliente(cli);

                return cliDAL.loadPorNroDoc(cli.NroDocumento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
