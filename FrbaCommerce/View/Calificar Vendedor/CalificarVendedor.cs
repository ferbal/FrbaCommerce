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
            try
            {
                CambiarEstadoObjetos(false);
                CargarCMB();
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }

        private void CargarCMB()
        {      
            DataTable dt = Controller.Compras.ObtenerComprasNoCalificadas(this.idUsuario);
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

                //Habilitar al Usuario
                if (Controller.Usuarios.ValidarEstadoDeUsuario(this.idUsuario, (int)Model.Usuarios.Estados.BloqueadoCompraOferta))
                    Controller.Usuarios.CambiarEstado(this.idUsuario,(int)Model.Usuarios.Estados.Habilitado);

            }
            txtDetalle.Text = String.Empty;
            mtxtCalificacion.Text = String.Empty;
            
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            try
            {
                this.Dispose();
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                CargarCMB();
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }

        private void btnCalificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarDatos())
                {
                    Controller.Calificaciones.IngresarCalificaciones((int)cmbCompras.SelectedValue, Convert.ToInt32(mtxtCalificacion.Text), "");
                    CambiarEstadoObjetos(false);
                    CargarCMB();
                }
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }

        private Boolean ValidarDatos()
        {
            Boolean result = true;

            if (Convert.ToInt32(mtxtCalificacion.Text) > 5 && Convert.ToInt32(mtxtCalificacion.Text) <= 0)
            {
                epCalificacion.SetError(mtxtCalificacion,"La calificacion debe ser entre 1 y 5.");
                result = false;
            }                
         
            return result;
        }

        private void CambiarEstadoObjetos(Boolean estado)
        {
            cmbCompras.Enabled = estado;
            mtxtCalificacion.Enabled = estado;
            btnCalificar.Enabled = estado;
            txtDetalle.Enabled = estado;
        }

        public void CargarDatos(Form vtn,int usr)
        {
            this.vtnAnterior = vtn;
            this.idUsuario = usr;
        }

        private void mtxtCalificacion_TextChanged(object sender, EventArgs e)
        {
            try
            {
                epCalificacion.Clear();
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }
    }
}
