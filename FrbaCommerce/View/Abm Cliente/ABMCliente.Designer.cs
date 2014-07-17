namespace FrbaCommerce.View.ABM_Cliente
{
    partial class ABM_de_Cliente
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
            this.vtnAnterior.Visible = true;

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlCliente = new System.Windows.Forms.Panel();
            this.mcFecha = new System.Windows.Forms.MonthCalendar();
            this.btnSeleccionarFecha = new System.Windows.Forms.Button();
            this.txtcuil = new System.Windows.Forms.TextBox();
            this.lblcuil = new System.Windows.Forms.Label();
            this.lblTipoDocumento = new System.Windows.Forms.Label();
            this.cmbTipoDocumento = new System.Windows.Forms.ComboBox();
            this.chkhabilitado = new System.Windows.Forms.CheckBox();
            this.txtError = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblFechaNac = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblCodigoPostal = new System.Windows.Forms.Label();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.lblDepto = new System.Windows.Forms.Label();
            this.lblPisoNro = new System.Windows.Forms.Label();
            this.lblCalle = new System.Windows.Forms.Label();
            this.txtFechaNac = new System.Windows.Forms.TextBox();
            this.txtCodigoPostal = new System.Windows.Forms.TextBox();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.txtDepto = new System.Windows.Forms.TextBox();
            this.txtPisoNro = new System.Windows.Forms.TextBox();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblDNI = new System.Windows.Forms.Label();
            this.epFecha = new System.Windows.Forms.ErrorProvider(this.components);
            this.epTelefono = new System.Windows.Forms.ErrorProvider(this.components);
            this.epLogin = new System.Windows.Forms.ErrorProvider(this.components);
            this.epPass = new System.Windows.Forms.ErrorProvider(this.components);
            this.epApellido = new System.Windows.Forms.ErrorProvider(this.components);
            this.epRazonSocial = new System.Windows.Forms.ErrorProvider(this.components);
            this.epCuil = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnlCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epTelefono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epApellido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epRazonSocial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCuil)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlCliente
            // 
            this.pnlCliente.AccessibleDescription = "";
            this.pnlCliente.AccessibleName = "";
            this.pnlCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCliente.Controls.Add(this.mcFecha);
            this.pnlCliente.Controls.Add(this.btnSeleccionarFecha);
            this.pnlCliente.Controls.Add(this.txtcuil);
            this.pnlCliente.Controls.Add(this.lblcuil);
            this.pnlCliente.Controls.Add(this.lblTipoDocumento);
            this.pnlCliente.Controls.Add(this.cmbTipoDocumento);
            this.pnlCliente.Controls.Add(this.chkhabilitado);
            this.pnlCliente.Controls.Add(this.txtError);
            this.pnlCliente.Controls.Add(this.btnAceptar);
            this.pnlCliente.Controls.Add(this.txtApellido);
            this.pnlCliente.Controls.Add(this.lblApellido);
            this.pnlCliente.Controls.Add(this.lblFechaNac);
            this.pnlCliente.Controls.Add(this.txtNombre);
            this.pnlCliente.Controls.Add(this.lblNombre);
            this.pnlCliente.Controls.Add(this.lblCodigoPostal);
            this.pnlCliente.Controls.Add(this.lblLocalidad);
            this.pnlCliente.Controls.Add(this.lblDepto);
            this.pnlCliente.Controls.Add(this.lblPisoNro);
            this.pnlCliente.Controls.Add(this.lblCalle);
            this.pnlCliente.Controls.Add(this.txtFechaNac);
            this.pnlCliente.Controls.Add(this.txtCodigoPostal);
            this.pnlCliente.Controls.Add(this.txtLocalidad);
            this.pnlCliente.Controls.Add(this.txtDepto);
            this.pnlCliente.Controls.Add(this.txtPisoNro);
            this.pnlCliente.Controls.Add(this.txtCalle);
            this.pnlCliente.Controls.Add(this.txtTelefono);
            this.pnlCliente.Controls.Add(this.lblTelefono);
            this.pnlCliente.Controls.Add(this.txtMail);
            this.pnlCliente.Controls.Add(this.txtDNI);
            this.pnlCliente.Controls.Add(this.lblMail);
            this.pnlCliente.Controls.Add(this.lblDNI);
            this.pnlCliente.Location = new System.Drawing.Point(12, 16);
            this.pnlCliente.Name = "pnlCliente";
            this.pnlCliente.Size = new System.Drawing.Size(884, 292);
            this.pnlCliente.TabIndex = 2;
            // 
            // mcFecha
            // 
            this.mcFecha.Location = new System.Drawing.Point(378, 15);
            this.mcFecha.Name = "mcFecha";
            this.mcFecha.TabIndex = 37;
            this.mcFecha.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.mcFecha_DateSelected);
            // 
            // btnSeleccionarFecha
            // 
            this.btnSeleccionarFecha.Location = new System.Drawing.Point(583, 178);
            this.btnSeleccionarFecha.Name = "btnSeleccionarFecha";
            this.btnSeleccionarFecha.Size = new System.Drawing.Size(22, 23);
            this.btnSeleccionarFecha.TabIndex = 36;
            this.btnSeleccionarFecha.Text = "<";
            this.btnSeleccionarFecha.UseVisualStyleBackColor = true;
            this.btnSeleccionarFecha.Click += new System.EventHandler(this.btnSeleccionarFecha_Click);
            // 
            // txtcuil
            // 
            this.txtcuil.Location = new System.Drawing.Point(177, 182);
            this.txtcuil.Name = "txtcuil";
            this.txtcuil.Size = new System.Drawing.Size(121, 20);
            this.txtcuil.TabIndex = 35;
            // 
            // lblcuil
            // 
            this.lblcuil.AutoSize = true;
            this.lblcuil.Location = new System.Drawing.Point(7, 182);
            this.lblcuil.Name = "lblcuil";
            this.lblcuil.Size = new System.Drawing.Size(34, 13);
            this.lblcuil.TabIndex = 34;
            this.lblcuil.Text = "CUIL:";
            // 
            // lblTipoDocumento
            // 
            this.lblTipoDocumento.AutoSize = true;
            this.lblTipoDocumento.Location = new System.Drawing.Point(6, 80);
            this.lblTipoDocumento.Name = "lblTipoDocumento";
            this.lblTipoDocumento.Size = new System.Drawing.Size(104, 13);
            this.lblTipoDocumento.TabIndex = 33;
            this.lblTipoDocumento.Text = "Tipo de Documento:";
            // 
            // cmbTipoDocumento
            // 
            this.cmbTipoDocumento.FormattingEnabled = true;
            this.cmbTipoDocumento.Location = new System.Drawing.Point(176, 77);
            this.cmbTipoDocumento.Name = "cmbTipoDocumento";
            this.cmbTipoDocumento.Size = new System.Drawing.Size(120, 21);
            this.cmbTipoDocumento.TabIndex = 32;
            // 
            // chkhabilitado
            // 
            this.chkhabilitado.AutoSize = true;
            this.chkhabilitado.Location = new System.Drawing.Point(10, 246);
            this.chkhabilitado.Name = "chkhabilitado";
            this.chkhabilitado.Size = new System.Drawing.Size(124, 17);
            this.chkhabilitado.TabIndex = 31;
            this.chkhabilitado.Text = "Habilitar/Deshabilitar";
            this.chkhabilitado.UseVisualStyleBackColor = true;
            // 
            // txtError
            // 
            this.txtError.AutoSize = true;
            this.txtError.Location = new System.Drawing.Point(317, 216);
            this.txtError.Name = "txtError";
            this.txtError.Size = new System.Drawing.Size(0, 13);
            this.txtError.TabIndex = 30;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(487, 259);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(175, 51);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(121, 20);
            this.txtApellido.TabIndex = 26;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(6, 54);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(44, 13);
            this.lblApellido.TabIndex = 3;
            this.lblApellido.Text = "Apellido";
            // 
            // lblFechaNac
            // 
            this.lblFechaNac.AutoSize = true;
            this.lblFechaNac.Location = new System.Drawing.Point(319, 187);
            this.lblFechaNac.Name = "lblFechaNac";
            this.lblFechaNac.Size = new System.Drawing.Size(134, 13);
            this.lblFechaNac.TabIndex = 25;
            this.lblFechaNac.Text = "Fecha de Nac. / Creacion:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(175, 24);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(121, 20);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtRazonSocial_TextChanged);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(6, 30);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblCodigoPostal
            // 
            this.lblCodigoPostal.AutoSize = true;
            this.lblCodigoPostal.Location = new System.Drawing.Point(319, 161);
            this.lblCodigoPostal.Name = "lblCodigoPostal";
            this.lblCodigoPostal.Size = new System.Drawing.Size(78, 13);
            this.lblCodigoPostal.TabIndex = 24;
            this.lblCodigoPostal.Text = "Codigo Postal: ";
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Location = new System.Drawing.Point(319, 131);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(59, 13);
            this.lblLocalidad.TabIndex = 23;
            this.lblLocalidad.Text = "Localidad: ";
            // 
            // lblDepto
            // 
            this.lblDepto.AutoSize = true;
            this.lblDepto.Location = new System.Drawing.Point(319, 107);
            this.lblDepto.Name = "lblDepto";
            this.lblDepto.Size = new System.Drawing.Size(36, 13);
            this.lblDepto.TabIndex = 22;
            this.lblDepto.Text = "Depto";
            // 
            // lblPisoNro
            // 
            this.lblPisoNro.AutoSize = true;
            this.lblPisoNro.Location = new System.Drawing.Point(319, 80);
            this.lblPisoNro.Name = "lblPisoNro";
            this.lblPisoNro.Size = new System.Drawing.Size(50, 13);
            this.lblPisoNro.TabIndex = 21;
            this.lblPisoNro.Text = "Piso Nro:";
            // 
            // lblCalle
            // 
            this.lblCalle.AutoSize = true;
            this.lblCalle.Location = new System.Drawing.Point(319, 55);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(33, 13);
            this.lblCalle.TabIndex = 20;
            this.lblCalle.Text = "Calle:";
            // 
            // txtFechaNac
            // 
            this.txtFechaNac.Location = new System.Drawing.Point(462, 180);
            this.txtFechaNac.Name = "txtFechaNac";
            this.txtFechaNac.Size = new System.Drawing.Size(100, 20);
            this.txtFechaNac.TabIndex = 18;
            this.txtFechaNac.TextChanged += new System.EventHandler(this.txtFechaNac_TextChanged);
            // 
            // txtCodigoPostal
            // 
            this.txtCodigoPostal.Location = new System.Drawing.Point(462, 154);
            this.txtCodigoPostal.Name = "txtCodigoPostal";
            this.txtCodigoPostal.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoPostal.TabIndex = 17;
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Location = new System.Drawing.Point(462, 127);
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(100, 20);
            this.txtLocalidad.TabIndex = 16;
            // 
            // txtDepto
            // 
            this.txtDepto.Location = new System.Drawing.Point(462, 100);
            this.txtDepto.MaxLength = 1;
            this.txtDepto.Name = "txtDepto";
            this.txtDepto.Size = new System.Drawing.Size(100, 20);
            this.txtDepto.TabIndex = 15;
            this.txtDepto.TextChanged += new System.EventHandler(this.txtDepto_TextChanged);
            // 
            // txtPisoNro
            // 
            this.txtPisoNro.Location = new System.Drawing.Point(462, 73);
            this.txtPisoNro.Name = "txtPisoNro";
            this.txtPisoNro.Size = new System.Drawing.Size(100, 20);
            this.txtPisoNro.TabIndex = 14;
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(462, 47);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(100, 20);
            this.txtCalle.TabIndex = 13;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(177, 157);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(121, 20);
            this.txtTelefono.TabIndex = 11;
            this.txtTelefono.TextChanged += new System.EventHandler(this.txtTelefono_TextChanged);
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(7, 157);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(52, 13);
            this.lblTelefono.TabIndex = 10;
            this.lblTelefono.Text = "Telefono:";
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(176, 129);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(121, 20);
            this.txtMail.TabIndex = 9;
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(176, 103);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(121, 20);
            this.txtDNI.TabIndex = 8;
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(7, 132);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(29, 13);
            this.lblMail.TabIndex = 4;
            this.lblMail.Text = "Mail:";
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblDNI.Location = new System.Drawing.Point(7, 109);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(120, 13);
            this.lblDNI.TabIndex = 3;
            this.lblDNI.Text = "Numero de Documento:";
            // 
            // epFecha
            // 
            this.epFecha.ContainerControl = this;
            // 
            // epTelefono
            // 
            this.epTelefono.ContainerControl = this;
            // 
            // epLogin
            // 
            this.epLogin.ContainerControl = this;
            // 
            // epPass
            // 
            this.epPass.ContainerControl = this;
            // 
            // epApellido
            // 
            this.epApellido.ContainerControl = this;
            // 
            // epRazonSocial
            // 
            this.epRazonSocial.ContainerControl = this;
            // 
            // epCuil
            // 
            this.epCuil.ContainerControl = this;
            // 
            // ABM_de_Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 331);
            this.Controls.Add(this.pnlCliente);
            this.Name = "ABM_de_Cliente";
            this.Text = "Alta, Baja y Modificacion de Cliente";
            this.Load += new System.EventHandler(this.ABM_de_Cliente_Load);
            this.pnlCliente.ResumeLayout(false);
            this.pnlCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epTelefono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epApellido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epRazonSocial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCuil)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCliente;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblFechaNac;
        private System.Windows.Forms.Label lblCodigoPostal;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.Label lblDepto;
        private System.Windows.Forms.Label lblPisoNro;
        private System.Windows.Forms.Label lblCalle;
        private System.Windows.Forms.TextBox txtFechaNac;
        private System.Windows.Forms.TextBox txtCodigoPostal;
        private System.Windows.Forms.TextBox txtLocalidad;
        private System.Windows.Forms.TextBox txtDepto;
        private System.Windows.Forms.TextBox txtPisoNro;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.ErrorProvider epFecha;
        private System.Windows.Forms.ErrorProvider epTelefono;
        private System.Windows.Forms.ErrorProvider epLogin;
        private System.Windows.Forms.ErrorProvider epPass;
        private System.Windows.Forms.ErrorProvider epApellido;
        private System.Windows.Forms.ErrorProvider epRazonSocial;
        private System.Windows.Forms.Label txtError;
        private System.Windows.Forms.CheckBox chkhabilitado;
        private System.Windows.Forms.Label lblTipoDocumento;
        private System.Windows.Forms.ComboBox cmbTipoDocumento;
        private System.Windows.Forms.TextBox txtcuil;
        private System.Windows.Forms.Label lblcuil;
        private System.Windows.Forms.ErrorProvider epCuil;
        private System.Windows.Forms.MonthCalendar mcFecha;
        private System.Windows.Forms.Button btnSeleccionarFecha;
    }
}