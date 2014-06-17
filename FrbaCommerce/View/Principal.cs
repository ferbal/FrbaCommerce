using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce
{
    public partial class Principal : Form
    {
        private int idUsuario = -1;
        private int rol = -1;
        private Form vtnAnterior = null;

        public Principal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (idUsuario != -1 || rol != -1)
            {
                Dictionary<String, bool> dic = Controller.RolesFuncionalidades.getFuncionalidadesDisponibles(idUsuario, rol);
                habilitarBotones(dic);

            }
        }

        public void cargarInfoUsuario(int usr, int rol, Form anterior)
        {
            this.idUsuario = usr;
            this.rol = rol;
            this.vtnAnterior = anterior;
        }

        private void habilitarBotones(Dictionary<String,bool> dic)
        {
            btnABMCliente.Enabled = dic["ABM de Cliente"];
            btnABMEmpresa.Enabled = dic["ABM de Empresa"];
            btnABMRol.Enabled =dic["ABM de Rol"];
            btnABMRubro.Enabled = dic["ABM de Rubro"];
            btnABMVisibilidad.Enabled = dic["ABM visibilidad"];
            btnCalificarVend.Enabled = dic["Calificar al Vend"];
            btnComprarOfertar.Enabled = dic["Comprar/Ofertar"];
            btnEditarPubli.Enabled = dic["Editar Publicación"];
            btnFacturarPubli.Enabled = dic["Facturar Publi"];
            btnGenerarPubli.Enabled = dic["Generar Publicación"];
            btnGestionarPreg.Enabled = dic["Gestión de Preg"];
            btnHistorialCli.Enabled = dic["Historial del cli"];
            btnListadoEstadistico.Enabled = dic["Listado Estadístico"];            
        }

        private void btnABMRol_Click(object sender, EventArgs e)
        {
            View.ABM_Rol.AdminRol vtnRol = new View.ABM_Rol.AdminRol();
            vtnRol.CargarDatos(this,idUsuario);
            this.Visible = false;
            vtnRol.Visible = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnABMEmpresa_Click(object sender, EventArgs e)
        {
            View.ABM_Empresa.AdminEmpresa vtnABMEmpresa = new FrbaCommerce.View.ABM_Empresa.AdminEmpresa();
            vtnABMEmpresa.ventana_anterior(this);
            this.Visible = false;
            vtnABMEmpresa.Visible = true;
        }

        private void btnGenerarPubli_Click(object sender, EventArgs e)
        {
            View.Generar_Publicacion.GenerarPublicacion vtnPublicacion = new FrbaCommerce.View.Generar_Publicacion.GenerarPublicacion();
            vtnPublicacion.cargarDatos(this,idUsuario);
            this.Visible = false;
            vtnPublicacion.Visible = true;
        }

        private void btnABMCliente_Click(object sender, EventArgs e)
        {
            View.ABM_Cliente.AdminCliente vtnABMCliente = new FrbaCommerce.View.ABM_Cliente.AdminCliente();
            vtnABMCliente.ventana_anterior(this);
            this.Visible = false;
            vtnABMCliente.Visible = true;
        }
    }
}
