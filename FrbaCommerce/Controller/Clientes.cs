using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Controller
{
    class Cientes
    {
        public static int ingresarClienteNuevo(String nombre,String apellido,int tipoDoc, int nroDoc,String nroCuil,String mail,DateTime fecha,String telefono,String calle,int pisoNro,Char depto, int codPost,String localidad,int usr,int estado)
        {
            try
            {                
                Model.Clientes cli = new FrbaCommerce.Model.Clientes(nombre, apellido, tipoDoc, nroDoc, nroCuil, mail, fecha, telefono, calle, pisoNro, depto, codPost, localidad,usr,estado);
                DAL.ClientesDAL cliDAL = new FrbaCommerce.DAL.ClientesDAL();

                if (cliDAL.existeClientePorNroDoc(nroDoc, tipoDoc))
                    throw new Exception("El Cliente ya existe.");

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
