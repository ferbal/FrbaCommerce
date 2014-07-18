using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.View.Comprar_Ofertar
{
    public partial class CompraOferta : Form
    {
        private Form vtnAnterior = null;
        private int idUsuario = -1;
        private int idPublicacion = -1;

        public CompraOferta()
        {
            InitializeComponent();
        }

        private void btnOfertar_Click(object sender, EventArgs e)
        {
            try
            {
                Double precio;
                if (Double.TryParse(mtxtPrecioOferta.Text, out precio))
                {
                    Controller.Ofertas.GenerarOferta(this.idUsuario, this.idPublicacion, DateTime.Now, precio);
                    this.Dispose();
                }
                else
                {
                    epPrecioOferta.SetError(mtxtPrecioOferta, "El precio ingresado no es valido.");
                }
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }

        private void CompraOferta_Load(object sender, EventArgs e)
        {
            try
            {
                CargarCMB();
                CargarDatosPublicacion();
                InhabilitarControles();
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }

        public void CargarValoresVentana(Form vtn, int usr,int publicacion)
        {
            this.vtnAnterior = vtn;
            this.idUsuario = usr;
            this.idPublicacion = publicacion;
        }

        public void CargarDatosPublicacion()
        {            
   
            Model.Publicaciones p = Controller.Publicaciones.LoadById(this.idPublicacion);
            cmbRubros.SelectedValue = p.IdRubro;
            cmbTiposPublicaciones.SelectedValue = p.IdTipoPublicacion;
            cmbTipoVisibilidad.SelectedValue = p.IdVisibilidad;
            chbPreguntas.Checked = p.PermiteRealizarPreguntas;
            mtxtCodPubli.Text = p.CodPublicacion.ToString();
            rtxtDescripcion.Text = p.Descripcion;
            mtxtFechaFin.Text = p.FechaFin.ToString();
            mtxtFechaInicio.Text = p.FechaInicio.ToString();
            mtxtPrecio.Text = p.Precio.ToString();
            mtxtStock.Text = p.Stock.ToString();

        }

        public void InhabilitarControles()
        {
            cmbRubros.Enabled = false;
            cmbTiposPublicaciones.Enabled = false;
            cmbTipoVisibilidad.Enabled = false;
            rtxtDescripcion.Enabled = false;
            mtxtCodPubli.Enabled = false;
            mtxtFechaFin.Enabled = false;
            mtxtFechaInicio.Enabled = false;
            mtxtPrecio.Enabled = false;
            mtxtStock.Enabled = false;
            chbPreguntas.Enabled = false;

            if (Convert.ToInt32(cmbTiposPublicaciones.SelectedValue) == (int)Model.TiposPublicaciones.Tipos.Compra_Inmediata)
            {
                btnComprar.Visible = true;
                lblCantidad.Visible = true;
                mtxtCantidad.Visible = true;

                btnOfertar.Visible = false;
                lblPrecioOferta.Visible = false;
                mtxtPrecioOferta.Visible = false;
            }
            else if (Convert.ToInt32(cmbTiposPublicaciones.SelectedValue) == (int)Model.TiposPublicaciones.Tipos.Subasta)   
            {
                btnComprar.Visible = false;
                lblCantidad.Visible = false;
                mtxtCantidad.Visible = false;

                btnOfertar.Visible = true;
                lblPrecioOferta.Visible = true;
                mtxtPrecioOferta.Visible = true;
            }


        }

        public void CargarCMB()
        {
            cmbRubros.DataSource = Controller.Rubros.obtenerRubros();
            cmbRubros.DisplayMember = "Descripcion";
            cmbRubros.ValueMember = "IdRubro";

            cmbTiposPublicaciones.DataSource = Controller.TiposPublicaciones.obtenerTiposPublicaciones();
            cmbTiposPublicaciones.DisplayMember = "Descripcion";
            cmbTiposPublicaciones.ValueMember = "IdTipoPublicacion";
            
            //Completar la carga del cmbVisibilidades!!!
            //cmbTipoVisibilidad.DataSource = Controller.
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

        private void btnComprar_Click(object sender, EventArgs e)
        {
            try
            {
                int cant;
                if (Int32.TryParse(mtxtCantidad.Text.ToString(), out cant))
                {
                    if (Convert.ToInt32(mtxtStock.Text) >= cant)
                    {
                        Controller.Compras.GenerarCompra(this.idUsuario, this.idPublicacion, DateTime.Now, cant);
                        this.Dispose();
                    }
                    else
                    {
                        epCantidad.SetError(mtxtCantidad, "La Cantidad es superior al Stock Disponible.");
                    }
                }
                else
                {
                    epCantidad.SetError(mtxtCantidad, "La Cantidad no es Correcta.");
                }
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }

        private void mtxtCantidad_TextChanged(object sender, EventArgs e)
        {
            try
            {
                epCantidad.Clear();
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }


        
    }
}
