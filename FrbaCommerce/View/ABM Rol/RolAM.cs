using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.View.ABM_Rol
{    
    
    public partial class RolAM : Form
    {

        private Form vtnAnterior;
        private int idRol = -1;

        public RolAM(Form ant)
        {
            vtnAnterior = ant;            
                       
            InitializeComponent();

        }

        public void asignarRolAModificar(int id,String nombre)
        {
            idRol = id;
            txtNombre.Text = nombre;                       
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validarDatos())
                {
                    if (this.idRol == -1)
                    {
                        Controller.Roles.IngresarNuevoRol(txtNombre.Text);                        
                    }
                    else
                    {
                        Controller.Roles.ActualizarRol(this.idRol,txtNombre.Text);
                    }
                    this.Dispose();
                }                
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
            }
        }

        private Boolean validarDatos()
        {
            Boolean estado = true;
            if (String.IsNullOrEmpty(txtNombre.Text))
            {
                epNombre.SetError(txtNombre, "El Nombre es un campo requerido.");
                estado = false;
            }

            return estado;

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {            
            epNombre.Clear();
        }
    }
}
