using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.View.ListadoEstadistico
{
    public partial class ListadoEstadistico : Form
    {
        private Form vtnAnterior;

        public ListadoEstadistico()
        {
            InitializeComponent();
        }

        public void ventana_anterior(Form ant)
        {
            vtnAnterior = ant;

        }

        private void llenarDataGrid()
        {
            DAL.ListadoEstadisticoDAL listado = new FrbaCommerce.DAL.ListadoEstadisticoDAL();

            DataTable dt = listado.GenerarListado(cmbAnio.Text,Convert.ToInt32(cmbTrimestre.Text),cmbListado.Text, cmbVisibilidad.Text);
                
            dgvRoles.DataSource = dt;

            dgvRoles.Visible = true;

            if (cmbListado.Text == "VENDEDORES CON MAYOR CANTIDAD DE PRODUCTOS NO VENDIDOS")
                dgvRoles.Columns["VISIBILIDAD"].Visible = false;

            if (cmbListado.Text == "CLIENTES CON MAYOR CANTIDAD DE PUBLICACIONES SIN CALIFICAR")
                dgvRoles.Columns["IdUsrComprador"].Visible = false;
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnLimpiar.Enabled = true;
            btnGenerar.Enabled = true;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            vtnAnterior.Visible = true;
            this.Dispose();
        }

        private void ListadoEstadistico_Load(object sender, EventArgs e)
        {
            cmbVisibilidad.Visible = false;
            lblVisilidad.Visible = false;

            DAL.ListadoEstadisticoDAL anioDAL = new FrbaCommerce.DAL.ListadoEstadisticoDAL();

            cmbAnio.DisplayMember = "AÑO";
            cmbAnio.ValueMember = "AÑO";
            cmbAnio.DataSource = anioDAL.obtenerAnios();

            DAL.ListadoEstadisticoDAL visibilidadDAL = new FrbaCommerce.DAL.ListadoEstadisticoDAL();

            cmbVisibilidad.DisplayMember = "Descripcion";
            cmbVisibilidad.ValueMember = "Descripcion";
            cmbVisibilidad.DataSource = visibilidadDAL.obtenerVisibilidades();

        }

        private void btnGenerar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (validarDatos())
                {
                    llenarDataGrid();
                }
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }

        private void cmbListado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbListado.Text == "VENDEDORES CON MAYOR CANTIDAD DE PRODUCTOS NO VENDIDOS")
                {
                    cmbVisibilidad.Visible = true;
                    lblVisilidad.Visible = true;

                    epVisibilidad.Dispose();
                    if (String.IsNullOrEmpty(cmbVisibilidad.Text))
                    {
                        epVisibilidad.SetError(lblVisilidad, "Para este listado debe completarse la Visibilidad.");
                    }

                }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            cmbAnio.SelectedIndex = 0;
            cmbListado.SelectedIndex = -1;
            cmbTrimestre.SelectedIndex = -1;
            cmbVisibilidad.SelectedIndex = 0;
            dgvRoles.Visible = false;
        }

        private Boolean validarDatos()
        {
            Boolean estado = true;

            epAño.Dispose();
            if (String.IsNullOrEmpty(cmbAnio.Text))
            {
                epAño.SetError(label4, "Se debe elegir un año.");
                estado = false;
            }

            epTrimestre.Dispose();
            if (String.IsNullOrEmpty(cmbTrimestre.Text))
            {
                epTrimestre.SetError(label1, "Se debe elegir un Trimestre.");
                estado = false;
            }

            epListado.Dispose();
            if (String.IsNullOrEmpty(cmbListado.Text))
            {
                epListado.SetError(label2, "Se debe elegir un listado.");
                estado = false;
            }

            return estado;
        }


    }
}
