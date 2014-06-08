using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Model
{
    class Funcionalidades
    {
        public int IdFuncionalidad { get; set; }
        public String Descripcion { get; set; }

        public enum EnumFunc
        {
            Login_Seguridad = 1,
            ABM_Rol = 2,
	        Registro_Usuario = 3,
            ABM_Cliente = 4,
            ABM_Empresa = 5,
	        ABM_Rubro = 6,
	        ABM_Visibilidad = 7,
            Generar_Publicacion = 8,
            Editar_Publicacion = 9,
	        Gestion_Preguntas = 10,
	        Comprar_Ofertar = 11,
            Historial_Cliente = 12,
	        Calificar_Vendedor = 13,
            Facturar_Publicacion = 14,
            Listado_Estadistico = 15	
        }

    }
}
