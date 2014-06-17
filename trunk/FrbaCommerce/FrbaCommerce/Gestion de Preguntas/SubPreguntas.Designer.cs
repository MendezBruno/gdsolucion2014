namespace FrbaCommerce.Gestion_de_Preguntas
{
    partial class SubPreguntas
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
            this.buttonResponder = new System.Windows.Forms.Button();
            this.buttonVer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonResponder
            // 
            this.buttonResponder.Location = new System.Drawing.Point(77, 31);
            this.buttonResponder.Name = "buttonResponder";
            this.buttonResponder.Size = new System.Drawing.Size(137, 71);
            this.buttonResponder.TabIndex = 0;
            this.buttonResponder.Text = "Responder Preguntas";
            this.buttonResponder.UseVisualStyleBackColor = true;
            this.buttonResponder.Click += new System.EventHandler(this.buttonResponder_Click);
            // 
            // buttonVer
            // 
            this.buttonVer.Location = new System.Drawing.Point(77, 130);
            this.buttonVer.Name = "buttonVer";
            this.buttonVer.Size = new System.Drawing.Size(137, 75);
            this.buttonVer.TabIndex = 1;
            this.buttonVer.Text = "Ver Respuestas";
            this.buttonVer.UseVisualStyleBackColor = true;
            this.buttonVer.Click += new System.EventHandler(this.buttonVer_Click);
            // 
            // SubPreguntas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.buttonVer);
            this.Controls.Add(this.buttonResponder);
            this.Name = "SubPreguntas";
            this.Text = "SubPreguntas";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonResponder;
        private System.Windows.Forms.Button buttonVer;
    }
}