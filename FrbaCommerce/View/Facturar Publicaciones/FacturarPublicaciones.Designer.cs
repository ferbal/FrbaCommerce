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
            System.Windows.Forms.DataGridView dgvFactura;
            this.lblCompraDesde = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCompraDesde = new System.Windows.Forms.ComboBox();
            this.cmbCompraHasta = new System.Windows.Forms.ComboBox();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.cmbVendedor = new System.Windows.Forms.ComboBox();
            this.lblTotal = new System.Windows.Forms.Label();
            dgvFactura = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(dgvFactura)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCompraDesde
            // 
            this.lblCompraDesde.AutoSize = true;
            this.lblCompraDesde.Location = new System.Drawing.Point(12, 95);
            this.lblCompraDesde.Name = "lblCompraDesde";
            this.lblCompraDesde.Size = new System.Drawing.Size(80, 13);
            this.lblCompraDesde.TabIndex = 1;
            this.lblCompraDesde.Text = "Desde Compra:";
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "lblCompraHasta";
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 94);
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
            this.cmbCompraDesde.Location = new System.Drawing.Point(89, 91);
            this.cmbCompraDesde.Name = "cmbCompraDesde";
            this.cmbCompraDesde.Size = new System.Drawing.Size(121, 21);
            this.cmbCompraDesde.TabIndex = 4;
            // 
            // cmbCompraHasta
            // 
            this.cmbCompraHasta.FormattingEnabled = true;
            this.cmbCompraHasta.Location = new System.Drawing.Point(309, 91);
            this.cmbCompraHasta.Name = "cmbCompraHasta";
            this.cmbCompraHasta.Size = new System.Drawing.Size(121, 21);
            this.cmbCompraHasta.TabIndex = 5;
            // 
            // lblVendedor
            // 
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.Location = new System.Drawing.Point(15, 65);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(59, 13);
            this.lblVendedor.TabIndex = 6;
            this.lblVendedor.Text = "Vendedor: ";
            // 
            // cmbVendedor
            // 
            this.cmbVendedor.FormattingEnabled = true;
            this.cmbVendedor.Location = new System.Drawing.Point(89, 62);
            this.cmbVendedor.Name = "cmbVendedor";
            this.cmbVendedor.Size = new System.Drawing.Size(121, 21);
            this.cmbVendedor.TabIndex = 7;
            // 
            // dgvFactura
            // 
            dgvFactura.AllowUserToAddRows = false;
            dgvFactura.AllowUserToDeleteRows = false;
            dgvFactura.AllowUserToResizeColumns = false;
            dgvFactura.AllowUserToResizeRows = false;
            dgvFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFactura.Location = new System.Drawing.Point(15, 130);
            dgvFactura.Name = "dgvFactura";
            dgvFactura.RowHeadersVisible = false;
            dgvFactura.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvFactura.Size = new System.Drawing.Size(716, 150);
            dgvFactura.TabIndex = 8;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(546, 283);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(37, 13);
            this.lblTotal.TabIndex = 9;
            this.lblTotal.Text = "Total: ";
            // 
            // FacturarPublicaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 404);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(dgvFactura);
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
            ((System.ComponentModel.ISupportInitialize)(dgvFactura)).EndInit();
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

    }
}