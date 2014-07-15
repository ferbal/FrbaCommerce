using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.View.Abm_Visibilidad
{
    public partial class AdminVisibilidad : Form
    {
        private Form vtnAnterior;
        private int idUsuario = -1;        

        public AdminVisibilidad()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarDGV();
        }

        private void CargarDGV()
        {
            int codigo = -1;

            if (!Int32.TryParse(txtCodigo.Text, out codigo))
            {
                codigo = -1;
            }
            
            dgvVisibilidades.DataSource = Controller.Visibilidades.ObtenerVisibilidades(codigo, txtDescripcion.Text);
            dgvVisibilidades.Columns["IdVisibilidad"].Visible = false;
            dgvVisibilidades.Columns["IdEstado"].Visible = false;            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = String.Empty;
            txtDescripcion.Text = String.Empty;
        }

        private void CargarDatos(Form vtn, int usr)
        {
            this.vtnAnterior = vtn;
            this.idUsuario = usr;
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            View.Abm_Visibilidad.VisibilidadAM vtnAlta = new VisibilidadAM();
            vtnAlta.CargarDatos(this,this.idUsuario,"Alta de Visibilidad");
            vtnAlta.Visible = true;
            this.Visible = false;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            View.Abm_Visibilidad.VisibilidadAM vtnModV = new VisibilidadAM();
            vtnModV.CargarDatos(this,this.idUsuario,"Modificar Visibilidad");

            DataGridViewSelectedRowCollection rows = dgvVisibilidades.SelectedRows;
            Model.Visibilidad v = new FrbaCommerce.Model.Visibilidad();
            if (rows.Count == 1)
            {
                DataGridViewCellCollection cell = rows[0].Cells;

                v.IdVisibilidad = Convert.ToInt32(cell["IdVisibilidad"].Value);
                v.Codigo = Convert.ToInt32(cell["Codigo"].Value);
                v.Descripcion = cell["Descripcion"].Value.ToString();
                v.Duracion = Convert.ToInt32(cell["Duracion"].Value);
                v.PrecioPorPublicar = Convert.ToDouble(cell["Precio por Publicar"].Value);
                v.PorcentajeVenta = Convert.ToDouble(cell["Porcentaje de Venta"].Value);
                v.IdEstado = Convert.ToInt32(cell["IdEstado"].Value);

                vtnModV.CargarVisibilidadAModificar(v);    
            }

            vtnModV.Visible = true;
            this.Visible = false;

            
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void AdminVisibilidad_VisibleChanged(object sender, EventArgs e)
        {
            txtCodigo.Text = String.Empty;
            txtDescripcion.Text = String.Empty;
            CargarDGV();
        }

        private void AdminVisibilidad_Load(object sender, EventArgs e)
        {
            CargarDGV();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = -1, estado = -1;
            DataGridViewSelectedRowCollection rows = dgvVisibilidades.SelectedRows;
            
            if (rows.Count == 1)
            {
                DataGridViewCellCollection cell = rows[0].Cells;

                id = Convert.ToInt32(cell["IdVisibilidad"].Value);
                
                estado = Convert.ToInt32(cell["IdEstado"].Value);

                if (estado == (int)Model.Visibilidad.Estados.Habilitado)
                {
                    Controller.Visibilidades.CambiarEstadoVisibilidad(id,(int)Model.Visibilidad.Estados.Deshabilitado);
                }
                else
                {
                    Controller.Visibilidades.CambiarEstadoVisibilidad(id, (int)Model.Visibilidad.Estados.Habilitado);
                }

                CargarDGV();
            }
        }        
    }
}
