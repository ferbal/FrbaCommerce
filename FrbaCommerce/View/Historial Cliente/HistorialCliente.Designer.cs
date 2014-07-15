namespace FrbaCommerce.View.Historial_Cliente
{
    partial class HistorialCliente
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.cmbTipoHistorial = new System.Windows.Forms.ComboBox();
            this.lblTipoHistorial = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.btnVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(224, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(183, 29);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Historial Cliente";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(13, 47);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(42, 13);
            this.lblCliente.TabIndex = 1;
            this.lblCliente.Text = "Cliente:";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(61, 44);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(163, 20);
            this.txtCliente.TabIndex = 2;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(230, 42);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(75, 23);
            this.btnSeleccionar.TabIndex = 3;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // cmbTipoHistorial
            // 
            this.cmbTipoHistorial.FormattingEnabled = true;
            this.cmbTipoHistorial.Location = new System.Drawing.Point(413, 44);
            this.cmbTipoHistorial.Name = "cmbTipoHistorial";
            this.cmbTipoHistorial.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoHistorial.TabIndex = 4;
            // 
            // lblTipoHistorial
            // 
            this.lblTipoHistorial.AutoSize = true;
            this.lblTipoHistorial.Location = new System.Drawing.Point(336, 47);
            this.lblTipoHistorial.Name = "lblTipoHistorial";
            this.lblTipoHistorial.Size = new System.Drawing.Size(71, 13);
            this.lblTipoHistorial.TabIndex = 5;
            this.lblTipoHistorial.Text = "Tipo Historial:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(540, 42);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Location = new System.Drawing.Point(16, 71);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.Size = new System.Drawing.Size(599, 234);
            this.dgvHistorial.TabIndex = 7;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(540, 311);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 8;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            // 
            // HistorialCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 346);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.dgvHistorial);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblTipoHistorial);
            this.Controls.Add(this.cmbTipoHistorial);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblTitulo);
            this.Name = "HistorialCliente";
            this.Text = "HistorialCliente";
            this.Load += new System.EventHandler(this.HistorialCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.ComboBox cmbTipoHistorial;
        private System.Windows.Forms.Label lblTipoHistorial;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.Button btnVolver;
    }
}