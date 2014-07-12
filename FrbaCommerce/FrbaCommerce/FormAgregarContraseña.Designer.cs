namespace FrbaCommerce
{
    partial class FormAgregarContraseña
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAgregarContraseña));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxContraseña = new System.Windows.Forms.TextBox();
            this.textBoxReContraseña = new System.Windows.Forms.TextBox();
            this.labelNoCoincide = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Contraseña";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Reingrese Contraseña";
            // 
            // textBoxContraseña
            // 
            this.textBoxContraseña.Location = new System.Drawing.Point(125, 38);
            this.textBoxContraseña.Name = "textBoxContraseña";
            this.textBoxContraseña.Size = new System.Drawing.Size(143, 20);
            this.textBoxContraseña.TabIndex = 2;
            // 
            // textBoxReContraseña
            // 
            this.textBoxReContraseña.Location = new System.Drawing.Point(125, 90);
            this.textBoxReContraseña.Name = "textBoxReContraseña";
            this.textBoxReContraseña.Size = new System.Drawing.Size(142, 20);
            this.textBoxReContraseña.TabIndex = 3;
            // 
            // labelNoCoincide
            // 
            this.labelNoCoincide.AutoSize = true;
            this.labelNoCoincide.ForeColor = System.Drawing.Color.Red;
            this.labelNoCoincide.Location = new System.Drawing.Point(73, 9);
            this.labelNoCoincide.Name = "labelNoCoincide";
            this.labelNoCoincide.Size = new System.Drawing.Size(159, 13);
            this.labelNoCoincide.TabIndex = 4;
            this.labelNoCoincide.Text = "La Contreseñas Deben Coincidir";
            this.labelNoCoincide.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(92, 135);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 35);
            this.button1.TabIndex = 5;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormAgregarContraseña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 192);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelNoCoincide);
            this.Controls.Add(this.textBoxReContraseña);
            this.Controls.Add(this.textBoxContraseña);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAgregarContraseña";
            this.Text = "FormAgregarContraseña";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxContraseña;
        private System.Windows.Forms.TextBox textBoxReContraseña;
        private System.Windows.Forms.Label labelNoCoincide;
        private System.Windows.Forms.Button button1;
    }
}