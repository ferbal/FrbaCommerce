namespace FrbaCommerce.View.Comprar_Ofertar
{
    partial class CompraOferta
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
            this.mtxtStock = new System.Windows.Forms.MaskedTextBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnComprar = new System.Windows.Forms.Button();
            this.chbPreguntas = new System.Windows.Forms.CheckBox();
            this.rtxtDescripcion = new System.Windows.Forms.RichTextBox();
            this.lblTipoPubli = new System.Windows.Forms.Label();
            this.cmbTiposPublicaciones = new System.Windows.Forms.ComboBox();
            this.lblRubros = new System.Windows.Forms.Label();
            this.mtxtPrecio = new System.Windows.Forms.MaskedTextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.mtxtCodPubli = new System.Windows.Forms.MaskedTextBox();
            this.lblCodigoPublicacion = new System.Windows.Forms.Label();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.cmbTipoVisibilidad = new System.Windows.Forms.ComboBox();
            this.lblTipoVisibilidad = new System.Windows.Forms.Label();
            this.mtxtFechaFin = new System.Windows.Forms.MaskedTextBox();
            this.mtxtFechaInicio = new System.Windows.Forms.MaskedTextBox();
            this.cmbRubros = new System.Windows.Forms.ComboBox();
            this.btnOfertar = new System.Windows.Forms.Button();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.mtxtCantidad = new System.Windows.Forms.MaskedTextBox();
            this.epCantidad = new System.Windows.Forms.ErrorProvider(this.components);
            this.mtxtPrecioOferta = new System.Windows.Forms.MaskedTextBox();
            this.lblPrecioOferta = new System.Windows.Forms.Label();
            this.epPrecioOferta = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.epCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPrecioOferta)).BeginInit();
            this.SuspendLayout();
            // 
            // mtxtStock
            // 
            this.mtxtStock.Location = new System.Drawing.Point(330, 88);
            this.mtxtStock.Mask = "99999";
            this.mtxtStock.Name = "mtxtStock";
            this.mtxtStock.Size = new System.Drawing.Size(46, 20);
            this.mtxtStock.TabIndex = 43;
            this.mtxtStock.ValidatingType = typeof(int);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(265, 340);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 42;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnComprar
            // 
            this.btnComprar.Location = new System.Drawing.Point(346, 340);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(75, 23);
            this.btnComprar.TabIndex = 41;
            this.btnComprar.Text = "Comprar";
            this.btnComprar.UseVisualStyleBackColor = true;
            this.btnComprar.Click += new System.EventHandler(this.btnComprar_Click);
            // 
            // chbPreguntas
            // 
            this.chbPreguntas.AutoSize = true;
            this.chbPreguntas.Location = new System.Drawing.Point(16, 309);
            this.chbPreguntas.Name = "chbPreguntas";
            this.chbPreguntas.Size = new System.Drawing.Size(159, 17);
            this.chbPreguntas.TabIndex = 40;
            this.chbPreguntas.Text = "Permite Realizar Preguntas?";
            this.chbPreguntas.UseVisualStyleBackColor = true;
            // 
            // rtxtDescripcion
            // 
            this.rtxtDescripcion.Location = new System.Drawing.Point(16, 181);
            this.rtxtDescripcion.Name = "rtxtDescripcion";
            this.rtxtDescripcion.Size = new System.Drawing.Size(486, 121);
            this.rtxtDescripcion.TabIndex = 39;
            this.rtxtDescripcion.Text = "";
            // 
            // lblTipoPubli
            // 
            this.lblTipoPubli.AutoSize = true;
            this.lblTipoPubli.Location = new System.Drawing.Point(13, 65);
            this.lblTipoPubli.Name = "lblTipoPubli";
            this.lblTipoPubli.Size = new System.Drawing.Size(104, 13);
            this.lblTipoPubli.TabIndex = 38;
            this.lblTipoPubli.Text = "Tipo de Publicacion:";
            // 
            // cmbTiposPublicaciones
            // 
            this.cmbTiposPublicaciones.AccessibleDescription = "cmbTipoPublicacion";
            this.cmbTiposPublicaciones.FormattingEnabled = true;
            this.cmbTiposPublicaciones.Location = new System.Drawing.Point(133, 61);
            this.cmbTiposPublicaciones.Name = "cmbTiposPublicaciones";
            this.cmbTiposPublicaciones.Size = new System.Drawing.Size(121, 21);
            this.cmbTiposPublicaciones.TabIndex = 37;
            // 
            // lblRubros
            // 
            this.lblRubros.AutoSize = true;
            this.lblRubros.Location = new System.Drawing.Point(284, 148);
            this.lblRubros.Name = "lblRubros";
            this.lblRubros.Size = new System.Drawing.Size(44, 13);
            this.lblRubros.TabIndex = 36;
            this.lblRubros.Text = "Rubros:";
            // 
            // mtxtPrecio
            // 
            this.mtxtPrecio.Location = new System.Drawing.Point(330, 115);
            this.mtxtPrecio.Mask = "999,99";
            this.mtxtPrecio.Name = "mtxtPrecio";
            this.mtxtPrecio.Size = new System.Drawing.Size(46, 20);
            this.mtxtPrecio.TabIndex = 34;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(284, 118);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(40, 13);
            this.lblPrecio.TabIndex = 33;
            this.lblPrecio.Text = "Precio:";
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(284, 91);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(41, 13);
            this.lblStock.TabIndex = 32;
            this.lblStock.Text = "Stock: ";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(13, 162);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(69, 13);
            this.lblDescripcion.TabIndex = 31;
            this.lblDescripcion.Text = "Descripcion: ";
            // 
            // mtxtCodPubli
            // 
            this.mtxtCodPubli.Location = new System.Drawing.Point(139, 34);
            this.mtxtCodPubli.Mask = "9999999999";
            this.mtxtCodPubli.Name = "mtxtCodPubli";
            this.mtxtCodPubli.Size = new System.Drawing.Size(71, 20);
            this.mtxtCodPubli.TabIndex = 30;
            // 
            // lblCodigoPublicacion
            // 
            this.lblCodigoPublicacion.AutoSize = true;
            this.lblCodigoPublicacion.Location = new System.Drawing.Point(13, 38);
            this.lblCodigoPublicacion.Name = "lblCodigoPublicacion";
            this.lblCodigoPublicacion.Size = new System.Drawing.Size(119, 13);
            this.lblCodigoPublicacion.TabIndex = 29;
            this.lblCodigoPublicacion.Text = "Codigo de Publicacion: ";
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Location = new System.Drawing.Point(13, 119);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(57, 13);
            this.lblFechaFin.TabIndex = 28;
            this.lblFechaFin.Text = "Fecha Fin:";
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(13, 91);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(71, 13);
            this.lblFechaInicio.TabIndex = 27;
            this.lblFechaInicio.Text = "Fecha Inicio: ";
            // 
            // cmbTipoVisibilidad
            // 
            this.cmbTipoVisibilidad.FormattingEnabled = true;
            this.cmbTipoVisibilidad.Location = new System.Drawing.Point(382, 61);
            this.cmbTipoVisibilidad.Name = "cmbTipoVisibilidad";
            this.cmbTipoVisibilidad.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoVisibilidad.TabIndex = 26;
            // 
            // lblTipoVisibilidad
            // 
            this.lblTipoVisibilidad.AutoSize = true;
            this.lblTipoVisibilidad.Location = new System.Drawing.Point(284, 64);
            this.lblTipoVisibilidad.Name = "lblTipoVisibilidad";
            this.lblTipoVisibilidad.Size = new System.Drawing.Size(98, 13);
            this.lblTipoVisibilidad.TabIndex = 25;
            this.lblTipoVisibilidad.Text = "Tipo de Visibilidad: ";
            // 
            // mtxtFechaFin
            // 
            this.mtxtFechaFin.Location = new System.Drawing.Point(85, 116);
            this.mtxtFechaFin.Mask = "00/00/0000";
            this.mtxtFechaFin.Name = "mtxtFechaFin";
            this.mtxtFechaFin.Size = new System.Drawing.Size(68, 20);
            this.mtxtFechaFin.TabIndex = 24;
            this.mtxtFechaFin.ValidatingType = typeof(System.DateTime);
            // 
            // mtxtFechaInicio
            // 
            this.mtxtFechaInicio.Location = new System.Drawing.Point(85, 88);
            this.mtxtFechaInicio.Mask = "00/00/0000";
            this.mtxtFechaInicio.Name = "mtxtFechaInicio";
            this.mtxtFechaInicio.Size = new System.Drawing.Size(68, 20);
            this.mtxtFechaInicio.TabIndex = 23;
            this.mtxtFechaInicio.ValidatingType = typeof(System.DateTime);
            // 
            // cmbRubros
            // 
            this.cmbRubros.FormattingEnabled = true;
            this.cmbRubros.Location = new System.Drawing.Point(330, 145);
            this.cmbRubros.Name = "cmbRubros";
            this.cmbRubros.Size = new System.Drawing.Size(173, 21);
            this.cmbRubros.TabIndex = 44;
            // 
            // btnOfertar
            // 
            this.btnOfertar.Location = new System.Drawing.Point(427, 340);
            this.btnOfertar.Name = "btnOfertar";
            this.btnOfertar.Size = new System.Drawing.Size(75, 23);
            this.btnOfertar.TabIndex = 45;
            this.btnOfertar.Text = "Ofertar";
            this.btnOfertar.UseVisualStyleBackColor = true;
            this.btnOfertar.Click += new System.EventHandler(this.btnOfertar_Click);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(305, 310);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(52, 13);
            this.lblCantidad.TabIndex = 46;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // mtxtCantidad
            // 
            this.mtxtCantidad.Location = new System.Drawing.Point(363, 307);
            this.mtxtCantidad.Name = "mtxtCantidad";
            this.mtxtCantidad.Size = new System.Drawing.Size(58, 20);
            this.mtxtCantidad.TabIndex = 47;
            this.mtxtCantidad.TextChanged += new System.EventHandler(this.mtxtCantidad_TextChanged);
            // 
            // epCantidad
            // 
            this.epCantidad.ContainerControl = this;
            // 
            // mtxtPrecioOferta
            // 
            this.mtxtPrecioOferta.Location = new System.Drawing.Point(427, 307);
            this.mtxtPrecioOferta.Name = "mtxtPrecioOferta";
            this.mtxtPrecioOferta.Size = new System.Drawing.Size(75, 20);
            this.mtxtPrecioOferta.TabIndex = 48;
            // 
            // lblPrecioOferta
            // 
            this.lblPrecioOferta.AutoSize = true;
            this.lblPrecioOferta.Location = new System.Drawing.Point(351, 310);
            this.lblPrecioOferta.Name = "lblPrecioOferta";
            this.lblPrecioOferta.Size = new System.Drawing.Size(72, 13);
            this.lblPrecioOferta.TabIndex = 49;
            this.lblPrecioOferta.Text = "Precio Oferta:";
            // 
            // epPrecioOferta
            // 
            this.epPrecioOferta.ContainerControl = this;
            // 
            // CompraOferta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 375);
            this.Controls.Add(this.lblPrecioOferta);
            this.Controls.Add(this.mtxtPrecioOferta);
            this.Controls.Add(this.mtxtCantidad);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.btnOfertar);
            this.Controls.Add(this.cmbRubros);
            this.Controls.Add(this.mtxtStock);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnComprar);
            this.Controls.Add(this.chbPreguntas);
            this.Controls.Add(this.rtxtDescripcion);
            this.Controls.Add(this.lblTipoPubli);
            this.Controls.Add(this.cmbTiposPublicaciones);
            this.Controls.Add(this.lblRubros);
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
            this.Name = "CompraOferta";
            this.Text = "CompraOferta";
            this.Load += new System.EventHandler(this.CompraOferta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epPrecioOferta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox mtxtStock;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnComprar;
        private System.Windows.Forms.CheckBox chbPreguntas;
        private System.Windows.Forms.RichTextBox rtxtDescripcion;
        private System.Windows.Forms.Label lblTipoPubli;
        private System.Windows.Forms.ComboBox cmbTiposPublicaciones;
        private System.Windows.Forms.Label lblRubros;
        private System.Windows.Forms.MaskedTextBox mtxtPrecio;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.MaskedTextBox mtxtCodPubli;
        private System.Windows.Forms.Label lblCodigoPublicacion;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.ComboBox cmbTipoVisibilidad;
        private System.Windows.Forms.Label lblTipoVisibilidad;
        private System.Windows.Forms.MaskedTextBox mtxtFechaFin;
        private System.Windows.Forms.MaskedTextBox mtxtFechaInicio;
        private System.Windows.Forms.ComboBox cmbRubros;
        private System.Windows.Forms.Button btnOfertar;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.MaskedTextBox mtxtCantidad;
        private System.Windows.Forms.ErrorProvider epCantidad;
        private System.Windows.Forms.Label lblPrecioOferta;
        private System.Windows.Forms.MaskedTextBox mtxtPrecioOferta;
        private System.Windows.Forms.ErrorProvider epPrecioOferta;
    }
}