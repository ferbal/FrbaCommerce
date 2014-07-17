using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.View.ABM_Rol
{
    public partial class AdminRol : Form
    {
        private Form vtnAnterior = null;
        private int idUsuario = -1;

        public AdminRol()
        {
            InitializeComponent();
        }
        public void CargarDatos(Form anterior,int usr)
        {
            this.vtnAnterior = anterior;
            this.idUsuario = usr;
        }
        private void AdminRol_Load(object sender, EventArgs e)
        {
            try
            {
                llenarDataGrid();
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }

        private void llenarDataGrid()
        {
            DAL.RolesDAL rol = new FrbaCommerce.DAL.RolesDAL();

            DataTable dt = rol.listarRoles(txtNombre.Text);
            
            dgvRoles.DataSource = dt;
            dgvRoles.Columns["IdRol"].Visible = false;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow dr = dgvRoles.CurrentRow;

                DataGridViewCell cellNombre = dr.Cells["Nombre"];
                DataGridViewCell cellIdRol = dr.Cells["IdRol"];

                int id = Convert.ToInt32(cellIdRol.Value);
                String n = Convert.ToString(cellNombre.Value);

                View.ABM_Rol.RolAM rolMod = new RolAM(this);
                rolMod.Text = "Modificacion de Rol";

                rolMod.asignarRolAModificar(id, n);

                rolMod.Visible = true;
                this.Visible = false;
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow dr = dgvRoles.CurrentRow;

                DataGridViewCell cellNombre = dr.Cells["Nombre"];
                DataGridViewCell cellIdRol = dr.Cells["IdRol"];            
                
                int id = Convert.ToInt32(cellIdRol.Value);

                Controller.Roles.EliminarRol(id);

                llenarDataGrid();
            }
            catch(Exception ex)
            {
                View.Error.ErrorForm vtnError = new View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                View.ABM_Rol.RolAM vtnAlta = new RolAM(this);

                vtnAlta.Text = "Alta de Rol";
                vtnAlta.Visible = true;

                this.Visible = false;
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
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

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnBuscar_VisibleChanged(object sender, EventArgs e)
        {
            if (dgvRoles.Rows.Count > 0)
                llenarDataGrid();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = String.Empty;                           
        }
    }
}
