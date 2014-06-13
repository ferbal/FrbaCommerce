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
    public partial class AM_de_Empresa : Form
    {
        private Form vtnAnterior;
        private int idEmpresa = -1;
        
        
        public AM_de_Empresa()
        {
            InitializeComponent();
        }

        public void ventana_anterior(Form ant)
        {
            vtnAnterior = ant;            
                       
        }

        public void asignarEmpresaAModificar(int id, String RZ, String CUIT, String MAIL, String NombreContacto, String Telefono, String Calle, String PisoNro, String Depto, String Localidad, int CodigoPostal, DateTime FechaCreacion, int IdEstado)
        {
            idEmpresa = id;
            txtRazonSocial.Text = RZ;
            txtCuit.Text = CUIT;
            txtMail.Text = MAIL;
            txtNombreContacto.Text = NombreContacto;
            txtTelefono.Text = Telefono;
            txtCalle.Text = Calle;
            txtPisoNro.Text = PisoNro;
            txtDepto.Text = Depto;
            txtLocalidad.Text = Localidad;
            txtCodigoPostal.Text = Convert.ToString(CodigoPostal);
            txtFechaNac.Text = Convert.ToString(FechaCreacion);

            if (IdEstado == (int)FrbaCommerce.Model.Empresas.Estados.Habilitado)
            {
                chkhabilitado.Checked = true;
            }
            else
            {
                chkhabilitado.Checked = false;
            }

            if (String.Equals(this.Text,"Baja de Empresa")){

                txtRazonSocial.Enabled = false;
                lblRazonSocial.Enabled = false;
                txtNombreContacto.Enabled = false;
                lblNombreContacto.Enabled = false;
                txtCuit.Enabled = false;
                lblCuit.Enabled = false;
                txtMail.Enabled = false;
                lblMail.Enabled = false;
                txtTelefono.Enabled = false;
                lblTelefono.Enabled = false;
                txtCalle.Enabled = false;
                lblCalle.Enabled = false;
                txtPisoNro.Enabled = false;
                lblPisoNro.Enabled = false;
                txtDepto.Enabled = false;
                lblDepto.Enabled = false;
                txtLocalidad.Enabled = false;
                lblLocalidad.Enabled = false;
                txtCodigoPostal.Enabled = false;
                lblCodigoPostal.Enabled = false;
                txtFechaNac.Enabled = false;
                lblFechaNac.Enabled = false;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int piso;
            int codigoPostal;
            char depto;
            int estado;

            try
            {
                
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
                
                if (chkhabilitado.Checked){
                    estado = (int)FrbaCommerce.Model.Empresas.Estados.Habilitado;
                }else{
                    estado = (int)FrbaCommerce.Model.Empresas.Estados.Inhabilitado;
                }

                if(validarDatos()){
                    if (String.Equals(this.Text,"Alta de Empresa")) 
                    //if (this.idEmpresa == -1)
                    {
                        Controller.Empresas.ingresarNuevaEmpresa(txtRazonSocial.Text, txtCuit.Text, txtNombreContacto.Text, txtMail.Text, txtTelefono.Text, txtCalle.Text, piso, depto, txtLocalidad.Text, codigoPostal, Convert.ToDateTime(txtFechaNac.Text), estado);

                    }else{
                        if (String.Equals(this.Text,"Modificacion de Empresa")) {
                            
                            Controller.Empresas.modificarEmpresa(this.idEmpresa, txtRazonSocial.Text, txtCuit.Text, txtNombreContacto.Text, txtMail.Text, txtTelefono.Text, txtCalle.Text, piso, depto, txtLocalidad.Text, codigoPostal, Convert.ToDateTime(txtFechaNac.Text), estado);

                        }else{
                                                        
                            Controller.Empresas.BajaEmpresa(this.idEmpresa, txtRazonSocial.Text, txtCuit.Text, txtNombreContacto.Text, txtMail.Text, txtTelefono.Text, txtCalle.Text, piso, depto, txtLocalidad.Text, codigoPostal, Convert.ToDateTime(txtFechaNac.Text), estado);
                        }
                    }
                    
                    vtnAnterior.Visible = true;
                    this.Dispose();

                }
            }
            catch (Exception ex)
            {
                txtError.Text = ex.Message;
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

            if (String.IsNullOrEmpty(txtRazonSocial.Text))
            {
                epRazonSocial.SetError(txtRazonSocial,"La RAZON SOCIAL es un campo requerido.");
                estado = false;
            }

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

    }
}
