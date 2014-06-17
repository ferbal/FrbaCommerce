using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Transactions;

namespace FrbaCommerce.Controller
{
    class Usuarios
    {
        public static int ingresarNuevoUsuario(int idNumero,int idTipoPersona,String pass, String login,object listaRoles)
        {
            try
            {
                DAL.UsuariosDAL usrDAL = new FrbaCommerce.DAL.UsuariosDAL();
                
                if (usrDAL.ExisteLogin(login))
                    throw new Exception("El Nombre de Usuario ya existe.");    
                
                usrDAL.InsertarUsuario(idTipoPersona, login, pass, (int)Model.Usuarios.Estados.Habilitado, 0);

                Model.Usuarios usr = usrDAL.loadPorLogin(login);
                
                return usr.idUsuario;

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

        public static Boolean AltaDeUsuario(String nombre,String apellido,int tipoDoc, int nroDoc,String mail,String razonSocial, String cuit, String nombreContacto, String telefono, String calle, int pisoNro, Char depto, String localidad, int codPost, DateTime fecha,int idTipoPersona,List<int> listaRoles)
        {
            SqlConnection conexion = DAL.Conexion.getConexion();
            CommittableTransaction ts = new CommittableTransaction();
            conexion.EnlistTransaction(ts);
            try
            {
                int idNumero = 0;

                int idUsr = Controller.Usuarios.ingresarNuevoUsuario(idNumero, idTipoPersona, "123456", mail, listaRoles);

                if (idTipoPersona == (int)Model.TiposPersonas.TiposPersonasEnum.Cliente)
                {                   
                    idNumero = Controller.Clientes.ingresarClienteNuevo(nombre, apellido, tipoDoc, nroDoc, cuit, mail, fecha, telefono, calle, pisoNro, depto, codPost, localidad,idUsr,(int)Model.Clientes.Estados.Habilitado);
                }
                else
                {
                    idNumero = Controller.Empresas.ingresarNuevaEmpresa(razonSocial, cuit, nombreContacto, mail, telefono, calle, pisoNro, depto, localidad, codPost, fecha,idUsr,(int)Model.Empresas.Estados.Habilitado);
                }

                //String password = Controller.Usuarios.encriptarPassword("");

                DAL.UsuariosRolesDAL urDAL = new FrbaCommerce.DAL.UsuariosRolesDAL();

                foreach (int itemRol in listaRoles)
                {
                    urDAL.insertarRolDeUsuario(idUsr,itemRol);    
                }
                ts.Commit();
                return true;
            }
            catch (Exception ex)
            {
                ts.Rollback();
                throw ex;
            }

        }

        public static int verficarLogin(String user, String pass)
        {
            try
            {
                DAL.UsuariosDAL usrDAL = new FrbaCommerce.DAL.UsuariosDAL();
                Model.Usuarios usuario = usrDAL.loadPorLogin(user);

                if (usuario.idEstado == (int)Model.Usuarios.Estados.Inhabilitado)
                    throw new Exception("El usuario se encuentra inhabilitado.");

                if (usuario.password.Equals("123456"))
                    return -1;

                String hashPass = Controller.Usuarios.encriptarPassword(pass);

                if (usuario.password.Equals(hashPass))
                {
                    usrDAL.limpiarIngresosFallidos(usuario.idUsuario);
                    return usuario.idUsuario;
                }
                else
                {
                    if (usuario.fallos < 3)
                    {
                        usrDAL.incrementarIngresoFallido(usuario.idUsuario);
                        
                    }
                    else
                    {
                        usrDAL.inhabilitarUsuario(usuario.idUsuario);
                        throw new Exception("Usuario Inhabilitado.");
                    }
                    throw new Exception("Contraseña Incorrecta.");
                }                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int ActualizarPassword(String usrNombre,String pass)
        {
            try
            {
                DAL.UsuariosDAL usrDAL = new FrbaCommerce.DAL.UsuariosDAL();
                
                String hashPass = Controller.Usuarios.encriptarPassword(pass);                
                
                Model.Usuarios usuario = usrDAL.loadPorLogin(usrNombre);

                usrDAL.ActualizarPassword(usuario.idUsuario,hashPass);

                return usuario.idUsuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
                
    }
}
