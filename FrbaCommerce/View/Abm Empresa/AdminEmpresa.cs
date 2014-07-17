using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.View.ABM_Empresa
{
    public partial class AdminEmpresa : Form
    {

        private Form vtnAnterior;

        public AdminEmpresa()
        {
            InitializeComponent();
        }

        public void ventana_anterior(Form ant)
        {
            vtnAnterior = ant;

        }

        private void AdminEmpresa_Load(object sender, EventArgs e)
        {
            llenarDataGrid();
        }

        private void llenarDataGrid()
        {
            DAL.EmpresasDAL empresa = new FrbaCommerce.DAL.EmpresasDAL();

            DataTable dt = empresa.listarEmpresas(txtRazonSocial.Text, txtCUIT.Text, txtMAIL.Text);

            dgvRoles.DataSource = dt;

            dgvRoles.Columns["IdEstado"].Visible = false;
            dgvRoles.Columns["IdEmpresa"].Visible = false;
            
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

                DataGridViewCell cellRazonSocial = dr.Cells["RazonSocial"];
                DataGridViewCell cellIdEmpresa = dr.Cells["IdEmpresa"];
                DataGridViewCell cellCUIT = dr.Cells["CUIT"];
                DataGridViewCell cellMail = dr.Cells["Mail"];
                DataGridViewCell cellNombreContacto = dr.Cells["NombreContacto"];
                DataGridViewCell cellTelefono = dr.Cells["Telefono"];
                DataGridViewCell cellCalle = dr.Cells["Calle"];
                DataGridViewCell cellPisoNro = dr.Cells["PisoNro"];
                DataGridViewCell cellDepto = dr.Cells["Depto"];
                DataGridViewCell cellLocalidad = dr.Cells["Localidad"];
                DataGridViewCell cellCodigoPostal = dr.Cells["CodigoPostal"];
                DataGridViewCell cellFechaCreacion = dr.Cells["FechaCreacion"];
                DataGridViewCell cellIdEstado = dr.Cells["IdEstado"];
             
                int id = Convert.ToInt32(cellIdEmpresa.Value);
                String RZ = Convert.ToString(cellRazonSocial.Value);
                String CUIT = Convert.ToString(cellCUIT.Value);
                String MAIL = Convert.ToString(cellMail.Value);
                String NombreContacto = Convert.ToString(cellNombreContacto.Value);
                String Telefono = Convert.ToString(cellTelefono.Value);
                String Calle = Convert.ToString(cellCalle.Value);
                String PisoNro = Convert.ToString(cellPisoNro.Value);
                String Depto = Convert.ToString(cellDepto.Value);
                String Localidad = Convert.ToString(cellLocalidad.Value);
                int CodigoPostal = Convert.ToInt32(cellCodigoPostal.Value);
                DateTime FechaCreacion = Convert.ToDateTime(cellFechaCreacion.Value);
                int IdEstado = Convert.ToInt32(cellIdEstado.Value);

                View.ABM_Empresa.AM_de_Empresa EmpresaMod = new AM_de_Empresa();
                EmpresaMod.ventana_anterior(this);
                EmpresaMod.Text = "Modificacion de Empresa";

                EmpresaMod.asignarEmpresaAModificar(id,RZ,CUIT,MAIL,NombreContacto,Telefono,Calle,PisoNro,Depto,Localidad,CodigoPostal,FechaCreacion,IdEstado);

                EmpresaMod.Visible = true;
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

                DataGridViewCell cellRazonSocial = dr.Cells["RazonSocial"];
                DataGridViewCell cellIdEmpresa = dr.Cells["IdEmpresa"];
                DataGridViewCell cellCUIT = dr.Cells["CUIT"];
                DataGridViewCell cellMail = dr.Cells["Mail"];
                DataGridViewCell cellNombreContacto = dr.Cells["NombreContacto"];
                DataGridViewCell cellTelefono = dr.Cells["Telefono"];
                DataGridViewCell cellCalle = dr.Cells["Calle"];
                DataGridViewCell cellPisoNro = dr.Cells["PisoNro"];
                DataGridViewCell cellDepto = dr.Cells["Depto"];
                DataGridViewCell cellLocalidad = dr.Cells["Localidad"];
                DataGridViewCell cellCodigoPostal = dr.Cells["CodigoPostal"];
                DataGridViewCell cellFechaCreacion = dr.Cells["FechaCreacion"];
                DataGridViewCell cellIdEstado = dr.Cells["IdEstado"];

                int id = Convert.ToInt32(cellIdEmpresa.Value);
                String RZ = Convert.ToString(cellRazonSocial.Value);
                String CUIT = Convert.ToString(cellCUIT.Value);
                String MAIL = Convert.ToString(cellMail.Value);
                String NombreContacto = Convert.ToString(cellNombreContacto.Value);
                String Telefono = Convert.ToString(cellTelefono.Value);
                String Calle = Convert.ToString(cellCalle.Value);
                String PisoNro = Convert.ToString(cellPisoNro.Value);
                String Depto = Convert.ToString(cellDepto.Value);
                String Localidad = Convert.ToString(cellLocalidad.Value);
                int CodigoPostal = Convert.ToInt32(cellCodigoPostal.Value);
                DateTime FechaCreacion = Convert.ToDateTime(cellFechaCreacion.Value);
                int IdEstado = Convert.ToInt32(cellIdEstado.Value);

                if(IdEstado == 1){

                    View.ABM_Empresa.AM_de_Empresa EmpresaMod = new AM_de_Empresa();
                    EmpresaMod.ventana_anterior(this);
                    EmpresaMod.Text = "Baja de Empresa";

                    EmpresaMod.asignarEmpresaAModificar(id, RZ, CUIT, MAIL, NombreContacto, Telefono, Calle, PisoNro, Depto, Localidad, CodigoPostal, FechaCreacion, IdEstado);

                    EmpresaMod.Visible = true;
                    this.Visible = false;
                }
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                View.ABM_Empresa.AM_de_Empresa vtnAlta = new  AM_de_Empresa();
                vtnAlta.ventana_anterior(this);
                vtnAlta.Text = "Alta de Empresa";

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
                dgvRoles.Visible = true;
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
            vtnAnterior.Visible = true;
            this.Dispose();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCUIT.Clear();
            txtMAIL.Clear();
            txtRazonSocial.Clear();
            dgvRoles.Visible = false;
        }

    }
}
