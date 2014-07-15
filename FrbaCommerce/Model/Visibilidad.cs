using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Model
{
    public class Visibilidad
    {
        public int IdVisibilidad { get; set; }
        public int Codigo { get; set; }
        public String Descripcion { get; set; }
        public int Duracion { get; set; }
        public Double PrecioPorPublicar { get; set; }
        public Double PorcentajeVenta { get; set; }
        public int IdEstado { get; set; }

        public enum Estados
        {
            Habilitado = 1,
            Deshabilitado = 2
        }
    }
}
