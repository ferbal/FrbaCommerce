using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.View.ABM_Cliente
{
    public partial class AdminCliente : Form
    {
        private Form vtnAnterior;

        public AdminCliente()
        {
            InitializeComponent();
        }

        public void ventana_anterior(Form ant)
        {
            vtnAnterior = ant;

        }

        private void AdminCliente_Load(object sender, EventArgs e)
        {

            DAL.TiposDocumentosDAL tdDAL = new FrbaCommerce.DAL.TiposDocumentosDAL();

            cmbTipoDocumento.DisplayMember = "Descripcion";
            cmbTipoDocumento.ValueMember = "IdTipoDocumento";
            cmbTipoDocumento.DataSource = tdDAL.obtenerTiposDocumentos();
           
            llenarDataGrid();

            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;

        }

        private void llenarDataGrid()
        {
            DAL.ClientesDAL cliente = new FrbaCommerce.DAL.ClientesDAL();

            DataTable dt = cliente.listarClientes(txtNombre.Text, txtApellido.Text, cmbTipoDocumento.Text, txtDNI.Text, txtMAIL.Text);
                
            dgvRoles.DataSource = dt;

            dgvRoles.Columns["IdEstado"].Visible = false;
            dgvRoles.Columns["IdCliente"].Visible = false;
            
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
                if (dgvRoles.SelectedRows.Count == 1)
                {
                    DataGridViewRow dr = dgvRoles.CurrentRow;

                    DataGridViewCell cellNombre = dr.Cells["Nombre"];
                    DataGridViewCell cellIdCliente = dr.Cells["IdCliente"];
                    DataGridViewCell celltipoNro = dr.Cells["TipoDoc"];
                    DataGridViewCell cellNroDocumento = dr.Cells["NroDocumento"];
                    DataGridViewCell cellcuil = dr.Cells["CUIL"];
                    DataGridViewCell cellMail = dr.Cells["Mail"];
                    DataGridViewCell cellApellido = dr.Cells["Apellido"];
                    DataGridViewCell cellTelefono = dr.Cells["Telefono"];
                    DataGridViewCell cellCalle = dr.Cells["Calle"];
                    DataGridViewCell cellPisoNro = dr.Cells["PisoNro"];
                    DataGridViewCell cellDepto = dr.Cells["Depto"];
                    DataGridViewCell cellLocalidad = dr.Cells["Localidad"];
                    DataGridViewCell cellCodigoPostal = dr.Cells["CodigoPostal"];
                    DataGridViewCell cellFechaNacimiento = dr.Cells["FechaNacimiento"];
                    DataGridViewCell cellIdEstado = dr.Cells["IdEstado"];

                    int id = Convert.ToInt32(cellIdCliente.Value);
                    String nombre = Convert.ToString(cellNombre.Value);
                    String tipodoc = Convert.ToString(celltipoNro.Value);
                    String DNI = Convert.ToString(cellNroDocumento.Value);
                    String CUIL = Convert.ToString(cellcuil.Value);
                    String MAIL = Convert.ToString(cellMail.Value);
                    String apellido = Convert.ToString(cellApellido.Value);
                    String Telefono = Convert.ToString(cellTelefono.Value);
                    String Calle = Convert.ToString(cellCalle.Value);
                    String PisoNro = Convert.ToString(cellPisoNro.Value);
                    String Depto = Convert.ToString(cellDepto.Value);
                    String Localidad = Convert.ToString(cellLocalidad.Value);
                    int CodigoPostal = Convert.ToInt32(cellCodigoPostal.Value);
                    DateTime FechaNacimiento = Convert.ToDateTime(cellFechaNacimiento.Value);
                    int IdEstado = Convert.ToInt32(cellIdEstado.Value);

                    View.ABM_Cliente.ABM_de_Cliente ClienteMod = new ABM_de_Cliente();
                    ClienteMod.ventana_anterior(this);
                    ClienteMod.Text = "Modificacion de Cliente";

                    ClienteMod.asignarClienteAModificar(id, nombre, apellido, tipodoc, DNI, CUIL, MAIL, Telefono, Calle, PisoNro, Depto, Localidad, CodigoPostal, FechaNacimiento, IdEstado);

                    ClienteMod.Visible = true;
                    this.Visible = false;
                }
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
                if (dgvRoles.SelectedRows.Count == 1)
                {
                    DataGridViewRow dr = dgvRoles.CurrentRow;

                    DataGridViewCell cellNombre = dr.Cells["Nombre"];
                    DataGridViewCell cellIdCliente = dr.Cells["IdCliente"];
                    DataGridViewCell celltipoNro = dr.Cells["TipoDoc"];
                    DataGridViewCell cellNroDocumento = dr.Cells["NroDocumento"];
                    DataGridViewCell cellcuil = dr.Cells["CUIL"];
                    DataGridViewCell cellMail = dr.Cells["Mail"];
                    DataGridViewCell cellApellido = dr.Cells["Apellido"];
                    DataGridViewCell cellTelefono = dr.Cells["Telefono"];
                    DataGridViewCell cellCalle = dr.Cells["Calle"];
                    DataGridViewCell cellPisoNro = dr.Cells["PisoNro"];
                    DataGridViewCell cellDepto = dr.Cells["Depto"];
                    DataGridViewCell cellLocalidad = dr.Cells["Localidad"];
                    DataGridViewCell cellCodigoPostal = dr.Cells["CodigoPostal"];
                    DataGridViewCell cellFechaNacimiento = dr.Cells["FechaNacimiento"];
                    DataGridViewCell cellIdEstado = dr.Cells["IdEstado"];

                    int id = Convert.ToInt32(cellIdCliente.Value);
                    String nombre = Convert.ToString(cellNombre.Value);
                    String tipodoc = Convert.ToString(celltipoNro.Value);
                    String DNI = Convert.ToString(cellNroDocumento.Value);
                    String CUIL = Convert.ToString(cellcuil.Value);
                    String MAIL = Convert.ToString(cellMail.Value);
                    String apellido = Convert.ToString(cellApellido.Value);
                    String Telefono = Convert.ToString(cellTelefono.Value);
                    String Calle = Convert.ToString(cellCalle.Value);
                    String PisoNro = Convert.ToString(cellPisoNro.Value);
                    String Depto = Convert.ToString(cellDepto.Value);
                    String Localidad = Convert.ToString(cellLocalidad.Value);
                    int CodigoPostal = Convert.ToInt32(cellCodigoPostal.Value);
                    DateTime FechaNacimiento = Convert.ToDateTime(cellFechaNacimiento.Value);
                    int IdEstado = Convert.ToInt32(cellIdEstado.Value);

                    if (IdEstado == 1)
                    {

                        View.ABM_Cliente.ABM_de_Cliente ClienteMod = new ABM_de_Cliente();
                        ClienteMod.ventana_anterior(this);
                        ClienteMod.Text = "Baja de Cliente";

                        ClienteMod.asignarClienteAModificar(id, nombre, apellido, tipodoc, DNI, CUIL, MAIL, Telefono, Calle, PisoNro, Depto, Localidad, CodigoPostal, FechaNacimiento, IdEstado);

                        ClienteMod.Visible = true;
                        this.Visible = false;
                    }
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
                View.ABM_Cliente.ABM_de_Cliente vtnAlta = new  ABM_de_Cliente();
                vtnAlta.ventana_anterior(this);
                vtnAlta.Text = "Alta de Cliente";

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

        private void AdminCliente_Load_1(object sender, EventArgs e)
        {
            DAL.TiposDocumentosDAL tdDAL = new FrbaCommerce.DAL.TiposDocumentosDAL();

            cmbTipoDocumento.DisplayMember = "Descripcion";
            cmbTipoDocumento.ValueMember = "IdTipoDocumento";
            cmbTipoDocumento.DataSource = tdDAL.obtenerTiposDocumentos();


        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDNI.Clear();
            txtMAIL.Clear();
            cmbTipoDocumento.SelectedIndex = 0;
            dgvRoles.Visible = false;
        }

    
    }
}
