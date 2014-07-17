using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.View.ABM_Rol
{    
    
    public partial class RolAM : Form
    {

        private Form vtnAnterior;
        private int idRol = -1;        

        public RolAM(Form ant)
        {
            vtnAnterior = ant;            
                       
            InitializeComponent();

        }

        public void asignarRolAModificar(int id,String nombre)
        {
            idRol = id;
            txtNombre.Text = nombre;
            
        }

        private void SeleccionarClbFuncionalidades(DataTable tabla)
        {

            for (int item = 0; item < tabla.Rows.Count; item++)
            {
                foreach (DataRowView view in clbFuncionalidades.Items)
                {                
                    if(view[clbFuncionalidades.DisplayMember].ToString()==tabla.Rows[item]["Descripcion"].ToString())
                    {
  
                        clbFuncionalidades.SetItemChecked(clbFuncionalidades.Items.IndexOf(view), true);
                        break;
                    }
                }
            } 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                clbFuncionalidades.DataSource = Controller.Funcionalidades.CargarListadoFuncionalidades();
                clbFuncionalidades.DisplayMember = "Descripcion";
                clbFuncionalidades.ValueMember = "IdFuncionalidad";
                if (this.idRol != -1)
                {
                    SeleccionarClbFuncionalidades(Controller.RolesFuncionalidades.ObtenerFuncionalidadesDeRol(this.idRol));
                }
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validarDatos())
                {
                    String msg;
                    if (this.idRol == -1)
                    {
                        Controller.Roles.IngresarNuevoRol(txtNombre.Text,ListarFuncionalidadesSeleccionadas());
                        msg = "El Rol se ha generado correctamente.";
                    }
                    else
                    {
                        Controller.Roles.ActualizarRol(this.idRol, txtNombre.Text, ListarFuncionalidadesSeleccionadas());
                        msg = "El Rol se ha actualizado correctamente.";
                    }
                    View.Aviso vtnAviso = new Aviso(this,msg);
                    vtnAviso.Visible = true;
                    this.Enabled = false;                    
                }                
            }
            catch (Exception ex)
            {
                View.Error.ErrorForm vtnError = new FrbaCommerce.View.Error.ErrorForm(ex.Message);
                vtnError.Visible = true;
            }
        }

        private Boolean validarDatos()
        {
            Boolean estado = true;

            if (String.IsNullOrEmpty(txtNombre.Text))
            {
                epNombre.SetError(txtNombre, "El Nombre es un campo requerido.");
                estado = false;
            }

            return estado;

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {            
            epNombre.Clear();
        }

        private List<int> ListarFuncionalidadesSeleccionadas()
        {
            try
            {
                List<int> lista = new List<int>();
                CheckedListBox.CheckedItemCollection cd = clbFuncionalidades.CheckedItems;

                foreach (DataRowView item in cd)
                {
                    lista.Add(Convert.ToInt32(item.Row.ItemArray[0]));
                }

                return lista;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
