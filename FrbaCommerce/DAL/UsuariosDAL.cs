using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace FrbaCommerce.DAL
{
    class UsuariosDAL
    {
        public void InsertarUsuario(Model.Usuarios usuario)
        {
            
            SqlConnection conexion = DAL.Conexion.getConexion();
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
                                                            0,
                                                            @idEstado
                                                        )",conexion);

            commando.Parameters.Add("@idTipoPersona",usuario.idTipoPersona);
            commando.Parameters.Add("@idNumero",usuario.idNumero);
            commando.Parameters.Add("@login",usuario.login);
            commando.Parameters.Add("@password", usuario.password);
            commando.Parameters.Add("@idEstado",usuario.idEstado);
            
            int cant = commando.ExecuteNonQuery();          
        }
    }
}
