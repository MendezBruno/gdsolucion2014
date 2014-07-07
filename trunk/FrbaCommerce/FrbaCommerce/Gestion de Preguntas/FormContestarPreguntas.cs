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
    public partial class FormContestarPreguntas : Form
    {
        SistemManager cManager;
        

        Cliente cliente;
        Empresa empresa;
        Administrador administrador;
        string userName;
              
        
        public FormContestarPreguntas(SistemManager cManager, Cliente cliente)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.cliente = cliente;
            cargarPublicaciones(cliente.getUsuario());
            this.userName = cliente.getUsuario();
        }

        public FormContestarPreguntas(SistemManager cManager, Empresa empresa)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.empresa = empresa;
            cargarPublicaciones(empresa.getUsuario());
            this.userName = empresa.getUsuario();

        }

        public FormContestarPreguntas(SistemManager cManager, Administrador administrador)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.administrador=administrador;
            cargarPublicaciones(administrador.getUsuario());
            this.userName = administrador.getUsuario();

        }

        private void cargarPublicaciones(string userName)
        {
            cManager.sqlPublicacion.ObtenerPublicacionesSegunUsuarioYPreguntasSinResponder(cManager, userName, this.dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Hide();
            bool responder = true;

            if (dataGridView1.Rows[e.RowIndex] != null)
            {
                PreguntasyRespuestas preguntasyRespuestas = new PreguntasyRespuestas(cManager, Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Publicacion_Codigo"].Value), userName, responder);
                preguntasyRespuestas.ShowDialog();
                this.Close();
            }
            else
                MessageBox.Show("No Hay preguntas para responder");


            
            this.Show();
        }

    }
}
