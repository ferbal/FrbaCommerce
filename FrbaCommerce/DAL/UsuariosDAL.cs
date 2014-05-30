﻿using System;
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
                                                            idUsuario,
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

        public void incrementarIngresoFallido(int idUsuario)
        {
            SqlConnection conexion = DAL.Conexion.getConexion();
            try
            {
                SqlCommand comando = new SqlCommand(@"UPDATE Usuarios
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
                SqlCommand comando = new SqlCommand(@"UPDATE Usuarios
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

        public void inhabilitarUsuario(int idUsuario)
        {
            SqlConnection conexion = DAL.Conexion.getConexion();
            try
            {
                SqlCommand comando = new SqlCommand(@"UPDATE Usuarios
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
                                                            idNumeroTabla,
                                                            login,
                                                            password,
                                                            fallos,
                                                            idEstado
                                                       FROM Usuarios
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

        public Model.Usuarios llenarUsuario(DataRow dr)
        {
            Model.Usuarios usr = new FrbaCommerce.Model.Usuarios((int)dr[0],(int)dr[1],(int)dr[2],(String)dr[3],(String)dr[4],(int)dr[5],(int) dr[6]);
            return usr;
        }
    }
}
