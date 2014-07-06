namespace FrbaCommerce.Editar_Publicacion
{
    partial class FormModificarPublicacion
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
            this.Pausar = new System.Windows.Forms.Button();
            this.Activar = new System.Windows.Forms.Button();
            this.Finalizar = new System.Windows.Forms.Button();
            this.modifStock = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Que desea hacer con la publicacion?";
            // 
            // Pausar
            // 
            this.Pausar.Location = new System.Drawing.Point(12, 93);
            this.Pausar.Name = "Pausar";
            this.Pausar.Size = new System.Drawing.Size(75, 23);
            this.Pausar.TabIndex = 1;
            this.Pausar.Text = "Pausar";
            this.Pausar.UseVisualStyleBackColor = true;
            this.Pausar.Click += new System.EventHandler(this.Pausar_Click);
            // 
            // Activar
            // 
            this.Activar.Location = new System.Drawing.Point(129, 93);
            this.Activar.Name = "Activar";
            this.Activar.Size = new System.Drawing.Size(75, 23);
            this.Activar.TabIndex = 2;
            this.Activar.Text = "Activar";
            this.Activar.UseVisualStyleBackColor = true;
            this.Activar.Click += new System.EventHandler(this.Activar_Click);
            // 
            // Finalizar
            // 
            this.Finalizar.Location = new System.Drawing.Point(246, 93);
            this.Finalizar.Name = "Finalizar";
            this.Finalizar.Size = new System.Drawing.Size(75, 23);
            this.Finalizar.TabIndex = 3;
            this.Finalizar.Text = "Finalizar";
            this.Finalizar.UseVisualStyleBackColor = true;
            this.Finalizar.Click += new System.EventHandler(this.Finalizar_Click);
            // 
            // modifStock
            // 
            this.modifStock.Location = new System.Drawing.Point(12, 123);
            this.modifStock.Name = "modifStock";
            this.modifStock.Size = new System.Drawing.Size(141, 23);
            this.modifStock.TabIndex = 4;
            this.modifStock.Text = "Modificar Stock";
            this.modifStock.UseVisualStyleBackColor = true;
            this.modifStock.Click += new System.EventHandler(this.modifStock_Click);
            // 
            // FormModificarPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 158);
            this.Controls.Add(this.modifStock);
            this.Controls.Add(this.Finalizar);
            this.Controls.Add(this.Activar);
            this.Controls.Add(this.Pausar);
            this.Controls.Add(this.label1);
            this.Name = "FormModificarPublicacion";
            this.Text = "FormModificarPublicacion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button Pausar;
        public System.Windows.Forms.Button Activar;
        public System.Windows.Forms.Button Finalizar;
        public System.Windows.Forms.Button modifStock;
    }
}