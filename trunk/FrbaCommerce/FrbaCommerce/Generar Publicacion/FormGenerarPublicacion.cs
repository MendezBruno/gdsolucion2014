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
        bool publico;

        public FormGenerarPublicacion(SistemManager cManager, Cliente cliente)
        {
            InitializeComponent();
            this.cliente = cliente;
            this.cManager = cManager;
            this.labelUserName.Text = cliente.getUsuario();
            this.publico = false;
            cargarForm();
        }

        

        public FormGenerarPublicacion(SistemManager cManager, Empresa empresa)
        {
            InitializeComponent();
            this.empresa = empresa;
            this.cManager = cManager;
            this.labelUserName.Text = empresa.getUsuario();
            this.publico = false;
            cargarForm();
        }

        private void cargarForm()
        {
            
            cManager.sqlAbmVisibilidad.listaDeVisibilidades(cManager, this.comboBoxVisibilidad.Items);
            cManager.sqlRubro.listaDeRubro(cManager, this.checkedListBoxRubro.Items);

        }
        
        private void buttonPublicar_Click(object sender, EventArgs e)
        {            

            cManager.sqlPublicacion.publicar(cManager,this.comboBoxTipoPublicacion.Text, this.textBoxDescripcion.Text, this.numericUpDownStockInicial.Value.ToString(), this.textBoxPrecio.Text, cManager.sqlAbmVisibilidad.codigoSegunDescripcion(cManager, this.comboBoxVisibilidad.Text), this.comboBoxAceptaPregunta.Text,this.labelUserName.Text);
            publico = true;
        
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            this.comboBoxTipoPublicacion.Text = "";
            this.comboBoxVisibilidad.Text = "";
            this.comboBoxAceptaPregunta.Text = "";
        }

        private void FormGenerarPublicacion_FormClosing(object sender, FormClosingEventArgs e)
        {

            cManager.sqlPublicacion.pasarBorrador(cManager, this.comboBoxTipoPublicacion.Text, this.textBoxDescripcion.Text, this.numericUpDownStockInicial.Value.ToString(), this.textBoxPrecio.Text, cManager.sqlAbmVisibilidad.codigoSegunDescripcion(cManager, this.comboBoxVisibilidad.Text), this.comboBoxAceptaPregunta.Text, this.labelUserName.Text);

        }

    }
}
