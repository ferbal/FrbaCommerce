using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;

namespace FrbaCommerce.View.Facturar_Publicaciones
{
    public partial class FacturarPublicaciones : Form
    {
        private Form vtnAnterior;
        private int idUsuario = -1;

        public FacturarPublicaciones()
        {
            InitializeComponent();
        }

        private void FacturarPublicaciones_Load(object sender, EventArgs e)
        {
            cargarCmbVendedores();
            CargaCmbFormasPago();
            CambiarVisibilidadFormasPago(false);

            lblSubTotal1.Text = String.Empty;
            lblSubTotal2.Text = String.Empty;
            lblTotalGral.Text = String.Empty;
        }

        private void cargarCmbVendedores()
        {
            //CARGA DE COMBOBOX DE VENDEDORES
            DataTable dt = Controller.Usuarios.ObtenerListaDeVendedores();
            DataRow dr = dt.NewRow();

            dr["IdUsuario"] = -1;
            dr["Descripcion"] = "Todos";
            dt.Rows.InsertAt(dr, 0);

            cmbVendedor.ValueMember = "IdUsuario";
            cmbVendedor.DisplayMember = "Descripcion";
            cmbVendedor.DataSource = dt;
        }

        private void CargarCmbCompras()
        {
            //CARGA DE COMBOBOX DE COMPRAS
            if ((int)(cmbVendedor.SelectedValue) > 0)
            {                
                cmbCompraHasta.DataSource = Controller.Compras.ArmarListaCompraHasta((int)cmbVendedor.SelectedValue);
                cmbCompraHasta.DisplayMember = "IdCompra";
                cmbCompraHasta.ValueMember = "IdCompra";                
                
                
                cmbCompraDesde.DisplayMember = "IdCompra";
                cmbCompraDesde.ValueMember = "IdCompra";
                cmbCompraDesde.DataSource = Controller.Compras.ArmarListaCompraDesde((int)cmbVendedor.SelectedValue);                
                cmbCompraDesde.Enabled = false;
            }        
        }

        private void cmbVendedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCmbCompras();
        }
        
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if ((int)cmbVendedor.SelectedValue != -1)
            {
                dgvFacturasItems.DataSource = Controller.Compras.ArmarListaComprasAFacturar((int)cmbVendedor.SelectedValue, (int)cmbCompraHasta.SelectedValue);
                dgvVisibilidades.DataSource = Controller.Compras.ObtenerGastosPorVisibilidad((int)cmbVendedor.SelectedValue, (int)cmbCompraHasta.SelectedValue);
                Double sumaItems = dgvFacturasItems.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToDouble(x.Cells["COMISION"].Value));
                Double sumaVisibilidad = dgvVisibilidades.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToDouble(x.Cells["PRECIO POR PUBLICAR"].Value));
                Double suma = sumaItems + sumaVisibilidad;
                lblSubTotal1.Text = "$ " + sumaItems.ToString();
                lblSubTotal2.Text = "$ " + sumaVisibilidad.ToString();
                lblTotalGral.Text = "$ " + suma.ToString();
            }
        }

        private void CargaCmbFormasPago()
        {            
            cmbFormasDePago.ValueMember = "IdFormaPago";
            cmbFormasDePago.DisplayMember = "Descripcion";
            cmbFormasDePago.DataSource = Controller.FormaPago.ObtenerFormasPago();
        }

        private void CambiarVisibilidadFormasPago(Boolean estado)
        {
            txtTitular.Visible = estado;
            mtxtCodSeguridad.Visible = estado;
            mtxtFechaVenc.Visible = estado;
            mtxtNroTarjeta.Visible = estado;
            lblTitular.Visible = estado;
            lblCodSeg.Visible = estado;
            lblFechaVenc.Visible = estado;
            lblNroTarjeta.Visible = estado;
        }

        private void cmbFormasDePago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((int)cmbFormasDePago.SelectedValue != 1)
                CambiarVisibilidadFormasPago(true);

            if ((int)cmbFormasDePago.SelectedValue == 1)
                CambiarVisibilidadFormasPago(false);
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {

            if ((int)cmbVendedor.SelectedValue != -1)
            {
                if (dgvFacturasItems.Rows.Count > 0 || dgvVisibilidades.Rows.Count > 0)
                {                                     
                    DateTime fecha;
                    int codSeg;
                    
                    if (String.IsNullOrEmpty(mtxtCodSeguridad.Text))
                    {
                        codSeg = 0;
                    }
                    else
                    {
                        codSeg = Convert.ToInt32(mtxtCodSeguridad.Text);
                    }

                    if (!DateTime.TryParse(mtxtFechaVenc.Text,out fecha))
                    {
                         fecha = Convert.ToDateTime("2014-01-01");
                    }
                    
                    Controller.FacturarPublicaciones.GenerarFactura((int)cmbVendedor.SelectedValue,(int)cmbCompraHasta.SelectedValue,(int)cmbFormasDePago.SelectedValue,mtxtNroTarjeta.Text,fecha,codSeg,txtTitular.Text);
                    
                    this.Dispose();
                }
            }
            else
            {
                epVendedor.SetError(cmbVendedor,"Debe Seleccionar un Vendedor.");
            }
        }

        public void CargarDatos(Form vtn, int usr)
        {
            this.vtnAnterior = vtn;
            this.idUsuario = usr;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}
