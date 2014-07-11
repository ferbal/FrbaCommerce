using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Model
{
    class Compras
    {
        public int IdCompra { get; set; }
        public int IdUsrComprador { get; set; }
        public int IdPublicacion { get; set; }
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }
    }
}
