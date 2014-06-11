using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Modelo;

namespace FrbaCommerce.Abm_Cliente
{
    public partial class FormAbmModificacionCliente : Form
    {
        SistemManager cManager;

        public FormAbmModificacionCliente(SistemManager cManager)
        {
            InitializeComponent();
            this.cManager = cManager;
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            this.cManager.sqlCliente.Buscar(cManager, textBoxNombre.Text, textBoxApellido.Text, comboBoxTipoDNI.Text,textBoxDni.Text, textBoxMail.Text, this.dataGridViewModificacionCliente);
            this.dataGridViewModificacionCliente.Update();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxNombre.Text="";
            textBoxApellido.Text="";
            textBoxDni.Text="";
            textBoxMail.Text = "";
        }

        private void dataGridViewModificacionCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Hide();
            if (this.Text.Equals("Modificacion Cliente"))
            {
               
                FormAbmClienteAlta formAltaCliente = new FormAbmClienteAlta(cManager,true);
                cManager.sqlCliente.cargarDatosDeModificacion(cManager, formAltaCliente, dataGridViewModificacionCliente.Rows[e.RowIndex].Cells[1].Value.ToString(), dataGridViewModificacionCliente.Rows[e.RowIndex].Cells[5].Value.ToString());
                formAltaCliente.ShowDialog();
            }
            else
            {
               // FormBajaCliente formBajaRol = new FormBajaCliente(cManager);
                cManager.sqlCliente.cargarDatosDeBaja(cManager, dataGridViewModificacionCliente.Rows[e.RowIndex].Cells[1].Value.ToString());
               // formBajaRol.ShowDialog();
            }

            this.Close();
        }




    }
}
