namespace FrbaCommerce.View.ListadoEstadistico
{
    partial class ListadoEstadistico
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
            this.dgvRoles = new System.Windows.Forms.DataGridView();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbAnio = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTrimestre = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbListado = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRoles
            // 
            this.dgvRoles.AllowUserToAddRows = false;
            this.dgvRoles.AllowUserToDeleteRows = false;
            this.dgvRoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRoles.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            this.dgvRoles.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoles.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dgvRoles.Location = new System.Drawing.Point(12, 83);
            this.dgvRoles.MultiSelect = false;
            this.dgvRoles.Name = "dgvRoles";
            this.dgvRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRoles.Size = new System.Drawing.Size(603, 160);
            this.dgvRoles.TabIndex = 1;
            this.dgvRoles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(459, 257);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(540, 257);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 4;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(540, 54);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(75, 23);
            this.btnGenerar.TabIndex = 9;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Año:";
            // 
            // cmbAnio
            // 
            this.cmbAnio.FormattingEnabled = true;
            this.cmbAnio.Location = new System.Drawing.Point(66, 17);
            this.cmbAnio.Name = "cmbAnio";
            this.cmbAnio.Size = new System.Drawing.Size(73, 21);
            this.cmbAnio.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Trimestre:";
            // 
            // cmbTrimestre
            // 
            this.cmbTrimestre.FormattingEnabled = true;
            this.cmbTrimestre.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cmbTrimestre.Location = new System.Drawing.Point(66, 44);
            this.cmbTrimestre.Name = "cmbTrimestre";
            this.cmbTrimestre.Size = new System.Drawing.Size(34, 21);
            this.cmbTrimestre.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Listado:";
            // 
            // cmbListado
            // 
            this.cmbListado.FormattingEnabled = true;
            this.cmbListado.Items.AddRange(new object[] {
            "VENDEDORES CON MAYOR CANTIDAD DE PRODUCTOS NO VENDIDOS",
            "VENDEDORES CON MAYOR FACTURACION",
            "VENDEDORES CON MAYORES CALIFICACIONES",
            "CLIENTES CON MAYOR CANTIDAD DE PUBLICACIONES SIN CALIFICAR"});
            this.cmbListado.Location = new System.Drawing.Point(193, 17);
            this.cmbListado.Name = "cmbListado";
            this.cmbListado.Size = new System.Drawing.Size(422, 21);
            this.cmbListado.TabIndex = 20;
            // 
            // ListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 292);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbListado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTrimestre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbAnio);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.dgvRoles);
            this.Name = "ListadoEstadistico";
            this.Text = "Listado Estadistico";
            this.Load += new System.EventHandler(this.ListadoEstadistico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRoles;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbAnio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTrimestre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbListado;

    }
}