namespace FrbaCommerce.Calificar_Vendedor
{
    partial class BuscarCalificar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuscarCalificar));
            this.dataGridViewClasificar = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClasificar)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewClasificar
            // 
            this.dataGridViewClasificar.AllowUserToAddRows = false;
            this.dataGridViewClasificar.AllowUserToDeleteRows = false;
            this.dataGridViewClasificar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClasificar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar});
            this.dataGridViewClasificar.Location = new System.Drawing.Point(12, 45);
            this.dataGridViewClasificar.Name = "dataGridViewClasificar";
            this.dataGridViewClasificar.Size = new System.Drawing.Size(359, 209);
            this.dataGridViewClasificar.TabIndex = 5;
            this.dataGridViewClasificar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewClasificar_CellContentClick);
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "Seleccionar";
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.Visible = false;
            // 
            // BuscarCalificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 266);
            this.Controls.Add(this.dataGridViewClasificar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BuscarCalificar";
            this.Text = "BuscarCalificar";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClasificar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridViewClasificar;
        private System.Windows.Forms.DataGridViewButtonColumn Seleccionar;

    }
}