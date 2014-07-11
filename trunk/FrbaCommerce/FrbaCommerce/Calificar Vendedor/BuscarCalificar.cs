using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Modelo;

namespace FrbaCommerce.Calificar_Vendedor
{
    public partial class BuscarCalificar : Form
    {

        SistemManager cManager;

        string usuario;
        
        public BuscarCalificar(SistemManager cManager, string usuario)
        {
            
            InitializeComponent();
            cManager.sqlClasificar.buscarClasificar(cManager, usuario,dataGridViewClasificar);
            dataGridViewClasificar.Update();

            this.usuario = usuario;
            /*
            if (dataGridViewClasificar.Rows.Count == 0)
            {

                cManager.sqlClasificar.permitirComprar(cManager, usuario);


            }*/
            this.cManager = cManager;
        
        }

        private void dataGridViewClasificar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

           

            if (dataGridViewClasificar.Columns[e.ColumnIndex].HeaderText.Equals("Seleccionar"))
            {
                this.Hide();
                FormCalificacion formcalificacion = new FormCalificacion(cManager, dataGridViewClasificar.Rows[e.RowIndex].Cells[0].Value.ToString(), usuario);
                formcalificacion.ShowDialog();
                this.Close();
            }

            
            
          



        }

    }
}
