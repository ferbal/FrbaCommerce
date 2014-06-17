using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Model
{
    public class Publicaciones
    {
        public int IdPublicacion { get; set; }
        public int CodPublicacion { get; set; }
        public int IdTipoPublicacion { get; set; }
        public int IdVisibilidad { get; set; }        
        public int IdEstado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public String Descripcion { get; set; }
        public int Stock { get; set; }
        public Double Precio { get; set; }
        public int IdUsuario { get; set; }
        public int IdRubro { get; set; }        
        public Boolean PermiteRealizarPreguntas { get; set; }

        public enum Estados
        {
            Borrador = 4,
            Activa = 5,
            Pausada = 6,
            Finalizada = 7
        }
    }
}
