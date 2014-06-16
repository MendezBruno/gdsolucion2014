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
                dataGridViewModificacionVisibilidad.Update();
            }
            else
            {
                cManager.sqlAbmVisibilidad.BuscarSinHabilitados(cManager, this.dataGridViewModificacionVisibilidad);
                dataGridViewModificacionVisibilidad.Update();
            }
            
        }



        private void dataGridViewModificacionVisibilidad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            this.Hide();
            if (this.Text.Equals("Modificacion Visibilidad"))
            {

                FormAltaVisibilidad formAltaVisibilidad = new FormAltaVisibilidad(cManager, true);
                cManager.sqlAbmVisibilidad.cargarDatosDeModificacion(cManager, formAltaVisibilidad, this.dataGridViewModificacionVisibilidad.Rows[e.RowIndex].Cells[1].Value.ToString());
                formAltaVisibilidad.ShowDialog();
            }
            else
            {
                cManager.sqlAbmVisibilidad.cargarDatosDeBaja(cManager, this.dataGridViewModificacionVisibilidad.Rows[e.RowIndex].Cells[2].Value.ToString());
              
            }
        }



    }
}
