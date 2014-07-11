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
        
        public Modificacion_Rol(SistemManager cManager, string nombre)
        {
            InitializeComponent();
            this.cManager = cManager;

            this.Text = nombre;

            if (this.Text.Equals("Modificacion Rol"))
                cManager.sqlAbmRol.Buscar(cManager, this.dataGridViewRolFuncion);
            else
            {
                cManager.sqlAbmRol.BuscarSinHabilitados(cManager, this.dataGridViewRolFuncion);
                this.SeleccionarColumn.HeaderText = "Eliminar";
            }
                
                dataGridViewRolFuncion.Update();

        }


        private void dataGridViewRolFuncion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
            if (dataGridViewRolFuncion.Columns[e.ColumnIndex].HeaderText.Equals("Seleccionar"))
            {
                this.Hide();
                FormAltaRol formAltaRol = new FormAltaRol(cManager, true);
                cManager.sqlAbmRol.cargarDatosDeModificacion(cManager, formAltaRol, dataGridViewRolFuncion.Rows[e.RowIndex].Cells[1].Value.ToString());
                formAltaRol.ShowDialog();
                this.Close();
            }

            if (dataGridViewRolFuncion.Columns[e.ColumnIndex].HeaderText.Equals("Eliminar"))
            {
                this.Hide();
                cManager.sqlAbmRol.cargarDatosDeBaja(cManager,dataGridViewRolFuncion.Rows[e.RowIndex].Cells[1].Value.ToString());
                this.Close();
            }

        }

        


    }
}