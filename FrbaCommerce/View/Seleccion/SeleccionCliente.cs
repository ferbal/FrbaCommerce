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
        private View.Facturar_Publicaciones.FacturarPublicaciones vtn2;
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
            DataTable dt = tpDAL.obtenerTiposPersonas();
            DataRow dr = dt.NewRow();
            dr["IdTipoPersona"] = -1;
            dr["Descripcion"] = "Todos";
            dt.Rows.InsertAt(dr,0);

            cmbTipoPersona.DisplayMember = "Descripcion";
            cmbTipoPersona.ValueMember = "IdTipoPersona";
            cmbTipoPersona.DataSource = dt;
        }

        private void cmbTipoPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((int)cmbTipoPersona.SelectedValue == (int)Model.TiposPersonas.TiposPersonasEnum.Cliente)
            {
                txtEmpresa.Enabled = false;

                txtApellido.Enabled = true;
                txtNombre.Enabled = true;
            }
            else if ((int)cmbTipoPersona.SelectedValue == (int)Model.TiposPersonas.TiposPersonasEnum.Empresa)
            {
                txtApellido.Enabled = false;
                txtNombre.Enabled = false;

                txtEmpresa.Enabled = true;
            }
            else
            {
                txtApellido.Enabled = false;
                txtNombre.Enabled = false;
                txtEmpresa.Enabled = false;
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
            try
            {
                CargarDGV();
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }

        private void CargarDGV()
        {
            dgvSeleccion.DataSource = Controller.Usuarios.ObtenerListaSeleccionClientes(txtNombre.Text, txtApellido.Text, txtEmpresa.Text, (int)cmbTipoPersona.SelectedValue);
            dgvSeleccion.Columns["IdUsuario"].Visible = false;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedRowCollection rows = dgvSeleccion.SelectedRows;
                if (rows.Count == 1)
                {
                    DataGridViewCellCollection cell = rows[0].Cells;
                    if (idVentanaFrom == 1)
                        vtn1.CargarSeleccion(Convert.ToInt32(cell["IdUsuario"].Value), Convert.ToString(cell["Descripcion"].Value));

                    if (idVentanaFrom == 2)
                        vtn2.CargarSeleccion(Convert.ToInt32(cell["IdUsuario"].Value), Convert.ToString(cell["Descripcion"].Value));
                }

                this.Dispose();
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }

        }

        public void CargarDatosVentana(Form vtn, int id)
        {
            this.idVentanaFrom = id;
            if (id == 1)
                this.vtn1 = (View.Historial_Cliente.HistorialCliente) vtn;

            if (id == 2)
                this.vtn2 = (View.Facturar_Publicaciones.FacturarPublicaciones)vtn;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnVolver_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
