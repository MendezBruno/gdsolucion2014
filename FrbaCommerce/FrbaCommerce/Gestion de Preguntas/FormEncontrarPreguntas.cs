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
            this.userName = cliente.getUsuario();
            if (verRespuestas) cargarPublicacionesVerRespuestas(cliente.getUsuario());
            else cargarPublicacionesResponderPreguntas(cliente.getUsuario());


        }

        

        public FormEncontrarPreguntas(SistemManager cManager, Empresa empresa, bool verRespuestas)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.empresa = empresa;
            this.verRespuestas = verRespuestas;
            this.userName = empresa.getUsuario();
            if (verRespuestas) cargarPublicacionesVerRespuestas(empresa.getUsuario());
            else cargarPublicacionesResponderPreguntas(empresa.getUsuario());

        }

        public FormEncontrarPreguntas(SistemManager cManager, Administrador administrador, bool verRespuestas)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.administrador=administrador;
            this.verRespuestas = verRespuestas;
            this.userName = administrador.getUsuario();
            if (verRespuestas) cargarPublicacionesVerRespuestas(administrador.getUsuario());
            else cargarPublicacionesResponderPreguntas(administrador.getUsuario());

        }

        private void cargarPublicacionesVerRespuestas(string p)
        {
            cManager.sqlPublicacion.ObtenerPublicacionesSegunUsuarioYPreguntasConRespuestas(cManager, this.userName, this.dataGridView1);
        
        }

        private void cargarPublicacionesResponderPreguntas(string userName)
        {
            cManager.sqlPublicacion.ObtenerPublicacionesSegunUsuarioYPreguntasSinResponder(cManager, this.userName, this.dataGridView1);
          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].HeaderText.Equals("Seleccionar"))
            {
                this.Hide();

                if (verRespuestas)
                {


                    FormVerRespuestas formVerRespuestas = new FormVerRespuestas(cManager, dataGridView1.Rows[e.RowIndex].Cells["Pregunta_Descripcion"].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells["Publicacion_Codigo"].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells["Publicacion_Usuario_Nombre"].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells["Publicacion_Tipo_ID"].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells["Pregunta_Usuario_Nombre"].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells["Pregunta_Respuesta_ID"].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells["Respuesta_Fecha"].Value.ToString());
                    formVerRespuestas.ShowDialog();
                    
                    this.Close();

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
}
