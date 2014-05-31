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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxFuncionalidad = new System.Windows.Forms.ComboBox();
            this.comboBoxNombreRol = new System.Windows.Forms.ComboBox();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.dataGridViewRolFuncion = new System.Windows.Forms.DataGridView();
            this.SeleccionarColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRolFuncion)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre Rol";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Funcionalidad";
            // 
            // comboBoxFuncionalidad
            // 
            this.comboBoxFuncionalidad.FormattingEnabled = true;
            this.comboBoxFuncionalidad.Items.AddRange(new object[] {
            "vender",
            "comprar",
            "publicar rubro"});
            this.comboBoxFuncionalidad.Location = new System.Drawing.Point(132, 49);
            this.comboBoxFuncionalidad.Name = "comboBoxFuncionalidad";
            this.comboBoxFuncionalidad.Size = new System.Drawing.Size(148, 21);
            this.comboBoxFuncionalidad.TabIndex = 2;
            // 
            // comboBoxNombreRol
            // 
            this.comboBoxNombreRol.FormattingEnabled = true;
            this.comboBoxNombreRol.Items.AddRange(new object[] {
            "Cliente",
            "Empresa",
            "Administrador"});
            this.comboBoxNombreRol.Location = new System.Drawing.Point(132, 17);
            this.comboBoxNombreRol.Name = "comboBoxNombreRol";
            this.comboBoxNombreRol.Size = new System.Drawing.Size(148, 21);
            this.comboBoxNombreRol.TabIndex = 3;
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Location = new System.Drawing.Point(17, 86);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(115, 23);
            this.buttonLimpiar.TabIndex = 5;
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Location = new System.Drawing.Point(165, 86);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(115, 23);
            this.buttonBuscar.TabIndex = 6;
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // dataGridViewRolFuncion
            // 
            this.dataGridViewRolFuncion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRolFuncion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SeleccionarColumn});
            this.dataGridViewRolFuncion.Location = new System.Drawing.Point(12, 127);
            this.dataGridViewRolFuncion.Name = "dataGridViewRolFuncion";
            this.dataGridViewRolFuncion.Size = new System.Drawing.Size(267, 153);
            this.dataGridViewRolFuncion.TabIndex = 7;
            this.dataGridViewRolFuncion.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRolFuncion_CellContentClick);
            // 
            // SeleccionarColumn
            // 
            this.SeleccionarColumn.HeaderText = "Seleccionar";
            this.SeleccionarColumn.Name = "SeleccionarColumn";
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
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.comboBoxNombreRol);
            this.Controls.Add(this.comboBoxFuncionalidad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Modificacion_Rol";
            this.Text = "Modificacion Rol";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRolFuncion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxFuncionalidad;
        private System.Windows.Forms.ComboBox comboBoxNombreRol;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.DataGridView dataGridViewRolFuncion;
        private System.Windows.Forms.DataGridViewButtonColumn SeleccionarColumn;
    }
}