namespace FrbaCommerce.Comprar_Ofertar
{
    partial class FormMostrarPublicacion
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonComprar = new System.Windows.Forms.Button();
            this.buttonPreguntar = new System.Windows.Forms.Button();
            this.tipo = new System.Windows.Forms.Label();
            this.descripcion = new System.Windows.Forms.Label();
            this.precio = new System.Windows.Forms.Label();
            this.stock = new System.Windows.Forms.Label();
            this.numericUpDownCantComprar = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.labelVendedor = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCantComprar)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo de Publicacion:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Publicacion Descripcion:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Precio Por Unidad:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Stock Disponible:";
            // 
            // buttonComprar
            // 
            this.buttonComprar.Location = new System.Drawing.Point(12, 267);
            this.buttonComprar.Name = "buttonComprar";
            this.buttonComprar.Size = new System.Drawing.Size(75, 23);
            this.buttonComprar.TabIndex = 4;
            this.buttonComprar.Text = "Comprar";
            this.buttonComprar.UseVisualStyleBackColor = true;
            this.buttonComprar.Click += new System.EventHandler(this.buttonComprar_Click);
            // 
            // buttonPreguntar
            // 
            this.buttonPreguntar.Location = new System.Drawing.Point(255, 267);
            this.buttonPreguntar.Name = "buttonPreguntar";
            this.buttonPreguntar.Size = new System.Drawing.Size(75, 23);
            this.buttonPreguntar.TabIndex = 5;
            this.buttonPreguntar.Text = "Preguntar";
            this.buttonPreguntar.UseVisualStyleBackColor = true;
            this.buttonPreguntar.Click += new System.EventHandler(this.buttonPreguntar_Click);
            // 
            // tipo
            // 
            this.tipo.AutoSize = true;
            this.tipo.Location = new System.Drawing.Point(123, 51);
            this.tipo.Name = "tipo";
            this.tipo.Size = new System.Drawing.Size(35, 13);
            this.tipo.TabIndex = 6;
            this.tipo.Text = "label5";
            // 
            // descripcion
            // 
            this.descripcion.AutoSize = true;
            this.descripcion.Location = new System.Drawing.Point(139, 98);
            this.descripcion.Name = "descripcion";
            this.descripcion.Size = new System.Drawing.Size(35, 13);
            this.descripcion.TabIndex = 7;
            this.descripcion.Text = "label6";
            // 
            // precio
            // 
            this.precio.AutoSize = true;
            this.precio.Location = new System.Drawing.Point(112, 142);
            this.precio.Name = "precio";
            this.precio.Size = new System.Drawing.Size(35, 13);
            this.precio.TabIndex = 8;
            this.precio.Text = "label7";
            // 
            // stock
            // 
            this.stock.AutoSize = true;
            this.stock.Location = new System.Drawing.Point(108, 185);
            this.stock.Name = "stock";
            this.stock.Size = new System.Drawing.Size(35, 13);
            this.stock.TabIndex = 9;
            this.stock.Text = "label8";
            // 
            // numericUpDownCantComprar
            // 
            this.numericUpDownCantComprar.Location = new System.Drawing.Point(124, 221);
            this.numericUpDownCantComprar.Name = "numericUpDownCantComprar";
            this.numericUpDownCantComprar.Size = new System.Drawing.Size(127, 20);
            this.numericUpDownCantComprar.TabIndex = 10;
            this.numericUpDownCantComprar.ValueChanged += new System.EventHandler(this.numericUpDownCantComprar_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Cantidad a Comprar: ";
            // 
            // labelVendedor
            // 
            this.labelVendedor.AutoSize = true;
            this.labelVendedor.Location = new System.Drawing.Point(281, 24);
            this.labelVendedor.Name = "labelVendedor";
            this.labelVendedor.Size = new System.Drawing.Size(49, 13);
            this.labelVendedor.TabIndex = 12;
            this.labelVendedor.Text = "..............";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(216, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Vendedor";
            // 
            // FormMostrarPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 302);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelVendedor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDownCantComprar);
            this.Controls.Add(this.stock);
            this.Controls.Add(this.precio);
            this.Controls.Add(this.descripcion);
            this.Controls.Add(this.tipo);
            this.Controls.Add(this.buttonPreguntar);
            this.Controls.Add(this.buttonComprar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormMostrarPublicacion";
            this.Text = "FormMostrarPublicacion";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCantComprar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label tipo;
        public System.Windows.Forms.Label descripcion;
        public System.Windows.Forms.Label precio;
        public System.Windows.Forms.Label stock;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Button buttonComprar;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.NumericUpDown numericUpDownCantComprar;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label labelVendedor;
        public System.Windows.Forms.Button buttonPreguntar;
    }
}