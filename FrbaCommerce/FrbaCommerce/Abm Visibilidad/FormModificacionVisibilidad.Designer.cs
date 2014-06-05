namespace FrbaCommerce.Abm_Visibilidad
{
    partial class FormModificacionVisibilidad
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
            this.dataGridViewModificacionVisibilidad = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewModificacionVisibilidad)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewModificacionVisibilidad
            // 
            this.dataGridViewModificacionVisibilidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewModificacionVisibilidad.Location = new System.Drawing.Point(14, 28);
            this.dataGridViewModificacionVisibilidad.Name = "dataGridViewModificacionVisibilidad";
            this.dataGridViewModificacionVisibilidad.Size = new System.Drawing.Size(257, 226);
            this.dataGridViewModificacionVisibilidad.TabIndex = 0;
            // 
            // FormModificacionVisibilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.dataGridViewModificacionVisibilidad);
            this.Name = "FormModificacionVisibilidad";
            this.Text = "Modificacion Visibilidad";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewModificacionVisibilidad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewModificacionVisibilidad;
    }
}