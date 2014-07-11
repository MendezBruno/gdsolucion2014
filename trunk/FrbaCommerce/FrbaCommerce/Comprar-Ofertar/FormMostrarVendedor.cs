using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Modelo;
using FrbaCommerce.Login;

namespace FrbaCommerce.Comprar_Ofertar
{
    public partial class FormMostrarVendedor : Form
    {

    
        public FormMostrarVendedor(SistemManager cManager,string public_Codigo,string usuario,string cantidad)
        {
            InitializeComponent();
            cManager.sqlCompra.confirmo_Compra(cManager, public_Codigo, usuario, cantidad);
            bool deshabilito=cManager.sqlCompra.DeshabilitarPorCalificacion(cManager, usuario);

            if (deshabilito == true)
            {


                MessageBox.Show("No puede Comprar Mas, ingrese de nuevo y califique todas las publicaciones");
                
                this.Hide();

                FormLoggin loggin = new FormLoggin(cManager);

                loggin.ShowDialog();


            }

        }



    }
}
