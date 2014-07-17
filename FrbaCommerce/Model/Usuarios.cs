using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Model
{
    class Usuarios
    {
        public int idUsuario { get; set; }
        public int idTipoPersona { get; set; }
        //public int idNumero { get; set; }
        public String login { get; set; }
        public String password { get; set; }
        public int fallos { get; set; }
        public int idEstado { get; set; }

        public Usuarios(int idUsuario,int idTipoPersona, String login,String pass,int fallos,int idEstado)
        {
            this.idUsuario = idUsuario;
            this.idTipoPersona = idTipoPersona;
            //this.idNumero = idNumero;
            this.login = login;
            this.password = pass;
            this.idEstado = idEstado;
            this.fallos = fallos;
        }

        public Usuarios()
        { 
        }

        public enum Estados
        {
            Habilitado = 1,
            Inhabilitado = 2,
            BloqueadoCompraOferta = 4
        }

    }
}
