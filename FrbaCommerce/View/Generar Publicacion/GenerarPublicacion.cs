using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.View.Generar_Publicacion
{
    public partial class GenerarPublicacion : Form
    {
        private Form vtnAnterior = null;
        private int idUsuario = -1;

        public GenerarPublicacion()
        {            
            InitializeComponent();
        }

        private void CargarClbRubros()
        {
            clbRubros.DataSource = Controller.Rubros.obtenerRubros();
            clbRubros.DisplayMember = "Descripcion";
            clbRubros.ValueMember = "IdRubro";
        }
        private void CargarCmbTipoPublicacion()
        {
            cmbTiposPublicaciones.DataSource = Controller.TiposPublicaciones.obtenerTiposPublicaciones();
            cmbTiposPublicaciones.DisplayMember = "Descripcion";
            cmbTiposPublicaciones.ValueMember = "IdTipoPublicacion";
        }

        private void CargarCmbVisibilidad()
        {
            cmbTipoVisibilidad.Items.Add("Test");
        }

        public void cargarDatos(Form anterior, int usr)
        {
            this.vtnAnterior = anterior;
            this.idUsuario = usr;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                Controller.Publicaciones.IngresarPublicacionNueva((int)cmbTiposPublicaciones.SelectedValue, 1, 0.00, Convert.ToDateTime(mtxtFechaInicio.Text), Convert.ToDateTime(mtxtFechaFin.Text),rtxtDescripcion.Text,Convert.ToInt32(mtxtStock.Text),Convert.ToDouble(mtxtPrecio.Text),idUsuario,chbPreguntas.Checked);
            }
        }

        private Boolean validarDatos()
        {
            Boolean result = true;
            if (String.IsNullOrEmpty(rtxtDescripcion.Text))
            {
                epDescripcion.SetError(rtxtDescripcion, "La DESCRIPCION es un campo requerido.");
                result = false;
            }

            if (String.IsNullOrEmpty(mtxtFechaInicio.Text))
            {
                epFechaInicio.SetError(mtxtFechaInicio, "La FECHA DE INICIO es un campo requerido.");
                result = false;
            }

            if (String.IsNullOrEmpty(mtxtPrecio.Text))
            {
                epPrecio.SetError(mtxtPrecio, "El PRECIO es un campo requerido.");
                result = false;
            }

            if (clbRubros.SelectedItems.Count < 0)
            {
                epRubros.SetError(clbRubros, "El RUBRO es un campo requerido.");
                result = false;
            }
            else if (clbRubros.SelectedItems.Count > 1)
            {
                epRubros.SetError(clbRubros, "Solo se debe seleccionar 1 rubro.");
                return false;
            }
            
            if (String.IsNullOrEmpty(mtxtStock.Text))
            {
                epStock.SetError(mtxtStock, "El STOCK es un campo requerido.");
                result = false;
            }

            return result;
        }
            
        private void GenerarPublicacion_Load(object sender, EventArgs e)
        {
            CargarCmbTipoPublicacion();
            CargarClbRubros();
            mtxtFechaFin.Text = DateTime.Now.ToString();
            mtxtFechaFin.Enabled = false;
            mtxtCodPubli.Text = (Controller.Publicaciones.UltimoCodigo() + 1).ToString();
            mtxtCodPubli.Enabled = false;
        }

        private void mtxtFechaInicio_TextChanged(object sender, EventArgs e)
        {
            mtxtFechaFin.Text = "";
            if(mtxtFechaInicio.Text.Length==10)
                mtxtFechaFin.Text = Controller.Publicaciones.calcularFechaFin(1, mtxtFechaInicio.Text).ToString();
        }

    }
}
