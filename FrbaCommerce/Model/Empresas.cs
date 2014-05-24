using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Model
{
    class Empresas
    {
        public int IdEmpresa { get; set; }
        public String RazonSocial { get; set; }
        public String Cuit { get; set; }
        public String NombreContacto { get; set; }
        public String Mail { get; set; }
        public String Telefono { get; set; }
        public String Calle { get; set; }
        public int PisoNro { get; set; }
        public Char Depto { get; set; }
        public String Localidad { get; set; }
        public int CodigoPostal { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
