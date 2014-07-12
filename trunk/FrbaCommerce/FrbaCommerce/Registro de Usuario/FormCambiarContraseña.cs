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
using FrbaCommerce.Facturar_Publicaciones;
using System.Data.SqlClient;

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
            if (this.dataGridViewUsuarios.Columns[e.ColumnIndex].HeaderText.Equals("Seleccionar"))
            {
                this.Hide();

                if (this.Text.Equals("FormCambiarContraseña"))
                {
                    Usuario user = new Usuario();
                    user.setUsuario(dataGridViewUsuarios.Rows[e.RowIndex].Cells["Usuario_Nombre"].Value.ToString());
                    FormAgregarContraseña formAgregarContraseña = new FormAgregarContraseña(cManager, user);
                    formAgregarContraseña.ShowDialog();
                    this.Show();
                }
                else
                {
                    try 
                    {
                        Usuario user = new Usuario();
                        user.setUsuario(dataGridViewUsuarios.Rows[e.RowIndex].Cells["Usuario_Nombre"].Value.ToString());
                        FormFacturarPublicaciones formFactura = new FormFacturarPublicaciones(cManager, user.getUsuario());
                        formFactura.textCantPubli.Visible = false;
                        formFactura.label1.Visible = false;
                        formFactura.buttonGenerarFactura.Visible = false;
                        formFactura.mostrarItems();
                        formFactura.ShowDialog();
                    }
                    catch
                    {
                        MessageBox.Show("No hay ningun usuario seleccionnado");
                    }

                }

            }
        }
    }
}
