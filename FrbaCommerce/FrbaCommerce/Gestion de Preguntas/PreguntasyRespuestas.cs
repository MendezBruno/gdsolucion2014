using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Modelo;

namespace FrbaCommerce.Gestion_de_Preguntas
{

    public partial class PreguntasyRespuestas : Form
    {
        SistemManager cManager;
        int codigoPublicacion;
        string usuario;
        public PreguntasyRespuestas(SistemManager cManager, int codigoPublicacion, string usuario)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.codigoPublicacion = codigoPublicacion;
            cargarPanelDePreguntasRespuestas(cManager);
            this.usuario = usuario;
            buttonResponder.Visible = false;
        }
        
        public PreguntasyRespuestas(SistemManager cManager, int codigoPublicacion, string usuario,bool responder)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.codigoPublicacion = codigoPublicacion; //me falta cargar esto con el codigo?
            cargarPanelDePreguntasRespuestas(cManager);
            this.usuario = usuario;
            buttonPreguntarResponder.Visible = false;
        }
        

        private void cargarPanelDePreguntasRespuestas(SistemManager cManager)
        {
            cManager.sqlPreguntas.CargarPreguntas(dataGridViewPreguntas,codigoPublicacion,cManager);
        }

        private void buttonPreguntarResponder_Click(object sender, EventArgs e)
        {
            cManager.sqlPreguntas.insertarPregunta(cManager,richTextBoxPregunta.Text,codigoPublicacion,usuario);
        }

        private void buttonResponder_Click(object sender, EventArgs e)
        {
            cManager.sqlPreguntas.insertarRespuesta(cManager, richTextBoxRespuesta.Text, codigoPublicacion);
            MessageBox.Show("Pregunta Cargada Correctamente");
            richTextBoxPregunta.Clear();
        }

        private void dataGridViewPreguntas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            richTextBoxPregunta.Enabled = true;
            richTextBoxRespuesta.Enabled = true;
            richTextBoxPregunta.Text = dataGridViewPreguntas.Rows[e.RowIndex].Cells[2].Value.ToString();
            richTextBoxRespuesta.Text = dataGridViewPreguntas.Rows[e.RowIndex].Cells["Respuesta_Respuesta"].Value.ToString();
            richTextBoxPregunta.Enabled = false;
            richTextBoxRespuesta.Enabled = false;
        }

        private void buttonEscribir_Click(object sender, EventArgs e)
        {
            if (buttonResponder.Visible)
            {
                richTextBoxRespuesta.Enabled = true;
                richTextBoxRespuesta.Clear();
            }
            else
            {
                richTextBoxPregunta.Enabled = true;
                richTextBoxPregunta.Clear();
            }

        }



    }
}
