namespace FrbaCommerce.ABM_Rol
{
    partial class FormABMRol
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
            this.buttonCrearRol = new System.Windows.Forms.Button();
            this.buttonModificar = new System.Windows.Forms.Button();
            this.buttonBaja = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCrearRol
            // 
            this.buttonCrearRol.Location = new System.Drawing.Point(68, 20);
            this.buttonCrearRol.Name = "buttonCrearRol";
            this.buttonCrearRol.Size = new System.Drawing.Size(147, 45);
            this.buttonCrearRol.TabIndex = 0;
            this.buttonCrearRol.Text = "Crear Rol";
            this.buttonCrearRol.UseVisualStyleBackColor = true;
            this.buttonCrearRol.Click += new System.EventHandler(this.buttonCrearRol_Click);
            // 
            // buttonModificar
            // 
            this.buttonModificar.Location = new System.Drawing.Point(68, 90);
            this.buttonModificar.Name = "buttonModificar";
            this.buttonModificar.Size = new System.Drawing.Size(146, 51);
            this.buttonModificar.TabIndex = 1;
            this.buttonModificar.Text = "Modificar";
            this.buttonModificar.UseVisualStyleBackColor = true;
            this.buttonModificar.Click += new System.EventHandler(this.buttonModificar_Click);
            // 
            // buttonBaja
            // 
            this.buttonBaja.Location = new System.Drawing.Point(68, 169);
            this.buttonBaja.Name = "buttonBaja";
            this.buttonBaja.Size = new System.Drawing.Size(142, 52);
            this.buttonBaja.TabIndex = 2;
            this.buttonBaja.Text = "Baja";
            this.buttonBaja.UseVisualStyleBackColor = true;
            this.buttonBaja.Click += new System.EventHandler(this.buttonBaja_Click);
            // 
            // FormABMRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.buttonBaja);
            this.Controls.Add(this.buttonModificar);
            this.Controls.Add(this.buttonCrearRol);
            this.Name = "FormABMRol";
            this.Text = "Roles";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCrearRol;
        private System.Windows.Forms.Button buttonModificar;
        private System.Windows.Forms.Button buttonBaja;
    }
}