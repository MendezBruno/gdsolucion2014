using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Buscar_Publicaciones;
using FrbaCommerce.Modelo;
using Sistema;

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
            FormEditarPublicacion formEditarPublicacion;
           
            //Aca va La obtenceion de la Publicacion

            if (cliente == null) formEditarPublicacion = new FormEditarPublicacion(cManager, empresa);
            else formEditarPublicacion = new FormEditarPublicacion(cManager, cliente);
            formEditarPublicacion.ShowDialog();
            this.Show();
        }
    }
}
