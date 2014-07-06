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
            cargarPanelDePreguntasRespuestas(cManager);
            this.cManager = cManager;
            this.codigoPublicacion = codigoPublicacion;
            this.usuario = usuario;
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
        }

        private void dataGridViewPreguntas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            richTextBoxPregunta.Text = dataGridViewPreguntas.Rows[e.RowIndex].Cells[2].ToString();
            richTextBoxRespuesta.Text = dataGridViewPreguntas.Rows[e.RowIndex].Cells["Respuesta_Respuesta"].ToString();
        }


    }
}
