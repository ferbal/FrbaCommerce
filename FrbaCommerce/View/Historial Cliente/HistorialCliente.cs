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
            Calificaciones = 3
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
            txtCliente.Enabled = false;
            ArmarCmbTiposHistoriales();
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
            dr["Descripcion"] = "Calificaciones";

            dt.Rows.InsertAt(dr, 3);

            
            cmbTipoHistorial.DataSource = dt;
            cmbTipoHistorial.ValueMember = "IdCol";
            cmbTipoHistorial.DisplayMember = "Descripcion";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if ((int)cmbTipoHistorial.SelectedValue != -1)
            {
                DataTable dt;
                switch((int)cmbTipoHistorial.SelectedValue)
                {
                    case (int)Historial_Cliente.HistorialCliente.Tipos.Compras:
                        dt = Controller.Compras.HistorialComprasPorUsuario(this.clienteSeleccionado);
                        break;
                    case (int)Historial_Cliente.HistorialCliente.Tipos.Ofertas:
                        //dt = Controller.Ofertas.HistorialOfertasPorUsuario(this.clienteSeleccionado);
                        break;
                    case (int)Historial_Cliente.HistorialCliente.Tipos.Calificaciones:
                        //dt = Controller.Calificaciones.HistorialCalificacionesPorUsuario(this.clienteSeleccionado);
                        break;
                    default
                        break;
                }                
            }
        }

    }
}
