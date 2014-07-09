namespace FrbaCommerce.Facturar_Publicaciones
{
    partial class FormFacturarPublicaciones
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewFacturar = new System.Windows.Forms.DataGridView();
            this.textCantPubli = new System.Windows.Forms.TextBox();
            this.buttonGenerarFactura = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBoxMedio = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFacturar)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewFacturar
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewFacturar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewFacturar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewFacturar.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewFacturar.Location = new System.Drawing.Point(12, 90);
            this.dataGridViewFacturar.Name = "dataGridViewFacturar";
            this.dataGridViewFacturar.Size = new System.Drawing.Size(280, 201);
            this.dataGridViewFacturar.TabIndex = 0;
            // 
            // textCantPubli
            // 
            this.textCantPubli.Location = new System.Drawing.Point(178, 12);
            this.textCantPubli.Name = "textCantPubli";
            this.textCantPubli.Size = new System.Drawing.Size(96, 20);
            this.textCantPubli.TabIndex = 1;
            // 
            // buttonGenerarFactura
            // 
            this.buttonGenerarFactura.Location = new System.Drawing.Point(92, 61);
            this.buttonGenerarFactura.Name = "buttonGenerarFactura";
            this.buttonGenerarFactura.Size = new System.Drawing.Size(121, 23);
            this.buttonGenerarFactura.TabIndex = 2;
            this.buttonGenerarFactura.Text = "Generar Factura";
            this.buttonGenerarFactura.UseVisualStyleBackColor = true;
            this.buttonGenerarFactura.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cantidad Compras A Rendir:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(119, 335);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Pagar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBoxMedio
            // 
            this.comboBoxMedio.FormattingEnabled = true;
            this.comboBoxMedio.Items.AddRange(new object[] {
            "Efectivo"});
            this.comboBoxMedio.Location = new System.Drawing.Point(119, 297);
            this.comboBoxMedio.Name = "comboBoxMedio";
            this.comboBoxMedio.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMedio.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 305);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Medio de pago:";
            // 
            // FormFacturarPublicaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 370);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxMedio);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonGenerarFactura);
            this.Controls.Add(this.textCantPubli);
            this.Controls.Add(this.dataGridViewFacturar);
            this.Name = "FormFacturarPublicaciones";
            this.Text = "Facturar Publicaciones";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFacturar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewFacturar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBoxMedio;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textCantPubli;
        public System.Windows.Forms.Button buttonGenerarFactura;
        public System.Windows.Forms.Label label1;
    }
}