using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Modelo;

namespace FrbaCommerce.Abm_Visibilidad
{
    public partial class FormModificacionVisibilidad : Form
    {
        SistemManager cManager;
        public FormModificacionVisibilidad(SistemManager cManager,string nombre)
        {
            InitializeComponent();
            this.cManager = cManager;

            this.Text = nombre;

            if (this.Text.Equals("Modificacion Visibilidad"))
            {
                cManager.sqlAbmVisibilidad.Buscar(cManager, this.dataGridViewModificacionVisibilidad);
                this.seleccionar.HeaderText = "Seleccionar";
                dataGridViewModificacionVisibilidad.Update();
              
            }
            else
            {
                cManager.sqlAbmVisibilidad.BuscarSinHabilitados(cManager, this.dataGridViewModificacionVisibilidad);
                this.seleccionar.HeaderText = "Eliminar";
                dataGridViewModificacionVisibilidad.Update();
              
            }
            
        }



        private void dataGridViewModificacionVisibilidad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridViewModificacionVisibilidad.Columns[e.ColumnIndex].HeaderText.Equals("Seleccionar"))
            {
                this.Hide();
                FormAltaVisibilidad formAltaVisibilidad = new FormAltaVisibilidad(cManager, true);
                cManager.sqlAbmVisibilidad.cargarDatosDeModificacion(cManager, formAltaVisibilidad, this.dataGridViewModificacionVisibilidad.Rows[e.RowIndex].Cells[1].Value.ToString());
                formAltaVisibilidad.ShowDialog();
                this.Close();
            }
            if (dataGridViewModificacionVisibilidad.Columns[e.ColumnIndex].HeaderText.Equals("Eliminar"))
            {
                this.Hide();
                cManager.sqlAbmVisibilidad.cargarDatosDeBaja(cManager, this.dataGridViewModificacionVisibilidad.Rows[e.RowIndex].Cells[2].Value.ToString());
                this.Close();
            }
        }



    }
}
