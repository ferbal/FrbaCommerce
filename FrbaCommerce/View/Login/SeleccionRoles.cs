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
    public partial class SeleccionRoles : Form
    {
        private DataTable tablaRoles = null;
        private int idUsuario = -1;
        private Form vtnAnterior = null;

        public SeleccionRoles()
        {
            InitializeComponent();
        }

        private void SeleccionRoles_Load(object sender, EventArgs e)
        {
            if (tablaRoles==null)
                throw new Exception("El usuario no tiene Roles asignados.");

            cmbRoles.DataSource = this.tablaRoles;
            cmbRoles.DisplayMember = "Nombre";
            cmbRoles.ValueMember = "IdRol";
        }

        public void cargarInfoUsuario(DataTable tabla,int idUsuario,Form anterior)
        {
            this.tablaRoles = tabla;
            this.idUsuario = idUsuario;
            this.vtnAnterior = anterior;
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            int rolSeleccionado = (int) cmbRoles.SelectedValue;
            Principal vtnPrincipal = new Principal();
            vtnPrincipal.cargarInfoUsuario(idUsuario,rolSeleccionado,this);
            vtnPrincipal.Visible = true;
            this.Visible = false;
        }
    }
}
