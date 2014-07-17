using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.View.Registro_de_Usuario
{
    public partial class RegistroUsuario : Form
    {
        private Form ventanaAnterior;

        public RegistroUsuario(Form vtnAnterior)
        {
            this.ventanaAnterior = vtnAnterior;
            InitializeComponent();
        }

        private void RegistroUsuario_Load(object sender, EventArgs e)
        {
            DAL.TiposPersonasDAL tpDAL = new FrbaCommerce.DAL.TiposPersonasDAL();
            DAL.TiposDocumentosDAL tdDAL = new FrbaCommerce.DAL.TiposDocumentosDAL();
            
            cmbTiposPersona.DisplayMember = "Descripcion";
            cmbTiposPersona.ValueMember = "IdTipoPersona";
            cmbTiposPersona.DataSource = tpDAL.obtenerTiposPersonas();

            cmbTipoDocumento.DisplayMember = "Descripcion";
            cmbTipoDocumento.ValueMember = "IdTipoDocumento";
            cmbTipoDocumento.DataSource = tdDAL.obtenerTiposDocumentos();

            this.cargarListaRoles();
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
            int NroDocumento;
            int piso;
            int codigoPostal;
            char depto;
            Boolean result=false;
            try
            {
                
                if (String.IsNullOrEmpty(txtDNI.Text))
                {
                    NroDocumento = 0;
                }
                else
                {
                    NroDocumento = Convert.ToInt32(txtDNI.Text);
                }

                if (String.IsNullOrEmpty(txtPisoNro.Text))
                {
                    piso = 0;
                }
                else
                {
                    piso = Convert.ToInt32(txtPisoNro.Text);
                }

                if (String.IsNullOrEmpty(txtCodigoPostal.Text))
                {
                    codigoPostal = 0;
                }
                else
                {
                    codigoPostal = Convert.ToInt32(txtCodigoPostal.Text);
                }

                if (String.IsNullOrEmpty(txtDepto.Text))
                {
                    depto = ' ';
                }
                else
                {
                    depto = txtDepto.Text[0];
                }
                CheckedListBox.CheckedItemCollection CheckedlistaRoles = clbRoles.CheckedItems;
                List<int> listaRoles = new List<int>();
                
                foreach (DataRowView indexRol in CheckedlistaRoles)
                {
                    
                    listaRoles.Add(Convert.ToInt32( indexRol.Row.ItemArray[0]));
                }
                 
                if(validarDatos())                
                    result = Controller.Usuarios.AltaDeUsuario(txtNombre.Text,txtApellido.Text,Convert.ToInt32(cmbTipoDocumento.SelectedValue),NroDocumento,txtMail.Text,txtRazonSocial.Text,txtCuit.Text,txtNombreContacto.Text,txtTelefono.Text,txtCalle.Text,piso,depto,txtLocalidad.Text,codigoPostal,Convert.ToDateTime(txtFechaNac.Text),(int) cmbTiposPersona.SelectedValue,listaRoles);

                if (result)
                {                    
                    this.Dispose();
                }
    
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }      

        private void txtDepto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Char c = txtDepto.Text[0];
                if(Char.IsDigit(c)|| Char.IsWhiteSpace(c)||Char.IsPunctuation(c))
                    throw (new Exception("El Depto ingresado debe ser un caracter."));

                if (Char.IsLetter(c))
                    txtError.Text = "";
            }
            catch(Exception ex)
            {
                if(!String.IsNullOrEmpty(ex.Message))
                    txtError.Text = ex.Message;

            }
        }

        private Boolean validarDatos()
        {
            Boolean estado = true;
            if (String.IsNullOrEmpty(txtFechaNac.Text))
            {
                epFecha.SetError(lblFechaNac, "La FECHA es un campo requerido.");
                estado = false;
            }

            if (String.IsNullOrEmpty(txtTelefono.Text))
            {
                epTelefono.SetError(lblTelefono, "El TELEFONO es un campo requerido.");
                estado = false;
            }

            if (String.IsNullOrEmpty(txtApellido.Text) && (int)cmbTiposPersona.SelectedValue == (int) Model.TiposPersonas.TiposPersonasEnum.Cliente)
            {
                epApellido.SetError(txtApellido, "El APELLIDO es un campo requerido.");
                estado = false;
            }

            if (String.IsNullOrEmpty(txtRazonSocial.Text) && (int)cmbTiposPersona.SelectedValue == (int)Model.TiposPersonas.TiposPersonasEnum.Empresa)
            {
                epRazonSocial.SetError(txtRazonSocial,"La RAZON SOCIAL es un campo requerido.");
                estado = false;
            }

            if (String.IsNullOrEmpty(txtMail.Text))
            {
                epLogin.SetError(txtMail, "El MAIL es un campo requerido.");
                estado = false;
            }

            /* CAMPOS ELIMINADOS
            if (String.IsNullOrEmpty(txtNombreUsuario.Text))
            {
                epLogin.SetError(txtNombreUsuario, "El NOMBRE DE USUARIO es un campo requerido.");
                estado = false;
            }

            if (String.IsNullOrEmpty(txtPassword.Text))
            {
                epPass.SetError(txtPassword, "El PASSWORD es un campo requerido.");
                estado = false;
            }
             * */
            return estado;
        }

        private void txtFechaNac_TextChanged(object sender, EventArgs e)
        {
            if (txtFechaNac.Text.Length == 2 || txtFechaNac.Text.Length == 5)
                txtFechaNac.AppendText("/");

            epFecha.Clear();

        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            epApellido.Clear();
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            epTelefono.Clear();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            epPass.Clear();
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {
            epRazonSocial.Clear();
        }

        private void txtNombreUsuario_TextChanged(object sender, EventArgs e)
        {
            epLogin.Clear();
        }

        private void cargarListaRoles()
        {
            DAL.RolesDAL rolDAL = new FrbaCommerce.DAL.RolesDAL();
            clbRoles.DataSource = rolDAL.listarRolesHabilitados();
            clbRoles.DisplayMember = "Nombre";
            clbRoles.ValueMember = "IdRol";
        }

        private void pnlCliente_Paint(object sender, PaintEventArgs e)
        {

        }
        
    }
}
