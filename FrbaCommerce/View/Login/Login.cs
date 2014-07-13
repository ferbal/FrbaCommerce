using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.View.Login
{
    public partial class LoginForm : Form
    {
        private DateTime fechaSistema;

        public LoginForm()
        {
            InitializeComponent();
        }

        public void cargarDatos(DateTime fecha)
        {
            this.fechaSistema = fecha;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            lblConfNuevoPass.Visible = false;
            lblNuevoPass.Visible = false;
            txtConfNuevoPass.Visible = false;
            txtNuevoPass.Visible = false;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            View.Registro_de_Usuario.RegistroUsuario vtnRegistroUsr = new View.Registro_de_Usuario.RegistroUsuario((Form) this);
            this.Visible = false;
            vtnRegistroUsr.Visible = true;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int idUsuario = -1;
            List<Model.Roles> lista = new List<FrbaCommerce.Model.Roles>();
            String msg = String.Empty;
            try
            {

                if (!this.validarExistenciaDeDatos())
                    throw new Exception("Debe completar el Nombre de Usuario y la Contraseña.");

                if (txtNuevoPass.Visible && txtNuevoPass.Text.Equals(txtConfNuevoPass.Text))
                {
                    idUsuario = Controller.Usuarios.ActualizarPassword(txtNombreUsuario.Text, txtNuevoPass.Text);
                }
                else
                {
                    idUsuario = Controller.Usuarios.verficarLogin(txtNombreUsuario.Text, txtPassword.Text);
                }

                if (idUsuario > 0)
                {
                    DataTable dt = Controller.UsuariosRoles.obtenerRoles(idUsuario);
                    if (dt.Rows.Count > 1)
                    {
                        View.Login.SeleccionRoles vtnSeleccionRoles = new SeleccionRoles();
                        vtnSeleccionRoles.cargarInfoUsuario(dt, idUsuario, this,this.fechaSistema);
                        vtnSeleccionRoles.Visible = true;
                        this.Visible = false;
                    }
                    else
                    {
                        Principal vtnPrincipal = new Principal();
                        DataRow dr = dt.Rows[0];
                        vtnPrincipal.cargarInfoUsuario(idUsuario, (int)dr.ItemArray[0], this);
                        vtnPrincipal.Visible = true;
                        this.Visible = false;
                    }
                }
                else
                {
                    lblConfNuevoPass.Visible = true;
                    lblNuevoPass.Visible = true;
                    txtConfNuevoPass.Visible = true;
                    txtNuevoPass.Visible = true;
                    txtPassword.Enabled = false;
                }

            }
            catch(Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }               
        }

        private Boolean validarExistenciaDeDatos()
        {
            if (String.IsNullOrEmpty(txtNombreUsuario.Text))
                return false;

            if (String.IsNullOrEmpty(txtPassword.Text))
                return false;

            return true;
        }
    }
}
