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
    public partial class FormVerRespuestas : Form
    {
        SistemManager cManager;
        string respuestaID;
        public FormVerRespuestas(SistemManager cManager,string pregunta,string codigoPublicacion, string Usuario, string tipoPublicacion,string preguntaUsuarioNombre,string Pregunta_Respuesta_ID,string fecha_Respuesta)
        {
            InitializeComponent();
            labelPublicacion.Text = codigoPublicacion;
            labelTipoPublicacion.Text = tipoPublicacion;
            labelUsuarioPublicacion.Text = Usuario;
            labelFechaRespuesta.Text = fecha_Respuesta;
            richTextBoxPregunta.Text = pregunta;
            this.respuestaID = Pregunta_Respuesta_ID;
            CargarRestoDelFormulario(cManager, codigoPublicacion);
        }

        private void CargarRestoDelFormulario(SistemManager cManager, string codigoPublicacion)
        {
            richTextBoxRespuesta.Text = cManager.sqlPreguntas.buscarRespuesta(cManager, this.respuestaID);
            
        }
    }
}
