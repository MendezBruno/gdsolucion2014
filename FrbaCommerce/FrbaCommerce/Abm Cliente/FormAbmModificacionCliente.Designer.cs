namespace FrbaCommerce.Abm_Cliente
{
    partial class FormAbmModificacionCliente
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
            this.textBoxMail = new System.Windows.Forms.TextBox();
            this.labelMail = new System.Windows.Forms.Label();
            this.textBoxDni = new System.Windows.Forms.TextBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.dataGridViewModificacionCliente = new System.Windows.Forms.DataGridView();
            this.SeleccionarColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxApellido = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxTipoDNI = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewModificacionCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxMail
            // 
            this.textBoxMail.Location = new System.Drawing.Point(138, 141);
            this.textBoxMail.Name = "textBoxMail";
            this.textBoxMail.Size = new System.Drawing.Size(259, 20);
            this.textBoxMail.TabIndex = 29;
            // 
            // labelMail
            // 
            this.labelMail.AutoSize = true;
            this.labelMail.Location = new System.Drawing.Point(27, 148);
            this.labelMail.Name = "labelMail";
            this.labelMail.Size = new System.Drawing.Size(42, 13);
            this.labelMail.TabIndex = 28;
            this.labelMail.Text = "E-MAIL";
            // 
            // textBoxDni
            // 
            this.textBoxDni.Location = new System.Drawing.Point(138, 110);
            this.textBoxDni.Name = "textBoxDni";
            this.textBoxDni.Size = new System.Drawing.Size(259, 20);
            this.textBoxDni.TabIndex = 27;
            this.textBoxDni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDni_KeyPress_1);
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(138, 17);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(259, 20);
            this.textBoxNombre.TabIndex = 26;
            // 
            // dataGridViewModificacionCliente
            // 
            this.dataGridViewModificacionCliente.AllowUserToAddRows = false;
            this.dataGridViewModificacionCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewModificacionCliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SeleccionarColumn});
            this.dataGridViewModificacionCliente.Location = new System.Drawing.Point(23, 221);
            this.dataGridViewModificacionCliente.Name = "dataGridViewModificacionCliente";
            this.dataGridViewModificacionCliente.ReadOnly = true;
            this.dataGridViewModificacionCliente.Size = new System.Drawing.Size(473, 230);
            this.dataGridViewModificacionCliente.TabIndex = 25;
            this.dataGridViewModificacionCliente.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewModificacionCliente_CellContentClick);
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
            // buttonBuscar
            // 
            this.buttonBuscar.Location = new System.Drawing.Point(381, 183);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(115, 23);
            this.buttonBuscar.TabIndex = 24;
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Location = new System.Drawing.Point(23, 183);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(115, 23);
            this.buttonLimpiar.TabIndex = 23;
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "DNI";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Nombre";
            // 
            // textBoxApellido
            // 
            this.textBoxApellido.Location = new System.Drawing.Point(138, 48);
            this.textBoxApellido.Name = "textBoxApellido";
            this.textBoxApellido.Size = new System.Drawing.Size(259, 20);
            this.textBoxApellido.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Apellido";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Tipo DNI";
            // 
            // comboBoxTipoDNI
            // 
            this.comboBoxTipoDNI.FormattingEnabled = true;
            this.comboBoxTipoDNI.Items.AddRange(new object[] {
            "DNI",
            "LC"});
            this.comboBoxTipoDNI.Location = new System.Drawing.Point(138, 79);
            this.comboBoxTipoDNI.Name = "comboBoxTipoDNI";
            this.comboBoxTipoDNI.Size = new System.Drawing.Size(259, 21);
            this.comboBoxTipoDNI.TabIndex = 33;
            // 
            // FormAbmModificacionCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 495);
            this.Controls.Add(this.comboBoxTipoDNI);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxApellido);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxMail);
            this.Controls.Add(this.labelMail);
            this.Controls.Add(this.textBoxDni);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.dataGridViewModificacionCliente);
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormAbmModificacionCliente";
            this.Text = "Modificacion Cliente";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewModificacionCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxMail;
        private System.Windows.Forms.Label labelMail;
        private System.Windows.Forms.TextBox textBoxDni;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.DataGridView dataGridViewModificacionCliente;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxApellido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewButtonColumn SeleccionarColumn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxTipoDNI;
    }
}