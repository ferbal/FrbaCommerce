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
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            View.Registro_de_Usuario.RegistroUsuario vtnRegistroUsr = new View.Registro_de_Usuario.RegistroUsuario((Form) this);
            this.Visible = false;
            vtnRegistroUsr.Visible = true;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.validarExistenciaDeDatos())
                    throw new Exception("Debe completar el Nombre de Usuario y la Contraseña.");

                Boolean result = Controller.Usuarios.verficarLogin(txtNombreUsuario.Text,txtPassword.Text);

                if (result)
                    throw new Exception("Ingreso Satisfactorio");

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
