using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Model
{
    class Clientes
    {
        public int IdCliente { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public long NroDocumento { get; set; }
        public long Cuil { get; set; }
        public int IdTipoDocumento { get; set; }
        public String mail { get; set; }
        public String telefono { get; set; }
        public String Calle { get; set; }
        public int PisoNro { get; set; }
        public Char Depto { get; set; }
        public String Localidad { get; set; }
        public int CodigoPostal { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
