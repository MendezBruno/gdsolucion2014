using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Modelo;
using Sistema;

namespace FrbaCommerce.Gestion_de_Preguntas
{
    public partial class FormEncontrarPreguntas : Form
    {
        SistemManager cManager;
        

        Cliente cliente;
        Empresa empresa;
        Administrador administrador;
        string userName;
        bool verRespuestas;
              
        
        public FormEncontrarPreguntas(SistemManager cManager, Cliente cliente, bool verRespuestas)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.cliente = cliente;
            this.verRespuestas = verRespuestas;
            if (verRespuestas) cargarPublicacionesVerRespuestas(cliente.getUsuario());
            else cargarPublicacionesResponderPreguntas(cliente.getUsuario());
            this.userName = cliente.getUsuario();
        }

        

        public FormEncontrarPreguntas(SistemManager cManager, Empresa empresa, bool verRespuestas)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.empresa = empresa;
            this.verRespuestas = verRespuestas;
            if (verRespuestas) cargarPublicacionesVerRespuestas(empresa.getUsuario());
            else cargarPublicacionesResponderPreguntas(empresa.getUsuario());
            this.userName = empresa.getUsuario();

        }

        public FormEncontrarPreguntas(SistemManager cManager, Administrador administrador, bool verRespuestas)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.administrador=administrador;
            this.verRespuestas = verRespuestas;
            if (verRespuestas) cargarPublicacionesVerRespuestas(administrador.getUsuario());
            else cargarPublicacionesResponderPreguntas(administrador.getUsuario());
            this.userName = administrador.getUsuario();

        }

        private void cargarPublicacionesVerRespuestas(string p)
        {
            cManager.sqlPublicacion.ObtenerPublicacionesSegunUsuarioYPreguntasConRespuestas(cManager, userName, this.dataGridView1);
        }

        private void cargarPublicacionesResponderPreguntas(string userName)
        {
            cManager.sqlPublicacion.ObtenerPublicacionesSegunUsuarioYPreguntasSinResponder(cManager, userName, this.dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Hide();
            if (verRespuestas)
            {
                if (!dataGridView1.Rows[e.RowIndex].Cells["Publicacion_Codigo"].Value.ToString().Equals(""))
                {
                    
                    FormVerRespuestas formVerRespuestas = new FormVerRespuestas(cManager,dataGridView1.Rows[e.RowIndex].Cells["Pregunta_Descripcion"].Value.ToString(),dataGridView1.Rows[e.RowIndex].Cells["Publicacion_Codigo"].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells["Publicacion_Usuario_Nombre"].Value.ToString(),  dataGridView1.Rows[e.RowIndex].Cells["Publicacion_Tipo_ID"].Value.ToString());
                    this.Close();
                }
                else
                    MessageBox.Show("No Hay Respuestas");

            }
            else
            {

                bool responder = true;

                if (!dataGridView1.Rows[e.RowIndex].Cells["Publicacion_Codigo"].Value.ToString().Equals(""))
                {
                    PreguntasyRespuestas preguntasyRespuestas = new PreguntasyRespuestas(cManager, Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Publicacion_Codigo"].Value), userName, responder);
                    preguntasyRespuestas.ShowDialog();
                    this.Close();
                }
                else
                    MessageBox.Show("No Hay preguntas para responder");
            }

            
            this.Show();
        }

    }
}
