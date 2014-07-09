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
    public partial class AdminCompraOferta : Form
    {
        private int paginaActual = 0;
        private int ultimaPagina = -1;
        private int idUsuario = -1;
        private Form vtnAnterior = null;

        public AdminCompraOferta()
        {
            InitializeComponent();
        }

        private void AdminCompraOferta_Load(object sender, EventArgs e)
        {
            
            this.cargarCMB();            
            this.cargarDGV();
            this.CargarPaginas();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if ((this.paginaActual + 1) <= this.ultimaPagina)
                this.paginaActual = paginaActual + 1;
            
            this.cargarDGV();
        }

        private void cargarDGV()
        {            
            dgvPublicaciones.DataSource = Controller.Publicaciones.CargarParaCompra(this.paginaActual,Convert.ToInt32(cmbRubro.SelectedValue),txtDescripcion.Text);
            dgvPublicaciones.Columns["IdPublicacion"].Visible = false;
            ArmarEtiquetaPaginas();
        }

        private void cargarCMB()
        {
            DataTable dt = Controller.Rubros.obtenerRubros();
            DataRow dr = dt.NewRow();

            dr["IdRubro"] = -1;
            dr["Descripcion"] = "Todos";
            dt.Rows.InsertAt(dr, 0);

            cmbRubro.DataSource = dt;
            cmbRubro.DisplayMember = "Descripcion";
            cmbRubro.ValueMember = "IdRubro";            
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if ((this.paginaActual - 1) >= 0)
                this.paginaActual = this.paginaActual - 1;

            this.cargarDGV();
        }

        private void btnUltima_Click(object sender, EventArgs e)
        {
            this.paginaActual = this.ultimaPagina;
            cargarDGV();
        }

        private void btnPrimera_Click(object sender, EventArgs e)
        {
            this.paginaActual = 0;
            cargarDGV();
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            cargarCMB();
            txtDescripcion.Text = String.Empty;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cargarDGV();
            CargarPaginas();
        }

        private void CargarPaginas()
        {
            this.ultimaPagina = Controller.Publicaciones.CantidadPublicacionesParaComprarOFertar(Convert.ToInt32(cmbRubro.SelectedValue),txtDescripcion.Text);
            this.ultimaPagina = this.ultimaPagina / 10;            
            this.paginaActual = 0;
            ArmarEtiquetaPaginas();
        }

        private void ArmarEtiquetaPaginas()
        {
            lblPaginas.Text = "Pagina " + (paginaActual + 1).ToString() + " de " + (ultimaPagina+1).ToString();
        }

        private void btnComprarOfertar_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dgvPublicaciones.SelectedRows;
            if (rows.Count == 1)
            {
                View.Comprar_Ofertar.CompraOferta vtnComprarOfertar = new View.Comprar_Ofertar.CompraOferta();
                vtnComprarOfertar.CargarValoresVentana(this, this.idUsuario, Convert.ToInt32(rows[0].Cells["IdPublicacion"].Value));
                vtnComprarOfertar.Visible = true;
                this.Visible = false;
            }            
        }
    }
}
