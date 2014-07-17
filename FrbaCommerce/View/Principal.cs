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
        private DateTime FechaSistema;

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

            VerificarEstadoUsuario();
        }

        public void cargarInfoUsuario(int usr, int rol, Form anterior)
        {
            this.idUsuario = usr;
            this.rol = rol;
            this.vtnAnterior = anterior;            
        }

        private void habilitarBotones(Dictionary<String,bool> dic)
        {
            /*
             * Inhabilito los botones segun la funcionalidad permitida
             * 
            btnABMCliente.Enabled = dic["ABM de Cliente"];
            btnABMEmpresa.Enabled = dic["ABM de Empresa"];
            btnABMRol.Enabled =dic["ABM de Rol"];
            btnABMRubro.Enabled = dic["ABM de Rubro"];
            btnABMVisibilidad.Enabled = dic["ABM visibilidad"];
            btnCalificarVend.Enabled = dic["Calificar al Vend"];
            btnComprarOfertar.Enabled = dic["Comprar/Ofertar"];
            //btnEditarPubli.Enabled = dic["Editar Publicación"];
            btnFacturarPubli.Enabled = dic["Facturar Publi"];
            btnGenerarPubli.Enabled = dic["Generar Publicación"];
            btnGestionarPreg.Enabled = dic["Gestión de Preg"];
            btnHistorialCli.Enabled = dic["Historial del cli"];
            btnListadoEstadistico.Enabled = dic["Listado Estadístico"];            
             */

            //Oculto los botones segun la funcionalidad permitida.
            btnABMCliente.Visible = dic["ABM de Cliente"];
            btnABMEmpresa.Visible = dic["ABM de Empresa"];
            btnABMRol.Visible = dic["ABM de Rol"];
            btnABMRubro.Visible = dic["ABM de Rubro"];
            btnABMVisibilidad.Visible = dic["ABM visibilidad"];
            btnCalificarVend.Visible = dic["Calificar al Vend"];
            btnComprarOfertar.Visible = dic["Comprar/Ofertar"];            
            btnFacturarPubli.Visible = dic["Facturar Publi"];
            btnGenerarPubli.Visible = dic["Generar Publicación"];
            btnGestionarPreg.Visible = dic["Gestión de Preg"];
            btnHistorialCli.Visible = dic["Historial del cli"];
            btnListadoEstadistico.Visible = dic["Listado Estadístico"];            
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
            View.Generar_Publicacion.AdminPublicaciones vtnAdminPubli = new FrbaCommerce.View.Generar_Publicacion.AdminPublicaciones();
            vtnAdminPubli.CargarDatos(this,this.idUsuario);
            this.Visible = false;
            vtnAdminPubli.Visible = true;
        }

        private void btnABMCliente_Click(object sender, EventArgs e)
        {
            View.ABM_Cliente.AdminCliente vtnABMCliente = new FrbaCommerce.View.ABM_Cliente.AdminCliente();
            vtnABMCliente.ventana_anterior(this);
            this.Visible = false;
            vtnABMCliente.Visible = true;
        }

        private void btnListadoEstadistico_Click(object sender, EventArgs e)
        {
            View.ListadoEstadistico.ListadoEstadistico vtnListadoEstadistico = new FrbaCommerce.View.ListadoEstadistico.ListadoEstadistico();
            vtnListadoEstadistico.ventana_anterior(this);
            this.Visible = false;
            vtnListadoEstadistico.Visible = true;
        }

        private void btnComprarOfertar_Click(object sender, EventArgs e)
        {
            View.Comprar_Ofertar.AdminCompraOferta vtnAdminCO = new FrbaCommerce.View.Comprar_Ofertar.AdminCompraOferta();
            vtnAdminCO.CargarDatos(this,this.idUsuario);
            this.Visible = false;
            vtnAdminCO.Visible = true;
        }

        private void btnFacturarPubli_Click(object sender, EventArgs e)
        {
            View.Facturar_Publicaciones.FacturarPublicaciones vtnFactPubli = new FrbaCommerce.View.Facturar_Publicaciones.FacturarPublicaciones();
            vtnFactPubli.CargarDatos(this,this.idUsuario);
            vtnFactPubli.Visible = true;
            this.Visible = false;
        }

        private void btnCalificarVend_Click(object sender, EventArgs e)
        {
            View.Calificar_Vendedor.CalificarVendedor vtnCalif = new FrbaCommerce.View.Calificar_Vendedor.CalificarVendedor();
            vtnCalif.CargarDatos(this,this.idUsuario);
            vtnCalif.Visible = true;
            this.Visible = false;
        }

        private void btnGestionarPreg_Click(object sender, EventArgs e)
        {
            View.Gestion_de_Preguntas.GestionPreguntas vtnGestPreg = new FrbaCommerce.View.Gestion_de_Preguntas.GestionPreguntas();
            vtnGestPreg.CargarDatos(this,this.idUsuario);
            vtnGestPreg.Visible = true;
            this.Visible = false;
        }

        private void btnHistorialCli_Click(object sender, EventArgs e)
        {
            View.Historial_Cliente.HistorialCliente vtnHistCli = new FrbaCommerce.View.Historial_Cliente.HistorialCliente();
            vtnHistCli.CargarDatos(this,this.idUsuario);
            vtnHistCli.Visible = true;
            this.Visible = false;
        }

        private void btnABMVisibilidad_Click(object sender, EventArgs e)
        {
            View.Abm_Visibilidad.AdminVisibilidad vtnAdminVis = new FrbaCommerce.View.Abm_Visibilidad.AdminVisibilidad();
            vtnAdminVis.CargarDatos(this,this.idUsuario);
            vtnAdminVis.Visible = true;
            this.Visible = false;
        }

        private void VerificarEstadoUsuario()
        {
            if (Controller.Usuarios.ValidarEstadoDeUsuario(this.idUsuario, (int)Model.Usuarios.Estados.BloqueadoCompraOferta))
            {
                btnComprarOfertar.Enabled = false;
            }
            else
            {
                btnComprarOfertar.Enabled = true;
            }
        }

        private void Principal_VisibleChanged(object sender, EventArgs e)
        {
            VerificarEstadoUsuario();
        }
    }
}
