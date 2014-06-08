namespace FrbaCommerce.View.Generar_Publicacion
{
    partial class GenerarPublicacion
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
            this.mtxtFechaInicio = new System.Windows.Forms.MaskedTextBox();
            this.mtxtFechaFin = new System.Windows.Forms.MaskedTextBox();
            this.lblTipoVisibilidad = new System.Windows.Forms.Label();
            this.cmbTipoVisibilidad = new System.Windows.Forms.ComboBox();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.lblCodigoPublicacion = new System.Windows.Forms.Label();
            this.mtxtCodPubli = new System.Windows.Forms.MaskedTextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.mtxtPrecio = new System.Windows.Forms.MaskedTextBox();
            this.clbRubros = new System.Windows.Forms.CheckedListBox();
            this.lblRubros = new System.Windows.Forms.Label();
            this.cmbTiposPublicaciones = new System.Windows.Forms.ComboBox();
            this.lblTipoPubli = new System.Windows.Forms.Label();
            this.rtxtDescripcion = new System.Windows.Forms.RichTextBox();
            this.chbPreguntas = new System.Windows.Forms.CheckBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.epFechaInicio = new System.Windows.Forms.ErrorProvider(this.components);
            this.epStock = new System.Windows.Forms.ErrorProvider(this.components);
            this.epPrecio = new System.Windows.Forms.ErrorProvider(this.components);
            this.epRubros = new System.Windows.Forms.ErrorProvider(this.components);
            this.epDescripcion = new System.Windows.Forms.ErrorProvider(this.components);
            this.mtxtStock = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.epFechaInicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epRubros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epDescripcion)).BeginInit();
            this.SuspendLayout();
            // 
            // mtxtFechaInicio
            // 
            this.mtxtFechaInicio.Location = new System.Drawing.Point(84, 59);
            this.mtxtFechaInicio.Mask = "00/00/0000";
            this.mtxtFechaInicio.Name = "mtxtFechaInicio";
            this.mtxtFechaInicio.Size = new System.Drawing.Size(68, 20);
            this.mtxtFechaInicio.TabIndex = 0;
            this.mtxtFechaInicio.ValidatingType = typeof(System.DateTime);
            this.mtxtFechaInicio.TextChanged += new System.EventHandler(this.mtxtFechaInicio_TextChanged);
            // 
            // mtxtFechaFin
            // 
            this.mtxtFechaFin.Location = new System.Drawing.Point(84, 87);
            this.mtxtFechaFin.Mask = "00/00/0000";
            this.mtxtFechaFin.Name = "mtxtFechaFin";
            this.mtxtFechaFin.Size = new System.Drawing.Size(68, 20);
            this.mtxtFechaFin.TabIndex = 1;
            this.mtxtFechaFin.ValidatingType = typeof(System.DateTime);
            // 
            // lblTipoVisibilidad
            // 
            this.lblTipoVisibilidad.AutoSize = true;
            this.lblTipoVisibilidad.Location = new System.Drawing.Point(283, 35);
            this.lblTipoVisibilidad.Name = "lblTipoVisibilidad";
            this.lblTipoVisibilidad.Size = new System.Drawing.Size(98, 13);
            this.lblTipoVisibilidad.TabIndex = 2;
            this.lblTipoVisibilidad.Text = "Tipo de Visibilidad: ";
            // 
            // cmbTipoVisibilidad
            // 
            this.cmbTipoVisibilidad.FormattingEnabled = true;
            this.cmbTipoVisibilidad.Location = new System.Drawing.Point(381, 32);
            this.cmbTipoVisibilidad.Name = "cmbTipoVisibilidad";
            this.cmbTipoVisibilidad.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoVisibilidad.TabIndex = 3;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(12, 62);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(71, 13);
            this.lblFechaInicio.TabIndex = 4;
            this.lblFechaInicio.Text = "Fecha Inicio: ";
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Location = new System.Drawing.Point(12, 90);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(57, 13);
            this.lblFechaFin.TabIndex = 5;
            this.lblFechaFin.Text = "Fecha Fin:";
            // 
            // lblCodigoPublicacion
            // 
            this.lblCodigoPublicacion.AutoSize = true;
            this.lblCodigoPublicacion.Location = new System.Drawing.Point(12, 9);
            this.lblCodigoPublicacion.Name = "lblCodigoPublicacion";
            this.lblCodigoPublicacion.Size = new System.Drawing.Size(119, 13);
            this.lblCodigoPublicacion.TabIndex = 6;
            this.lblCodigoPublicacion.Text = "Codigo de Publicacion: ";
            // 
            // mtxtCodPubli
            // 
            this.mtxtCodPubli.Location = new System.Drawing.Point(138, 5);
            this.mtxtCodPubli.Mask = "9999999999";
            this.mtxtCodPubli.Name = "mtxtCodPubli";
            this.mtxtCodPubli.Size = new System.Drawing.Size(71, 20);
            this.mtxtCodPubli.TabIndex = 7;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(12, 119);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(69, 13);
            this.lblDescripcion.TabIndex = 8;
            this.lblDescripcion.Text = "Descripcion: ";
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(283, 62);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(41, 13);
            this.lblStock.TabIndex = 10;
            this.lblStock.Text = "Stock: ";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(283, 89);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(40, 13);
            this.lblPrecio.TabIndex = 12;
            this.lblPrecio.Text = "Precio:";
            // 
            // mtxtPrecio
            // 
            this.mtxtPrecio.Location = new System.Drawing.Point(329, 86);
            this.mtxtPrecio.Mask = "999,99";
            this.mtxtPrecio.Name = "mtxtPrecio";
            this.mtxtPrecio.Size = new System.Drawing.Size(46, 20);
            this.mtxtPrecio.TabIndex = 13;
            // 
            // clbRubros
            // 
            this.clbRubros.FormattingEnabled = true;
            this.clbRubros.Location = new System.Drawing.Point(286, 135);
            this.clbRubros.Name = "clbRubros";
            this.clbRubros.Size = new System.Drawing.Size(216, 124);
            this.clbRubros.TabIndex = 14;
            // 
            // lblRubros
            // 
            this.lblRubros.AutoSize = true;
            this.lblRubros.Location = new System.Drawing.Point(283, 119);
            this.lblRubros.Name = "lblRubros";
            this.lblRubros.Size = new System.Drawing.Size(44, 13);
            this.lblRubros.TabIndex = 15;
            this.lblRubros.Text = "Rubros:";
            // 
            // cmbTiposPublicaciones
            // 
            this.cmbTiposPublicaciones.AccessibleDescription = "cmbTipoPublicacion";
            this.cmbTiposPublicaciones.FormattingEnabled = true;
            this.cmbTiposPublicaciones.Location = new System.Drawing.Point(132, 32);
            this.cmbTiposPublicaciones.Name = "cmbTiposPublicaciones";
            this.cmbTiposPublicaciones.Size = new System.Drawing.Size(121, 21);
            this.cmbTiposPublicaciones.TabIndex = 16;
            // 
            // lblTipoPubli
            // 
            this.lblTipoPubli.AutoSize = true;
            this.lblTipoPubli.Location = new System.Drawing.Point(12, 36);
            this.lblTipoPubli.Name = "lblTipoPubli";
            this.lblTipoPubli.Size = new System.Drawing.Size(104, 13);
            this.lblTipoPubli.TabIndex = 17;
            this.lblTipoPubli.Text = "Tipo de Publicacion:";
            // 
            // rtxtDescripcion
            // 
            this.rtxtDescripcion.Location = new System.Drawing.Point(15, 138);
            this.rtxtDescripcion.Name = "rtxtDescripcion";
            this.rtxtDescripcion.Size = new System.Drawing.Size(238, 121);
            this.rtxtDescripcion.TabIndex = 18;
            this.rtxtDescripcion.Text = "";
            // 
            // chbPreguntas
            // 
            this.chbPreguntas.AutoSize = true;
            this.chbPreguntas.Location = new System.Drawing.Point(15, 266);
            this.chbPreguntas.Name = "chbPreguntas";
            this.chbPreguntas.Size = new System.Drawing.Size(159, 17);
            this.chbPreguntas.TabIndex = 19;
            this.chbPreguntas.Text = "Permite Realizar Preguntas?";
            this.chbPreguntas.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(426, 266);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 20;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(286, 265);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 21;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // epFechaInicio
            // 
            this.epFechaInicio.ContainerControl = this;
            // 
            // epStock
            // 
            this.epStock.ContainerControl = this;
            // 
            // epPrecio
            // 
            this.epPrecio.ContainerControl = this;
            // 
            // epRubros
            // 
            this.epRubros.ContainerControl = this;
            // 
            // epDescripcion
            // 
            this.epDescripcion.ContainerControl = this;
            // 
            // mtxtStock
            // 
            this.mtxtStock.Location = new System.Drawing.Point(329, 59);
            this.mtxtStock.Mask = "99999";
            this.mtxtStock.Name = "mtxtStock";
            this.mtxtStock.Size = new System.Drawing.Size(46, 20);
            this.mtxtStock.TabIndex = 22;
            this.mtxtStock.ValidatingType = typeof(int);
            // 
            // GenerarPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 296);
            this.Controls.Add(this.mtxtStock);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.chbPreguntas);
            this.Controls.Add(this.rtxtDescripcion);
            this.Controls.Add(this.lblTipoPubli);
            this.Controls.Add(this.cmbTiposPublicaciones);
            this.Controls.Add(this.lblRubros);
            this.Controls.Add(this.clbRubros);
            this.Controls.Add(this.mtxtPrecio);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.mtxtCodPubli);
            this.Controls.Add(this.lblCodigoPublicacion);
            this.Controls.Add(this.lblFechaFin);
            this.Controls.Add(this.lblFechaInicio);
            this.Controls.Add(this.cmbTipoVisibilidad);
            this.Controls.Add(this.lblTipoVisibilidad);
            this.Controls.Add(this.mtxtFechaFin);
            this.Controls.Add(this.mtxtFechaInicio);
            this.Name = "GenerarPublicacion";
            this.Text = "Generar Publicacion";
            this.Load += new System.EventHandler(this.GenerarPublicacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epFechaInicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epRubros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epDescripcion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox mtxtFechaInicio;
        private System.Windows.Forms.MaskedTextBox mtxtFechaFin;
        private System.Windows.Forms.Label lblTipoVisibilidad;
        private System.Windows.Forms.ComboBox cmbTipoVisibilidad;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.Label lblCodigoPublicacion;
        private System.Windows.Forms.MaskedTextBox mtxtCodPubli;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.MaskedTextBox mtxtPrecio;
        private System.Windows.Forms.CheckedListBox clbRubros;
        private System.Windows.Forms.Label lblRubros;
        private System.Windows.Forms.ComboBox cmbTiposPublicaciones;
        private System.Windows.Forms.Label lblTipoPubli;
        private System.Windows.Forms.RichTextBox rtxtDescripcion;
        private System.Windows.Forms.CheckBox chbPreguntas;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.ErrorProvider epFechaInicio;
        private System.Windows.Forms.ErrorProvider epStock;
        private System.Windows.Forms.ErrorProvider epPrecio;
        private System.Windows.Forms.ErrorProvider epRubros;
        private System.Windows.Forms.ErrorProvider epDescripcion;
        private System.Windows.Forms.MaskedTextBox mtxtStock;
    }
}