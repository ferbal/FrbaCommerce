namespace FrbaCommerce.View.Facturar_Publicaciones
{
    partial class FacturarPublicaciones
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
            this.lblCompraDesde = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCompraDesde = new System.Windows.Forms.ComboBox();
            this.cmbCompraHasta = new System.Windows.Forms.ComboBox();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.cmbVendedor = new System.Windows.Forms.ComboBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.dgvFacturasItems = new System.Windows.Forms.DataGridView();
            this.dgvVisibilidades = new System.Windows.Forms.DataGridView();
            this.lblSubTotalCompras = new System.Windows.Forms.Label();
            this.lblSubTotalPubli = new System.Windows.Forms.Label();
            this.lblSubTotal1 = new System.Windows.Forms.Label();
            this.lblSubTotal2 = new System.Windows.Forms.Label();
            this.lblTotalGral = new System.Windows.Forms.Label();
            this.cmbFormasDePago = new System.Windows.Forms.ComboBox();
            this.lblFormasPago = new System.Windows.Forms.Label();
            this.lblNroTarjeta = new System.Windows.Forms.Label();
            this.lblFechaVenc = new System.Windows.Forms.Label();
            this.lblCodSeg = new System.Windows.Forms.Label();
            this.lblTitular = new System.Windows.Forms.Label();
            this.mtxtNroTarjeta = new System.Windows.Forms.MaskedTextBox();
            this.mtxtFechaVenc = new System.Windows.Forms.MaskedTextBox();
            this.mtxtCodSeguridad = new System.Windows.Forms.MaskedTextBox();
            this.txtTitular = new System.Windows.Forms.TextBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnPagar = new System.Windows.Forms.Button();
            this.epVendedor = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturasItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisibilidades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epVendedor)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCompraDesde
            // 
            this.lblCompraDesde.AutoSize = true;
            this.lblCompraDesde.Location = new System.Drawing.Point(15, 74);
            this.lblCompraDesde.Name = "lblCompraDesde";
            this.lblCompraDesde.Size = new System.Drawing.Size(80, 13);
            this.lblCompraDesde.TabIndex = 1;
            this.lblCompraDesde.Text = "Desde Compra:";
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "lblCompraHasta";
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hasta Compra:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(198, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(329, 29);
            this.label3.TabIndex = 3;
            this.label3.Text = "Facturacion de Publicaciones";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbCompraDesde
            // 
            this.cmbCompraDesde.FormattingEnabled = true;
            this.cmbCompraDesde.Location = new System.Drawing.Point(99, 71);
            this.cmbCompraDesde.Name = "cmbCompraDesde";
            this.cmbCompraDesde.Size = new System.Drawing.Size(121, 21);
            this.cmbCompraDesde.TabIndex = 4;
            // 
            // cmbCompraHasta
            // 
            this.cmbCompraHasta.FormattingEnabled = true;
            this.cmbCompraHasta.Location = new System.Drawing.Point(309, 71);
            this.cmbCompraHasta.Name = "cmbCompraHasta";
            this.cmbCompraHasta.Size = new System.Drawing.Size(121, 21);
            this.cmbCompraHasta.TabIndex = 5;
            // 
            // lblVendedor
            // 
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.Location = new System.Drawing.Point(15, 45);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(59, 13);
            this.lblVendedor.TabIndex = 6;
            this.lblVendedor.Text = "Vendedor: ";
            // 
            // cmbVendedor
            // 
            this.cmbVendedor.FormattingEnabled = true;
            this.cmbVendedor.Location = new System.Drawing.Point(99, 42);
            this.cmbVendedor.Name = "cmbVendedor";
            this.cmbVendedor.Size = new System.Drawing.Size(121, 21);
            this.cmbVendedor.TabIndex = 7;
            this.cmbVendedor.SelectedIndexChanged += new System.EventHandler(this.cmbVendedor_SelectedIndexChanged);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(396, 306);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(44, 13);
            this.lblTotal.TabIndex = 9;
            this.lblTotal.Text = "Total: ";
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(656, 69);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(75, 23);
            this.btnCalcular.TabIndex = 10;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // dgvFacturasItems
            // 
            this.dgvFacturasItems.AllowUserToAddRows = false;
            this.dgvFacturasItems.AllowUserToDeleteRows = false;
            this.dgvFacturasItems.AllowUserToResizeColumns = false;
            this.dgvFacturasItems.AllowUserToResizeRows = false;
            this.dgvFacturasItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFacturasItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturasItems.Location = new System.Drawing.Point(18, 98);
            this.dgvFacturasItems.Name = "dgvFacturasItems";
            this.dgvFacturasItems.RowHeadersVisible = false;
            this.dgvFacturasItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFacturasItems.Size = new System.Drawing.Size(713, 156);
            this.dgvFacturasItems.TabIndex = 11;
            // 
            // dgvVisibilidades
            // 
            this.dgvVisibilidades.AllowUserToAddRows = false;
            this.dgvVisibilidades.AllowUserToDeleteRows = false;
            this.dgvVisibilidades.AllowUserToResizeColumns = false;
            this.dgvVisibilidades.AllowUserToResizeRows = false;
            this.dgvVisibilidades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVisibilidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVisibilidades.Location = new System.Drawing.Point(18, 261);
            this.dgvVisibilidades.Name = "dgvVisibilidades";
            this.dgvVisibilidades.RowHeadersVisible = false;
            this.dgvVisibilidades.Size = new System.Drawing.Size(364, 150);
            this.dgvVisibilidades.TabIndex = 12;
            // 
            // lblSubTotalCompras
            // 
            this.lblSubTotalCompras.AutoSize = true;
            this.lblSubTotalCompras.Location = new System.Drawing.Point(396, 261);
            this.lblSubTotalCompras.Name = "lblSubTotalCompras";
            this.lblSubTotalCompras.Size = new System.Drawing.Size(100, 13);
            this.lblSubTotalCompras.TabIndex = 13;
            this.lblSubTotalCompras.Text = "Sub Total Compras:";
            // 
            // lblSubTotalPubli
            // 
            this.lblSubTotalPubli.AutoSize = true;
            this.lblSubTotalPubli.Location = new System.Drawing.Point(396, 283);
            this.lblSubTotalPubli.Name = "lblSubTotalPubli";
            this.lblSubTotalPubli.Size = new System.Drawing.Size(117, 13);
            this.lblSubTotalPubli.TabIndex = 14;
            this.lblSubTotalPubli.Text = "Sub Total Publicacion: ";
            // 
            // lblSubTotal1
            // 
            this.lblSubTotal1.AutoSize = true;
            this.lblSubTotal1.Location = new System.Drawing.Point(546, 261);
            this.lblSubTotal1.Name = "lblSubTotal1";
            this.lblSubTotal1.Size = new System.Drawing.Size(66, 13);
            this.lblSubTotal1.TabIndex = 15;
            this.lblSubTotal1.Text = "lblSubTotal1";
            // 
            // lblSubTotal2
            // 
            this.lblSubTotal2.AutoSize = true;
            this.lblSubTotal2.Location = new System.Drawing.Point(546, 283);
            this.lblSubTotal2.Name = "lblSubTotal2";
            this.lblSubTotal2.Size = new System.Drawing.Size(66, 13);
            this.lblSubTotal2.TabIndex = 16;
            this.lblSubTotal2.Text = "lblSubTotal2";
            // 
            // lblTotalGral
            // 
            this.lblTotalGral.AutoSize = true;
            this.lblTotalGral.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalGral.Location = new System.Drawing.Point(546, 306);
            this.lblTotalGral.Name = "lblTotalGral";
            this.lblTotalGral.Size = new System.Drawing.Size(72, 13);
            this.lblTotalGral.TabIndex = 17;
            this.lblTotalGral.Text = "lblTotalGral";
            // 
            // cmbFormasDePago
            // 
            this.cmbFormasDePago.FormattingEnabled = true;
            this.cmbFormasDePago.Location = new System.Drawing.Point(102, 416);
            this.cmbFormasDePago.Name = "cmbFormasDePago";
            this.cmbFormasDePago.Size = new System.Drawing.Size(121, 21);
            this.cmbFormasDePago.TabIndex = 18;
            this.cmbFormasDePago.SelectedIndexChanged += new System.EventHandler(this.cmbFormasDePago_SelectedIndexChanged);
            // 
            // lblFormasPago
            // 
            this.lblFormasPago.AutoSize = true;
            this.lblFormasPago.Location = new System.Drawing.Point(15, 419);
            this.lblFormasPago.Name = "lblFormasPago";
            this.lblFormasPago.Size = new System.Drawing.Size(87, 13);
            this.lblFormasPago.TabIndex = 19;
            this.lblFormasPago.Text = "Formas de Pago:";
            // 
            // lblNroTarjeta
            // 
            this.lblNroTarjeta.AutoSize = true;
            this.lblNroTarjeta.Location = new System.Drawing.Point(242, 419);
            this.lblNroTarjeta.Name = "lblNroTarjeta";
            this.lblNroTarjeta.Size = new System.Drawing.Size(63, 13);
            this.lblNroTarjeta.TabIndex = 20;
            this.lblNroTarjeta.Text = "Nro Tarjeta:";
            // 
            // lblFechaVenc
            // 
            this.lblFechaVenc.AutoSize = true;
            this.lblFechaVenc.Location = new System.Drawing.Point(242, 446);
            this.lblFechaVenc.Name = "lblFechaVenc";
            this.lblFechaVenc.Size = new System.Drawing.Size(101, 13);
            this.lblFechaVenc.TabIndex = 21;
            this.lblFechaVenc.Text = "Fecha Vencimiento:";
            // 
            // lblCodSeg
            // 
            this.lblCodSeg.AutoSize = true;
            this.lblCodSeg.Location = new System.Drawing.Point(467, 419);
            this.lblCodSeg.Name = "lblCodSeg";
            this.lblCodSeg.Size = new System.Drawing.Size(94, 13);
            this.lblCodSeg.TabIndex = 22;
            this.lblCodSeg.Text = "Codigo Seguridad:";
            // 
            // lblTitular
            // 
            this.lblTitular.AutoSize = true;
            this.lblTitular.Location = new System.Drawing.Point(467, 446);
            this.lblTitular.Name = "lblTitular";
            this.lblTitular.Size = new System.Drawing.Size(39, 13);
            this.lblTitular.TabIndex = 23;
            this.lblTitular.Text = "Titular:";
            // 
            // mtxtNroTarjeta
            // 
            this.mtxtNroTarjeta.Location = new System.Drawing.Point(309, 416);
            this.mtxtNroTarjeta.Mask = "9999999999999";
            this.mtxtNroTarjeta.Name = "mtxtNroTarjeta";
            this.mtxtNroTarjeta.Size = new System.Drawing.Size(152, 20);
            this.mtxtNroTarjeta.TabIndex = 24;
            // 
            // mtxtFechaVenc
            // 
            this.mtxtFechaVenc.Location = new System.Drawing.Point(361, 443);
            this.mtxtFechaVenc.Mask = "00/00/0000";
            this.mtxtFechaVenc.Name = "mtxtFechaVenc";
            this.mtxtFechaVenc.Size = new System.Drawing.Size(100, 20);
            this.mtxtFechaVenc.TabIndex = 25;
            this.mtxtFechaVenc.ValidatingType = typeof(System.DateTime);
            // 
            // mtxtCodSeguridad
            // 
            this.mtxtCodSeguridad.Location = new System.Drawing.Point(567, 416);
            this.mtxtCodSeguridad.Mask = "9999";
            this.mtxtCodSeguridad.Name = "mtxtCodSeguridad";
            this.mtxtCodSeguridad.Size = new System.Drawing.Size(100, 20);
            this.mtxtCodSeguridad.TabIndex = 26;
            // 
            // txtTitular
            // 
            this.txtTitular.Location = new System.Drawing.Point(518, 443);
            this.txtTitular.Name = "txtTitular";
            this.txtTitular.Size = new System.Drawing.Size(149, 20);
            this.txtTitular.TabIndex = 27;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(656, 469);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 28;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnPagar
            // 
            this.btnPagar.Location = new System.Drawing.Point(575, 469);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(75, 23);
            this.btnPagar.TabIndex = 29;
            this.btnPagar.Text = "Pagar";
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // epVendedor
            // 
            this.epVendedor.ContainerControl = this;
            // 
            // FacturarPublicaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 499);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.txtTitular);
            this.Controls.Add(this.mtxtCodSeguridad);
            this.Controls.Add(this.mtxtFechaVenc);
            this.Controls.Add(this.mtxtNroTarjeta);
            this.Controls.Add(this.lblTitular);
            this.Controls.Add(this.lblCodSeg);
            this.Controls.Add(this.lblFechaVenc);
            this.Controls.Add(this.lblNroTarjeta);
            this.Controls.Add(this.lblFormasPago);
            this.Controls.Add(this.cmbFormasDePago);
            this.Controls.Add(this.lblTotalGral);
            this.Controls.Add(this.lblSubTotal2);
            this.Controls.Add(this.lblSubTotal1);
            this.Controls.Add(this.lblSubTotalPubli);
            this.Controls.Add(this.lblSubTotalCompras);
            this.Controls.Add(this.dgvVisibilidades);
            this.Controls.Add(this.dgvFacturasItems);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.cmbVendedor);
            this.Controls.Add(this.lblVendedor);
            this.Controls.Add(this.cmbCompraHasta);
            this.Controls.Add(this.cmbCompraDesde);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCompraDesde);
            this.Name = "FacturarPublicaciones";
            this.Text = "FacturarPublicaciones";
            this.Load += new System.EventHandler(this.FacturarPublicaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturasItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisibilidades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epVendedor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCompraDesde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCompraDesde;
        private System.Windows.Forms.ComboBox cmbCompraHasta;
        private System.Windows.Forms.Label lblVendedor;
        private System.Windows.Forms.ComboBox cmbVendedor;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.DataGridView dgvFacturasItems;
        private System.Windows.Forms.DataGridView dgvVisibilidades;
        private System.Windows.Forms.Label lblSubTotalCompras;
        private System.Windows.Forms.Label lblSubTotalPubli;
        private System.Windows.Forms.Label lblSubTotal1;
        private System.Windows.Forms.Label lblSubTotal2;
        private System.Windows.Forms.Label lblTotalGral;
        private System.Windows.Forms.ComboBox cmbFormasDePago;
        private System.Windows.Forms.Label lblFormasPago;
        private System.Windows.Forms.Label lblNroTarjeta;
        private System.Windows.Forms.Label lblFechaVenc;
        private System.Windows.Forms.Label lblCodSeg;
        private System.Windows.Forms.Label lblTitular;
        private System.Windows.Forms.MaskedTextBox mtxtNroTarjeta;
        private System.Windows.Forms.MaskedTextBox mtxtFechaVenc;
        private System.Windows.Forms.MaskedTextBox mtxtCodSeguridad;
        private System.Windows.Forms.TextBox txtTitular;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.ErrorProvider epVendedor;

    }
}