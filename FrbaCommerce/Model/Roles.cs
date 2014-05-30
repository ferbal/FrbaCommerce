using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Model
{
    class Roles
    {
        public int IdRole { get; set; }
        public String Nombre { get; set; }
        public int IdEstado { get; set; }

        public Roles()
        {
        }

        public enum Estados
        {
            Habilitado = 1,
            Inhabilitado = 2
        }
    }

}
