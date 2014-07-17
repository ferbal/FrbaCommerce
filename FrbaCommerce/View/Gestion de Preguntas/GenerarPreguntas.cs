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
    public partial class GenerarPreguntas : Form
    {
        private Form vtnAnterior;
        private int idUsuario = -1;
        private int idPublicacion = -1;

        public GenerarPreguntas()
        {
            InitializeComponent();
        }

        private void GenerarPreguntas_Load(object sender, EventArgs e)
        {
            txtCodPublicacion.Enabled = false;
            rtxtDescripcion.Enabled = false;
        }

        public void CargarDatos(Form vtn,int usr,int idPubli,String codPubli,String descripcion)
        {
            this.vtnAnterior = vtn;
            this.idUsuario = usr;
            this.idPublicacion = idPubli;
            txtCodPublicacion.Text = codPubli;
            rtxtDescripcion.Text = descripcion;            
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarDatos())
                {
                    Controller.Preguntas.GenerarPregunta(this.idUsuario,this.idPublicacion,rtxtPregunta.Text);
                    View.Aviso vtnAviso = new Aviso(this,"La Pregunta se realizo correctamente.");
                    this.Enabled = false;
                    vtnAviso.Visible = true;
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

            if (String.IsNullOrEmpty(rtxtPregunta.Text))
            {
                result = false;
                epPregunta.SetError(rtxtPregunta,"La Pregunta es un campo requerido.");
            }

            return result;
        }

        private void rtxtPregunta_TextChanged(object sender, EventArgs e)
        {
            epPregunta.Clear();
        }
    }
}
