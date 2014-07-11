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

        string usuario;

        DataGridViewColumn seleccionar;

        public FormComprarOfertar(SistemManager cManager,string usuario)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.cargarForm();
            this.usuario = usuario;
        }

        private void cargarForm()
        {

            cManager.sqlRubro.listaDeRubro(cManager, this.checkedListBoxRubro.Items);

        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            /*for(int i=0; i==this.dataGridViewCompra.Columns.Count; i++)
            {
                 if(this.dataGridViewCompra.Columns[i].Name.Equals("Seleccionar")) 
            
                 }*/
            this.seleccionar = guardarColumnaSeleccionar(this.dataGridViewCompra);
            this.dataGridViewCompra.Columns.Clear();
            this.tabla = cManager.sqlCompra.buscarCompras(cManager, this.checkedListBoxRubro.CheckedItems, this.textBoxDescripcion.Text, this.dataGridViewCompra,this.usuario);
            this.paginaActual = 0;
            this.paginalbl.Text = "0";
            mostrar_Pagina();
            this.dataGridViewCompra.Update();
            
        }

        private DataGridViewColumn guardarColumnaSeleccionar(DataGridView dataGridView)
        {
            for(int i=0; i<=dataGridView.Columns.Count; i++)
            {
                 if(dataGridView.Columns[i].Name.Equals("Seleccionar")) return dataGridView.Columns[i];
                 }

            return null;
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
            
            int inicio = 10*this.paginaActual;

            int final = 10 *paginaActual+10;
            
            DataRow fila;

            this.dataGridViewCompra.Columns.Add("Rubro", "Rubro");

            this.dataGridViewCompra.Columns.Add("Descripcion", "Descripcion Publicacion");

            this.dataGridViewCompra.Columns.Add("Visibilidad", "Visibilidad");

            this.dataGridViewCompra.Columns.Add("Public_Cod", "Public_Cod");

            this.dataGridViewCompra.Columns.Add(seleccionar);

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

           // this.dataGridViewCompra.Columns.Insert(this.dataGridViewCompra.Columns.Count, seleccionar);

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
            if (dataGridViewCompra.Columns[e.ColumnIndex].HeaderText.Equals("Seleccionar"))
            {
                
                this.Hide();

                string estado;

                FormMostrarPublicacion mostrarPublic = new FormMostrarPublicacion(cManager, this.dataGridViewCompra.Rows[e.RowIndex].Cells[3].Value.ToString(), this.usuario);

                estado = cManager.sqlCompra.BuscarPublicacion(cManager, mostrarPublic, this.dataGridViewCompra.Rows[e.RowIndex].Cells[3].Value.ToString());

                mostrarPublic.numericUpDownCantComprar.Value = 1;

                if (mostrarPublic.tipo.Text.Equals("Subasta"))
                {


                    mostrarPublic.stock.Visible = false;

                    mostrarPublic.label4.Visible = false;

                    mostrarPublic.label4.Text = "Precio";

                    mostrarPublic.buttonComprar.Text = "Ofertar";

                    mostrarPublic.label5.Visible = false;

                    mostrarPublic.numericUpDownCantComprar.Visible = false;

                }

                if (estado.Equals("Pausada"))
                {

                    mostrarPublic.buttonComprar.Visible = false;

                    mostrarPublic.buttonPreguntar.Visible = false;

                }

                mostrarPublic.ShowDialog();

            }


        }
        


    }

}
