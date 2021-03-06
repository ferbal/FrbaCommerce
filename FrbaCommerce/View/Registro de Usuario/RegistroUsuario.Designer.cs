﻿namespace FrbaCommerce.View.Registro_de_Usuario
{
    partial class RegistroUsuario
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
            if(ventanaAnterior!=null)
                this.ventanaAnterior.Visible = true;

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
            this.cmbTiposPersona = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlCliente = new System.Windows.Forms.Panel();
            this.mcFecha = new System.Windows.Forms.MonthCalendar();
            this.btnSeleccionarFecha = new System.Windows.Forms.Button();
            this.clbRoles = new System.Windows.Forms.CheckedListBox();
            this.txtError = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtNombreContacto = new System.Windows.Forms.TextBox();
            this.lblNombreContacto = new System.Windows.Forms.Label();
            this.lblFechaNac = new System.Windows.Forms.Label();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.lblRazonSocial = new System.Windows.Forms.Label();
            this.lblCodigoPostal = new System.Windows.Forms.Label();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.lblDepto = new System.Windows.Forms.Label();
            this.lblPisoNro = new System.Windows.Forms.Label();
            this.lblCalle = new System.Windows.Forms.Label();
            this.lblTipoDocumento = new System.Windows.Forms.Label();
            this.txtFechaNac = new System.Windows.Forms.TextBox();
            this.txtCodigoPostal = new System.Windows.Forms.TextBox();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.txtDepto = new System.Windows.Forms.TextBox();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.cmbTipoDocumento = new System.Windows.Forms.ComboBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.lblCuit = new System.Windows.Forms.Label();
            this.lblNroDocumento = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.epFecha = new System.Windows.Forms.ErrorProvider(this.components);
            this.epTelefono = new System.Windows.Forms.ErrorProvider(this.components);
            this.epLogin = new System.Windows.Forms.ErrorProvider(this.components);
            this.epPass = new System.Windows.Forms.ErrorProvider(this.components);
            this.epApellido = new System.Windows.Forms.ErrorProvider(this.components);
            this.epRazonSocial = new System.Windows.Forms.ErrorProvider(this.components);
            this.epTipoDocumento = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtTelefono = new System.Windows.Forms.MaskedTextBox();
            this.txtDNI = new System.Windows.Forms.MaskedTextBox();
            this.txtCuit = new System.Windows.Forms.MaskedTextBox();
            this.txtPisoNro = new System.Windows.Forms.MaskedTextBox();
            this.pnlCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epTelefono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epApellido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epRazonSocial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epTipoDocumento)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbTiposPersona
            // 
            this.cmbTiposPersona.FormattingEnabled = true;
            this.cmbTiposPersona.Location = new System.Drawing.Point(98, 6);
            this.cmbTiposPersona.Name = "cmbTiposPersona";
            this.cmbTiposPersona.Size = new System.Drawing.Size(152, 21);
            this.cmbTiposPersona.TabIndex = 0;
            this.cmbTiposPersona.SelectedIndexChanged += new System.EventHandler(this.cmbTiposPersona_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tipo de Persona:";
            // 
            // pnlCliente
            // 
            this.pnlCliente.AccessibleDescription = "";
            this.pnlCliente.AccessibleName = "";
            this.pnlCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCliente.Controls.Add(this.txtPisoNro);
            this.pnlCliente.Controls.Add(this.txtCuit);
            this.pnlCliente.Controls.Add(this.txtDNI);
            this.pnlCliente.Controls.Add(this.txtTelefono);
            this.pnlCliente.Controls.Add(this.mcFecha);
            this.pnlCliente.Controls.Add(this.btnSeleccionarFecha);
            this.pnlCliente.Controls.Add(this.clbRoles);
            this.pnlCliente.Controls.Add(this.txtError);
            this.pnlCliente.Controls.Add(this.btnAceptar);
            this.pnlCliente.Controls.Add(this.txtNombreContacto);
            this.pnlCliente.Controls.Add(this.lblNombreContacto);
            this.pnlCliente.Controls.Add(this.lblFechaNac);
            this.pnlCliente.Controls.Add(this.txtRazonSocial);
            this.pnlCliente.Controls.Add(this.lblRazonSocial);
            this.pnlCliente.Controls.Add(this.lblCodigoPostal);
            this.pnlCliente.Controls.Add(this.lblLocalidad);
            this.pnlCliente.Controls.Add(this.lblDepto);
            this.pnlCliente.Controls.Add(this.lblPisoNro);
            this.pnlCliente.Controls.Add(this.lblCalle);
            this.pnlCliente.Controls.Add(this.lblTipoDocumento);
            this.pnlCliente.Controls.Add(this.txtFechaNac);
            this.pnlCliente.Controls.Add(this.txtCodigoPostal);
            this.pnlCliente.Controls.Add(this.txtLocalidad);
            this.pnlCliente.Controls.Add(this.txtDepto);
            this.pnlCliente.Controls.Add(this.txtCalle);
            this.pnlCliente.Controls.Add(this.cmbTipoDocumento);
            this.pnlCliente.Controls.Add(this.lblTelefono);
            this.pnlCliente.Controls.Add(this.txtMail);
            this.pnlCliente.Controls.Add(this.txtApellido);
            this.pnlCliente.Controls.Add(this.txtNombre);
            this.pnlCliente.Controls.Add(this.lblMail);
            this.pnlCliente.Controls.Add(this.lblCuit);
            this.pnlCliente.Controls.Add(this.lblNroDocumento);
            this.pnlCliente.Controls.Add(this.lblApellido);
            this.pnlCliente.Controls.Add(this.lblNombre);
            this.pnlCliente.Location = new System.Drawing.Point(12, 33);
            this.pnlCliente.Name = "pnlCliente";
            this.pnlCliente.Size = new System.Drawing.Size(577, 325);
            this.pnlCliente.TabIndex = 2;
            this.pnlCliente.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCliente_Paint);
            // 
            // mcFecha
            // 
            this.mcFecha.Location = new System.Drawing.Point(329, 105);
            this.mcFecha.MaxSelectionCount = 1;
            this.mcFecha.Name = "mcFecha";
            this.mcFecha.TabIndex = 33;
            this.mcFecha.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.mcFecha_DateSelected);
            // 
            // btnSeleccionarFecha
            // 
            this.btnSeleccionarFecha.Location = new System.Drawing.Point(302, 245);
            this.btnSeleccionarFecha.Name = "btnSeleccionarFecha";
            this.btnSeleccionarFecha.Size = new System.Drawing.Size(20, 23);
            this.btnSeleccionarFecha.TabIndex = 32;
            this.btnSeleccionarFecha.Text = "<";
            this.btnSeleccionarFecha.UseVisualStyleBackColor = true;
            this.btnSeleccionarFecha.Click += new System.EventHandler(this.btnSeleccionarFecha_Click);
            // 
            // clbRoles
            // 
            this.clbRoles.FormattingEnabled = true;
            this.clbRoles.Location = new System.Drawing.Point(320, 139);
            this.clbRoles.Name = "clbRoles";
            this.clbRoles.Size = new System.Drawing.Size(242, 79);
            this.clbRoles.TabIndex = 31;
            // 
            // txtError
            // 
            this.txtError.AutoSize = true;
            this.txtError.Location = new System.Drawing.Point(317, 175);
            this.txtError.Name = "txtError";
            this.txtError.Size = new System.Drawing.Size(0, 13);
            this.txtError.TabIndex = 30;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(487, 293);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtNombreContacto
            // 
            this.txtNombreContacto.Location = new System.Drawing.Point(175, 86);
            this.txtNombreContacto.Name = "txtNombreContacto";
            this.txtNombreContacto.Size = new System.Drawing.Size(121, 20);
            this.txtNombreContacto.TabIndex = 26;
            // 
            // lblNombreContacto
            // 
            this.lblNombreContacto.AutoSize = true;
            this.lblNombreContacto.Location = new System.Drawing.Point(6, 89);
            this.lblNombreContacto.Name = "lblNombreContacto";
            this.lblNombreContacto.Size = new System.Drawing.Size(108, 13);
            this.lblNombreContacto.TabIndex = 3;
            this.lblNombreContacto.Text = "Nombre de Contacto:";
            // 
            // lblFechaNac
            // 
            this.lblFechaNac.AutoSize = true;
            this.lblFechaNac.Location = new System.Drawing.Point(6, 250);
            this.lblFechaNac.Name = "lblFechaNac";
            this.lblFechaNac.Size = new System.Drawing.Size(134, 13);
            this.lblFechaNac.TabIndex = 25;
            this.lblFechaNac.Text = "Fecha de Nac. / Creacion:";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Location = new System.Drawing.Point(175, 59);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(121, 20);
            this.txtRazonSocial.TabIndex = 1;
            this.txtRazonSocial.TextChanged += new System.EventHandler(this.txtRazonSocial_TextChanged);
            // 
            // lblRazonSocial
            // 
            this.lblRazonSocial.AutoSize = true;
            this.lblRazonSocial.Location = new System.Drawing.Point(6, 65);
            this.lblRazonSocial.Name = "lblRazonSocial";
            this.lblRazonSocial.Size = new System.Drawing.Size(73, 13);
            this.lblRazonSocial.TabIndex = 0;
            this.lblRazonSocial.Text = "Razon Social:";
            // 
            // lblCodigoPostal
            // 
            this.lblCodigoPostal.AutoSize = true;
            this.lblCodigoPostal.Location = new System.Drawing.Point(319, 120);
            this.lblCodigoPostal.Name = "lblCodigoPostal";
            this.lblCodigoPostal.Size = new System.Drawing.Size(78, 13);
            this.lblCodigoPostal.TabIndex = 24;
            this.lblCodigoPostal.Text = "Codigo Postal: ";
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Location = new System.Drawing.Point(319, 90);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(59, 13);
            this.lblLocalidad.TabIndex = 23;
            this.lblLocalidad.Text = "Localidad: ";
            // 
            // lblDepto
            // 
            this.lblDepto.AutoSize = true;
            this.lblDepto.Location = new System.Drawing.Point(319, 66);
            this.lblDepto.Name = "lblDepto";
            this.lblDepto.Size = new System.Drawing.Size(36, 13);
            this.lblDepto.TabIndex = 22;
            this.lblDepto.Text = "Depto";
            // 
            // lblPisoNro
            // 
            this.lblPisoNro.AutoSize = true;
            this.lblPisoNro.Location = new System.Drawing.Point(319, 35);
            this.lblPisoNro.Name = "lblPisoNro";
            this.lblPisoNro.Size = new System.Drawing.Size(112, 13);
            this.lblPisoNro.TabIndex = 21;
            this.lblPisoNro.Text = "Piso Nro (En Numero):";
            // 
            // lblCalle
            // 
            this.lblCalle.AutoSize = true;
            this.lblCalle.Location = new System.Drawing.Point(319, 14);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(33, 13);
            this.lblCalle.TabIndex = 20;
            this.lblCalle.Text = "Calle:";
            // 
            // lblTipoDocumento
            // 
            this.lblTipoDocumento.AutoSize = true;
            this.lblTipoDocumento.Location = new System.Drawing.Point(6, 118);
            this.lblTipoDocumento.Name = "lblTipoDocumento";
            this.lblTipoDocumento.Size = new System.Drawing.Size(92, 13);
            this.lblTipoDocumento.TabIndex = 19;
            this.lblTipoDocumento.Text = "Tipo Documento: ";
            // 
            // txtFechaNac
            // 
            this.txtFechaNac.Location = new System.Drawing.Point(175, 247);
            this.txtFechaNac.Name = "txtFechaNac";
            this.txtFechaNac.Size = new System.Drawing.Size(121, 20);
            this.txtFechaNac.TabIndex = 18;
            this.txtFechaNac.TextChanged += new System.EventHandler(this.txtFechaNac_TextChanged);
            // 
            // txtCodigoPostal
            // 
            this.txtCodigoPostal.Location = new System.Drawing.Point(462, 113);
            this.txtCodigoPostal.Name = "txtCodigoPostal";
            this.txtCodigoPostal.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoPostal.TabIndex = 17;
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Location = new System.Drawing.Point(462, 86);
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(100, 20);
            this.txtLocalidad.TabIndex = 16;
            // 
            // txtDepto
            // 
            this.txtDepto.Location = new System.Drawing.Point(462, 59);
            this.txtDepto.MaxLength = 1;
            this.txtDepto.Name = "txtDepto";
            this.txtDepto.Size = new System.Drawing.Size(100, 20);
            this.txtDepto.TabIndex = 15;
            this.txtDepto.TextChanged += new System.EventHandler(this.txtDepto_TextChanged);
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(462, 6);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(100, 20);
            this.txtCalle.TabIndex = 13;
            // 
            // cmbTipoDocumento
            // 
            this.cmbTipoDocumento.FormattingEnabled = true;
            this.cmbTipoDocumento.Location = new System.Drawing.Point(175, 113);
            this.cmbTipoDocumento.Name = "cmbTipoDocumento";
            this.cmbTipoDocumento.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoDocumento.TabIndex = 12;
            this.cmbTipoDocumento.SelectedIndexChanged += new System.EventHandler(this.cmbTipoDocumento_SelectedIndexChanged);
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(6, 222);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(52, 13);
            this.lblTelefono.TabIndex = 10;
            this.lblTelefono.Text = "Telefono:";
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(175, 194);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(121, 20);
            this.txtMail.TabIndex = 9;
            this.txtMail.TextChanged += new System.EventHandler(this.txtMail_TextChanged);
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(175, 32);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(121, 20);
            this.txtApellido.TabIndex = 6;
            this.txtApellido.TextChanged += new System.EventHandler(this.txtApellido_TextChanged);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(175, 7);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(121, 20);
            this.txtNombre.TabIndex = 5;
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(6, 197);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(29, 13);
            this.lblMail.TabIndex = 4;
            this.lblMail.Text = "Mail:";
            // 
            // lblCuit
            // 
            this.lblCuit.AutoSize = true;
            this.lblCuit.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblCuit.Location = new System.Drawing.Point(6, 174);
            this.lblCuit.Name = "lblCuit";
            this.lblCuit.Size = new System.Drawing.Size(70, 13);
            this.lblCuit.TabIndex = 3;
            this.lblCuit.Text = "CUIL / CUIT:";
            // 
            // lblNroDocumento
            // 
            this.lblNroDocumento.AutoSize = true;
            this.lblNroDocumento.Location = new System.Drawing.Point(6, 146);
            this.lblNroDocumento.Name = "lblNroDocumento";
            this.lblNroDocumento.Size = new System.Drawing.Size(85, 13);
            this.lblNroDocumento.TabIndex = 2;
            this.lblNroDocumento.Text = "Nro Documento:";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(6, 38);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(47, 13);
            this.lblApellido.TabIndex = 1;
            this.lblApellido.Text = "Apellido:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(6, 13);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
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
            // epTipoDocumento
            // 
            this.epTipoDocumento.ContainerControl = this;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(175, 220);
            this.txtTelefono.Mask = "0000-0000";
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(121, 20);
            this.txtTelefono.TabIndex = 34;
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(175, 142);
            this.txtDNI.Mask = "00000000";
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(121, 20);
            this.txtDNI.TabIndex = 35;
            // 
            // txtCuit
            // 
            this.txtCuit.Location = new System.Drawing.Point(175, 167);
            this.txtCuit.Mask = "00000000000";
            this.txtCuit.Name = "txtCuit";
            this.txtCuit.Size = new System.Drawing.Size(121, 20);
            this.txtCuit.TabIndex = 36;
            // 
            // txtPisoNro
            // 
            this.txtPisoNro.Location = new System.Drawing.Point(462, 32);
            this.txtPisoNro.Mask = "0";
            this.txtPisoNro.Name = "txtPisoNro";
            this.txtPisoNro.Size = new System.Drawing.Size(100, 20);
            this.txtPisoNro.TabIndex = 37;
            // 
            // RegistroUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 370);
            this.Controls.Add(this.pnlCliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTiposPersona);
            this.Name = "RegistroUsuario";
            this.Text = "Registro de Usuario";
            this.Load += new System.EventHandler(this.RegistroUsuario_Load);
            this.pnlCliente.ResumeLayout(false);
            this.pnlCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epTelefono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epApellido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epRazonSocial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epTipoDocumento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTiposPersona;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlCliente;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Label lblCuit;
        private System.Windows.Forms.Label lblNroDocumento;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblFechaNac;
        private System.Windows.Forms.Label lblCodigoPostal;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.Label lblDepto;
        private System.Windows.Forms.Label lblPisoNro;
        private System.Windows.Forms.Label lblCalle;
        private System.Windows.Forms.Label lblTipoDocumento;
        private System.Windows.Forms.TextBox txtFechaNac;
        private System.Windows.Forms.TextBox txtCodigoPostal;
        private System.Windows.Forms.TextBox txtLocalidad;
        private System.Windows.Forms.TextBox txtDepto;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.ComboBox cmbTipoDocumento;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblRazonSocial;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Label lblNombreContacto;
        private System.Windows.Forms.TextBox txtNombreContacto;
        private System.Windows.Forms.ErrorProvider epFecha;
        private System.Windows.Forms.ErrorProvider epTelefono;
        private System.Windows.Forms.ErrorProvider epLogin;
        private System.Windows.Forms.ErrorProvider epPass;
        private System.Windows.Forms.ErrorProvider epApellido;
        private System.Windows.Forms.ErrorProvider epRazonSocial;
        private System.Windows.Forms.Label txtError;
        private System.Windows.Forms.CheckedListBox clbRoles;
        private System.Windows.Forms.MonthCalendar mcFecha;
        private System.Windows.Forms.Button btnSeleccionarFecha;
        private System.Windows.Forms.ErrorProvider epTipoDocumento;
        private System.Windows.Forms.MaskedTextBox txtCuit;
        private System.Windows.Forms.MaskedTextBox txtDNI;
        private System.Windows.Forms.MaskedTextBox txtTelefono;
        private System.Windows.Forms.MaskedTextBox txtPisoNro;
    }
}