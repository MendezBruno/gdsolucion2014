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

namespace FrbaCommerce.Registro_de_Usuario
{
    public partial class FormCambiarContraseña : Form
    {
        SistemManager cManager;
        public FormCambiarContraseña(SistemManager cManager)
        {
            InitializeComponent();
            this.cManager = cManager;
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            cManager.sqlUsuario.buscarUsuarios(cManager, dataGridViewUsuarios, textBoxUsuario.Text);
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxUsuario.Text = "";
        }

        private void dataGridViewUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Hide();
            Usuario user = new Usuario();
            user.setUsuario(dataGridViewUsuarios.Rows[e.RowIndex].Cells["Usuario_Nombre"].ToString());
            FormAgregarContraseña formAgregarContraseña = new FormAgregarContraseña(cManager,user);
            formAgregarContraseña.ShowDialog();
            this.Show();
        }
    }
}
