namespace FrbaCommerce.Login
{
    partial class FormLoggin
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
            this.labelUsuario = new System.Windows.Forms.Label();
            this.labelContrasenia = new System.Windows.Forms.Label();
            this.buttonIngresar = new System.Windows.Forms.Button();
            this.textBoxUsuario = new System.Windows.Forms.TextBox();
            this.textBoxContraseña = new System.Windows.Forms.TextBox();
            this.linkLabelRegistrarse = new System.Windows.Forms.LinkLabel();
            this.labelUsuarioInexistente = new System.Windows.Forms.Label();
            this.labelContraseñaincorrecta = new System.Windows.Forms.Label();
            this.labelUsuarioDeshabilitado = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // labelUsuario
            // 
            this.labelUsuario.AutoSize = true;
            this.labelUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsuario.Location = new System.Drawing.Point(22, 37);
            this.labelUsuario.Name = "labelUsuario";
            this.labelUsuario.Size = new System.Drawing.Size(60, 18);
            this.labelUsuario.TabIndex = 0;
            this.labelUsuario.Text = "Usuario";
            // 
            // labelContrasenia
            // 
            this.labelContrasenia.AutoSize = true;
            this.labelContrasenia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelContrasenia.Location = new System.Drawing.Point(22, 77);
            this.labelContrasenia.Name = "labelContrasenia";
            this.labelContrasenia.Size = new System.Drawing.Size(85, 18);
            this.labelContrasenia.TabIndex = 1;
            this.labelContrasenia.Text = "Contraseña";
            // 
            // buttonIngresar
            // 
            this.buttonIngresar.Location = new System.Drawing.Point(92, 115);
            this.buttonIngresar.Name = "buttonIngresar";
            this.buttonIngresar.Size = new System.Drawing.Size(132, 29);
            this.buttonIngresar.TabIndex = 2;
            this.buttonIngresar.Text = "Ingresar";
            this.buttonIngresar.UseVisualStyleBackColor = true;
            this.buttonIngresar.Click += new System.EventHandler(this.buttonIngresar_Click);
            // 
            // textBoxUsuario
            // 
            this.textBoxUsuario.Location = new System.Drawing.Point(125, 35);
            this.textBoxUsuario.Name = "textBoxUsuario";
            this.textBoxUsuario.Size = new System.Drawing.Size(144, 20);
            this.textBoxUsuario.TabIndex = 3;
            // 
            // textBoxContraseña
            // 
            this.textBoxContraseña.Location = new System.Drawing.Point(125, 75);
            this.textBoxContraseña.Name = "textBoxContraseña";
            this.textBoxContraseña.Size = new System.Drawing.Size(144, 20);
            this.textBoxContraseña.TabIndex = 4;
            // 
            // linkLabelRegistrarse
            // 
            this.linkLabelRegistrarse.AutoSize = true;
            this.linkLabelRegistrarse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelRegistrarse.Location = new System.Drawing.Point(100, 156);
            this.linkLabelRegistrarse.Name = "linkLabelRegistrarse";
            this.linkLabelRegistrarse.Size = new System.Drawing.Size(113, 17);
            this.linkLabelRegistrarse.TabIndex = 5;
            this.linkLabelRegistrarse.TabStop = true;
            this.linkLabelRegistrarse.Text = "Registrar Cliente";
            this.linkLabelRegistrarse.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelRegistrarse_LinkClicked);
            // 
            // labelUsuarioInexistente
            // 
            this.labelUsuarioInexistente.AutoSize = true;
            this.labelUsuarioInexistente.ForeColor = System.Drawing.Color.Red;
            this.labelUsuarioInexistente.Location = new System.Drawing.Point(98, 9);
            this.labelUsuarioInexistente.Name = "labelUsuarioInexistente";
            this.labelUsuarioInexistente.Size = new System.Drawing.Size(97, 13);
            this.labelUsuarioInexistente.TabIndex = 6;
            this.labelUsuarioInexistente.Text = "Usuario Inexistente";
            this.labelUsuarioInexistente.Visible = false;
            // 
            // labelContraseñaincorrecta
            // 
            this.labelContraseñaincorrecta.AutoSize = true;
            this.labelContraseñaincorrecta.ForeColor = System.Drawing.Color.Red;
            this.labelContraseñaincorrecta.Location = new System.Drawing.Point(98, 9);
            this.labelContraseñaincorrecta.Name = "labelContraseñaincorrecta";
            this.labelContraseñaincorrecta.Size = new System.Drawing.Size(115, 13);
            this.labelContraseñaincorrecta.TabIndex = 7;
            this.labelContraseñaincorrecta.Text = "Contraseña Incorrecta!";
            this.labelContraseñaincorrecta.Visible = false;
            // 
            // labelUsuarioDeshabilitado
            // 
            this.labelUsuarioDeshabilitado.AutoSize = true;
            this.labelUsuarioDeshabilitado.ForeColor = System.Drawing.Color.Red;
            this.labelUsuarioDeshabilitado.Location = new System.Drawing.Point(36, 9);
            this.labelUsuarioDeshabilitado.Name = "labelUsuarioDeshabilitado";
            this.labelUsuarioDeshabilitado.Size = new System.Drawing.Size(233, 13);
            this.labelUsuarioDeshabilitado.TabIndex = 8;
            this.labelUsuarioDeshabilitado.Text = "usuario deshabilitado comunicarse con sistemas";
            this.labelUsuarioDeshabilitado.Visible = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(98, 182);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(126, 17);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Registrar Empresa";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // FormLoggin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 208);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.labelUsuarioDeshabilitado);
            this.Controls.Add(this.labelContraseñaincorrecta);
            this.Controls.Add(this.labelUsuarioInexistente);
            this.Controls.Add(this.linkLabelRegistrarse);
            this.Controls.Add(this.textBoxContraseña);
            this.Controls.Add(this.textBoxUsuario);
            this.Controls.Add(this.buttonIngresar);
            this.Controls.Add(this.labelContrasenia);
            this.Controls.Add(this.labelUsuario);
            this.Name = "FormLoggin";
            this.Text = "LOGIN";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUsuario;
        private System.Windows.Forms.Label labelContrasenia;
        private System.Windows.Forms.Button buttonIngresar;
        private System.Windows.Forms.TextBox textBoxUsuario;
        private System.Windows.Forms.TextBox textBoxContraseña;
        private System.Windows.Forms.LinkLabel linkLabelRegistrarse;
        private System.Windows.Forms.Label labelUsuarioInexistente;
        private System.Windows.Forms.Label labelContraseñaincorrecta;
        private System.Windows.Forms.Label labelUsuarioDeshabilitado;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}