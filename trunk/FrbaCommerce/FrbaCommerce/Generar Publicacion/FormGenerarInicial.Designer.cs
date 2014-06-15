namespace FrbaCommerce.Generar_Publicacion
{
    partial class FormGenerarInicial
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
            this.botonContinuarPublicacion = new System.Windows.Forms.Button();
            this.botonModificarPublicacion = new System.Windows.Forms.Button();
            this.botonFinalizarPublicacion = new System.Windows.Forms.Button();
            this.botonPausarPublicacion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // botonGenerarPublicacion
            // 
            this.botonGenerarPublicacion.Location = new System.Drawing.Point(74, 12);
            this.botonGenerarPublicacion.Name = "botonGenerarPublicacion";
            this.botonGenerarPublicacion.Size = new System.Drawing.Size(131, 40);
            this.botonGenerarPublicacion.TabIndex = 0;
            this.botonGenerarPublicacion.Text = "Generar Publicacion";
            this.botonGenerarPublicacion.UseVisualStyleBackColor = true;
            this.botonGenerarPublicacion.Click += new System.EventHandler(this.botonGenerarPublicacion_Click);
            // 
            // botonContinuarPublicacion
            // 
            this.botonContinuarPublicacion.Location = new System.Drawing.Point(74, 58);
            this.botonContinuarPublicacion.Name = "botonContinuarPublicacion";
            this.botonContinuarPublicacion.Size = new System.Drawing.Size(131, 43);
            this.botonContinuarPublicacion.TabIndex = 1;
            this.botonContinuarPublicacion.Text = "Continuar Publicacion";
            this.botonContinuarPublicacion.UseVisualStyleBackColor = true;
            this.botonContinuarPublicacion.Click += new System.EventHandler(this.botonContinuarPublicacion_Click);
            // 
            // botonModificarPublicacion
            // 
            this.botonModificarPublicacion.Location = new System.Drawing.Point(74, 107);
            this.botonModificarPublicacion.Name = "botonModificarPublicacion";
            this.botonModificarPublicacion.Size = new System.Drawing.Size(131, 44);
            this.botonModificarPublicacion.TabIndex = 2;
            this.botonModificarPublicacion.Text = "Modificar Publicacion Activa";
            this.botonModificarPublicacion.UseVisualStyleBackColor = true;
            this.botonModificarPublicacion.Click += new System.EventHandler(this.botonModificarPublicacion_Click);
            // 
            // botonFinalizarPublicacion
            // 
            this.botonFinalizarPublicacion.Location = new System.Drawing.Point(74, 209);
            this.botonFinalizarPublicacion.Name = "botonFinalizarPublicacion";
            this.botonFinalizarPublicacion.Size = new System.Drawing.Size(131, 46);
            this.botonFinalizarPublicacion.TabIndex = 3;
            this.botonFinalizarPublicacion.Text = "Finalizar Publicacion";
            this.botonFinalizarPublicacion.UseVisualStyleBackColor = true;
            this.botonFinalizarPublicacion.Click += new System.EventHandler(this.botonFinalizarPublicacion_Click);
            // 
            // botonPausarPublicacion
            // 
            this.botonPausarPublicacion.Location = new System.Drawing.Point(74, 157);
            this.botonPausarPublicacion.Name = "botonPausarPublicacion";
            this.botonPausarPublicacion.Size = new System.Drawing.Size(131, 46);
            this.botonPausarPublicacion.TabIndex = 4;
            this.botonPausarPublicacion.Text = "Pausar Publicacion";
            this.botonPausarPublicacion.UseVisualStyleBackColor = true;
            this.botonPausarPublicacion.Click += new System.EventHandler(this.botonPausarPublicacion_Click);
            // 
            // FormGenerarInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 265);
            this.Controls.Add(this.botonPausarPublicacion);
            this.Controls.Add(this.botonFinalizarPublicacion);
            this.Controls.Add(this.botonModificarPublicacion);
            this.Controls.Add(this.botonContinuarPublicacion);
            this.Controls.Add(this.botonGenerarPublicacion);
            this.Name = "FormGenerarInicial";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button botonGenerarPublicacion;
        private System.Windows.Forms.Button botonContinuarPublicacion;
        private System.Windows.Forms.Button botonModificarPublicacion;
        private System.Windows.Forms.Button botonFinalizarPublicacion;
        private System.Windows.Forms.Button botonPausarPublicacion;
    }
}