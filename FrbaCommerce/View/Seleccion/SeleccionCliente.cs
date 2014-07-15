using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.View.Seleccion
{
    public partial class SeleccionCliente : Form
    {
        private View.Historial_Cliente.HistorialCliente vtn1;
        private int idVentanaFrom = -1;

        public SeleccionCliente()
        {
            InitializeComponent();
        }

        private void SeleccionCliente_Load(object sender, EventArgs e)
        {
            CargarCMB();
        }

        private void CargarCMB()
        {
            DAL.TiposPersonasDAL tpDAL = new FrbaCommerce.DAL.TiposPersonasDAL();
            
            cmbTipoPersona.DisplayMember = "Descripcion";
            cmbTipoPersona.ValueMember = "IdTipoPersona";
            cmbTipoPersona.DataSource = tpDAL.obtenerTiposPersonas();
        }

        private void cmbTipoPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((int)cmbTipoPersona.SelectedValue == (int)Model.TiposPersonas.TiposPersonasEnum.Cliente)
            {
                txtEmpresa.Enabled = false;
            }
            else
            {
                txtApellido.Enabled = false;
                txtNombre.Enabled = false;
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = String.Empty;
            txtApellido.Text = String.Empty;
            txtEmpresa.Text = String.Empty;
            CargarDGV();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarDGV();
        }

        private void CargarDGV()
        {
            dgvSeleccion.DataSource = Controller.Usuarios.ObtenerListaSeleccionClientes(txtNombre.Text, txtApellido.Text, txtEmpresa.Text);
            dgvSeleccion.Columns["IdUsuario"].Visible = false;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dgvSeleccion.SelectedRows;
            DataGridViewCellCollection cell = rows[0].Cells;
            vtn1.CargarSeleccion(Convert.ToInt32(cell["IdUsuario"].Value), Convert.ToString(cell["Descripcion"].Value));
            
            this.Dispose();
        }

        public void CargarDatosVentana(Form vtn, int id)
        {
            if (id == 1)
                this.vtn1 = (View.Historial_Cliente.HistorialCliente) vtn;
        }
    }
}
