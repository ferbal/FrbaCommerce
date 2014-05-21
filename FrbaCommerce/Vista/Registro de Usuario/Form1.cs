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
            
            cmbTiposPersona.DisplayMember = "Descripcion";
            cmbTiposPersona.ValueMember = "IdTipoPersona";
            cmbTiposPersona.DataSource = tpDAL.obtenerTiposPersonas();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmbTiposPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( (int)cmbTiposPersona.SelectedValue == 1)
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
            Model.Clientes cli = new FrbaCommerce.Model.Clientes();

            cli.Nombre = txtNombre.Text;
            cli.Apellido = txtApellido.Text;
            cli.NroDocumento = Convert.ToInt32(txtDNI.Text);
            cli.Cuil = Convert.ToInt32(txtCuit.Text);
            cli.mail = txtMail.Text;
            cli.FechaNacimiento = DateTime.Now;
            cli.telefono = "123456";
            //cli.Calle = "";
            

            DAL.ClientesDAL cliDAL = new FrbaCommerce.DAL.ClientesDAL();
            cliDAL.InsertarCliente(cli);
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
    }
}
