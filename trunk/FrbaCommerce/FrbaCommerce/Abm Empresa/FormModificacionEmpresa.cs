using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Modelo;

namespace FrbaCommerce.Abm_Empresa
{
    public partial class FormModificacionEmpresa : Form
    {
        SistemManager cManager;

        public FormModificacionEmpresa(SistemManager cManager)
        {
            InitializeComponent();
            this.cManager = cManager;

        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            if (this.Text.Equals("Modificacion Empresa"))
            {
                cManager.sqlEmpresa.BuscarEmpresa(cManager, textBoxRazonSocial.Text, textBoxMail.Text, textBoxCuit.Text, this.dataGridViewEmpresa);
                dataGridViewEmpresa.Update();
                this.SeleccionarColumn.HeaderText = "Seleccionar";
            }
            else
            {
                cManager.sqlEmpresa.BuscarEmpresaHabilitada(cManager, textBoxRazonSocial.Text, textBoxMail.Text, textBoxCuit.Text, this.dataGridViewEmpresa);
                dataGridViewEmpresa.Update();
                this.SeleccionarColumn.HeaderText = "Eliminar";
            }
        }

        private void dataGridViewEmpresa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridViewEmpresa.Columns[e.ColumnIndex].HeaderText.Equals("Seleccionar"))
            {

                this.Hide();
                FormAbmEmpresaAlta formAltaEmpresa = new FormAbmEmpresaAlta(cManager, true);
                cManager.sqlEmpresa.cargarDatosDeModificacion(cManager, formAltaEmpresa, dataGridViewEmpresa.Rows[e.RowIndex].Cells[2].Value.ToString());
                formAltaEmpresa.ShowDialog();
                this.Close();
            }
            if (dataGridViewEmpresa.Columns[e.ColumnIndex].HeaderText.Equals("Eliminar"))
            {
                this.Hide();
                // FormBajaCliente formBajaRol = new FormBajaCliente(cManager);
                cManager.sqlEmpresa.cargarDatosDeBaja(cManager, dataGridViewEmpresa.Rows[e.RowIndex].Cells[2].Value.ToString());
                // formBajaRol.ShowDialog();
                this.Close();
            }

        


        }



    }
}
