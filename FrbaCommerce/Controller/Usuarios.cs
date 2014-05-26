using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace FrbaCommerce.Controller
{
    class Usuarios
    {
        public static void ingresarNuevoUsuario(int idNumero,int idTipoPersona,String pass, String login)
        {
            try
            {
                DAL.UsuariosDAL usrDAL = new FrbaCommerce.DAL.UsuariosDAL();
                int count = usrDAL.ExisteLogin(login);
                if (count>0)
                    throw new Exception("El Nombre de Usuario ya existe.");    
                
                usrDAL.InsertarUsuario(idTipoPersona, idNumero, login, pass, (int)Model.Usuarios.Estados.Habilitado, 0);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public static String encriptarPassword(String pass)
        {
            SHA256 sha = new SHA256Managed();

            byte[] temp = Encoding.ASCII.GetBytes(pass);

            byte[] clave = sha.ComputeHash(temp);

            StringBuilder sb = new StringBuilder(clave.Length);
            
            for (int i = 0; i < clave.Length; i++)
            {                
                sb.Append(clave[i].ToString("X"));
            }
            
            return sb.ToString(0,sb.Length);
        }

        public static void AltaDeUsuario(String nombre,String apellido,int tipoDoc, int nroDoc,String mail,String razonSocial, String cuit, String nombreContacto, String telefono, String calle, int pisoNro, Char depto, String localidad, int codPost, DateTime fecha,int idTipoPersona,String pass, String login)
        {            
            try
            {
                int idNumero = 0;

                if (idTipoPersona == (int)Model.TiposPersonas.TiposPersonasEnum.Cliente)
                {
                    idNumero = Controller.Cientes.ingresarClienteNuevo(nombre, apellido, tipoDoc, nroDoc, cuit, mail, fecha, telefono, calle, pisoNro, depto, codPost, localidad);
                }
                else
                {
                    idNumero = Controller.Empresas.ingresarNuevaEmpresa(razonSocial, cuit, nombreContacto, mail, telefono, calle, pisoNro, depto, localidad, codPost, fecha);
                }

                String password = Controller.Usuarios.encriptarPassword(pass);

                Controller.Usuarios.ingresarNuevoUsuario(idNumero, idTipoPersona, password, login);         
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
                
    }
}
