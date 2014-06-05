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
        public FormModificacionVisibilidad(SistemManager cManager)
        {
            InitializeComponent();
            this.cManager = cManager;
            cManager.sqlAbmVisibilidad.Buscar(cManager, this.dataGridViewModificacionVisibilidad);
            dataGridViewModificacionVisibilidad.Update();
        }



        private void dataGridViewRolFuncion_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                FormBajaVisibilidad formBajaVisibilidad = new FormBajaVisibilidad(cManager);
                cManager.sqlAbmVisibilidad.cargarDatosDeBaja(cManager, formBajaVisibilidad, this.dataGridViewModificacionVisibilidad.Rows[e.RowIndex].Cells[1].Value.ToString());
                formBajaVisibilidad.ShowDialog();
            }
        }
    }
}
