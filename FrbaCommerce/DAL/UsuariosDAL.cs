using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace FrbaCommerce.DAL
{
    class UsuariosDAL
    {
        public void InsertarUsuario(int idTipoPersona, int idNumero, String login, String pass, int idEstado,int fallos)
        {            
            SqlConnection conexion = DAL.Conexion.getConexion();

            try
            {
                SqlCommand commando = new SqlCommand(@"INSERT INTO Usuarios 
                                                        (
                                                            idTipoPersona,
                                                            idNumeroTabla,
                                                            login,
                                                            password,
                                                            fallos,
                                                            idEstado
                                                        )
                                                        VALUES 
                                                        (
                                                            @idTipoPersona,
                                                            @idNumero,
                                                            @login,
                                                            @password,
                                                            @fallos,
                                                            @idEstado
                                                        )", conexion);

                commando.Parameters.AddWithValue("@idTipoPersona", idTipoPersona);
                commando.Parameters.AddWithValue("@idNumero", idNumero);
                commando.Parameters.AddWithValue("@login", login);
                commando.Parameters.AddWithValue("@password", pass);
                commando.Parameters.AddWithValue("@idEstado", idEstado);
                commando.Parameters.AddWithValue("@fallos", fallos);

                int cant = commando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Model.Usuarios loadPorLogin(String login)
        {
            SqlConnection conexion = DAL.Conexion.getConexion();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand comando = new SqlCommand(@"SELECT 
                                                            idTipoPersona,
                                                            idNumeroTabla,
                                                            login,
                                                            password,
                                                            fallos,
                                                            idEstado
                                                       FROM Usuarios
                                                       WHERE login = @login", conexion);

                comando.Parameters.AddWithValue("@login", login);
                                
                dt.Load(comando.ExecuteReader());
                
                return llenarUsuario(dt.Rows[0]);                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ExisteLogin(String login)
        {
            SqlConnection conexion = DAL.Conexion.getConexion();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand comando = new SqlCommand(@"SELECT 
                                                            idTipoPersona,
                                                            idNumeroTabla,
                                                            login,
                                                            password,
                                                            fallos,
                                                            idEstado
                                                       FROM Usuarios
                                                       WHERE login = @login", conexion);

                comando.Parameters.AddWithValue("@login", login);
                dt.Load(comando.ExecuteReader());

                return dt.Rows.Count;                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Model.Usuarios llenarUsuario(DataRow dr)
        {
            Model.Usuarios usr = new FrbaCommerce.Model.Usuarios((int)dr[0],(int)dr[1],(String)dr[2],(String)dr[3],(int)dr[4],(int)dr[5]);
            return usr;
        }
    }
}
