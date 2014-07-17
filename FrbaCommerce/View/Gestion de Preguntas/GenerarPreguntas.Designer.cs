namespace FrbaCommerce.View.Gestion_de_Preguntas
{
    partial class GenerarPreguntas
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblCodPublicacion = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtCodPublicacion = new System.Windows.Forms.TextBox();
            this.rtxtDescripcion = new System.Windows.Forms.RichTextBox();
            this.rtxtPregunta = new System.Windows.Forms.RichTextBox();
            this.lblPregunta = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.epPregunta = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.epPregunta)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(116, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Realizar Pregunta";
            // 
            // lblCodPublicacion
            // 
            this.lblCodPublicacion.AutoSize = true;
            this.lblCodPublicacion.Location = new System.Drawing.Point(13, 47);
            this.lblCodPublicacion.Name = "lblCodPublicacion";
            this.lblCodPublicacion.Size = new System.Drawing.Size(90, 13);
            this.lblCodPublicacion.TabIndex = 1;
            this.lblCodPublicacion.Text = "Cod. Publicacion:";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(13, 67);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(66, 13);
            this.lblDescripcion.TabIndex = 2;
            this.lblDescripcion.Text = "Descripcion:";
            // 
            // txtCodPublicacion
            // 
            this.txtCodPublicacion.Location = new System.Drawing.Point(109, 44);
            this.txtCodPublicacion.Name = "txtCodPublicacion";
            this.txtCodPublicacion.Size = new System.Drawing.Size(85, 20);
            this.txtCodPublicacion.TabIndex = 3;
            // 
            // rtxtDescripcion
            // 
            this.rtxtDescripcion.Location = new System.Drawing.Point(109, 67);
            this.rtxtDescripcion.Name = "rtxtDescripcion";
            this.rtxtDescripcion.Size = new System.Drawing.Size(322, 96);
            this.rtxtDescripcion.TabIndex = 4;
            this.rtxtDescripcion.Text = "";
            // 
            // rtxtPregunta
            // 
            this.rtxtPregunta.Location = new System.Drawing.Point(109, 169);
            this.rtxtPregunta.Name = "rtxtPregunta";
            this.rtxtPregunta.Size = new System.Drawing.Size(322, 107);
            this.rtxtPregunta.TabIndex = 5;
            this.rtxtPregunta.Text = "";
            this.rtxtPregunta.TextChanged += new System.EventHandler(this.rtxtPregunta_TextChanged);
            // 
            // lblPregunta
            // 
            this.lblPregunta.AutoSize = true;
            this.lblPregunta.Location = new System.Drawing.Point(13, 169);
            this.lblPregunta.Name = "lblPregunta";
            this.lblPregunta.Size = new System.Drawing.Size(53, 13);
            this.lblPregunta.TabIndex = 6;
            this.lblPregunta.Text = "Pregunta:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(275, 282);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(356, 282);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 8;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // epPregunta
            // 
            this.epPregunta.ContainerControl = this;
            // 
            // GenerarPreguntas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 315);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lblPregunta);
            this.Controls.Add(this.rtxtPregunta);
            this.Controls.Add(this.rtxtDescripcion);
            this.Controls.Add(this.txtCodPublicacion);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblCodPublicacion);
            this.Controls.Add(this.label1);
            this.Name = "GenerarPreguntas";
            this.Text = "GenerarPreguntas";
            this.Load += new System.EventHandler(this.GenerarPreguntas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.epPregunta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCodPublicacion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtCodPublicacion;
        private System.Windows.Forms.RichTextBox rtxtDescripcion;
        private System.Windows.Forms.RichTextBox rtxtPregunta;
        private System.Windows.Forms.Label lblPregunta;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.ErrorProvider epPregunta;
    }
}