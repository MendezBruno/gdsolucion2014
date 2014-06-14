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
            if(this.Text.Equals("Modificacion Cliente"))
            this.cManager.sqlCliente.Buscar(cManager, textBoxNombre.Text, textBoxApellido.Text, textBoxDni.Text,comboBoxTipoDNI.Text, textBoxMail.Text, this.dataGridViewModificacionCliente);
            else   
            this.cManager.sqlCliente.BuscarSinHabilitados(cManager, textBoxNombre.Text, textBoxApellido.Text, textBoxDni.Text,comboBoxTipoDNI.Text, textBoxMail.Text, this.dataGridViewModificacionCliente);
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
               
                FormAbmClienteAlta formAltaCliente = new FormAbmClienteAlta(cManager,true,false);
                cManager.sqlCliente.cargarDatosDeModificacion(cManager, formAltaCliente, dataGridViewModificacionCliente.Rows[e.RowIndex].Cells[2].Value.ToString(), dataGridViewModificacionCliente.Rows[e.RowIndex].Cells[1].Value.ToString());
                formAltaCliente.ShowDialog();
            }
            else
            {
               // FormBajaCliente formBajaRol = new FormBajaCliente(cManager);
                cManager.sqlCliente.cargarDatosDeBaja(cManager,dataGridViewModificacionCliente.Rows[e.RowIndex].Cells[1].Value.ToString(), dataGridViewModificacionCliente.Rows[e.RowIndex].Cells[2].Value.ToString());
               // formBajaRol.ShowDialog();
            }

            this.Close();
        }

        private void textBoxDni_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan 
                e.Handled = true;
            }

        }



    }
}
