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
    public partial class FormMostrarPublicacion : Form
    {
        SistemManager cManager;

        string public_Codigo;
        
        public FormMostrarPublicacion(SistemManager cManger, string public_Codigo)
        {
            
            InitializeComponent();

            this.cManager = cManager;

            this.public_Codigo = public_Codigo;


        }

        private void buttonComprar_Click(object sender, EventArgs e)
        {

            if (buttonComprar.Text.Equals("Ofertar"))
            {

                this.Hide();
                
                FormOfertar formOfertar = new FormOfertar();

                formOfertar.ShowDialog();

                this.Show();
                

            }




        }

        private void numericUpDownCantComprar_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownCantComprar.Value >= Convert.ToInt16(this.stock.Text))
                numericUpDownCantComprar.Value = Convert.ToInt16(this.stock.Text);
        }



    }
}
