using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;


namespace FrbaCommerce.Controller
{
    class Usuarios
    {
        //INGRESA UN NUEVO USUARIO AL SISTEMA
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
        //ENCRIPTA EL PASSWORD SEGUN EL ALGORITMO SHA256
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
        //GENERA LA LOGICA DEL ALTA DE UN USUARIO (GENERANDO LA PERSONA CORRESPONDIENTE)
        public static Boolean AltaDeUsuario(String nombre,String apellido,int tipoDoc, int nroDoc,String mail,String razonSocial, String cuit, String nombreContacto, String telefono, String calle, int pisoNro, Char depto, String localidad, int codPost, DateTime fecha,int idTipoPersona,List<int> listaRoles)
        {
            SqlConnection conexion = DAL.Conexion.getConexion();
            CommittableTransaction ts = new CommittableTransaction();
            conexion.EnlistTransaction(ts);
            try
            {
                int idNumero = 0;
                String password = Controller.Usuarios.encriptarPassword("12345678");
                int idUsr = Controller.Usuarios.ingresarNuevoUsuario(idNumero, idTipoPersona, password, mail, listaRoles);

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
        //VERIFICA EL LOGUEO DEL USUARIO VALIDANDO EL PASSWORD.
        //CONTANDO LOS INTENTOS FALLIDOS SI LLEGA A 3 EN EL 4° INTENTO SE BLOQUEA EL USUARIO,
        //SI REALIZA UN INGRESO SATISFACTORIO ANTES DEL 4° INTENTO SE RENUEVA EL CONTADOR.
        public static int verficarLogin(String user, String pass)
        {
            try
            {
                DAL.UsuariosDAL usrDAL = new FrbaCommerce.DAL.UsuariosDAL();
                Model.Usuarios usuario = usrDAL.loadPorLogin(user);

                if (usuario.idEstado == (int)Model.Usuarios.Estados.Inhabilitado)
                    throw new Exception("El usuario se encuentra inhabilitado.");

                if (usuario.password.Equals(Controller.Usuarios.encriptarPassword("12345678")))
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
        //ACTUALIZA EL PASSWORD DEL USUARIO
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
        //GENERA UN LISTADO DE VENDEDORES
        public static DataTable ObtenerListaDeVendedores()
        {
            try
            {
                DAL.UsuariosDAL usrDAL = new FrbaCommerce.DAL.UsuariosDAL();

                return usrDAL.ListarVendedores();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //GENERA UN LISTADO DE CLIENTES
        public static DataTable ObtenerListaSeleccionClientes(String nombre,String apellido,String razonSocial,int idTipoPersona)
        {
            try
            {
                DAL.UsuariosDAL usrDAL = new FrbaCommerce.DAL.UsuariosDAL();

                return usrDAL.ListarClientes(nombre,apellido,razonSocial,idTipoPersona);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //VALIDA QUE EL ESTADO DEL USUARIO SEA IGUAL AL PASADO POR PARAMETRO
        public static Boolean ValidarEstadoDeUsuario(int idUsuario, int idEstado)
        {
            try
            {
                DAL.UsuariosDAL usrDAL = new FrbaCommerce.DAL.UsuariosDAL();

                Model.Usuarios usr = usrDAL.loadPorId(idUsuario);

                return (usr.idEstado == idEstado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //SE CAMBIA EL ESTADO DEL USUARIO
        public static void CambiarEstado(int idUsuario, int idEstado)
        {
            try
            {
                DAL.UsuariosDAL usrDAL = new FrbaCommerce.DAL.UsuariosDAL();

                usrDAL.CambiarEstado(idUsuario,idEstado);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
