using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Model
{
    class Ofertas
    {
        public int IdOferta { get; set; }
        public int IdPublicacion { get; set; }
        public int IdUsrOfertante { get; set; }
        public DateTime Oferta_Fecha { get; set; }
        public Double Oferta_Monto { get; set; }

    }
}
