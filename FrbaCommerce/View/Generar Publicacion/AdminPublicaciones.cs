﻿using System;
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

        public AdminPublicaciones()
        {
            InitializeComponent();
        }

        private void AdminPublicaciones_Load(object sender, EventArgs e)
        {
            RefreshControles();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            View.Generar_Publicacion.GenerarPublicacion vtnGenerarPubli = new GenerarPublicacion();
            vtnGenerarPubli.cargarDatos(this,7);
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

            dgvPublicaciones.DataSource = Controller.Publicaciones.ListarPublicaciones(codigo,descripcion,usrVend,tipoPubli,estado);
            dgvPublicaciones.Columns["IdPublicacion"].Visible = false;
            dgvPublicaciones.Columns["IdEstado"].Visible = false;
            dgvPublicaciones.Columns["IdUsuario"].Visible = false;
            dgvPublicaciones.Columns["IdRubro"].Visible = false;
            dgvPublicaciones.Columns["IdVisibilidad"].Visible = false;
            dgvPublicaciones.Columns["IdTipoPublicacion"].Visible = false;
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
                
                //if (this.idUsuario == publicacion.IdUsuario)
                //{
                    View.Generar_Publicacion.GenerarPublicacion vtnModif = new GenerarPublicacion();
                    vtnModif.Text = "Modificar Publicacion";
                    vtnModif.cargarPublicacionModificar(publicacion);
                    vtnModif.cargarDatos(this, publicacion.IdUsuario);
                    vtnModif.Visible = true;
                    this.Visible = false;
                /*
                }
                else
                {
                    View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm("El Usuario no tiene permiso para modificar la publicacion.");
                    vtnError.Visible = true; 
                }
                 */
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
                Controller.Publicaciones.ActualizarEstado((int)Model.Publicaciones.Estados.Finalizada, idPublicacion);
            }

            RefreshControles();
        }

        private void RefreshControles()
        {
            this.cargarDgvPublicaciones();
            this.cargarCmbEstados();
            this.cargarCmbTipoPublicacion();
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
            
            dr["IdEstado"] = -1;
            dr["Descripcion"] = "Todos";
            dt.Rows.InsertAt(dr,0);
            
            cmbEstado.DataSource = dt;            
            cmbEstado.DisplayMember = "Descripcion";
            cmbEstado.ValueMember = "IdEstado";
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cargarDgvPublicaciones();
        }

        public void CargarDatos(Form anterior, int usuario)
        {
            this.vtnAnterior = anterior;
            this.idUsuario = usuario;
        }
    }
}