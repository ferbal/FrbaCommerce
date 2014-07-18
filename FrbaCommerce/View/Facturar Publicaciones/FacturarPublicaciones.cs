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
        private int idVendedorSeleccionado = -1;

        public FacturarPublicaciones()
        {
            InitializeComponent();
        }

        private void FacturarPublicaciones_Load(object sender, EventArgs e)
        {
            try
            {
                //cargarCmbVendedores();
                CargaCmbFormasPago();
                CambiarVisibilidadFormasPago(false);

                lblSubTotal1.Text = String.Empty;
                lblSubTotal2.Text = String.Empty;
                lblTotalGral.Text = String.Empty;
                txtVendedor.Enabled = false;
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }
        
        /*
         * CAMBIO EN MODO DE SELECCION DE VENDEDOR
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
        */
        private void CargarCmbCompras()
        {
            //CARGA DE COMBOBOX DE COMPRAS
            if (this.idVendedorSeleccionado > 0)
            {                
                cmbCompraHasta.DataSource = Controller.Compras.ArmarListaCompraHasta(this.idVendedorSeleccionado);
                cmbCompraHasta.DisplayMember = "IdCompra";
                cmbCompraHasta.ValueMember = "IdCompra";                
                
                
                cmbCompraDesde.DisplayMember = "IdCompra";
                cmbCompraDesde.ValueMember = "IdCompra";
                cmbCompraDesde.DataSource = Controller.Compras.ArmarListaCompraDesde(this.idVendedorSeleccionado);                
                cmbCompraDesde.Enabled = false;
            }        
        }

        private void cmbVendedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarCmbCompras();
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }
        
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.idVendedorSeleccionado != -1)
                {
                    dgvFacturasItems.DataSource = Controller.Compras.ArmarListaComprasAFacturar(this.idVendedorSeleccionado, (int)cmbCompraHasta.SelectedValue);
                    dgvVisibilidades.DataSource = Controller.Compras.ObtenerGastosPorVisibilidad(this.idVendedorSeleccionado, (int)cmbCompraHasta.SelectedValue);
                    Double sumaItems = dgvFacturasItems.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToDouble(x.Cells["COMISION"].Value));
                    Double sumaVisibilidad = dgvVisibilidades.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToDouble(x.Cells["PRECIO POR PUBLICAR"].Value));
                    Double suma = sumaItems + sumaVisibilidad;
                    lblSubTotal1.Text = "$ " + sumaItems.ToString();
                    lblSubTotal2.Text = "$ " + sumaVisibilidad.ToString();
                    lblTotalGral.Text = "$ " + suma.ToString();
                }
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
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
            try
            {
                if ((int)cmbFormasDePago.SelectedValue != 1)
                    CambiarVisibilidadFormasPago(true);

                if ((int)cmbFormasDePago.SelectedValue == 1)
                    CambiarVisibilidadFormasPago(false);
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.idVendedorSeleccionado != -1)
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

                        if (!DateTime.TryParse(mtxtFechaVenc.Text, out fecha))
                        {
                            fecha = Convert.ToDateTime("2014-01-01");
                        }

                        Controller.FacturarPublicaciones.GenerarFactura(this.idVendedorSeleccionado, (int)cmbCompraHasta.SelectedValue, (int)cmbFormasDePago.SelectedValue, mtxtNroTarjeta.Text, fecha, codSeg, txtTitular.Text);

                        View.Aviso vtnAviso = new Aviso(this, "La publicacion se ha generado correctamente");
                        vtnAviso.Visible = true;
                        this.Enabled = false;
                    }
                }
                else
                {
                    epVendedor.SetError(txtVendedor, "Debe Seleccionar un Vendedor.");
                }
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }

        public void CargarDatos(Form vtn, int usr)
        {
            this.vtnAnterior = vtn;
            this.idUsuario = usr;
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

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                View.Seleccion.SeleccionCliente vtnSeleccionC = new FrbaCommerce.View.Seleccion.SeleccionCliente();
                vtnSeleccionC.CargarDatosVentana(this, 2);
                vtnSeleccionC.Visible = true;
                this.Visible = false;
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }

        public void CargarSeleccion(int id, String seleccion)
        {
            this.idVendedorSeleccionado = id;
            txtVendedor.Text = seleccion;
        }

        private void txtVendedor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CargarCmbCompras();
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }

    }
}
