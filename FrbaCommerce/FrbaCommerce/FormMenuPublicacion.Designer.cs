﻿namespace FrbaCommerce
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenuPublicacion));
            this.botonGenerarPublicacion = new System.Windows.Forms.Button();
            this.buttonEditarPublicacion = new System.Windows.Forms.Button();
            this.linkLabelContestarPreguntas = new System.Windows.Forms.LinkLabel();
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
            // linkLabelContestarPreguntas
            // 
            this.linkLabelContestarPreguntas.AutoSize = true;
            this.linkLabelContestarPreguntas.Location = new System.Drawing.Point(82, 134);
            this.linkLabelContestarPreguntas.Name = "linkLabelContestarPreguntas";
            this.linkLabelContestarPreguntas.Size = new System.Drawing.Size(103, 13);
            this.linkLabelContestarPreguntas.TabIndex = 8;
            this.linkLabelContestarPreguntas.TabStop = true;
            this.linkLabelContestarPreguntas.Text = "Contestar Preguntas";
            this.linkLabelContestarPreguntas.Visible = false;
            this.linkLabelContestarPreguntas.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelContestarPreguntas_LinkClicked);
            // 
            // FormMenuPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 171);
            this.Controls.Add(this.linkLabelContestarPreguntas);
            this.Controls.Add(this.buttonEditarPublicacion);
            this.Controls.Add(this.botonGenerarPublicacion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMenuPublicacion";
            this.Text = "FormMenuPublicacion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button botonGenerarPublicacion;
        private System.Windows.Forms.Button buttonEditarPublicacion;
        private System.Windows.Forms.LinkLabel linkLabelContestarPreguntas;
    }
}