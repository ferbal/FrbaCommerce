using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.View.Gestion_de_Preguntas
{
    public partial class GestionPreguntas : Form
    {
        private Form vtnAnterior;
        private int idUsuario = -1;

        public enum TipoOp
        {
            ResponderPreguntas = 1,
            VerRespuestas = 2
        }

        public GestionPreguntas()
        {
            InitializeComponent();
        }

        private void GestionPreguntas_Load(object sender, EventArgs e)
        {
            ArmarCmbTiposOperaciones();
        }

        private void ArmarCmbTiposOperaciones()
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
            dr["Descripcion"] = "Preguntas A Responder";
            dt.Rows.InsertAt(dr, 1);

            dr = dt.NewRow();
            dr["IdCol"] = 2;
            dr["Descripcion"] = "Preguntas Con Respuesta";
            dt.Rows.InsertAt(dr, 2);

            cmbTipoOperacion.ValueMember = "IdCol";
            cmbTipoOperacion.DisplayMember = "Descripcion";
            cmbTipoOperacion.DataSource = dt;
            
        }

        private void cmbTipoOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            epTipoOperacion.Clear();
            if (Convert.ToInt32(cmbTipoOperacion.SelectedValue) == (int)Gestion_de_Preguntas.GestionPreguntas.TipoOp.ResponderPreguntas)
            {
                btnResponder.Enabled = true;
            }
            else
            {
                btnResponder.Enabled = false;
            }
        }

        public void CargarDatos(Form vtn,int usr)
        {
            this.vtnAnterior = vtn;
            this.idUsuario = usr;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cmbTipoOperacion.SelectedValue) != -1)
                {
                    CargarDGV();
                }
                else
                {
                    epTipoOperacion.SetError(cmbTipoOperacion, "Debe Seleccionar un tipo de Operacion.");
                }
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }

        private void btnResponder_Click(object sender, EventArgs e)
        {
            try
            {

                DataGridViewRowCollection rows = dgvGestionPreguntas.Rows;
                DataGridViewCellCollection cells = rows[0].Cells;

                View.Gestion_de_Preguntas.ResponerPreguntas vtnRespuesta = new ResponerPreguntas();
                vtnRespuesta.CargarDatos(this, this.idUsuario, Convert.ToInt32(cells["IdPregunta"].Value), cells["Pregunta"].Value.ToString());
                vtnRespuesta.Visible = true;
                this.Visible = false;
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }

        private void CargarDGV()
        {
            switch (Convert.ToInt32(cmbTipoOperacion.SelectedValue))
            {
                case (int)Gestion_de_Preguntas.GestionPreguntas.TipoOp.ResponderPreguntas:
                    dgvGestionPreguntas.DataSource = Controller.Preguntas.ObtenerPregSinRespuesta(this.idUsuario);
                    dgvGestionPreguntas.Columns["IdPregunta"].Visible = false;
                    break;

                case (int)Gestion_de_Preguntas.GestionPreguntas.TipoOp.VerRespuestas:
                    dgvGestionPreguntas.DataSource = Controller.Preguntas.ObtenerPregConRespuesta(this.idUsuario);
                    break;

                default:
                    break;
            }
        }

        private void GestionPreguntas_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                CargarDGV();
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }
    }
}
