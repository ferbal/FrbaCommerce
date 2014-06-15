namespace FrbaCommerce.View.Login
{
    partial class LoginForm
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
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNuevoPass = new System.Windows.Forms.Label();
            this.lblConfNuevoPass = new System.Windows.Forms.Label();
            this.txtNuevoPass = new System.Windows.Forms.TextBox();
            this.txtConfNuevoPass = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Location = new System.Drawing.Point(38, 66);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(104, 13);
            this.lblNombreUsuario.TabIndex = 0;
            this.lblNombreUsuario.Text = "Nombre de Usuario: ";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(38, 93);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(59, 13);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Password: ";
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.Location = new System.Drawing.Point(149, 58);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(175, 20);
            this.txtNombreUsuario.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(149, 86);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(175, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(345, 57);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(345, 86);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(75, 23);
            this.btnRegistrar.TabIndex = 5;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 30);
            this.label1.TabIndex = 6;
            this.label1.Text = "UTN FRBA Commerce";            
            // 
            // lblNuevoPass
            // 
            this.lblNuevoPass.AutoSize = true;
            this.lblNuevoPass.Location = new System.Drawing.Point(38, 118);
            this.lblNuevoPass.Name = "lblNuevoPass";
            this.lblNuevoPass.Size = new System.Drawing.Size(112, 13);
            this.lblNuevoPass.TabIndex = 7;
            this.lblNuevoPass.Text = "Ingresar Nuevo Pass.:";
            // 
            // lblConfNuevoPass
            // 
            this.lblConfNuevoPass.AutoSize = true;
            this.lblConfNuevoPass.Location = new System.Drawing.Point(38, 147);
            this.lblConfNuevoPass.Name = "lblConfNuevoPass";
            this.lblConfNuevoPass.Size = new System.Drawing.Size(103, 13);
            this.lblConfNuevoPass.TabIndex = 8;
            this.lblConfNuevoPass.Text = "Confirmar Password:";
            // 
            // txtNuevoPass
            // 
            this.txtNuevoPass.Location = new System.Drawing.Point(149, 115);
            this.txtNuevoPass.Name = "txtNuevoPass";
            this.txtNuevoPass.PasswordChar = '*';
            this.txtNuevoPass.Size = new System.Drawing.Size(175, 20);
            this.txtNuevoPass.TabIndex = 9;
            // 
            // txtConfNuevoPass
            // 
            this.txtConfNuevoPass.Location = new System.Drawing.Point(149, 144);
            this.txtConfNuevoPass.Name = "txtConfNuevoPass";
            this.txtConfNuevoPass.PasswordChar = '*';
            this.txtConfNuevoPass.Size = new System.Drawing.Size(175, 20);
            this.txtConfNuevoPass.TabIndex = 10;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 198);
            this.Controls.Add(this.txtConfNuevoPass);
            this.Controls.Add(this.txtNuevoPass);
            this.Controls.Add(this.lblConfNuevoPass);
            this.Controls.Add(this.lblNuevoPass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtNombreUsuario);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblNombreUsuario);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "LoginForm";
            this.Text = "Ingreso al Sistema";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtNombreUsuario;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNuevoPass;
        private System.Windows.Forms.Label lblConfNuevoPass;
        private System.Windows.Forms.TextBox txtNuevoPass;
        private System.Windows.Forms.TextBox txtConfNuevoPass;
    }
}