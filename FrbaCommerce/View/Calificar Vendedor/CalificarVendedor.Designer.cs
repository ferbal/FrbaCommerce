namespace FrbaCommerce.View.Calificar_Vendedor
{
    partial class CalificarVendedor
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
            if (this.vtnAnterior != null)
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCompras = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mtxtCalificacion = new System.Windows.Forms.MaskedTextBox();
            this.btnCalificar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.txtDetalle = new System.Windows.Forms.TextBox();
            this.epCalificacion = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.epCalificacion)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(56, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(237, 29);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Calificar al Vendedor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Compras a Calificar:";
            // 
            // cmbCompras
            // 
            this.cmbCompras.FormattingEnabled = true;
            this.cmbCompras.Location = new System.Drawing.Point(119, 84);
            this.cmbCompras.Name = "cmbCompras";
            this.cmbCompras.Size = new System.Drawing.Size(220, 21);
            this.cmbCompras.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Calificacion (1-5):";
            // 
            // mtxtCalificacion
            // 
            this.mtxtCalificacion.Location = new System.Drawing.Point(119, 111);
            this.mtxtCalificacion.Mask = "0";
            this.mtxtCalificacion.Name = "mtxtCalificacion";
            this.mtxtCalificacion.Size = new System.Drawing.Size(64, 20);
            this.mtxtCalificacion.TabIndex = 6;
            this.mtxtCalificacion.TextChanged += new System.EventHandler(this.mtxtCalificacion_TextChanged);
            // 
            // btnCalificar
            // 
            this.btnCalificar.Location = new System.Drawing.Point(183, 166);
            this.btnCalificar.Name = "btnCalificar";
            this.btnCalificar.Size = new System.Drawing.Size(75, 23);
            this.btnCalificar.TabIndex = 7;
            this.btnCalificar.Text = "Calificar";
            this.btnCalificar.UseVisualStyleBackColor = true;
            this.btnCalificar.Click += new System.EventHandler(this.btnCalificar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(264, 166);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 8;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblDetalle
            // 
            this.lblDetalle.AutoSize = true;
            this.lblDetalle.Location = new System.Drawing.Point(13, 140);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(43, 13);
            this.lblDetalle.TabIndex = 10;
            this.lblDetalle.Text = "Detalle:";
            // 
            // txtDetalle
            // 
            this.txtDetalle.Location = new System.Drawing.Point(119, 137);
            this.txtDetalle.Name = "txtDetalle";
            this.txtDetalle.Size = new System.Drawing.Size(220, 20);
            this.txtDetalle.TabIndex = 11;
            // 
            // epCalificacion
            // 
            this.epCalificacion.ContainerControl = this;
            // 
            // CalificarVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 201);
            this.Controls.Add(this.txtDetalle);
            this.Controls.Add(this.lblDetalle);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnCalificar);
            this.Controls.Add(this.mtxtCalificacion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbCompras);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTitulo);
            this.Name = "CalificarVendedor";
            this.Text = "Calificar Al Vendedor";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epCalificacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCompras;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox mtxtCalificacion;
        private System.Windows.Forms.Button btnCalificar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.TextBox txtDetalle;
        private System.Windows.Forms.ErrorProvider epCalificacion;
    }
}