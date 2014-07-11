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
    public partial class FormOfertar : Form
    {

        SistemManager cManager;

  //      int oferta_Inicial;

        string usuario;

        string public_Codigo;

        string valor_minimo;
        
        public FormOfertar()
        {
            InitializeComponent();
        }


        public FormOfertar(SistemManager cManager, string public_Codigo,string usuario)
        {


            InitializeComponent();
            this.cManager = cManager;
            this.usuario = usuario;
            this.public_Codigo = public_Codigo;
            this.valor_minimo = cManager.sqlCompra.Ver_Minimo(cManager, public_Codigo);
            if (!valor_minimo.Equals(""))
                numericUpDownOfer.Value = Convert.ToInt32(valor_minimo)+1;
            else
                this.valor_minimo = "0";



        }

        private void boton_Confirmar_Oferta_Click(object sender, EventArgs e)
        {

            
            cManager.sqlCompra.confirmo_oferta(cManager, this.usuario, this.public_Codigo,this.numericUpDownOfer.Value.ToString());
            this.Hide();

            MessageBox.Show("Oferta realizada exitosamente");
            
            //    cManager.sqlCompra.DeshabilitarPorCalificacion(cManager, this.usuario);

        }

        private void numericUpDownOfer_ValueChanged(object sender, EventArgs e)
        {

            if(numericUpDownOfer.Value<Convert.ToInt32(valor_minimo)+1)
                numericUpDownOfer.Value = Convert.ToInt32(valor_minimo)+1;

        }
    }
}
