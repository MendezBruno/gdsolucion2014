namespace FrbaCommerce
{
    partial class FormPrincipal
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
            this.BotonComprar = new System.Windows.Forms.Button();
            this.buttonCrearUsuario = new System.Windows.Forms.Button();
            this.buttonModificaciones = new System.Windows.Forms.Button();
            this.buttonPublicaciones = new System.Windows.Forms.Button();
            this.BotonOfertar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonCalificar = new System.Windows.Forms.Button();
            this.buttonHistorial = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BotonComprar
            // 
            this.BotonComprar.Location = new System.Drawing.Point(12, 23);
            this.BotonComprar.Name = "BotonComprar";
            this.BotonComprar.Size = new System.Drawing.Size(137, 42);
            this.BotonComprar.TabIndex = 0;
            this.BotonComprar.Text = "Comprar";
            this.BotonComprar.UseVisualStyleBackColor = true;
            // 
            // buttonCrearUsuario
            // 
            this.buttonCrearUsuario.Location = new System.Drawing.Point(247, 23);
            this.buttonCrearUsuario.Name = "buttonCrearUsuario";
            this.buttonCrearUsuario.Size = new System.Drawing.Size(137, 43);
            this.buttonCrearUsuario.TabIndex = 1;
            this.buttonCrearUsuario.Text = "Crear Usuario";
            this.buttonCrearUsuario.UseVisualStyleBackColor = true;
            this.buttonCrearUsuario.Click += new System.EventHandler(this.buttonCrearUsuario_Click);
            // 
            // buttonModificaciones
            // 
            this.buttonModificaciones.Location = new System.Drawing.Point(247, 72);
            this.buttonModificaciones.Name = "buttonModificaciones";
            this.buttonModificaciones.Size = new System.Drawing.Size(135, 45);
            this.buttonModificaciones.TabIndex = 2;
            this.buttonModificaciones.Text = "Modificaciones";
            this.buttonModificaciones.UseVisualStyleBackColor = true;
            this.buttonModificaciones.Click += new System.EventHandler(this.buttonModificaciones_Click);
            // 
            // buttonPublicaciones
            // 
            this.buttonPublicaciones.Location = new System.Drawing.Point(12, 72);
            this.buttonPublicaciones.Name = "buttonPublicaciones";
            this.buttonPublicaciones.Size = new System.Drawing.Size(137, 45);
            this.buttonPublicaciones.TabIndex = 3;
            this.buttonPublicaciones.Text = "Publicaciones";
            this.buttonPublicaciones.UseVisualStyleBackColor = true;
            this.buttonPublicaciones.Click += new System.EventHandler(this.buttonPublicaciones_Click);
            // 
            // BotonOfertar
            // 
            this.BotonOfertar.Location = new System.Drawing.Point(12, 123);
            this.BotonOfertar.Name = "BotonOfertar";
            this.BotonOfertar.Size = new System.Drawing.Size(137, 44);
            this.BotonOfertar.TabIndex = 4;
            this.BotonOfertar.Text = "Ofertar";
            this.BotonOfertar.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(247, 123);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(137, 44);
            this.button2.TabIndex = 5;
            this.button2.Text = "Estadisticas";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // buttonCalificar
            // 
            this.buttonCalificar.Location = new System.Drawing.Point(12, 173);
            this.buttonCalificar.Name = "buttonCalificar";
            this.buttonCalificar.Size = new System.Drawing.Size(137, 44);
            this.buttonCalificar.TabIndex = 6;
            this.buttonCalificar.Text = "Calificar";
            this.buttonCalificar.UseVisualStyleBackColor = true;
            // 
            // buttonHistorial
            // 
            this.buttonHistorial.Location = new System.Drawing.Point(247, 173);
            this.buttonHistorial.Name = "buttonHistorial";
            this.buttonHistorial.Size = new System.Drawing.Size(137, 44);
            this.buttonHistorial.TabIndex = 7;
            this.buttonHistorial.Text = "Historial";
            this.buttonHistorial.UseVisualStyleBackColor = true;
            this.buttonHistorial.Click += new System.EventHandler(this.buttonHistorial_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 255);
            this.Controls.Add(this.buttonHistorial);
            this.Controls.Add(this.buttonCalificar);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.BotonOfertar);
            this.Controls.Add(this.buttonPublicaciones);
            this.Controls.Add(this.buttonModificaciones);
            this.Controls.Add(this.buttonCrearUsuario);
            this.Controls.Add(this.BotonComprar);
            this.Name = "FormPrincipal";
            this.Text = "Cuadro de Opciones Principales";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BotonComprar;
        private System.Windows.Forms.Button buttonCrearUsuario;
        private System.Windows.Forms.Button buttonModificaciones;
        private System.Windows.Forms.Button buttonPublicaciones;
        private System.Windows.Forms.Button BotonOfertar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonCalificar;
        private System.Windows.Forms.Button buttonHistorial;
    }
}

