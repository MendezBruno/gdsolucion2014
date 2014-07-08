using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Modelo;
using FrbaCommerce.Gestion_de_Preguntas;

namespace FrbaCommerce.Comprar_Ofertar
{
    public partial class FormMostrarPublicacion : Form
    {
        SistemManager cManager;

        string public_Codigo;

        string usuario;
        
        public FormMostrarPublicacion(SistemManager cManager, string public_Codigo,string usuario)
        {
            
            InitializeComponent();

            this.cManager = cManager;

            this.public_Codigo = public_Codigo;

            this.usuario = usuario;


        }

        private void buttonComprar_Click(object sender, EventArgs e)
        {

            if(buttonComprar.Text.Equals("Comprar"))
            {

                this.Hide();

                if (this.numericUpDownCantComprar.Value == Convert.ToInt16(stock.Text))
                {

                    cManager.sqlPublicacion.CambiarAFinalizada(cManager, this.public_Codigo);

                }

                 cManager.sqlPublicacion.DeshabilitarDiezCompras(cManager, this.public_Codigo);
   
                FormMostrarVendedor formOfertar = new FormMostrarVendedor(cManager,this.public_Codigo,this.usuario,this.numericUpDownCantComprar.Value.ToString());
             
                formOfertar.ShowDialog();

                this.Show();
            
            
            
            }
            else
            if (buttonComprar.Text.Equals("Ofertar"))
            {

                this.Hide();
                
                FormOfertar formOfertar = new FormOfertar(cManager,this.public_Codigo,this.usuario);

                formOfertar.ShowDialog();

                this.Show();
                

            }




        }

        private void numericUpDownCantComprar_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownCantComprar.Value >= Convert.ToInt16(this.stock.Text))
                numericUpDownCantComprar.Value = Convert.ToInt16(this.stock.Text);
        }

        private void buttonPreguntar_Click(object sender, EventArgs e)
        {
            this.Hide();


            PreguntasyRespuestas preguntasyRespuestas = new PreguntasyRespuestas(cManager,Convert.ToInt32(public_Codigo),usuario);

            preguntasyRespuestas.ShowDialog();

            this.Show();
        }



    }
}
