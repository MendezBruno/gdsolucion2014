namespace FrbaCommerce.Generar_Publicacion
{
    partial class FormGenerarPublicacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGenerarPublicacion));
            this.comboBoxAceptaPregunta = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxVisibilidad = new System.Windows.Forms.ComboBox();
            this.numericUpDownStockInicial = new System.Windows.Forms.NumericUpDown();
            this.textBoxDescripcion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelprecio = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelstock = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxTipoPublicacion = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.buttonPublicar = new System.Windows.Forms.Button();
            this.labelUserName = new System.Windows.Forms.Label();
            this.linkLabelSalir = new System.Windows.Forms.LinkLabel();
            this.checkedListBoxRubro = new System.Windows.Forms.CheckedListBox();
            this.textBoxPrecio = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStockInicial)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxAceptaPregunta
            // 
            this.comboBoxAceptaPregunta.FormattingEnabled = true;
            this.comboBoxAceptaPregunta.Items.AddRange(new object[] {
            "SI",
            "NO"});
            this.comboBoxAceptaPregunta.Location = new System.Drawing.Point(261, 432);
            this.comboBoxAceptaPregunta.Name = "comboBoxAceptaPregunta";
            this.comboBoxAceptaPregunta.Size = new System.Drawing.Size(55, 21);
            this.comboBoxAceptaPregunta.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 432);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(216, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "¿Acepta Recibir Pregunta De Los Usuarios?";
            // 
            // comboBoxVisibilidad
            // 
            this.comboBoxVisibilidad.FormattingEnabled = true;
            this.comboBoxVisibilidad.Location = new System.Drawing.Point(91, 382);
            this.comboBoxVisibilidad.Name = "comboBoxVisibilidad";
            this.comboBoxVisibilidad.Size = new System.Drawing.Size(212, 21);
            this.comboBoxVisibilidad.TabIndex = 22;
            // 
            // numericUpDownStockInicial
            // 
            this.numericUpDownStockInicial.Location = new System.Drawing.Point(91, 298);
            this.numericUpDownStockInicial.Name = "numericUpDownStockInicial";
            this.numericUpDownStockInicial.Size = new System.Drawing.Size(212, 20);
            this.numericUpDownStockInicial.TabIndex = 20;
            this.numericUpDownStockInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownStockInicial.ValueChanged += new System.EventHandler(this.numericUpDownStockInicial_ValueChanged);
            // 
            // textBoxDescripcion
            // 
            this.textBoxDescripcion.Location = new System.Drawing.Point(25, 203);
            this.textBoxDescripcion.Multiline = true;
            this.textBoxDescripcion.Name = "textBoxDescripcion";
            this.textBoxDescripcion.Size = new System.Drawing.Size(291, 66);
            this.textBoxDescripcion.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 382);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Visibilidad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Descripcion:";
            // 
            // labelprecio
            // 
            this.labelprecio.AutoSize = true;
            this.labelprecio.Location = new System.Drawing.Point(21, 339);
            this.labelprecio.Name = "labelprecio";
            this.labelprecio.Size = new System.Drawing.Size(37, 13);
            this.labelprecio.TabIndex = 15;
            this.labelprecio.Text = "Precio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Rubros:";
            // 
            // labelstock
            // 
            this.labelstock.AutoSize = true;
            this.labelstock.Location = new System.Drawing.Point(21, 298);
            this.labelstock.Name = "labelstock";
            this.labelstock.Size = new System.Drawing.Size(65, 13);
            this.labelstock.TabIndex = 13;
            this.labelstock.Text = "Stock Inicial";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(53, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(199, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "¿Que tipo de publicaciòn desea realizar?";
            // 
            // comboBoxTipoPublicacion
            // 
            this.comboBoxTipoPublicacion.FormattingEnabled = true;
            this.comboBoxTipoPublicacion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBoxTipoPublicacion.Items.AddRange(new object[] {
            "Subasta",
            "Compra Inmediata"});
            this.comboBoxTipoPublicacion.Location = new System.Drawing.Point(56, 70);
            this.comboBoxTipoPublicacion.Name = "comboBoxTipoPublicacion";
            this.comboBoxTipoPublicacion.Size = new System.Drawing.Size(208, 21);
            this.comboBoxTipoPublicacion.TabIndex = 26;
            this.comboBoxTipoPublicacion.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipoPublicacion_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(258, 187);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "(Max: 255)";
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Location = new System.Drawing.Point(25, 484);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(113, 26);
            this.buttonLimpiar.TabIndex = 28;
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // buttonPublicar
            // 
            this.buttonPublicar.Location = new System.Drawing.Point(203, 484);
            this.buttonPublicar.Name = "buttonPublicar";
            this.buttonPublicar.Size = new System.Drawing.Size(113, 26);
            this.buttonPublicar.TabIndex = 29;
            this.buttonPublicar.Text = "Publicar";
            this.buttonPublicar.UseVisualStyleBackColor = true;
            this.buttonPublicar.Click += new System.EventHandler(this.buttonPublicar_Click);
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserName.Location = new System.Drawing.Point(45, 9);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(32, 17);
            this.labelUserName.TabIndex = 31;
            this.labelUserName.Text = "......";
            // 
            // linkLabelSalir
            // 
            this.linkLabelSalir.AutoSize = true;
            this.linkLabelSalir.Location = new System.Drawing.Point(264, 11);
            this.linkLabelSalir.Name = "linkLabelSalir";
            this.linkLabelSalir.Size = new System.Drawing.Size(27, 13);
            this.linkLabelSalir.TabIndex = 32;
            this.linkLabelSalir.TabStop = true;
            this.linkLabelSalir.Text = "Salir";
            this.linkLabelSalir.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSalir_LinkClicked);
            // 
            // checkedListBoxRubro
            // 
            this.checkedListBoxRubro.FormattingEnabled = true;
            this.checkedListBoxRubro.Location = new System.Drawing.Point(91, 104);
            this.checkedListBoxRubro.Name = "checkedListBoxRubro";
            this.checkedListBoxRubro.Size = new System.Drawing.Size(212, 64);
            this.checkedListBoxRubro.TabIndex = 33;
            // 
            // textBoxPrecio
            // 
            this.textBoxPrecio.Location = new System.Drawing.Point(91, 339);
            this.textBoxPrecio.Name = "textBoxPrecio";
            this.textBoxPrecio.Size = new System.Drawing.Size(212, 20);
            this.textBoxPrecio.TabIndex = 34;
            // 
            // FormGenerarPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 546);
            this.Controls.Add(this.textBoxPrecio);
            this.Controls.Add(this.checkedListBoxRubro);
            this.Controls.Add(this.linkLabelSalir);
            this.Controls.Add(this.labelUserName);
            this.Controls.Add(this.buttonPublicar);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBoxTipoPublicacion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxAceptaPregunta);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBoxVisibilidad);
            this.Controls.Add(this.numericUpDownStockInicial);
            this.Controls.Add(this.textBoxDescripcion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelprecio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelstock);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormGenerarPublicacion";
            this.Text = "Generar Publicacion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGenerarPublicacion_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStockInicial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.Button buttonPublicar;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.LinkLabel linkLabelSalir;
        public System.Windows.Forms.CheckedListBox checkedListBoxRubro;
        public System.Windows.Forms.ComboBox comboBoxAceptaPregunta;
        public System.Windows.Forms.ComboBox comboBoxVisibilidad;
        public System.Windows.Forms.NumericUpDown numericUpDownStockInicial;
        public System.Windows.Forms.TextBox textBoxDescripcion;
        public System.Windows.Forms.ComboBox comboBoxTipoPublicacion;
        public System.Windows.Forms.TextBox textBoxPrecio;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label labelprecio;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label labelstock;
        public System.Windows.Forms.Label label7;

    }
}