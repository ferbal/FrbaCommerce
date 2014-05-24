using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Vista.Registro_de_Usuario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DAL.TiposPersonasDAL tpDAL = new FrbaCommerce.DAL.TiposPersonasDAL();
            DAL.TiposDocumentosDAL tdDAL = new FrbaCommerce.DAL.TiposDocumentosDAL();
            
            cmbTiposPersona.DisplayMember = "Descripcion";
            cmbTiposPersona.ValueMember = "IdTipoPersona";
            cmbTiposPersona.DataSource = tpDAL.obtenerTiposPersonas();

            cmbTipoDocumento.DisplayMember = "Descripcion";
            cmbTipoDocumento.ValueMember = "IdTipoDocumento";
            cmbTipoDocumento.DataSource = tdDAL.obtenerTiposDocumentos();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmbTiposPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( (int)cmbTiposPersona.SelectedValue == (int)Model.TiposPersonas.TiposPersonasEnum.Cliente)
            {
                txtRazonSocial.Enabled = false;
                lblRazonSocial.Enabled = false;
                txtNombreContacto.Enabled = false;
                lblNombreContacto.Enabled = false;
                lblNombre.Enabled = true;
                txtNombre.Enabled = true;
                lblApellido.Enabled = true;
                txtApellido.Enabled = true;
                lblTipoDocumento.Enabled = true;
                cmbTipoDocumento.Enabled = true;
                lblNroDocumento.Enabled = true;
                txtDNI.Enabled = true;
            }else{
                txtRazonSocial.Enabled = true;
                lblRazonSocial.Enabled = true;
                txtNombreContacto.Enabled = true;
                lblNombreContacto.Enabled = true;
                lblNombre.Enabled = false;
                txtNombre.Enabled = false;
                lblApellido.Enabled = false;
                txtApellido.Enabled = false;
                lblTipoDocumento.Enabled = false;
                cmbTipoDocumento.Enabled = false;
                lblNroDocumento.Enabled = false;
                txtDNI.Enabled = false;

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Model.Usuarios usr = new FrbaCommerce.Model.Usuarios();
            int idNumero = 0;
            if ((int)cmbTiposPersona.SelectedValue == (int)Model.TiposPersonas.TiposPersonasEnum.Cliente)
            {
                idNumero = ingresarClienteNuevo();
                
            }
            else
            {
                idNumero = ingresarEmpresaNueva();
            }
            usr.idNumero = idNumero;
            usr.idTipoPersona = (int)cmbTiposPersona.SelectedValue;
            usr.password = txtPassword.Text;
            usr.login = txtNombreUsuario.Text;
            usr.idEstado = 1;
            usr.fallos = 0;

            DAL.UsuariosDAL usrDAL = new FrbaCommerce.DAL.UsuariosDAL();
            usrDAL.InsertarUsuario(usr);
            
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtDNI_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCuit_TextChanged(object sender, EventArgs e)
        {

        }

        private void pnlCliente_Paint(object sender, PaintEventArgs e)
        {

        }
        private int ingresarClienteNuevo()
        {
            Model.Clientes cli = new FrbaCommerce.Model.Clientes();
            DAL.ClientesDAL cliDAL = new FrbaCommerce.DAL.ClientesDAL();

            cli.Nombre = txtNombre.Text;
            cli.Apellido = txtApellido.Text;
            cli.IdTipoDocumento = Convert.ToInt32(cmbTipoDocumento.SelectedValue);
            cli.NroDocumento = Convert.ToInt32(txtDNI.Text);
            cli.Cuil = Convert.ToInt32(txtCuit.Text);
            cli.mail = txtMail.Text;
            cli.FechaNacimiento = DateTime.Now;
            cli.telefono = txtTelefono.Text;
            cli.Calle = txtCalle.Text;
            cli.PisoNro = Convert.ToInt32( txtPisoNro.Text);
            cli.Depto = txtDepto.Text[0];
            cli.CodigoPostal = Convert.ToInt32(txtCodigoPostal.Text);
            cli.Localidad = txtLocalidad.Text;
            cli.FechaNacimiento = Convert.ToDateTime(txtFechaNac.Text);
            
            cliDAL.InsertarCliente(cli);

            return cliDAL.loadPorNroDoc(cli.NroDocumento);
        }

        private int ingresarEmpresaNueva()
        {
            Model.Empresas emp = new FrbaCommerce.Model.Empresas();
            DAL.EmpresaDAL empDAL = new FrbaCommerce.DAL.EmpresaDAL();

            emp.RazonSocial = txtRazonSocial.Text;
            emp.Cuit = txtCuit.Text;
            emp.NombreContacto = txtNombreContacto.Text;
            emp.Mail = txtMail.Text;
            emp.Telefono = txtTelefono.Text;
            emp.Calle = txtCalle.Text;
            emp.PisoNro = Convert.ToInt32(txtPisoNro.Text);
            emp.Depto = txtDepto.Text[0];
            emp.Localidad = txtLocalidad.Text;
            emp.CodigoPostal = Convert.ToInt32(txtCodigoPostal.Text);
            emp.FechaCreacion = Convert.ToDateTime(txtFechaNac.Text);

            empDAL.insertarEmpresa(emp);

            return empDAL.loadPorCuit(emp.Cuit);
        }
    }
}
