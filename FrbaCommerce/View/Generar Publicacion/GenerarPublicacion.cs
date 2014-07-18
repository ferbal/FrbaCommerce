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
        private Model.Publicaciones publicacion = null;

        public GenerarPublicacion()
        {                        
            InitializeComponent();
        }

        private void CargarClbRubros()
        {
            DataTable dt = Controller.Rubros.obtenerRubros();
            DataRow dr = dt.NewRow();
            dr["IdRubro"] = -1;
            dr["Descripcion"] = "Seleccionar";
            dt.Rows.InsertAt(dr, 0);
            cmbRubros.DataSource = dt;
            cmbRubros.DisplayMember = "Descripcion";
            cmbRubros.ValueMember = "IdRubro";            
        }
        private void CargarCmbTipoPublicacion()
        {
            DataTable dt = Controller.TiposPublicaciones.obtenerTiposPublicaciones();
            DataRow dr = dt.NewRow();

            dr["IdTipoPublicacion"] = -1;
            dr["Descripcion"] = "Seleccionar";
            dt.Rows.InsertAt(dr, 0);        

            cmbTiposPublicaciones.DisplayMember = "Descripcion";
            cmbTiposPublicaciones.ValueMember = "IdTipoPublicacion";
            cmbTiposPublicaciones.DataSource = dt;
        }

        private void CargarCmbVisibilidad()
        {
            cmbTipoVisibilidad.DisplayMember = "Descripcion";
            cmbTipoVisibilidad.ValueMember = "IdVisibilidad";
            
            DataTable dt = Controller.Visibilidades.ListarVisibilidadesHabilitadas();
            DataRow dr = dt.NewRow();
            
            dr["IdVisibilidad"] = -1;
            dr["Descripcion"] = "Seleccionar";
            dt.Rows.InsertAt(dr,0);           

            cmbTipoVisibilidad.DataSource = dt;
        }

        public void cargarDatos(Form anterior, int usr)
        {
            this.vtnAnterior = anterior;
            this.idUsuario = usr;
        }

        public void cargarPublicacionModificar(Model.Publicaciones publi)
        {
            this.publicacion = publi;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            try
            {
                this.Dispose();
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validarDatos())
                {
                    int stock = Convert.ToInt32(mtxtStock.Text);
                    Double precio = Convert.ToDouble(mtxtPrecio.Text);
                    int cod = Convert.ToInt32(mtxtCodPubli.Text);
                    int idRubro = (int)cmbRubros.SelectedValue;//clbRubros.SelectedValue;
                    

                    if (publicacion == null)
                    {
                        Controller.Publicaciones.IngresarPublicacionNueva((int)cmbTiposPublicaciones.SelectedValue, cod, (int)cmbRubros.SelectedValue, 1, Convert.ToDateTime(mtxtFechaInicio.Text), Convert.ToDateTime(mtxtFechaFin.Text), rtxtDescripcion.Text, stock, precio, idUsuario, chbPreguntas.Checked);
                    }
                    else
                    {
                        Controller.Publicaciones.ActualizarPublicacion(publicacion.IdPublicacion, (int)cmbTiposPublicaciones.SelectedValue, cod, (int)cmbRubros.SelectedValue, 1, Convert.ToDateTime(mtxtFechaInicio.Text), Convert.ToDateTime(mtxtFechaFin.Text), rtxtDescripcion.Text, stock, precio, idUsuario, chbPreguntas.Checked);
                    }
                    
                    this.Dispose();
                }
                
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }

        private Boolean validarDatos()
        {
            Boolean result = true;
            Double precio;

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
            else if (!Double.TryParse(mtxtPrecio.Text, out precio))
            {
                epPrecio.SetError(mtxtPrecio,"El PRECIO debe tener el formato 000,00");
                result = false;
            }

            if (Convert.ToInt32(cmbRubros.SelectedValue) == -1)
            {
                epRubros.SetError(cmbRubros, "El RUBRO es un campo requerido.");
                result = false;
            }            
            
            if (String.IsNullOrEmpty(mtxtStock.Text))
            {
                epStock.SetError(mtxtStock, "El STOCK es un campo requerido.");
                result = false;
            }
            if (publicacion != null)
            {
                if (publicacion.IdTipoPublicacion == (int)Model.TiposPublicaciones.Tipos.Compra_Inmediata
                    && publicacion.IdEstado == (int)Model.Publicaciones.Estados.Activa)
                {
                    if (Convert.ToInt32(mtxtStock.Text) < publicacion.Stock)
                    {
                        epStock.SetError(mtxtStock,"Al modificar un Stock este solo puede ser mayor que el anterior.");
                        result = false;
                    }
                }
            }

            return result;
        }
            
        private void GenerarPublicacion_Load(object sender, EventArgs e)
        {
            try
            {
                CargarCmbTipoPublicacion();
                CargarClbRubros();
                CargarCmbVisibilidad();
                //Seteo los datos del Calendario con la fecha del sistema
                mcFecha.Visible = false;
                mcFecha.SelectionRange.Start = Controller.Validaciones.ObtenerFechaSistema();
                mcFecha.SelectionRange.End = Controller.Validaciones.ObtenerFechaSistema();
                mcFecha.MaxDate = Controller.Validaciones.ObtenerFechaSistema();
                mcFecha.TodayDate = Controller.Validaciones.ObtenerFechaSistema();

                mtxtFechaInicio.Enabled = false;
                mtxtFechaFin.Enabled = false;
                mtxtCodPubli.Enabled = false;

                if (this.publicacion == null)
                {
                    mtxtCodPubli.Text = (Controller.Publicaciones.UltimoCodigo() + 1).ToString();
                }
                else
                {
                    mtxtCodPubli.Text = this.publicacion.CodPublicacion.ToString();
                    mtxtFechaFin.Text = this.publicacion.FechaFin.ToString();
                    mtxtFechaInicio.Text = this.publicacion.FechaInicio.ToString();
                    mtxtPrecio.Text = this.publicacion.Precio.ToString();
                    mtxtStock.Text = this.publicacion.Stock.ToString();
                    rtxtDescripcion.Text = this.publicacion.Descripcion.ToString();
                    chbPreguntas.Checked = Convert.ToBoolean(this.publicacion.PermiteRealizarPreguntas);
                    cmbTiposPublicaciones.SelectedValue = this.publicacion.IdTipoPublicacion;
                    cmbRubros.SelectedValue = this.publicacion.IdRubro;
                    cmbTipoVisibilidad.SelectedValue = this.publicacion.IdVisibilidad;

                    if (publicacion.IdTipoPublicacion == (int)Model.TiposPublicaciones.Tipos.Compra_Inmediata
                        && publicacion.IdEstado == (int)Model.Publicaciones.Estados.Activa)
                    {
                        mtxtFechaInicio.Enabled = false;
                        btnSeleccionarFecha.Enabled = false;
                        mtxtPrecio.Enabled = false;
                        chbPreguntas.Enabled = false;
                        cmbRubros.Enabled = false;
                        cmbTiposPublicaciones.Enabled = false;
                        cmbTipoVisibilidad.Enabled = false;
                    }

                }
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }

        }

        private void mtxtFechaInicio_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if ((int)cmbTipoVisibilidad.SelectedValue != -1)
                {
                    ActualizarFechaFin();
                }
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }

        private void ActualizarFechaFin()
        {
            if (mtxtFechaInicio.Text.Length == 10)
                mtxtFechaFin.Text = Controller.Publicaciones.calcularFechaFin((int)cmbTipoVisibilidad.SelectedValue, mtxtFechaInicio.Text).ToString();
        }

        private void btnSeleccionarFecha_Click(object sender, EventArgs e)
        {
            try
            {

                mcFecha.Visible = true;
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }

        private void mcFecha_DateSelected(object sender, DateRangeEventArgs e)
        {
            try
            {
                mtxtFechaInicio.Text = mcFecha.SelectionEnd.ToShortDateString();
                mcFecha.Visible = false;
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        
        }

        private void cmbTipoVisibilidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(mtxtFechaInicio.Text))
                    ActualizarFechaFin();
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }

        private void mtxtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }     

    }
}
