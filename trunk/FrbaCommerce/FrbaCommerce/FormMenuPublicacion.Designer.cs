namespace FrbaCommerce
{
    partial class FormMenuPublicacion
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
            this.botonGenerarPublicacion = new System.Windows.Forms.Button();
            this.buttonEditarPublicacion = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // botonGenerarPublicacion
            // 
            this.botonGenerarPublicacion.Location = new System.Drawing.Point(68, 12);
            this.botonGenerarPublicacion.Name = "botonGenerarPublicacion";
            this.botonGenerarPublicacion.Size = new System.Drawing.Size(131, 40);
            this.botonGenerarPublicacion.TabIndex = 5;
            this.botonGenerarPublicacion.Text = "Generar Publicacion";
            this.botonGenerarPublicacion.UseVisualStyleBackColor = true;
            this.botonGenerarPublicacion.Click += new System.EventHandler(this.botonGenerarPublicacion_Click);
            // 
            // buttonEditarPublicacion
            // 
            this.buttonEditarPublicacion.Location = new System.Drawing.Point(69, 69);
            this.buttonEditarPublicacion.Name = "buttonEditarPublicacion";
            this.buttonEditarPublicacion.Size = new System.Drawing.Size(130, 44);
            this.buttonEditarPublicacion.TabIndex = 6;
            this.buttonEditarPublicacion.Text = "Editar Publicacion";
            this.buttonEditarPublicacion.UseVisualStyleBackColor = true;
            this.buttonEditarPublicacion.Click += new System.EventHandler(this.buttonEditarPublicacion_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(69, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 48);
            this.button1.TabIndex = 7;
            this.button1.Text = "Borrar Publicacion";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormMenuPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 203);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonEditarPublicacion);
            this.Controls.Add(this.botonGenerarPublicacion);
            this.Name = "FormMenuPublicacion";
            this.Text = "FormMenuPublicacion";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button botonGenerarPublicacion;
        private System.Windows.Forms.Button buttonEditarPublicacion;
        private System.Windows.Forms.Button button1;
    }
}