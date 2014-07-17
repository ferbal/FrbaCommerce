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

                int idTipoDoc = DAL.ClientesDAL.obtenerTipoDoc(cmbTipoDocumento.Text);

                List<int> listaRoles = new List<int>();
                listaRoles.Add(Convert.ToInt32(1));

                Boolean result = false;

                if(validarDatos()){
                    if (String.Equals(this.Text,"Alta de Cliente")) 
                    {
                        //Controller.Clientes.ingresarClienteNuevo(txtNombre.Text, txtApellido.Text, idTipoDoc, Convert.ToInt32(txtDNI.Text), txtcuil.Text, txtMail.Text, Convert.ToDateTime(txtFechaNac.Text), txtTelefono.Text, txtCalle.Text, piso, depto, codigoPostal, txtLocalidad.Text, 0, estado);
                        result = Controller.Usuarios.AltaDeUsuario(txtNombre.Text, txtApellido.Text, Convert.ToInt32(cmbTipoDocumento.SelectedValue), Convert.ToInt32(txtDNI.Text), txtMail.Text, String.Empty, txtcuil.Text, String.Empty, txtTelefono.Text, txtCalle.Text, piso, depto, txtLocalidad.Text, codigoPostal, Convert.ToDateTime(txtFechaNac.Text), 1, listaRoles);

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

            epFecha.Dispose();
            if (String.IsNullOrEmpty(txtFechaNac.Text))
            {
                epFecha.SetError(lblFechaNac, "La FECHA es un campo requerido.");
                estado = false;
            }

            epTelefono.Dispose();
            if (String.IsNullOrEmpty(txtTelefono.Text))
            {
                epTelefono.SetError(lblTelefono, "El TELEFONO es un campo requerido.");
                estado = false;
            }

            epRazonSocial.Dispose();
            if (String.IsNullOrEmpty(txtNombre.Text))
            {
                epRazonSocial.SetError(lblNombre,"El NOMBRE es un campo requerido.");
                estado = false;
            }

            epCuil.Dispose();
            if (!ValidaCuit(txtcuil.Text))
            {
                epCuil.SetError(txtcuil, "El CUIT no es valido.");
                estado = false;
            }

            return estado;
        }


        /// <summary>
        /// Valida el CUIT ingresado.
        /// </summary>
        /// <param name="cuit" />Número de CUIT como string con o sin guiones
        /// <returns>True si el CUIT es válido y False si no.</returns>
        public static bool ValidaCuit(string cuit)
        {
            if (cuit == null)
            {
                return false;
            }

            //Quito los guiones, el cuit resultante debe tener 11 caracteres.
            cuit = cuit.Replace("-", string.Empty);
            if (cuit.Length != 11)
            {
                return false;
            }
            else
            {
                int calculado = CalcularDigitoCuit(cuit);
                int digito = int.Parse(cuit.Substring(10));
                return calculado == digito;
            }
        }

        // <summary>
        /// Calcula el dígito verificador dado un CUIT completo o sin él.
        /// </summary>
        /// <param name="cuit">El CUIT como String sin guiones</param>
        /// <returns>El valor del dígito verificador calculado.</returns>
        public static int CalcularDigitoCuit(string cuit)
        {
            int[] mult = new[] { 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
            char[] nums = cuit.ToCharArray();
            int total = 0;
            for (int i = 0; i < mult.Length; i++)
            {
                total += int.Parse(nums[i].ToString()) * mult[i];
            }
            var resto = total % 11;
            return resto == 0 ? 0 : resto == 1 ? 9 : 11 - resto;
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

            mcFecha.Visible = false;
            mcFecha.SelectionRange.Start = Controller.Validaciones.ObtenerFechaSistema();
            mcFecha.SelectionRange.End = Controller.Validaciones.ObtenerFechaSistema();
            mcFecha.MaxDate = Controller.Validaciones.ObtenerFechaSistema();
            mcFecha.TodayDate = Controller.Validaciones.ObtenerFechaSistema();

            if (String.Equals(this.Text,"Alta de Cliente")) 
            {
                DAL.TiposDocumentosDAL tdDAL = new FrbaCommerce.DAL.TiposDocumentosDAL();

                cmbTipoDocumento.DisplayMember = "Descripcion";
                cmbTipoDocumento.ValueMember = "IdTipoDocumento";
                cmbTipoDocumento.DataSource = tdDAL.obtenerTiposDocumentos();
                txtFechaNac.Enabled = false;
            }
        }

        private void btnSeleccionarFecha_Click(object sender, EventArgs e)
        {
            mcFecha.Visible = true;
        }

        private void mcFecha_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtFechaNac.Text = mcFecha.SelectionEnd.ToShortDateString();
            mcFecha.Visible = false;
        }




    }
}
