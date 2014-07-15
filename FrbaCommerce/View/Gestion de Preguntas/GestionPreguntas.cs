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

        public enum Op
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
            dr["Descripcion"] = "Responder Preguntas";
            dt.Rows.InsertAt(dr, 1);

            dr = dt.NewRow();
            dr["IdCol"] = 2;
            dr["Descripcion"] = "Ofertas";
            dt.Rows.InsertAt(dr, 2);

            cmbTipoOperacion.DataSource = dt;
            cmbTipoOperacion.ValueMember = "IdCol";
            cmbTipoOperacion.DisplayMember = "Descripcion";
        }

        private void cmbTipoOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbTipoOperacion.SelectedValue) == (int)Gestion_de_Preguntas.GestionPreguntas.Op.ResponderPreguntas)
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
    }
}
