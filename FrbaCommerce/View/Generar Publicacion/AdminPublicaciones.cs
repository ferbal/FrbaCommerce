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
    public partial class AdminPublicaciones : Form
    {
        private Form vtnAnterior = null;
        private int idUsuario = -1;
        private int paginaActual = 0;
        private int ultimaPagina = 0;

        public AdminPublicaciones()
        {
            InitializeComponent();
        }

        private void AdminPublicaciones_Load(object sender, EventArgs e)
        {
            RefreshControles();
<<<<<<< Updated upstream
            /*
            int codigo = -1;
            int tipoPubli = -1;
            int estado = -1;

            String descripcion = txtDescripcion.Text;

            if (!String.IsNullOrEmpty(txtCodigo.Text))
                codigo = Convert.ToInt32(txtCodigo.Text);

            String usrVend = txtVendedor.Text;

            if (cmbTipoPublicacion.SelectedValue != null)
                tipoPubli = (int)cmbTipoPublicacion.SelectedValue;

            if (cmbEstado.SelectedValue != null)
                estado = (int)cmbEstado.SelectedValue;
            this.ultimaPagina = Controller.Publicaciones.CantidadDePublicaciones(this.paginaActual, codigo, descripcion, usrVend, tipoPubli, estado);
            this.ultimaPagina = this.ultimaPagina / 10;
            this.ActualizarEtiquetaPaginas();
             * */
=======
>>>>>>> Stashed changes
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            View.Generar_Publicacion.GenerarPublicacion vtnGenerarPubli = new GenerarPublicacion();
            vtnGenerarPubli.cargarDatos(this,this.idUsuario);
            this.Visible = false;
            vtnGenerarPubli.Visible = true;
        }

        private void cargarDgvPublicaciones()
        {
            int codigo = -1;
            int tipoPubli = -1;
            int estado = -1;

            String descripcion = txtDescripcion.Text;
            
            if (!String.IsNullOrEmpty(txtCodigo.Text))
                codigo = Convert.ToInt32(txtCodigo.Text);

            String usrVend = txtVendedor.Text;

            if (cmbTipoPublicacion.SelectedValue != null)
                tipoPubli = (int) cmbTipoPublicacion.SelectedValue;

            if (cmbEstado.SelectedValue != null)
                estado = (int)cmbEstado.SelectedValue;
            
            //DataTable dt = Controller.Publicaciones.ListarPublicaciones(codigo, descripcion, usrVend, tipoPubli, estado);
            DataTable dtPaginado = Controller.Publicaciones.ListarPublicaciones(this.paginaActual,codigo,descripcion,usrVend,tipoPubli,estado);

            dgvPublicaciones.DataSource = dtPaginado;
            dgvPublicaciones.Columns["IdPublicacion"].Visible = false;
            dgvPublicaciones.Columns["IdEstado"].Visible = false;
            dgvPublicaciones.Columns["IdUsuario"].Visible = false;
            dgvPublicaciones.Columns["IdRubro"].Visible = false;
            dgvPublicaciones.Columns["IdVisibilidad"].Visible = false;
            dgvPublicaciones.Columns["IdTipoPublicacion"].Visible = false;

            ActualizarEtiquetaPaginas();
        }

        private void AdminPublicaciones_VisibleChanged(object sender, EventArgs e)
        {
            cargarDgvPublicaciones();
        }

        private void dgvPublicaciones_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dgvPublicaciones.SelectedRows;
            if (rows.Count == 1)
            {                
                HabilitarAcciones(Convert.ToInt32(rows[0].Cells["IdEstado"].Value));

                btnPreguntar.Enabled = Convert.ToBoolean(rows[0].Cells["PermiteRealizarPreguntas"].Value);               
            }
            else
            {
                InhabilitarAcciones();
            }
        }

        private void InhabilitarAcciones()
        {
            btnModificar.Enabled = false;
            btnActivar.Enabled = false;
            btnPausar.Enabled = false;
            btnFinalizar.Enabled = false;
        }

        private void HabilitarAcciones(int estado)
        {
            InhabilitarAcciones();

            switch (estado)
            {
                case (int)Model.Publicaciones.Estados.Activa:
                    btnModificar.Enabled = true;
                    btnPausar.Enabled = true;
                    btnFinalizar.Enabled = true;
                    break;
                case (int) Model.Publicaciones.Estados.Borrador:
                    btnModificar.Enabled = true;
                    btnActivar.Enabled = true;
                    btnPausar.Enabled = true;
                    btnFinalizar.Enabled = true;
                    break;
                case (int) Model.Publicaciones.Estados.Finalizada:
                    //DEJA TODO EN FALSE                        
                    break;
                case (int) Model.Publicaciones.Estados.Pausada:
                    btnActivar.Enabled = true;
                    btnModificar.Enabled = true;
                    btnFinalizar.Enabled = true;
                    break;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Model.Publicaciones publicacion = new FrbaCommerce.Model.Publicaciones();
            DataGridViewSelectedRowCollection rows = dgvPublicaciones.SelectedRows;
            if (rows.Count == 1)
            {
                DataGridViewCellCollection cells = rows[0].Cells;

                //vtnModif.cargarPublicacionModificar(cells["IdPublicacion"])

                publicacion.IdPublicacion = Convert.ToInt32(cells["IdPublicacion"].Value);
                publicacion.CodPublicacion = Convert.ToInt32(cells["Codigo"].Value);
                publicacion.IdVisibilidad = Convert.ToInt32(cells["IdVisibilidad"].Value);
                publicacion.IdTipoPublicacion = Convert.ToInt32(cells["IdTipoPublicacion"].Value);
                publicacion.IdEstado = Convert.ToInt32(cells["IdEstado"].Value);
                publicacion.FechaInicio = Convert.ToDateTime(cells["Fecha Inicio"].Value);
                publicacion.FechaFin = Convert.ToDateTime(cells["Fecha Fin"].Value);
                publicacion.Descripcion = cells["Descripcion"].Value.ToString();
                publicacion.Stock = Convert.ToInt32(cells["Stock"].Value);
                publicacion.IdUsuario = Convert.ToInt32(cells["IdUsuario"].Value);
                publicacion.Precio = Convert.ToDouble(cells["Precio"].Value);
                publicacion.IdRubro = Convert.ToInt32(cells["IdRubro"].Value);
                publicacion.PermiteRealizarPreguntas = Convert.ToBoolean(cells["PermiteRealizarPreguntas"].Value);
                
                if (this.idUsuario == publicacion.IdUsuario)
                {
                    View.Generar_Publicacion.GenerarPublicacion vtnModif = new GenerarPublicacion();
                    vtnModif.Text = "Modificar Publicacion";
                    vtnModif.cargarPublicacionModificar(publicacion);
                    vtnModif.cargarDatos(this, publicacion.IdUsuario);
                    vtnModif.Visible = true;
                    this.Visible = false;
                
                }
                else
                {
                    View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm("El Usuario no tiene permiso para modificar la publicacion. \n\rEl usuario que genero la publicacion es el unico\n\rhabilitado para realizar modificaciones.");
                    vtnError.Visible = true; 
                }
                
            }
            
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dgvRows = dgvPublicaciones.SelectedRows;
            if (dgvRows.Count == 1)
            {
                int idPublicacion = Convert.ToInt32(dgvRows[0].Cells["IdPublicacion"].Value);
                Controller.Publicaciones.ActualizarEstado( (int) Model.Publicaciones.Estados.Activa,idPublicacion);
            }

            RefreshControles();
        }

        private void btnPausar_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dgvRows = dgvPublicaciones.SelectedRows;
            if (dgvRows.Count == 1)
            {
                int idPublicacion = Convert.ToInt32(dgvRows[0].Cells["IdPublicacion"].Value);
                Controller.Publicaciones.ActualizarEstado((int)Model.Publicaciones.Estados.Pausada, idPublicacion);
            }

            RefreshControles();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection dgvRows = dgvPublicaciones.SelectedRows;
            if (dgvRows.Count == 1)
            {
                int idPublicacion = Convert.ToInt32(dgvRows[0].Cells["IdPublicacion"].Value);

                if (Convert.ToInt32(dgvRows[0].Cells["IdTipoPublicacion"].Value) == (int)Model.TiposPublicaciones.Tipos.Subasta)
                    Controller.Publicaciones.ConvertirOfertasEnCompras(idPublicacion);
                
                Controller.Publicaciones.ActualizarEstado((int)Model.Publicaciones.Estados.Finalizada, idPublicacion);
            }

            RefreshControles();
        }

        private void RefreshControles()
        {
            this.cargarDgvPublicaciones();
            this.cargarCmbEstados();
            this.cargarCmbTipoPublicacion();

            this.ActualizarEtiquetaPaginas();
        }

        private void cargarCmbTipoPublicacion()
        {
            DataTable dt = Controller.TiposPublicaciones.obtenerTiposPublicaciones();
            DataRow dr = dt.NewRow();
            
            dr["IdTipoPublicacion"] = -1;
            dr["Descripcion"] = "Todos";
            dt.Rows.InsertAt(dr,0);

            cmbTipoPublicacion.DataSource = dt;
            cmbTipoPublicacion.ValueMember = "IdTipoPublicacion";
            cmbTipoPublicacion.DisplayMember = "Descripcion";
        }

        private void cargarCmbEstados()
        {
            DataTable dt = Controller.Publicaciones.ObtenerListaEstados();
            DataRow dr = dt.NewRow();
            
            dr["IdEstadoPublicacion"] = -1;
            dr["Descripcion"] = "Todos";
            dt.Rows.InsertAt(dr,0);
            
            cmbEstado.DataSource = dt;            
            cmbEstado.DisplayMember = "Descripcion";
            cmbEstado.ValueMember = "IdEstadoPublicacion";
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                cargarDgvPublicaciones();
                ActualizarEtiquetaPaginas();
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }

        public void CargarDatos(Form anterior, int usuario)
        {
            this.vtnAnterior = anterior;
            this.idUsuario = usuario;
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            try
            {
                if ((this.paginaActual + 1) <= this.ultimaPagina)
                    this.paginaActual = this.paginaActual + 1;

                cargarDgvPublicaciones();
                
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }

        private void ActualizarEtiquetaPaginas()
        {
            int codigo = -1;
            int tipoPubli = -1;
            int estado = -1;

            String descripcion = txtDescripcion.Text;

            if (!String.IsNullOrEmpty(txtCodigo.Text))
                codigo = Convert.ToInt32(txtCodigo.Text);

            String usrVend = txtVendedor.Text;

            if (cmbTipoPublicacion.SelectedValue != null)
                tipoPubli = (int)cmbTipoPublicacion.SelectedValue;

            if (cmbEstado.SelectedValue != null)
                estado = (int)cmbEstado.SelectedValue;

            this.ultimaPagina = Controller.Publicaciones.CantidadDePublicaciones(this.paginaActual, codigo, descripcion, usrVend, tipoPubli, estado);
            this.ultimaPagina = this.ultimaPagina / 10;

            lblPagina.Text = "Pagina " + (this.paginaActual+1).ToString() + " de " + (this.ultimaPagina+1).ToString();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            try
            {

                if ((this.paginaActual - 1) >= 0)
                    this.paginaActual = this.paginaActual - 1;
                cargarDgvPublicaciones();
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }

        private void btnPrimera_Click(object sender, EventArgs e)
        {
            try
            {
                this.paginaActual = 0;
                cargarDgvPublicaciones();
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            try
            {
                this.paginaActual = this.ultimaPagina;
                cargarDgvPublicaciones();
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }

        private void btnPreguntar_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedRowCollection dgvRows = dgvPublicaciones.SelectedRows;

                if (dgvRows.Count == 1)
                {
                    int idPublicacion = Convert.ToInt32(dgvRows[0].Cells["IdPublicacion"].Value);
                    String codPubli = Convert.ToString(dgvRows[0].Cells["Codigo"].Value);
                    String descripcion = Convert.ToString(dgvRows[0].Cells["Descripcion"].Value);

                    View.Gestion_de_Preguntas.GenerarPreguntas vtnPreg = new FrbaCommerce.View.Gestion_de_Preguntas.GenerarPreguntas();
                    vtnPreg.CargarDatos(this, this.idUsuario, idPublicacion, codPubli, descripcion);
                    vtnPreg.Visible = true;
                    this.Visible = false;
                }
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                txtCodigo.Text = String.Empty;
                txtDescripcion.Text = String.Empty;
                txtVendedor.Text = String.Empty;
                cargarCmbEstados();
                cargarCmbTipoPublicacion();
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }

    }
}
