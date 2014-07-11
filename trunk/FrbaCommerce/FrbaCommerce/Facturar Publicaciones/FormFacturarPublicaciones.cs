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

        DataTable tablaCompras;

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
            
            int j=0,i,n=0;
            
            this.tabla=cManager.sqlFactura.buscarFactura(cManager, this.usuario, textCantPubli.Text);

            this.tablaCompras = cManager.sqlFactura.buscarCompras(cManager,this.usuario,textCantPubli.Text);
            
            DataRow fila;

            this.dataGridViewFacturar.Columns.Add("Item", "Nro Item");

            this.dataGridViewFacturar.Columns.Add("Cantidad", "Cantidad");

            this.dataGridViewFacturar.Columns.Add("Precio", "Precio");

            this.dataGridViewFacturar.Columns.Add("Codigo","Codigo");

            this.dataGridViewFacturar.Columns["Codigo"].Visible = false;

            this.dataGridViewFacturar.Columns.Add("Tipo", "Tipo");

            this.dataGridViewFacturar.Columns.Add("Publicacion_Cod","Publicacion_Cod");

            this.dataGridViewFacturar.Columns["Publicacion_Cod"].Visible = false;

            if (tabla.Rows.Count > 0 || tablaCompras.Rows.Count > 0)
            {

                for (i = 0; i < tabla.Rows.Count; i++)
                {

                    fila = tabla.Rows[j];

                    this.dataGridViewFacturar.Rows.Add();

                    this.dataGridViewFacturar.Rows[j].Cells["Item"].Value = j + 1;

                    this.dataGridViewFacturar.Rows[j].Cells["Cantidad"].Value = fila[0].ToString();

                    this.dataGridViewFacturar.Rows[j].Cells["Precio"].Value = fila[1].ToString();

                    this.dataGridViewFacturar.Rows[j].Cells["Codigo"].Value = fila[2].ToString();

                    this.dataGridViewFacturar.Rows[j].Cells["Tipo"].Value = fila[3].ToString();

                    this.dataGridViewFacturar.Rows[j].Cells["Publicacion_Cod"].Value = fila[4].ToString();
 
                    j = j + 1;

                }
                i = 0;
                if (!textCantPubli.Text.Equals(""))
                {
                    while (i < Convert.ToInt16(textCantPubli.Text) && i < (tablaCompras.Rows.Count))
                    {


                        fila = tablaCompras.Rows[i];

                        this.dataGridViewFacturar.Rows.Add();

                        this.dataGridViewFacturar.Rows[j].Cells["Item"].Value = j + 1;

                        this.dataGridViewFacturar.Rows[j].Cells["Cantidad"].Value = fila[0].ToString();

                        this.dataGridViewFacturar.Rows[j].Cells["Precio"].Value = fila[1].ToString();

                        this.dataGridViewFacturar.Rows[j].Cells["Codigo"].Value = fila[2].ToString();

                        this.dataGridViewFacturar.Rows[j].Cells["Tipo"].Value = fila[3].ToString();

                        this.dataGridViewFacturar.Rows[j].Cells["Publicacion_Cod"].Value = fila[4].ToString();

                        j = j + 1;

                        i = i + 1;

                    }
                }
                else
                {
                    while (i < tablaCompras.Rows.Count)
                    {

                        fila = tablaCompras.Rows[i];

                        this.dataGridViewFacturar.Rows.Add();

                        this.dataGridViewFacturar.Rows[j].Cells["Item"].Value = j + 1;

                        this.dataGridViewFacturar.Rows[j].Cells["Cantidad"].Value = fila[0].ToString();

                        this.dataGridViewFacturar.Rows[j].Cells["Precio"].Value = fila[1].ToString();

                        this.dataGridViewFacturar.Rows[j].Cells["Codigo"].Value = fila[2].ToString();

                        this.dataGridViewFacturar.Rows[j].Cells["Tipo"].Value = fila[3].ToString();

                        this.dataGridViewFacturar.Rows[j].Cells["Publicacion_Cod"].Value = fila[4].ToString();

                        j = j + 1;

                        i = i + 1;

                    }




                }

                    /*
                    while (tabla.Rows[j + 1][2].ToString().Equals(fila[2].ToString()))
                    {


                        j = j + 1;

                        fila = tabla.Rows[j];

                        this.dataGridViewFacturar.Rows.Add();

                        this.dataGridViewFacturar.Rows[j].Cells["Item"].Value = j + 1;

                        this.dataGridViewFacturar.Rows[j].Cells["Cantidad"].Value = fila[0].ToString();

                        this.dataGridViewFacturar.Rows[j].Cells["Precio"].Value = fila[1].ToString();

                        this.dataGridViewFacturar.Rows[j].Cells["Publicacion_Cod"].Value = fila[2].ToString();


                    }
                    */





                    int cantidad_Total = 0;

                    float precio_Total = 0;

                    for (i = 0; i < this.dataGridViewFacturar.RowCount - 1; i++)
                    {

                        cantidad_Total = cantidad_Total + int.Parse(dataGridViewFacturar.Rows[i].Cells[1].Value.ToString());

                        precio_Total = precio_Total + float.Parse(dataGridViewFacturar.Rows[i].Cells[2].Value.ToString());


                    }
                    this.dataGridViewFacturar.Rows.Add();

                    this.dataGridViewFacturar.Rows[j].Cells["Item"].Value = "Total";

                    this.dataGridViewFacturar.Rows[j].Cells["Cantidad"].Value = cantidad_Total;

                    this.dataGridViewFacturar.Rows[j].Cells["Precio"].Value = precio_Total;

                

            }  
        }

        private void button2_Click(object sender, EventArgs e)
        {

            
            int i;

            string monto_Total;

            string nro_Factura;

            if (dataGridViewFacturar.Rows.Count > 1)
            {

                monto_Total = this.dataGridViewFacturar.Rows[this.dataGridViewFacturar.Rows.Count - 2].Cells["Precio"].Value.ToString();

                nro_Factura = cManager.sqlFactura.Cargar_Factura(cManager, monto_Total, comboBoxMedio.Text);


                for (i = 0; i < this.dataGridViewFacturar.RowCount - 2; i++)
                {


                    if (this.dataGridViewFacturar.Rows[i].Cells["Tipo"].Value.Equals("Visibilidad_Publicacion"))
                    {

                        cManager.sqlFactura.CargarVisibilidad(cManager, this.dataGridViewFacturar.Rows[i].Cells["Codigo"].Value.ToString(), this.dataGridViewFacturar.Rows[i].Cells["Precio"].Value.ToString(), this.dataGridViewFacturar.Rows[i].Cells["Cantidad"].Value.ToString(), nro_Factura);

                    }

                    else

                        cManager.sqlFactura.CargarCompra(cManager, this.dataGridViewFacturar.Rows[i].Cells["Codigo"].Value.ToString(), this.dataGridViewFacturar.Rows[i].Cells["Publicacion_Cod"].Value.ToString(), this.dataGridViewFacturar.Rows[i].Cells["Cantidad"].Value.ToString(), this.dataGridViewFacturar.Rows[i].Cells["Precio"].Value.ToString(), nro_Factura);


                }
            }

        }



    }
}
