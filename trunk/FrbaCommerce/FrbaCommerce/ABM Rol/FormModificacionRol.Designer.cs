namespace FrbaCommerce.ABM_Rol
{
    partial class Modificacion_Rol
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
            this.dataGridViewRolFuncion = new System.Windows.Forms.DataGridView();
            this.SeleccionarColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRolFuncion)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewRolFuncion
            // 
            this.dataGridViewRolFuncion.AllowUserToAddRows = false;
            this.dataGridViewRolFuncion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRolFuncion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SeleccionarColumn});
            this.dataGridViewRolFuncion.Location = new System.Drawing.Point(12, 26);
            this.dataGridViewRolFuncion.Name = "dataGridViewRolFuncion";
            this.dataGridViewRolFuncion.ReadOnly = true;
            this.dataGridViewRolFuncion.Size = new System.Drawing.Size(269, 246);
            this.dataGridViewRolFuncion.TabIndex = 7;
            this.dataGridViewRolFuncion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRolFuncion_CellContentClick);
            // 
            // SeleccionarColumn
            // 
            this.SeleccionarColumn.HeaderText = "Seleccionar";
            this.SeleccionarColumn.Name = "SeleccionarColumn";
            this.SeleccionarColumn.ReadOnly = true;
            this.SeleccionarColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SeleccionarColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SeleccionarColumn.Visible = false;
            // 
            // Modificacion_Rol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 295);
            this.Controls.Add(this.dataGridViewRolFuncion);
            this.Name = "Modificacion_Rol";
            this.Text = "Modificacion Rol";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRolFuncion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewRolFuncion;
        private System.Windows.Forms.DataGridViewButtonColumn SeleccionarColumn;
    }
}