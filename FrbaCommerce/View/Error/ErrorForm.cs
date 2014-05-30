using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.View.Error
{
    public partial class ErrorForm : Form
    {
        public ErrorForm(String msg)
        {
            InitializeComponent();
            lblError.Text = msg;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
