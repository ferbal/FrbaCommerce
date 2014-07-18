using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.View.Historial_Cliente
{
    public partial class HistorialCliente : Form
    {
        private Form vtnAnterior;
        private int idUsuario = -1;
        private int clienteSeleccionado = -1;

        public enum Tipos
        {
            Compras = 1,
            Ofertas = 2,
            CalificacionesRealizadas = 3,
            CalificacionesRecibidas = 4
        }
        
        public HistorialCliente()
        {
            InitializeComponent();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {            
            View.Seleccion.SeleccionCliente vtnSeleccion = new FrbaCommerce.View.Seleccion.SeleccionCliente();
            vtnSeleccion.CargarDatosVentana(this,1);
            vtnSeleccion.Visible = true;
            this.Visible = false;
            epCliente.Clear();
        }

        
        public void CargarSeleccion(int idSeleccion,String seleccion)
        {
            txtCliente.Text = seleccion;
            this.clienteSeleccionado = idSeleccion;
        }

        public void CargarDatos(Form vtn, int usr)
        {
            this.vtnAnterior = vtn;
            this.idUsuario = usr;
        }

        private void HistorialCliente_Load(object sender, EventArgs e)
        {
            try
            {
                txtCliente.Enabled = false;
                ArmarCmbTiposHistoriales();
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }

        private void ArmarCmbTiposHistoriales()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IdCol");
            dt.Columns.Add("Descripcion");

            DataRow dr = dt.NewRow();
            dr["IdCol"] = -1;
            dr["Descripcion"] = "Seleccionar";            
            dt.Rows.InsertAt(dr, 0);

            dr = dt.NewRow();
            dr["IdCol"] = 1;
            dr["Descripcion"] = "Compras";
            dt.Rows.InsertAt(dr, 1);

            dr = dt.NewRow();
            dr["IdCol"] = 2;
            dr["Descripcion"] = "Ofertas";
            dt.Rows.InsertAt(dr, 2);
            
            dr = dt.NewRow();
            dr["IdCol"] = 3;
            dr["Descripcion"] = "Calificaciones Realizadas";
            dt.Rows.InsertAt(dr, 3);
            
            dr = dt.NewRow();
            dr["IdCol"] = 4;
            dr["Descripcion"] = "Calificaciones Recibidas";
            dt.Rows.InsertAt(dr, 4);

            
            cmbTipoHistorial.DataSource = dt;
            cmbTipoHistorial.ValueMember = "IdCol";
            cmbTipoHistorial.DisplayMember = "Descripcion";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarDatos())
                {

                    switch (Convert.ToInt32(cmbTipoHistorial.SelectedValue))
                    {
                        case (int)Historial_Cliente.HistorialCliente.Tipos.Compras:
                            dgvHistorial.DataSource = Controller.Compras.HistorialComprasPorUsuario(this.idUsuario);
                            break;
                        case (int)Historial_Cliente.HistorialCliente.Tipos.Ofertas:
                            dgvHistorial.DataSource = Controller.Ofertas.HistorialOfertasPorUsuario(this.idUsuario);
                            break;
                        case (int)Historial_Cliente.HistorialCliente.Tipos.CalificacionesRealizadas:
                            dgvHistorial.DataSource = Controller.Calificaciones.HistorialCalificacionesPorUsuario(this.idUsuario);
                            break;
                        case (int)Historial_Cliente.HistorialCliente.Tipos.CalificacionesRecibidas:
                            dgvHistorial.DataSource = Controller.Calificaciones.HistorialCalificacionesRecibidasPorUsuario(this.idUsuario);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }

        private void cmbTipoHistorial_SelectedIndexChanged(object sender, EventArgs e)
        {
            epTipoHistorial.Clear();
        }

        private Boolean ValidarDatos()
        {
            Boolean result = true;

            if (Convert.ToInt32(cmbTipoHistorial.SelectedValue) == -1)
            {
                epTipoHistorial.SetError(cmbTipoHistorial, "Debe Seleccionar un tipo de Historial.");
                result = false;
            }
            
            /*
            if (this.clienteSeleccionado == -1)
            {
                epCliente.SetError(txtCliente,"Debe Seleccionar un Cliente");
                result = false;
            }
            */

            return result;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
