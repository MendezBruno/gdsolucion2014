using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Modelo;

namespace FrbaCommerce.Comprar_Ofertar
{
    public partial class FormComprarOfertar : Form
    {

        SistemManager cManager;

        public FormComprarOfertar(SistemManager cManager)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.cargarForm();
        }

        private void cargarForm()
        {

            cManager.sqlRubro.listaDeRubro(cManager, this.checkedListBoxRubro.Items);

        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            cManager.sqlCompra.buscarCompras(cManager);
        }

    
    }

}
