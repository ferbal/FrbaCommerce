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
        public int idNumero { get; set; }
        public String login { get; set; }
        public String password { get; set; }
        public int fallos { get; set; }
        public int idEstado { get; set; }

        public void AltaUsuarios(int tabla, int numero, String login)
        {
            this.idTipoPersona = tabla;
            this.idNumero = numero;
            this.login = login;
            this.idEstado = 1;
        }

    }
}
