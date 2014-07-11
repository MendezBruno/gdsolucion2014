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
    public partial class FormCalificacion : Form
    {
        SistemManager cManager;
        string compra_id;
        string usuario;

        public FormCalificacion(SistemManager cManager, string compra_id,string usuario)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.compra_id = compra_id;
            this.usuario = usuario;

        }

        private void buttonClasificar_Click(object sender, EventArgs e)
        {

            cManager.sqlClasificar.IngresarClasificacion(cManager, compra_id, comboBoxCalificacion.Text.ToString(), descripcionClasificacion.Text.ToString());
            cManager.sqlClasificar.permitirComprar(cManager, usuario);
            this.Hide();

        }


    }

      
}
