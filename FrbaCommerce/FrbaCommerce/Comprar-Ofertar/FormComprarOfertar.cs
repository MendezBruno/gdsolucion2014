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

        int paginaActual;

        DataTable tabla;

        bool paginaUltima;

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

            this.dataGridViewCompra.Columns.Clear();
            this.tabla = cManager.sqlCompra.buscarCompras(cManager, this.checkedListBoxRubro.CheckedItems, this.textBoxDescripcion.Text, this.dataGridViewCompra);
            this.paginaActual = 0;
            this.paginalbl.Text = "0";
            mostrar_Pagina();
            this.dataGridViewCompra.Update();
        }

        private void buttonAnterior_Click(object sender, EventArgs e)
        {

            if (this.paginaActual != 0)
            {
                this.paginaActual--;

                this.paginalbl.Text = paginaActual.ToString();

                this.dataGridViewCompra.Columns.Clear();
                
                this.mostrar_Pagina();
            }           


        }

        private void mostrar_Pagina()
        {


            this.dataGridViewCompra.Rows.Clear();
            
            int inicio = 50*this.paginaActual;

            int final = 50 *paginaActual+50;
            
            DataRow fila;

            this.dataGridViewCompra.Columns.Add("Rubro", "Rubro");

            this.dataGridViewCompra.Columns.Add("Descripcion", "Descripcion Publicacion");

            this.dataGridViewCompra.Columns.Add("Visibilidad", "Visibilidad");

            this.dataGridViewCompra.Columns.Add("Public_Cod", "Public_Cod");

            this.dataGridViewCompra.Columns["Public_Cod"].Visible = false;

            if (this.tabla.Rows.Count < final)
            {

                final = this.tabla.Rows.Count;
                this.paginaUltima = true;

            }
            else
                this.paginaUltima = false;
            
            for (int i = inicio; i < final; i++)
            {

                int indice;

                fila = tabla.Rows[i];

                this.dataGridViewCompra.Rows.Add();

                indice = i-inicio;

                this.dataGridViewCompra.Rows[indice].Cells["Visibilidad"].Value = fila[0].ToString();

                this.dataGridViewCompra.Rows[indice].Cells["Rubro"].Value = fila[1].ToString();

                this.dataGridViewCompra.Rows[indice].Cells["Descripcion"].Value = fila[2].ToString();

                this.dataGridViewCompra.Rows[indice].Cells["Public_Cod"].Value = fila[3].ToString();

            }
              


        }

        private void buttonSiguiente_Click(object sender, EventArgs e)
        {

            if (this.paginaUltima == false)
            {
                this.paginaActual++;

                this.paginalbl.Text = paginaActual.ToString();
                
                this.dataGridViewCompra.Columns.Clear();

                this.mostrar_Pagina();
            }


        }

        private void dataGridViewCompra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            this.Hide();

            FormMostrarPublicacion mostrarPublic = new FormMostrarPublicacion(cManager, this.dataGridViewCompra.Rows[e.RowIndex].Cells[3].Value.ToString());

            cManager.sqlCompra.BuscarPublicacion(cManager, mostrarPublic, this.dataGridViewCompra.Rows[e.RowIndex].Cells[3].Value.ToString());


            if (mostrarPublic.tipo.Text.Equals("Subasta"))
            {

                mostrarPublic.stock.Visible = false;

                mostrarPublic.label4.Visible = false;

                mostrarPublic.label4.Text = "Precio";

                mostrarPublic.buttonComprar.Text = "Ofertar";

                mostrarPublic.label5.Visible = false;

                mostrarPublic.numericUpDownCantComprar.Visible = false;

            }
            
            mostrarPublic.ShowDialog();




        }



    }

}
