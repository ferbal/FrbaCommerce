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

            DataTable dt = listado.GenerarListado(cmbAnio.Text,Convert.ToInt32(cmbTrimestre.Text),cmbListado.Text);
                
            dgvRoles.DataSource = dt;

            //dgvRoles.Columns["IdEstado"].Visible = false;
            //dgvRoles.Columns["IdCliente"].Visible = false;
            
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
            DAL.ListadoEstadisticoDAL anioDAL = new FrbaCommerce.DAL.ListadoEstadisticoDAL();

            cmbAnio.DisplayMember = "AÑO";
            cmbAnio.ValueMember = "AÑO";
            cmbAnio.DataSource = anioDAL.obtenerAnios();

        }

        private void btnGenerar_Click_1(object sender, EventArgs e)
        {
            try
            {
                llenarDataGrid();
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }

    }
}
