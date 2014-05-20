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
            SqlCommand commando = new SqlCommand("INSERT INTO Usuarios (idTabla,idNumeroTabla,login,password,fallos,idEstado)"+
                                                 "VALUES (@idTabla,@idNumero,@login,@password,0,@idEstado)",conexion);
            commando.Parameters.Add("@idTabla",usuario.idTabla);
            commando.Parameters.Add("@idNumero",usuario.idNumero);
            commando.Parameters.Add("@login",usuario.login);
            commando.Parameters.Add("@password", "HOLA");
            commando.Parameters.Add("@idEstado",usuario.idEstado);
            
            int cant = commando.ExecuteNonQuery();          
        }
    }
}
