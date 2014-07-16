namespace FrbaCommerce.View.Gestion_de_Preguntas
{
    partial class GestionPreguntas
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
            this.btnVolver = new System.Windows.Forms.Button();
            this.dgvGestionPreguntas = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblTipoOperacion = new System.Windows.Forms.Label();
            this.cmbTipoOperacion = new System.Windows.Forms.ComboBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnResponder = new System.Windows.Forms.Button();
            this.epTipoOperacion = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGestionPreguntas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epTipoOperacion)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(536, 340);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 16;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // dgvGestionPreguntas
            // 
            this.dgvGestionPreguntas.AllowUserToAddRows = false;
            this.dgvGestionPreguntas.AllowUserToDeleteRows = false;
            this.dgvGestionPreguntas.AllowUserToResizeColumns = false;
            this.dgvGestionPreguntas.AllowUserToResizeRows = false;
            this.dgvGestionPreguntas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGestionPreguntas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGestionPreguntas.Location = new System.Drawing.Point(12, 71);
            this.dgvGestionPreguntas.Name = "dgvGestionPreguntas";
            this.dgvGestionPreguntas.RowHeadersVisible = false;
            this.dgvGestionPreguntas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGestionPreguntas.Size = new System.Drawing.Size(599, 263);
            this.dgvGestionPreguntas.TabIndex = 15;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(536, 42);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 14;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblTipoOperacion
            // 
            this.lblTipoOperacion.AutoSize = true;
            this.lblTipoOperacion.Location = new System.Drawing.Point(320, 47);
            this.lblTipoOperacion.Name = "lblTipoOperacion";
            this.lblTipoOperacion.Size = new System.Drawing.Size(83, 13);
            this.lblTipoOperacion.TabIndex = 13;
            this.lblTipoOperacion.Text = "Tipo Operacion:";
            // 
            // cmbTipoOperacion
            // 
            this.cmbTipoOperacion.FormattingEnabled = true;
            this.cmbTipoOperacion.Location = new System.Drawing.Point(409, 44);
            this.cmbTipoOperacion.Name = "cmbTipoOperacion";
            this.cmbTipoOperacion.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoOperacion.TabIndex = 12;
            this.cmbTipoOperacion.SelectedIndexChanged += new System.EventHandler(this.cmbTipoOperacion_SelectedIndexChanged);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(199, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(232, 29);
            this.lblTitulo.TabIndex = 17;
            this.lblTitulo.Text = "Gestionar Preguntas";
            // 
            // btnResponder
            // 
            this.btnResponder.Location = new System.Drawing.Point(12, 341);
            this.btnResponder.Name = "btnResponder";
            this.btnResponder.Size = new System.Drawing.Size(75, 23);
            this.btnResponder.TabIndex = 18;
            this.btnResponder.Text = "Responder";
            this.btnResponder.UseVisualStyleBackColor = true;
            this.btnResponder.Click += new System.EventHandler(this.btnResponder_Click);
            // 
            // epTipoOperacion
            // 
            this.epTipoOperacion.ContainerControl = this;
            // 
            // GestionPreguntas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 377);
            this.Controls.Add(this.btnResponder);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.dgvGestionPreguntas);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblTipoOperacion);
            this.Controls.Add(this.cmbTipoOperacion);
            this.Name = "GestionPreguntas";
            this.Text = "GestionPreguntas";
            this.Load += new System.EventHandler(this.GestionPreguntas_Load);
            this.VisibleChanged += new System.EventHandler(this.GestionPreguntas_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGestionPreguntas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epTipoOperacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.DataGridView dgvGestionPreguntas;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblTipoOperacion;
        private System.Windows.Forms.ComboBox cmbTipoOperacion;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnResponder;
        private System.Windows.Forms.ErrorProvider epTipoOperacion;
    }
}