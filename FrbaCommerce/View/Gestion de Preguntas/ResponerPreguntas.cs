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
    public partial class ResponerPreguntas : Form
    {
        private int idPregunta = -1;
        private int idUsuario = -1;
        private Form vtnAnterior;

        public ResponerPreguntas()
        {
            InitializeComponent();
        }

        private void ResponerPreguntas_Load(object sender, EventArgs e)
        {
            txtPregunta.Enabled = false;
        }

        public void CargarDatos(Form vtn, int usuario, int idPreg, String pregunta)
        {
            this.vtnAnterior = vtn;
            this.idUsuario = usuario;
            this.idPregunta = idPreg;
            txtPregunta.Text = pregunta;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtRespuesta.Text))
            {
                Controller.Respuestas.ResponderPregunta(this.idPregunta, txtRespuesta.Text);
            }
            else
            {
                epRespuesta.SetError(txtRespuesta,"Debe escribir una respuesta.");
            }
        }

        private void txtRespuesta_TextChanged(object sender, EventArgs e)
        {
            epRespuesta.Clear();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
