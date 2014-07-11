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
        public FacturarPublicaciones()
        {
            InitializeComponent();
        }

        private void FacturarPublicaciones_Load(object sender, EventArgs e)
        {
            cargarCMB();
        }

        private void cargarCMB()
        {
            DataTable dt = Controller.Usuarios.ObtenerListaDeVendedores();
            DataRow dr = dt.NewRow();

            dr["IdUsuario"] = -1;
            dr["Descripcion"] = "Todos";
            dt.Rows.InsertAt(dr, 0);

            cmbVendedor.DataSource = dt;
            cmbVendedor.DisplayMember = "Descripcion";
            cmbVendedor.ValueMember = "IdUsuario";
        }
    }
}
