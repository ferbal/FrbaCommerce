﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Model
{
    class TiposPersonas
    {
        public int IdTipoPersona { get; set; }
        public String Descripcion { get; set; }

        public enum TiposPersonasEnum
        {
            Cliente = 1,
            Empresa = 2
        }
    }
}
