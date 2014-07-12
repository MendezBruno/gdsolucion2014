namespace FrbaCommerce.Comprar_Ofertar
{
    partial class FormOfertar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOfertar));
            this.label1 = new System.Windows.Forms.Label();
            this.boton_Confirmar_Oferta = new System.Windows.Forms.Button();
            this.numericUpDownOfer = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOfer)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Monto:";
            // 
            // boton_Confirmar_Oferta
            // 
            this.boton_Confirmar_Oferta.Location = new System.Drawing.Point(89, 90);
            this.boton_Confirmar_Oferta.Name = "boton_Confirmar_Oferta";
            this.boton_Confirmar_Oferta.Size = new System.Drawing.Size(121, 23);
            this.boton_Confirmar_Oferta.TabIndex = 2;
            this.boton_Confirmar_Oferta.Text = "Confirmar Oferta";
            this.boton_Confirmar_Oferta.UseVisualStyleBackColor = true;
            this.boton_Confirmar_Oferta.Click += new System.EventHandler(this.boton_Confirmar_Oferta_Click);
            // 
            // numericUpDownOfer
            // 
            this.numericUpDownOfer.Location = new System.Drawing.Point(121, 46);
            this.numericUpDownOfer.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.numericUpDownOfer.Name = "numericUpDownOfer";
            this.numericUpDownOfer.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownOfer.TabIndex = 3;
            this.numericUpDownOfer.ValueChanged += new System.EventHandler(this.numericUpDownOfer_ValueChanged);
            // 
            // FormOfertar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 136);
            this.Controls.Add(this.numericUpDownOfer);
            this.Controls.Add(this.boton_Confirmar_Oferta);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormOfertar";
            this.Text = "Ingresar Monto";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOfer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button boton_Confirmar_Oferta;
        private System.Windows.Forms.NumericUpDown numericUpDownOfer;
    }
}