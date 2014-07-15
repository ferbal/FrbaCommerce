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
        public Aviso(String msg)
        {
            InitializeComponent();
            lblMensaje.Text = msg;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
