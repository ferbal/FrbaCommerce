using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.View.Calificar_Vendedor
{
    public partial class CalificarVendedor : Form
    {
        private Form vtnAnterior;
        private int idUsuario = -1;

        public CalificarVendedor()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CambiarEstadoObjetos(false);
        }

        private void CargarCMB()
        {      
            DataTable dt = Controller.Compras.ObtenerComprasNoCalificadas(txtLogin.Text);
            cmbCompras.DataSource = dt;
            cmbCompras.DisplayMember = "Descripcion";
            cmbCompras.ValueMember = "IdCompra";

            CambiarEstadoObjetos(true);
            
            if (dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();
                dr["IdCompra"] = -1;
                dr["Descripcion"] = "No posee compras pendientes.";
                dt.Rows.InsertAt(dr,0);

                CambiarEstadoObjetos(false);
            }
            
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarCMB();
        }

        private void btnCalificar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                Controller.Calificaciones.IngresarCalificaciones((int)cmbCompras.SelectedValue, Convert.ToInt32(mtxtCalificacion.Text), "");
                CambiarEstadoObjetos(false);
                CargarCMB();
            }
        }

        private Boolean ValidarDatos()
        {
            if (Convert.ToInt32(mtxtCalificacion.Text) > 5)
                return false;
         
            return true;
        }

        private void CambiarEstadoObjetos(Boolean estado)
        {
            cmbCompras.Enabled = estado;
            mtxtCalificacion.Enabled = estado;
            btnCalificar.Enabled = estado;
            txtDetalle.Enabled = estado;
        }
    }
}
