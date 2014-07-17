using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.View
{
    public partial class Aviso : Form
    {
        private Form vtnAnterior;

        public Aviso(Form vtn,String msg)
        {
            InitializeComponent();
            this.vtnAnterior = vtn;
            lblMensaje.Text = msg;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
