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
        
        public FormCalificacion(SistemManager cManager,string compra_id)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.compra_id=compra_id;

        }

        private void buttonClasificar_Click(object sender, EventArgs e)
        {
        
            cManager.sqlClasificar.IngresarClasificacion(cManager,compra_id,comboBoxCalificacion.Text.ToString(),descripcionClasificacion.Text.ToString());



        }




      
}
