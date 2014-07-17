namespace FrbaCommerce.Calificar_Vendedor
{
    partial class FormCalificacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCalificacion));
            this.descripcionClasificacion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonClasificar = new System.Windows.Forms.Button();
            this.numericUpDownCalificacion = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCalificacion)).BeginInit();
            this.SuspendLayout();
            // 
            // descripcionClasificacion
            // 
            this.descripcionClasificacion.Location = new System.Drawing.Point(82, 102);
            this.descripcionClasificacion.Multiline = true;
            this.descripcionClasificacion.Name = "descripcionClasificacion";
            this.descripcionClasificacion.Size = new System.Drawing.Size(350, 103);
            this.descripcionClasificacion.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "CantidadDeEstrellas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Descripcion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(375, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "(Max. 255)";
            // 
            // buttonClasificar
            // 
            this.buttonClasificar.Location = new System.Drawing.Point(212, 218);
            this.buttonClasificar.Name = "buttonClasificar";
            this.buttonClasificar.Size = new System.Drawing.Size(75, 23);
            this.buttonClasificar.TabIndex = 6;
            this.buttonClasificar.Text = "Clasificar";
            this.buttonClasificar.UseVisualStyleBackColor = true;
            this.buttonClasificar.Click += new System.EventHandler(this.buttonClasificar_Click);
            // 
            // numericUpDownCalificacion
            // 
            this.numericUpDownCalificacion.Location = new System.Drawing.Point(221, 45);
            this.numericUpDownCalificacion.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownCalificacion.Name = "numericUpDownCalificacion";
            this.numericUpDownCalificacion.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownCalificacion.TabIndex = 7;
            this.numericUpDownCalificacion.ValueChanged += new System.EventHandler(this.numericUpDownCalificacion_ValueChanged);
            // 
            // FormCalificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 253);
            this.Controls.Add(this.numericUpDownCalificacion);
            this.Controls.Add(this.buttonClasificar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.descripcionClasificacion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCalificacion";
            this.Text = "Calificar";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCalificacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonClasificar;
        public System.Windows.Forms.TextBox descripcionClasificacion;
        private System.Windows.Forms.NumericUpDown numericUpDownCalificacion;

    }
}