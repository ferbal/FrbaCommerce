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
    public partial class ABM_de_Cliente : Form
    {
        private Form vtnAnterior;
        private int idCliente = -1;
        
        
        public ABM_de_Cliente()
        {
            InitializeComponent();
        }

        public void ventana_anterior(Form ant)
        {
            vtnAnterior = ant;            
                       
        }

        public void asignarClienteAModificar(int id, String nombre, String apellido, String tipoDoc, String nroDoc, String nroCuil, String MAIL, String Telefono, String Calle, String PisoNro, String Depto, String Localidad, int CodigoPostal, DateTime FechaCreacion, int IdEstado)
        {
            idCliente = id;
            txtNombre.Text = nombre;
            cmbTipoDocumento.Text = tipoDoc;
            txtDNI.Text = nroDoc;
            txtcuil.Text = nroCuil;
            txtMail.Text = MAIL;
            txtApellido.Text = apellido;
            txtTelefono.Text = Telefono;
            txtCalle.Text = Calle;
            txtPisoNro.Text = PisoNro;
            txtDepto.Text = Depto;
            txtLocalidad.Text = Localidad;
            txtCodigoPostal.Text = Convert.ToString(CodigoPostal);
            txtFechaNac.Text = Convert.ToString(FechaCreacion);

            if (IdEstado == (int)FrbaCommerce.Model.Clientes.Estados.Habilitado)
            {
                chkhabilitado.Checked = true;
            }
            else
            {
                chkhabilitado.Checked = false;
            }

            if (String.Equals(this.Text,"Baja de Cliente")){

                txtNombre.Enabled = false;
                lblNombre.Enabled = false;
                txtApellido.Enabled = false;
                lblApellido.Enabled = false;
                cmbTipoDocumento.Enabled = false;
                lblTipoDocumento.Enabled = false;
                txtDNI.Enabled = false;
                lblDNI.Enabled = false;
                txtcuil.Enabled = false;
                lblcuil.Enabled = false;
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

            //ver validacion CUIL
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
                    estado = (int)FrbaCommerce.Model.Clientes.Estados.Habilitado;
                }else{
                    estado = (int)FrbaCommerce.Model.Clientes.Estados.Inhabilitado;
                }

                //DAL.ClientesDAL cliente = new FrbaCommerce.DAL.ClientesDAL();

                int idTipoDoc = DAL.ClientesDAL.obtenerTipoDoc(cmbTipoDocumento.Text);

                if(validarDatos()){
                    if (String.Equals(this.Text,"Alta de Cliente")) 
                    //if (this.idEmpresa == -1)
                    {
                        Controller.Clientes.ingresarClienteNuevo(txtNombre.Text, txtApellido.Text, idTipoDoc, Convert.ToInt32(txtDNI.Text), txtcuil.Text, txtMail.Text, Convert.ToDateTime(txtFechaNac.Text), txtTelefono.Text, txtCalle.Text, piso, depto, codigoPostal, txtLocalidad.Text, 0, estado);

                    }else{
                        if (String.Equals(this.Text,"Modificacion de Cliente")) {

                            Controller.Clientes.modificarCliente(this.idCliente, txtNombre.Text, txtApellido.Text, idTipoDoc, Convert.ToInt32(txtDNI.Text), txtcuil.Text, txtMail.Text, Convert.ToDateTime(txtFechaNac.Text), txtTelefono.Text, txtCalle.Text, piso, depto, codigoPostal, txtLocalidad.Text, estado);

                        }else{

                            Controller.Clientes.BajaCliente(this.idCliente, txtNombre.Text, txtApellido.Text, idTipoDoc, Convert.ToInt32(txtDNI.Text), txtcuil.Text, txtMail.Text, Convert.ToDateTime(txtFechaNac.Text), txtTelefono.Text, txtCalle.Text, piso, depto, codigoPostal, txtLocalidad.Text, estado);
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

            if (String.IsNullOrEmpty(txtNombre.Text))
            {
                epRazonSocial.SetError(txtNombre,"La RAZON SOCIAL es un campo requerido.");
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

        private void ABM_de_Cliente_Load(object sender, EventArgs e)
        {
            DAL.TiposDocumentosDAL tdDAL = new FrbaCommerce.DAL.TiposDocumentosDAL();

            cmbTipoDocumento.DisplayMember = "Descripcion";
            cmbTipoDocumento.ValueMember = "IdTipoDocumento";
            cmbTipoDocumento.DataSource = tdDAL.obtenerTiposDocumentos();
        }


    }
}
