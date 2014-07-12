namespace FrbaCommerce.Gestion_de_Preguntas
{
    partial class PreguntasyRespuestas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreguntasyRespuestas));
            this.dataGridViewPreguntas = new System.Windows.Forms.DataGridView();
            this.ColumnSeleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.buttonPreguntarResponder = new System.Windows.Forms.Button();
            this.richTextBoxRespuesta = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBoxPregunta = new System.Windows.Forms.RichTextBox();
            this.buttonResponder = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonEscribir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPreguntas)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPreguntas
            // 
            this.dataGridViewPreguntas.AllowUserToAddRows = false;
            this.dataGridViewPreguntas.AllowUserToDeleteRows = false;
            this.dataGridViewPreguntas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPreguntas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSeleccionar});
            this.dataGridViewPreguntas.Location = new System.Drawing.Point(12, 25);
            this.dataGridViewPreguntas.Name = "dataGridViewPreguntas";
            this.dataGridViewPreguntas.Size = new System.Drawing.Size(774, 179);
            this.dataGridViewPreguntas.TabIndex = 0;
            this.dataGridViewPreguntas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPreguntas_CellContentClick);
            // 
            // ColumnSeleccionar
            // 
            this.ColumnSeleccionar.HeaderText = "Seleccionar";
            this.ColumnSeleccionar.Name = "ColumnSeleccionar";
            // 
            // buttonPreguntarResponder
            // 
            this.buttonPreguntarResponder.Location = new System.Drawing.Point(12, 429);
            this.buttonPreguntarResponder.Name = "buttonPreguntarResponder";
            this.buttonPreguntarResponder.Size = new System.Drawing.Size(175, 35);
            this.buttonPreguntarResponder.TabIndex = 2;
            this.buttonPreguntarResponder.Text = "Publicar Pregunta";
            this.buttonPreguntarResponder.UseVisualStyleBackColor = true;
            this.buttonPreguntarResponder.Click += new System.EventHandler(this.buttonPreguntarResponder_Click);
            // 
            // richTextBoxRespuesta
            // 
            this.richTextBoxRespuesta.Location = new System.Drawing.Point(12, 329);
            this.richTextBoxRespuesta.Name = "richTextBoxRespuesta";
            this.richTextBoxRespuesta.Size = new System.Drawing.Size(774, 67);
            this.richTextBoxRespuesta.TabIndex = 3;
            this.richTextBoxRespuesta.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(669, 399);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Maximo 255 caracteres";
            // 
            // richTextBoxPregunta
            // 
            this.richTextBoxPregunta.Location = new System.Drawing.Point(12, 234);
            this.richTextBoxPregunta.Name = "richTextBoxPregunta";
            this.richTextBoxPregunta.Size = new System.Drawing.Size(773, 72);
            this.richTextBoxPregunta.TabIndex = 5;
            this.richTextBoxPregunta.Text = "";
            // 
            // buttonResponder
            // 
            this.buttonResponder.Location = new System.Drawing.Point(227, 429);
            this.buttonResponder.Name = "buttonResponder";
            this.buttonResponder.Size = new System.Drawing.Size(188, 35);
            this.buttonResponder.TabIndex = 6;
            this.buttonResponder.Text = "Responder";
            this.buttonResponder.UseVisualStyleBackColor = true;
            this.buttonResponder.Click += new System.EventHandler(this.buttonResponder_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Pregunta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 313);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Respuesta";
            // 
            // buttonEscribir
            // 
            this.buttonEscribir.Location = new System.Drawing.Point(644, 434);
            this.buttonEscribir.Name = "buttonEscribir";
            this.buttonEscribir.Size = new System.Drawing.Size(141, 30);
            this.buttonEscribir.TabIndex = 9;
            this.buttonEscribir.Text = "Escribir";
            this.buttonEscribir.UseVisualStyleBackColor = true;
            this.buttonEscribir.Click += new System.EventHandler(this.buttonEscribir_Click);
            // 
            // PreguntasyRespuestas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 476);
            this.Controls.Add(this.buttonEscribir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonResponder);
            this.Controls.Add(this.richTextBoxPregunta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBoxRespuesta);
            this.Controls.Add(this.buttonPreguntarResponder);
            this.Controls.Add(this.dataGridViewPreguntas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PreguntasyRespuestas";
            this.Text = "Preguntas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPreguntas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPreguntas;
        private System.Windows.Forms.Button buttonPreguntarResponder;
        private System.Windows.Forms.RichTextBox richTextBoxRespuesta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBoxPregunta;
        private System.Windows.Forms.Button buttonResponder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnSeleccionar;
        private System.Windows.Forms.Button buttonEscribir;
    }
}