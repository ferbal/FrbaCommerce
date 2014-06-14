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
        public int IdUsuario { get; set; }
        public int IdEstado { get; set; }

        public enum Estados
        {
            Habilitado = 1,
            Inhabilitado = 2
        }

        public Empresas(String razonSocial, String cuit, String nombreContacto, String mail, String telefono, String calle, int pisoNro, Char depto, String localidad, int codPost, DateTime fecha,int usr,int estado)
        {
            this.IdUsuario = usr;
            this.RazonSocial = razonSocial;
            this.Cuit = cuit;
            this.NombreContacto = nombreContacto;
            this.Mail = mail;
            this.Telefono = telefono;
            this.Calle = calle;
            this.PisoNro = pisoNro;
            this.Depto = depto;
            this.Localidad = localidad;
            this.CodigoPostal = codPost;
            this.FechaCreacion = fecha;
            this.IdEstado = estado;
        }

        public Empresas(int IdEmpresa,String razonSocial, String cuit, String nombreContacto, String mail, String telefono, String calle, int pisoNro, Char depto, String localidad, int codPost, DateTime fecha, int estado)
        {
            this.IdEmpresa = IdEmpresa;
            this.RazonSocial = razonSocial;
            this.Cuit = cuit;
            this.NombreContacto = nombreContacto;
            this.Mail = mail;
            this.Telefono = telefono;
            this.Calle = calle;
            this.PisoNro = pisoNro;
            this.Depto = depto;
            this.Localidad = localidad;
            this.CodigoPostal = codPost;
            this.FechaCreacion = fecha;
            this.IdEstado = estado;
        }

    }   
}
