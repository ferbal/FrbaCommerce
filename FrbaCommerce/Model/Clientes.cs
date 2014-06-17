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
        public int NroDocumento { get; set; }
        public String Cuil { get; set; }
        public int IdTipoDocumento { get; set; }
        public String mail { get; set; }
        public String telefono { get; set; }
        public String Calle { get; set; }
        public int PisoNro { get; set; }
        public Char Depto { get; set; }
        public String Localidad { get; set; }
        public int CodigoPostal { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int IdUsuario { get; set; }
        public int IdEstado { get; set; }

        public Clientes(String nombre, String apellido, int tipoDoc, int nroDoc, String nroCuil, String mail, DateTime fecha, String telefono, String calle, int pisoNro, Char depto, int codPost, String localidad, int estado)
        {
            //this.IdCliente = idCliente;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.IdTipoDocumento = tipoDoc;
            this.NroDocumento = nroDoc;
            this.Cuil = nroCuil;
            this.mail = mail;
            this.telefono = telefono;
            this.Calle = calle;
            this.PisoNro = pisoNro;
            this.Depto = depto;
            this.CodigoPostal = codPost;
            this.Localidad = localidad;
            this.FechaNacimiento = fecha;
            //this.IdUsuario = usr;
            this.IdEstado = estado;
        }

        public Clientes(int idCliente, String nombre, String apellido, int tipoDoc, int nroDoc, String nroCuil, String mail, DateTime fecha, String telefono, String calle, int pisoNro, Char depto, int codPost, String localidad,int usr, int estado)
        {
            this.IdCliente = idCliente;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.IdTipoDocumento = tipoDoc;
            this.NroDocumento = nroDoc;
            this.Cuil = nroCuil;
            this.mail = mail;
            this.telefono = telefono;
            this.Calle = calle;
            this.PisoNro = pisoNro;
            this.Depto = depto;
            this.CodigoPostal = codPost;
            this.Localidad = localidad;
            this.FechaNacimiento = fecha;
            this.IdUsuario = usr;
            this.IdEstado = estado;
        }

        public Clientes()
        {
        }

        public enum Estados
        {
            Habilitado = 1,
            Inhabilitado = 2
        }
    }
}
