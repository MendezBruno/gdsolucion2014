namespace FrbaCommerce.Listado_Estadistico
{
    partial class FormListadoEstadistico
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
            this.listado = new System.Windows.Forms.ComboBox();
            this.trimestre = new System.Windows.Forms.TextBox();
            this.anio = new System.Windows.Forms.TextBox();
            this.dataGridViewListado = new System.Windows.Forms.DataGridView();
            this.Año = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListado)).BeginInit();
            this.SuspendLayout();
            // 
            // listado
            // 
            this.listado.Enabled = false;
            this.listado.FormattingEnabled = true;
            this.listado.Items.AddRange(new object[] {
            "Vendedores Mayor Facturacion",
            "Vendedores Con Mayores Calificaciones",
            "Clientes Con Mayor Cantidad De Publicaciones Sin Clasificar"});
            this.listado.Location = new System.Drawing.Point(106, 78);
            this.listado.Name = "listado";
            this.listado.Size = new System.Drawing.Size(340, 21);
            this.listado.TabIndex = 0;
            this.listado.SelectedIndexChanged += new System.EventHandler(this.listado_SelectedIndexChanged);
            // 
            // trimestre
            // 
            this.trimestre.Enabled = false;
            this.trimestre.Location = new System.Drawing.Point(106, 45);
            this.trimestre.Name = "trimestre";
            this.trimestre.Size = new System.Drawing.Size(340, 20);
            this.trimestre.TabIndex = 1;
            this.trimestre.TextChanged += new System.EventHandler(this.mes_TextChanged);
            // 
            // anio
            // 
            this.anio.Location = new System.Drawing.Point(106, 12);
            this.anio.Name = "anio";
            this.anio.Size = new System.Drawing.Size(340, 20);
            this.anio.TabIndex = 2;
            this.anio.TextChanged += new System.EventHandler(this.anio_TextChanged);
            // 
            // dataGridViewListado
            // 
            this.dataGridViewListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListado.Location = new System.Drawing.Point(21, 140);
            this.dataGridViewListado.Name = "dataGridViewListado";
            this.dataGridViewListado.Size = new System.Drawing.Size(425, 312);
            this.dataGridViewListado.TabIndex = 3;
            // 
            // Año
            // 
            this.Año.AutoSize = true;
            this.Año.Location = new System.Drawing.Point(36, 12);
            this.Año.Name = "Año";
            this.Año.Size = new System.Drawing.Size(25, 13);
            this.Año.TabIndex = 4;
            this.Año.Text = "año";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "trimestre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "listado";
            // 
            // FormListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 479);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Año);
            this.Controls.Add(this.dataGridViewListado);
            this.Controls.Add(this.anio);
            this.Controls.Add(this.trimestre);
            this.Controls.Add(this.listado);
            this.Name = "FormListadoEstadistico";
            this.Text = "Listado Estadistico";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewListado;
        private System.Windows.Forms.Label Año;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox listado;
        public System.Windows.Forms.TextBox trimestre;
        public System.Windows.Forms.TextBox anio;
    }
}