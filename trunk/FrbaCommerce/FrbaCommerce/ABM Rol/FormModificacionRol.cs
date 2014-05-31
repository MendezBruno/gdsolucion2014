using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Modelo;
using System.Data;
using Sistema;

namespace FrbaCommerce.ABM_Rol
{
    public partial class Modificacion_Rol : Form
    {
        SistemManager cManager;
        public Modificacion_Rol(SistemManager cManager)
        {
            InitializeComponent();
            this.cManager = cManager;
            // FillData();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {

            this.cManager.sqlAbmRol.Buscar(cManager, comboBoxNombreRol.Text, comboBoxFuncionalidad.Text, this.dataGridViewRolFuncion);
            this.dataGridViewRolFuncion.Update();
       
        }

        private void dataGridViewRolFuncion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            this.Hide();
            if (this.Text.Equals("Modificacion Rol"))   
            {
                
                FormAltaRol formAltaRol = new FormAltaRol(cManager, true);
                cManager.sqlAbmRol.cargarDatosDeModificacion(cManager, formAltaRol, dataGridViewRolFuncion.Rows[e.RowIndex].Cells[1].Value.ToString());
                formAltaRol.ShowDialog();
            }
            else
            {
                FormBajaRol formBajaRol = new FormBajaRol(cManager);
                cManager.sqlAbmRol.cargarDatosDeBaja(cManager, formBajaRol, dataGridViewRolFuncion.Rows[e.RowIndex].Cells[1].Value.ToString());
                formBajaRol.ShowDialog();
            }

            this.Close();
            //MessageBox.Show(dataGridViewRolFuncion.Rows[1].Cells[1].Value.ToString());
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            this.comboBoxFuncionalidad.Text = "";
            this.comboBoxNombreRol.Text = "";
            this.dataGridViewRolFuncion.Rows.Clear();
        }


    }
}