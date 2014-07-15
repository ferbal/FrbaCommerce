namespace FrbaCommerce.View.Abm_Visibilidad
{
    partial class VisibilidadAM
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
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblDuracion = new System.Windows.Forms.Label();
            this.lblPrecioPorPublicar = new System.Windows.Forms.Label();
            this.lblPorcentajeVenta = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtDuracion = new System.Windows.Forms.TextBox();
            this.txtPrecioXPublicar = new System.Windows.Forms.TextBox();
            this.txtPrecioXVenta = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.epCodigo = new System.Windows.Forms.ErrorProvider(this.components);
            this.epDescripcion = new System.Windows.Forms.ErrorProvider(this.components);
            this.epDuracion = new System.Windows.Forms.ErrorProvider(this.components);
            this.epPrecioPublicar = new System.Windows.Forms.ErrorProvider(this.components);
            this.epPorcentajeVenta = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnLimpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.epCodigo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epDescripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epDuracion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPrecioPublicar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPorcentajeVenta)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(12, 45);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(43, 13);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Codigo:";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(12, 71);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(66, 13);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Descripcion:";
            // 
            // lblDuracion
            // 
            this.lblDuracion.AutoSize = true;
            this.lblDuracion.Location = new System.Drawing.Point(12, 96);
            this.lblDuracion.Name = "lblDuracion";
            this.lblDuracion.Size = new System.Drawing.Size(96, 13);
            this.lblDuracion.TabIndex = 2;
            this.lblDuracion.Text = "Duracion (en dias):";
            // 
            // lblPrecioPorPublicar
            // 
            this.lblPrecioPorPublicar.AutoSize = true;
            this.lblPrecioPorPublicar.Location = new System.Drawing.Point(12, 123);
            this.lblPrecioPorPublicar.Name = "lblPrecioPorPublicar";
            this.lblPrecioPorPublicar.Size = new System.Drawing.Size(100, 13);
            this.lblPrecioPorPublicar.TabIndex = 3;
            this.lblPrecioPorPublicar.Text = "Precio Por Publicar:";
            // 
            // lblPorcentajeVenta
            // 
            this.lblPorcentajeVenta.AutoSize = true;
            this.lblPorcentajeVenta.Location = new System.Drawing.Point(12, 149);
            this.lblPorcentajeVenta.Name = "lblPorcentajeVenta";
            this.lblPorcentajeVenta.Size = new System.Drawing.Size(111, 13);
            this.lblPorcentajeVenta.TabIndex = 4;
            this.lblPorcentajeVenta.Text = "Porcentaje Por Venta:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(84, 42);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(135, 20);
            this.txtCodigo.TabIndex = 6;
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(84, 68);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(135, 20);
            this.txtDescripcion.TabIndex = 7;
            this.txtDescripcion.TextChanged += new System.EventHandler(this.txtDescripcion_TextChanged);
            // 
            // txtDuracion
            // 
            this.txtDuracion.Location = new System.Drawing.Point(129, 93);
            this.txtDuracion.Name = "txtDuracion";
            this.txtDuracion.Size = new System.Drawing.Size(90, 20);
            this.txtDuracion.TabIndex = 8;
            this.txtDuracion.TextChanged += new System.EventHandler(this.txtDuracion_TextChanged);
            // 
            // txtPrecioXPublicar
            // 
            this.txtPrecioXPublicar.Location = new System.Drawing.Point(129, 120);
            this.txtPrecioXPublicar.Name = "txtPrecioXPublicar";
            this.txtPrecioXPublicar.Size = new System.Drawing.Size(90, 20);
            this.txtPrecioXPublicar.TabIndex = 9;
            this.txtPrecioXPublicar.TextChanged += new System.EventHandler(this.txtPrecioXPublicar_TextChanged);
            // 
            // txtPrecioXVenta
            // 
            this.txtPrecioXVenta.Location = new System.Drawing.Point(129, 146);
            this.txtPrecioXVenta.Name = "txtPrecioXVenta";
            this.txtPrecioXVenta.Size = new System.Drawing.Size(90, 20);
            this.txtPrecioXVenta.TabIndex = 10;
            this.txtPrecioXVenta.TextChanged += new System.EventHandler(this.txtPrecioXVenta_TextChanged);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(96, 197);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 11;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(177, 197);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 12;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(55, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(131, 24);
            this.lblTitulo.TabIndex = 13;
            this.lblTitulo.Text = "Alta Visibilidad";
            // 
            // epCodigo
            // 
            this.epCodigo.ContainerControl = this;
            // 
            // epDescripcion
            // 
            this.epDescripcion.ContainerControl = this;
            // 
            // epDuracion
            // 
            this.epDuracion.ContainerControl = this;
            // 
            // epPrecioPublicar
            // 
            this.epPrecioPublicar.ContainerControl = this;
            // 
            // epPorcentajeVenta
            // 
            this.epPorcentajeVenta.ContainerControl = this;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(15, 197);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 14;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // VisibilidadAM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 232);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtPrecioXVenta);
            this.Controls.Add(this.txtPrecioXPublicar);
            this.Controls.Add(this.txtDuracion);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblPorcentajeVenta);
            this.Controls.Add(this.lblPrecioPorPublicar);
            this.Controls.Add(this.lblDuracion);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblCodigo);
            this.Name = "VisibilidadAM";
            this.Text = "VisibilidadAM";
            this.Load += new System.EventHandler(this.VisibilidadAM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epCodigo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epDescripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epDuracion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPrecioPublicar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPorcentajeVenta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblDuracion;
        private System.Windows.Forms.Label lblPrecioPorPublicar;
        private System.Windows.Forms.Label lblPorcentajeVenta;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtDuracion;
        private System.Windows.Forms.TextBox txtPrecioXPublicar;
        private System.Windows.Forms.TextBox txtPrecioXVenta;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ErrorProvider epCodigo;
        private System.Windows.Forms.ErrorProvider epDescripcion;
        private System.Windows.Forms.ErrorProvider epDuracion;
        private System.Windows.Forms.ErrorProvider epPrecioPublicar;
        private System.Windows.Forms.ErrorProvider epPorcentajeVenta;
        private System.Windows.Forms.Button btnLimpiar;
    }
}