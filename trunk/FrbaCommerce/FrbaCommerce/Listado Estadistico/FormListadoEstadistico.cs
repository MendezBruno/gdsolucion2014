using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using FrbaCommerce.Modelo;

namespace FrbaCommerce.Listado_Estadistico
{
    
    public partial class FormListadoEstadistico : Form
    {
        SistemManager cManager;

        public FormListadoEstadistico(SistemManager cManager)
        {
            this.cManager = cManager;
            
            InitializeComponent();
        }

        private void anio_TextChanged(object sender, EventArgs e)
        {
            this.trimestre.Enabled = true;
        }

        private void mes_TextChanged(object sender, EventArgs e)
        {
            this.listado.Enabled = true;
        }

        private void listado_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(listado.Text.Equals("Vendedores Mayor Cantidad Productos No Vendidos"))
            {
                cManager.sqlListado.CargarDatosMayorCantidadNoVendidos(cManager, dataGridViewListado, anio.Text.ToString(), trimestre.Text.ToString());
                dataGridViewListado.Update();
            
            
            }

            if (listado.Text.Equals("Vendedores Mayor Facturacion"))
            {


                cManager.sqlListado.CargarDatosMayorFacturados(cManager, dataGridViewListado, anio.Text.ToString(), trimestre.Text.ToString());
                dataGridViewListado.Update();
                
            }

            if(listado.Text.Equals("Vendedores Con Mayores Calificaciones"))
            {
                cManager.sqlListado.CargarDatosMayorCalificacion(cManager, dataGridViewListado, trimestre.Text.ToString(), anio.Text.ToString());
                dataGridViewListado.Update();
            }

            if(listado.Text.Equals("Clientes Con Mayor Cantidad De Publicaciones Sin Clasificar"))
            {
                cManager.sqlListado.CargarDatosSinClasificar(cManager, dataGridViewListado, trimestre.Text.ToString(), anio.Text.ToString());
                dataGridViewListado.Update();
            }
            this.anio.Text = "";
            this.listado.Text = "";
            this.trimestre.Text = "";
            this.trimestre.Enabled = false;
            this.listado.Enabled = false;

        
        }



    }
}
