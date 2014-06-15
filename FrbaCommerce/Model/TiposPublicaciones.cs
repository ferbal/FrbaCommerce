using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Model
{
    class TiposPublicaciones
    {
        public int IdTipoPublicacion { get; set; }
        public String Descripcion { get; set; }

        public enum Tipos
        {
            Compra_Inmediata = 1,
            Subasta = 2
        }
    }

    
}
