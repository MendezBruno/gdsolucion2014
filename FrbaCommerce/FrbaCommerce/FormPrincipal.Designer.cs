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
            this.buttonLoggin = new System.Windows.Forms.Button();
            this.buttonCrearUsuario = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonLoggin
            // 
            this.buttonLoggin.Location = new System.Drawing.Point(74, 20);
            this.buttonLoggin.Name = "buttonLoggin";
            this.buttonLoggin.Size = new System.Drawing.Size(137, 42);
            this.buttonLoggin.TabIndex = 0;
            this.buttonLoggin.Text = "loggin";
            this.buttonLoggin.UseVisualStyleBackColor = true;
            this.buttonLoggin.Click += new System.EventHandler(this.buttonLoggin_Click);
            // 
            // buttonCrearUsuario
            // 
            this.buttonCrearUsuario.Location = new System.Drawing.Point(74, 80);
            this.buttonCrearUsuario.Name = "buttonCrearUsuario";
            this.buttonCrearUsuario.Size = new System.Drawing.Size(137, 43);
            this.buttonCrearUsuario.TabIndex = 1;
            this.buttonCrearUsuario.Text = "Crear Usuario";
            this.buttonCrearUsuario.UseVisualStyleBackColor = true;
            this.buttonCrearUsuario.Click += new System.EventHandler(this.buttonCrearUsuario_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(75, 146);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 45);
            this.button1.TabIndex = 2;
            this.button1.Text = "Modificaciones";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonCrearUsuario);
            this.Controls.Add(this.buttonLoggin);
            this.Name = "FormPrincipal";
            this.Text = "Cuadro de Opciones Principales";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonLoggin;
        private System.Windows.Forms.Button buttonCrearUsuario;
        private System.Windows.Forms.Button button1;
    }
}

