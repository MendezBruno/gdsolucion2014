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
        public FormVerRespuestas(SistemManager cManager,string pregunta,string codigoPublicacion, string Usuario, string tipoPublicacion)
        {
            InitializeComponent();
            labelPublicacion.Text = codigoPublicacion;
            labelTipoPublicacion.Text = tipoPublicacion;
            labelUsuarioPublicacion.Text = Usuario;
            richTextBoxPregunta.Text = pregunta;
            CargarRestoDelFormulario(cManager, codigoPublicacion);
        }

        private void CargarRestoDelFormulario(SistemManager cManager, string codigoPublicacion)
        {
            richTextBoxRespuesta.Text= cManager.sqlPreguntas.buscarRespuesta(cManager, codigoPublicacion);
            
        }
    }
}
