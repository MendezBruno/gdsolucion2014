using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Modelo;
using Sistema;

namespace FrbaCommerce.Generar_Publicacion
{
    public partial class FormGenerarPublicacion : Form
    {
        SistemManager cManager;
        Empresa empresa;
        Cliente cliente;

        public FormGenerarPublicacion(SistemManager cManager, Cliente cliente)
        {
        InitializeComponent();
        this.cliente = cliente;
        this.cManager = cManager;
        this.labelUserName.Text = cliente.getUsuario();
        cargarForm();
        }

        

        public FormGenerarPublicacion(SistemManager cManager, Empresa empresa)
        {
        InitializeComponent();
        this.empresa = empresa;
        this.cManager = cManager;
        this.labelUserName.Text = empresa.getUsuario();
        cargarForm();
        }

        private void cargarForm()
        {
            
            cManager.sqlAbmVisibilidad.listaDeVisibilidades(cManager, this.comboBoxVisibilidad.Items);
           // llenarCombo(this.comboBoxVisibilidad.Items, listaAux);
            cManager.sqlRubro.listaDeRubro(cManager, this.comboBoxRubro.Items);
           // llenarCombo(this.comboBoxRubro.Items,listaAux);

        }

        private void llenarCombo(ComboBox.ObjectCollection objectCollection, List<string> listaCargada)
        {
            foreach (string item in listaCargada) objectCollection.Add(item);
            listaCargada.Clear();
        }
        
        private void buttonPublicar_Click(object sender, EventArgs e)
        {            
            cManager.sqlPublicacion.publicar(cManager,this.comboBoxTipoPublicacion.Text, this.comboBoxRubro.Text, this.textBoxDescripcion.Text, this.numericUpDownStockInicial.Value, this.numericUpDownPrecio.Value, cManager.sqlAbmVisibilidad.codigoSegunDescripcion(cManager, this.comboBoxVisibilidad.Text), this.comboBoxAceptaPregunta.Text,this.labelUserName.Text); 
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            this.comboBoxTipoPublicacion.Text = "";
            this.comboBoxRubro.Text = "";
            this.comboBoxVisibilidad.Text = "";
            this.comboBoxAceptaPregunta.Text = "";
        }


    }
}
