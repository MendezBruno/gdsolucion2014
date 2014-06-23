using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Modelo;

namespace FrbaCommerce.Facturar_Publicaciones
{
    public partial class FormFacturarPublicaciones : Form
    {
        SistemManager cManager;

        string usuario;

        DataTable tabla;

        public FormFacturarPublicaciones(SistemManager cManager, string usuario)
        {
            InitializeComponent();

            this.cManager = cManager;

            this.usuario = usuario;

        }


        private void button1_Click(object sender, EventArgs e)
        {

            mostrarItems();

        }

        public void mostrarItems()
        {


            this.dataGridViewFacturar.Rows.Clear();

            this.dataGridViewFacturar.Columns.Clear();
            
            int j=0,i;
            
            this.tabla=cManager.sqlFactura.buscarFactura(cManager, this.usuario, textCantPubli.Text);

            DataRow fila;

            this.dataGridViewFacturar.Columns.Add("Item", "Nro Item");

            this.dataGridViewFacturar.Columns.Add("Cantidad", "Cantiadad");

            this.dataGridViewFacturar.Columns.Add("Precio", "Precio");

            this.dataGridViewFacturar.Columns.Add("Publicacion_Cod","Publicacion_Cod");
            
            for (i = 0; i < Convert.ToInt16(textCantPubli.Text); i++)
            {
                
                fila = tabla.Rows[j];

                this.dataGridViewFacturar.Rows.Add();

                this.dataGridViewFacturar.Rows[j].Cells["Item"].Value = j + 1;

                this.dataGridViewFacturar.Rows[j].Cells["Cantidad"].Value = fila[0].ToString();

                this.dataGridViewFacturar.Rows[j].Cells["Precio"].Value = fila[1].ToString();

                this.dataGridViewFacturar.Rows[j].Cells["Publicacion_Cod"].Value=fila[2].ToString();
                
                while(tabla.Rows[j+1][2].ToString().Equals(fila[2].ToString()))
                {

                    
                    j=j+1;

                    fila = tabla.Rows[j];

                    this.dataGridViewFacturar.Rows.Add();
                    
                    this.dataGridViewFacturar.Rows[j].Cells["Item"].Value = j + 1;

                    this.dataGridViewFacturar.Rows[j].Cells["Cantidad"].Value = fila[0].ToString();

                    this.dataGridViewFacturar.Rows[j].Cells["Precio"].Value = fila[1].ToString();

                    this.dataGridViewFacturar.Rows[j].Cells["Publicacion_Cod"].Value = fila[2].ToString();


                }

                j = j + 1;


            }

            int cantidad_Total=0,precio_Total=0;
            
            for (i = 0; i < this.dataGridViewFacturar.RowCount-1; i++)
            {
                
                cantidad_Total=cantidad_Total+int.Parse(dataGridViewFacturar.Rows[i].Cells[1].Value.ToString());

                precio_Total = precio_Total + int.Parse(dataGridViewFacturar.Rows[i].Cells[2].Value.ToString());


            }

            this.dataGridViewFacturar.Rows[j].Cells["Item"].Value = "Total";

            this.dataGridViewFacturar.Rows[j].Cells["Cantidad"].Value = cantidad_Total;

            this.dataGridViewFacturar.Rows[j].Cells["Precio"].Value = precio_Total;

        }



    }
}
