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
                pnlCliente.Visible = true;

            }else{
                pnlCliente.Visible = false;
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
    }
}
