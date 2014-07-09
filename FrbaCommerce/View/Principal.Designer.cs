using System.Windows.Forms;
namespace FrbaCommerce
{
    partial class Principal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
            Application.Exit();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnABMRol = new System.Windows.Forms.Button();
            this.btnHistorialCli = new System.Windows.Forms.Button();
            this.btnComprarOfertar = new System.Windows.Forms.Button();
            this.btnGestionarPreg = new System.Windows.Forms.Button();
            this.btnGenerarPubli = new System.Windows.Forms.Button();
            this.btnListadoEstadistico = new System.Windows.Forms.Button();
            this.btnFacturarPubli = new System.Windows.Forms.Button();
            this.btnCalificarVend = new System.Windows.Forms.Button();
            this.btnABMVisibilidad = new System.Windows.Forms.Button();
            this.btnABMRubro = new System.Windows.Forms.Button();
            this.btnABMEmpresa = new System.Windows.Forms.Button();
            this.btnABMCliente = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnABMRol
            // 
            this.btnABMRol.Location = new System.Drawing.Point(12, 63);
            this.btnABMRol.Name = "btnABMRol";
            this.btnABMRol.Size = new System.Drawing.Size(154, 23);
            this.btnABMRol.TabIndex = 0;
            this.btnABMRol.Text = "ABM Rol";
            this.btnABMRol.UseVisualStyleBackColor = true;
            this.btnABMRol.Click += new System.EventHandler(this.btnABMRol_Click);
            // 
            // btnHistorialCli
            // 
            this.btnHistorialCli.Location = new System.Drawing.Point(178, 150);
            this.btnHistorialCli.Name = "btnHistorialCli";
            this.btnHistorialCli.Size = new System.Drawing.Size(154, 23);
            this.btnHistorialCli.TabIndex = 3;
            this.btnHistorialCli.Text = "Historial Cliente";
            this.btnHistorialCli.UseVisualStyleBackColor = true;
            // 
            // btnComprarOfertar
            // 
            this.btnComprarOfertar.Location = new System.Drawing.Point(178, 121);
            this.btnComprarOfertar.Name = "btnComprarOfertar";
            this.btnComprarOfertar.Size = new System.Drawing.Size(154, 23);
            this.btnComprarOfertar.TabIndex = 4;
            this.btnComprarOfertar.Text = "Comprar / Ofertar";
            this.btnComprarOfertar.UseVisualStyleBackColor = true;
            this.btnComprarOfertar.Click += new System.EventHandler(this.btnComprarOfertar_Click);
            // 
            // btnGestionarPreg
            // 
            this.btnGestionarPreg.Location = new System.Drawing.Point(178, 92);
            this.btnGestionarPreg.Name = "btnGestionarPreg";
            this.btnGestionarPreg.Size = new System.Drawing.Size(154, 23);
            this.btnGestionarPreg.TabIndex = 5;
            this.btnGestionarPreg.Text = "Gestionar Preguntas";
            this.btnGestionarPreg.UseVisualStyleBackColor = true;
            // 
            // btnGenerarPubli
            // 
            this.btnGenerarPubli.Location = new System.Drawing.Point(178, 63);
            this.btnGenerarPubli.Name = "btnGenerarPubli";
            this.btnGenerarPubli.Size = new System.Drawing.Size(154, 23);
            this.btnGenerarPubli.TabIndex = 7;
            this.btnGenerarPubli.Text = "Administrador Publicaciones";
            this.btnGenerarPubli.UseVisualStyleBackColor = true;
            this.btnGenerarPubli.Click += new System.EventHandler(this.btnGenerarPubli_Click);
            // 
            // btnListadoEstadistico
            // 
            this.btnListadoEstadistico.Location = new System.Drawing.Point(343, 121);
            this.btnListadoEstadistico.Name = "btnListadoEstadistico";
            this.btnListadoEstadistico.Size = new System.Drawing.Size(154, 23);
            this.btnListadoEstadistico.TabIndex = 8;
            this.btnListadoEstadistico.Text = "Listado Estadistico";
            this.btnListadoEstadistico.UseVisualStyleBackColor = true;
            // 
            // btnFacturarPubli
            // 
            this.btnFacturarPubli.Location = new System.Drawing.Point(343, 92);
            this.btnFacturarPubli.Name = "btnFacturarPubli";
            this.btnFacturarPubli.Size = new System.Drawing.Size(154, 23);
            this.btnFacturarPubli.TabIndex = 9;
            this.btnFacturarPubli.Text = "Facturar Publicacion";
            this.btnFacturarPubli.UseVisualStyleBackColor = true;
            // 
            // btnCalificarVend
            // 
            this.btnCalificarVend.Location = new System.Drawing.Point(343, 63);
            this.btnCalificarVend.Name = "btnCalificarVend";
            this.btnCalificarVend.Size = new System.Drawing.Size(154, 23);
            this.btnCalificarVend.TabIndex = 10;
            this.btnCalificarVend.Text = "Calificar Vendedor";
            this.btnCalificarVend.UseVisualStyleBackColor = true;
            // 
            // btnABMVisibilidad
            // 
            this.btnABMVisibilidad.Location = new System.Drawing.Point(343, 150);
            this.btnABMVisibilidad.Name = "btnABMVisibilidad";
            this.btnABMVisibilidad.Size = new System.Drawing.Size(154, 23);
            this.btnABMVisibilidad.TabIndex = 11;
            this.btnABMVisibilidad.Text = "ABM Visibilidad";
            this.btnABMVisibilidad.UseVisualStyleBackColor = true;
            // 
            // btnABMRubro
            // 
            this.btnABMRubro.Location = new System.Drawing.Point(12, 150);
            this.btnABMRubro.Name = "btnABMRubro";
            this.btnABMRubro.Size = new System.Drawing.Size(154, 23);
            this.btnABMRubro.TabIndex = 12;
            this.btnABMRubro.Text = "ABM Rubro";
            this.btnABMRubro.UseVisualStyleBackColor = true;
            // 
            // btnABMEmpresa
            // 
            this.btnABMEmpresa.Location = new System.Drawing.Point(11, 121);
            this.btnABMEmpresa.Name = "btnABMEmpresa";
            this.btnABMEmpresa.Size = new System.Drawing.Size(155, 23);
            this.btnABMEmpresa.TabIndex = 13;
            this.btnABMEmpresa.Text = "ABM Empresa";
            this.btnABMEmpresa.UseVisualStyleBackColor = true;
            this.btnABMEmpresa.Click += new System.EventHandler(this.btnABMEmpresa_Click);
            // 
            // btnABMCliente
            // 
            this.btnABMCliente.Location = new System.Drawing.Point(12, 92);
            this.btnABMCliente.Name = "btnABMCliente";
            this.btnABMCliente.Size = new System.Drawing.Size(154, 23);
            this.btnABMCliente.TabIndex = 14;
            this.btnABMCliente.Text = "ABM Cliente";
            this.btnABMCliente.UseVisualStyleBackColor = true;
            this.btnABMCliente.Click += new System.EventHandler(this.btnABMCliente_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(422, 211);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 15;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 246);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnABMCliente);
            this.Controls.Add(this.btnABMEmpresa);
            this.Controls.Add(this.btnABMRubro);
            this.Controls.Add(this.btnABMVisibilidad);
            this.Controls.Add(this.btnCalificarVend);
            this.Controls.Add(this.btnFacturarPubli);
            this.Controls.Add(this.btnListadoEstadistico);
            this.Controls.Add(this.btnGenerarPubli);
            this.Controls.Add(this.btnGestionarPreg);
            this.Controls.Add(this.btnComprarOfertar);
            this.Controls.Add(this.btnHistorialCli);
            this.Controls.Add(this.btnABMRol);
            this.Name = "Principal";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnABMRol;
        private System.Windows.Forms.Button btnHistorialCli;
        private System.Windows.Forms.Button btnComprarOfertar;
        private System.Windows.Forms.Button btnGestionarPreg;
        private System.Windows.Forms.Button btnGenerarPubli;
        private System.Windows.Forms.Button btnListadoEstadistico;
        private System.Windows.Forms.Button btnFacturarPubli;
        private System.Windows.Forms.Button btnCalificarVend;
        private System.Windows.Forms.Button btnABMVisibilidad;
        private System.Windows.Forms.Button btnABMRubro;
        private System.Windows.Forms.Button btnABMEmpresa;
        private System.Windows.Forms.Button btnABMCliente;
        private System.Windows.Forms.Button btnSalir;
    }
}

