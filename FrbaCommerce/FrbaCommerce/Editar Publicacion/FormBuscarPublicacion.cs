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
using FrbaCommerce.Generar_Publicacion;

namespace FrbaCommerce.Editar_Publicacion
{
    public partial class FormBuscarPublicacion : Form
    {
        SistemManager cManager;
        Cliente cliente;
        Empresa empresa;
              
        
        public FormBuscarPublicacion(SistemManager cManager, Cliente cliente)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.cliente = cliente;
            cargarPublicaciones(cliente.getUsuario());
        }

        public FormBuscarPublicacion(SistemManager cManager, Empresa empresa)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.empresa = empresa;
            cargarPublicaciones(empresa.getUsuario());

        }

        private void cargarPublicaciones(string userName)
        {
            cManager.sqlPublicacion.ObtenerPublicacionesSegunUsuario(cManager, userName, this.dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Hide();

            if(this.dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString().Equals("Borrada"))
            {

                FormGenerarPublicacion formGenerarPublicacion;

                if (cliente == null) formGenerarPublicacion = new FormGenerarPublicacion(cManager, empresa);
                else formGenerarPublicacion = new FormGenerarPublicacion(cManager, cliente);
                cManager.sqlPublicacion.cargarDatosGenerar(cManager, formGenerarPublicacion, dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()); 
                formGenerarPublicacion.ShowDialog();
                this.Show();

            }
            if (this.dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString().Equals("Publicada"))
            {






            }

 
           
        }
    }
}
