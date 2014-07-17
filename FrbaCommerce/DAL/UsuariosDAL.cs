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
        public void InsertarUsuario(int idTipoPersona, String login, String pass, int idEstado,int fallos)
        {            
            SqlConnection conexion = DAL.Conexion.getConexion();

            try
            {
                SqlCommand commando = new SqlCommand(@"INSERT INTO BAZINGUEANDO_EN_SLQ.Usuarios 
                                                        (
                                                            idTipoPersona,                                                            
                                                            login,
                                                            password,
                                                            fallos,
                                                            idEstado
                                                        )
                                                        VALUES 
                                                        (
                                                            @idTipoPersona,
                                                            @login,
                                                            @password,
                                                            @fallos,
                                                            @idEstado
                                                        )", conexion);

                commando.Parameters.AddWithValue("@idTipoPersona", idTipoPersona);                
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
                                                            idUsuario,
                                                            idTipoPersona,
                                                            login,
                                                            password,
                                                            fallos,
                                                            idEstado
                                                       FROM BAZINGUEANDO_EN_SLQ.Usuarios
                                                       WHERE login = @login", conexion);

                comando.Parameters.AddWithValue("@login", login);
                                
                dt.Load(comando.ExecuteReader());

                if (dt.Rows.Count == 0)
                {
                    throw new Exception("El usuario ingresado no existe.");
                }

                return llenarUsuario(dt.Rows[0]);                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void incrementarIngresoFallido(int idUsuario)
        {
            SqlConnection conexion = DAL.Conexion.getConexion();
            try
            {
                SqlCommand comando = new SqlCommand(@"UPDATE BAZINGUEANDO_EN_SLQ.Usuarios
                                                      SET fallos = fallos + 1
                                                      WHERE idUsuario = @idUsuario",conexion);
                comando.Parameters.AddWithValue("@idUsuario",idUsuario);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void limpiarIngresosFallidos(int idUsuario)
        {
            SqlConnection conexion = DAL.Conexion.getConexion();
            try
            {
                SqlCommand comando = new SqlCommand(@"UPDATE BAZINGUEANDO_EN_SLQ.Usuarios
                                                      SET fallos = 0
                                                      WHERE idUsuario = @idUsuario", conexion);
                comando.Parameters.AddWithValue("@idUsuario", idUsuario);

                comando.ExecuteNonQuery();                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizarPassword(int idUsuario,String pass)
        {
            SqlConnection conexion = DAL.Conexion.getConexion();
            try
            {
                SqlCommand comando = new SqlCommand(@"UPDATE BAZINGUEANDO_EN_SLQ.Usuarios
                                                      SET password = @pass
                                                      WHERE idUsuario = @idUsuario", conexion);
                comando.Parameters.AddWithValue("@idUsuario", idUsuario);
                comando.Parameters.AddWithValue("@pass", pass);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void inhabilitarUsuario(int idUsuario)
        {
            SqlConnection conexion = DAL.Conexion.getConexion();
            try
            {
                SqlCommand comando = new SqlCommand(@"UPDATE BAZINGUEANDO_EN_SLQ.Usuarios
                                                      SET idEstado = @idEstado
                                                      WHERE idUsuario = @idUsuario", conexion);

                comando.Parameters.AddWithValue("@idUsuario", idUsuario);
                comando.Parameters.AddWithValue("@idEstado", Model.Usuarios.Estados.Inhabilitado);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean ExisteLogin(String login)
        {
            SqlConnection conexion = DAL.Conexion.getConexion();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand comando = new SqlCommand(@"SELECT 
                                                            idTipoPersona,                                                            
                                                            login,
                                                            password,
                                                            fallos,
                                                            idEstado
                                                       FROM BAZINGUEANDO_EN_SLQ.Usuarios
                                                       WHERE login = @login", conexion);

                comando.Parameters.AddWithValue("@login", login);
                dt.Load(comando.ExecuteReader());

                return (dt.Rows.Count>0);                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ListarVendedores()
        {
            SqlConnection conexion = DAL.Conexion.getConexion();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand comando = new SqlCommand(@"(
	                                                        SELECT	U.idUsuario IdUsuario,
			                                                        C.Apellido + ', '+ C.Nombre Descripcion
	                                                        FROM BAZINGUEANDO_EN_SLQ.Usuarios U
	                                                        INNER JOIN BAZINGUEANDO_EN_SLQ.Clientes C
		                                                        ON U.idUsuario = C.idUsuario
	                                                        UNION ALL
	                                                        SELECT	U.idUsuario IdUsuario,
			                                                        E.RazonSocial Descripcion
	                                                        FROM BAZINGUEANDO_EN_SLQ.Usuarios U
	                                                        INNER JOIN BAZINGUEANDO_EN_SLQ.Empresas E
		                                                        ON U.idUsuario = E.idUsuario
                                                        )
                                                        ORDER BY 1,2", conexion);

                
                dt.Load(comando.ExecuteReader());

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ListarClientes(String nombre, String apellido, String razonSocial,int idTipoPersona)
        {
            String where = String.Empty;

            if (idTipoPersona!=-1)
                where = where + " AND U.IdTipoPersona = " + idTipoPersona.ToString();

            if (!String.IsNullOrEmpty(nombre))
                where = where + " AND C.Nombre LIKE '%" + nombre + "%'";

            if (!String.IsNullOrEmpty(apellido))
                where = where + " AND C.Apellido LIKE '%" + apellido + "%'";

            if (!String.IsNullOrEmpty(razonSocial))
                where = where + " AND E.RazonSocial LIKE '%" + razonSocial + "%'";

            if (!String.IsNullOrEmpty(where))
                where = "WHERE " + where.Substring(4);

            SqlConnection conexion = DAL.Conexion.getConexion();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand comando = new SqlCommand(@"  SELECT	U.idUsuario IdUsuario,
                                                                CASE 
                                                                    WHEN C.Apellido IS NOT NULL THEN C.Apellido + ', '+ C.Nombre
                                                                    ELSE E.RazonSocial
                                                                END Descripcion,
                                                                ISNULL(CONVERT(VARCHAR(10),C.NroDocumento),E.Cuit) [Nro Documento]
                                                        FROM BAZINGUEANDO_EN_SLQ.Usuarios U
                                                        LEFT JOIN BAZINGUEANDO_EN_SLQ.Clientes C
                                                            ON U.idUsuario = C.idUsuario	                                                            
                                                        LEFT JOIN BAZINGUEANDO_EN_SLQ.Empresas E
                                                            ON U.idUsuario = E.idUsuario
                                                        " + where + @" 
                                                        ORDER BY 1,2", conexion);


                dt.Load(comando.ExecuteReader());

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Model.Usuarios loadPorId(int idUsuario)
        {
            SqlConnection conexion = DAL.Conexion.getConexion();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand comando = new SqlCommand(@"SELECT 
                                                            idUsuario,
                                                            idTipoPersona,
                                                            login,
                                                            password,
                                                            fallos,
                                                            idEstado
                                                       FROM BAZINGUEANDO_EN_SLQ.Usuarios
                                                       WHERE idUsuario = @IdUsuario", conexion);

                comando.Parameters.AddWithValue("@IdUsuario", idUsuario);

                dt.Load(comando.ExecuteReader());

                if (dt.Rows.Count == 0)
                {
                    throw new Exception("El usuario ingresado no existe.");
                }

                return llenarUsuario(dt.Rows[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CambiarEstado(int idUsuario,int idEstado)
        {
            SqlConnection conexion = DAL.Conexion.getConexion();
            try
            {
                SqlCommand comando = new SqlCommand(@"UPDATE BAZINGUEANDO_EN_SLQ.Usuarios
                                                      SET idEstado = @idEstado
                                                      WHERE idUsuario = @idUsuario", conexion);

                comando.Parameters.AddWithValue("@idUsuario", idUsuario);
                comando.Parameters.AddWithValue("@idEstado", idEstado);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Model.Usuarios llenarUsuario(DataRow dr)
        {
            Model.Usuarios usr = new FrbaCommerce.Model.Usuarios((int)dr[0], (int)dr[1], (String)dr[2], (String)dr[3], (int)dr[4], (int)dr[5]);
            return usr;
        }
    }
}
