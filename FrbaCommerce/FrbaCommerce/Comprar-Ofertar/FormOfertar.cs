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

        int oferta_Inicial;

        string usuario;

        string public_Codigo;
        
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

        }

        private void boton_Confirmar_Oferta_Click(object sender, EventArgs e)
        {

            cManager.sqlCompra.confirmo_oferta(cManager, this.usuario, this.public_Codigo,this.numericUpDownOfer.Value.ToString());
            

        }

        private void numericUpDownOfer_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
