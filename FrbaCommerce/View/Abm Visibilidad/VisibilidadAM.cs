using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.View.Abm_Visibilidad
{
    public partial class VisibilidadAM : Form
    {

        private Form vtnAnterior;
        private int idUsuario = -1;
        private int idVisibilidad = -1;

        public VisibilidadAM()
        {
            InitializeComponent();
        }

        public void CargarDatos(Form vtn, int usr,String titulo)
        {
            this.vtnAnterior = vtn;
            this.idUsuario = usr;
            lblTitulo.Text = titulo;
            this.Text= titulo;
        }

        public void CargarVisibilidadAModificar(Model.Visibilidad v)
        {
            this.idVisibilidad = v.IdVisibilidad;

            txtCodigo.Text = v.Codigo.ToString();
            txtDescripcion.Text = v.Descripcion;
            txtDuracion.Text = v.Duracion.ToString();
            txtPrecioXPublicar.Text = v.PrecioPorPublicar.ToString();
            txtPrecioXVenta.Text = (v.PorcentajeVenta * 100).ToString();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            String msg = String.Empty;
            if (ValidarDatos())
            {
                if (this.idVisibilidad == -1)
                {
                    Controller.Visibilidades.InsertarVisibilidad(Convert.ToInt32(txtCodigo.Text), txtDescripcion.Text, Convert.ToInt32(txtDuracion.Text), Convert.ToDouble(txtPrecioXPublicar.Text), Convert.ToDouble(txtPrecioXVenta.Text));
                    msg = "La Visibilidad se genero correctamente.";
                }
                else
                {
                    Controller.Visibilidades.ActualizarVisibilidad(this.idVisibilidad, Convert.ToInt32(txtCodigo.Text), txtDescripcion.Text, Convert.ToInt32(txtDuracion.Text), Convert.ToDouble(txtPrecioXPublicar.Text), Convert.ToDouble(txtPrecioXVenta.Text));
                    msg = "La visibilidad se actualizo correctamente.";
                }

                View.Aviso vtnAviso = new Aviso(msg);
                vtnAviso.Visible = true;                
            }
        }

        private Boolean ValidarDatos()
        {
            Boolean result = true;

            if (String.IsNullOrEmpty(txtCodigo.Text))
            {
                epCodigo.SetError(txtCodigo, "El Codigo es un campo requerido.");
                result = false;
            }
            else
            {
                int cod;
                if(!Int32.TryParse(txtCodigo.Text,out cod)){
                    result = false;
                }
            }

            if (String.IsNullOrEmpty(txtDescripcion.Text))
            {
                epCodigo.SetError(txtDescripcion, "La Descripcion es un campo requerido.");
                result = false;
            }

            if (String.IsNullOrEmpty(txtDuracion.Text))
            {
                epCodigo.SetError(txtDuracion, "La Duracion es un campo requerido.");
                result = false;
            }
            else
            {
                int num;
                if (!Int32.TryParse(txtDuracion.Text, out num))
                {
                    result = false;
                }
            }

            if (String.IsNullOrEmpty(txtPrecioXVenta.Text))
            {
                epCodigo.SetError(txtPrecioXVenta, "El Porcentaje Por Venta es un campo requerido.");
                result = false;
            }
            else
            {
                int num;
                if (!Int32.TryParse(txtPrecioXVenta.Text, out num))
                {
                    result = false;
                    epCodigo.SetError(txtPrecioXVenta, "El Porcentaje Por Venta debe ser un numero entero entre 0 y 99.");
                }
                else
                {
                    if (num < 0 || num >= 100)
                    {
                        result = false;
                        epCodigo.SetError(txtPrecioXVenta, "El Porcentaje Por Venta debe ser un numero entero entre 0 y 99.");
                    }
                }
            }

            if (String.IsNullOrEmpty(txtPrecioXPublicar.Text))
            {
                epCodigo.SetError(txtPrecioXPublicar, "El Precio Por Publicar es un campo requerido.");
                result = false;
            }
            else
            {
                Double num;
                if (!Double.TryParse(txtPrecioXPublicar.Text, out num))
                {
                    result = false;
                }
            }
            return result;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = String.Empty;
            txtDescripcion.Text = String.Empty;
            txtDuracion.Text = String.Empty;
            txtPrecioXPublicar.Text = String.Empty;
            txtPrecioXVenta.Text = String.Empty;
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            epCodigo.Clear();
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            epDescripcion.Clear();
        }

        private void txtDuracion_TextChanged(object sender, EventArgs e)
        {
            epDuracion.Clear();
        }

        private void txtPrecioXPublicar_TextChanged(object sender, EventArgs e)
        {
            epPrecioPublicar.Clear();
        }

        private void txtPrecioXVenta_TextChanged(object sender, EventArgs e)
        {
            epPorcentajeVenta.Clear();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void VisibilidadAM_Load(object sender, EventArgs e)
        {

        }
    }
}
