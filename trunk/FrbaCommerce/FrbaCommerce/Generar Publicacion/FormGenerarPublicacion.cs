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
        cargarForm();
        this.cliente = cliente;
        this.cManager = cManager;
        }

        

        public FormGenerarPublicacion(SistemManager cManager, Empresa empresa)
        {
        cargarForm();
        this.empresa = empresa;
        this.cManager = cManager;
        }

        private void cargarForm()
        {
            InitializeComponent();
            List<string> visibilidades = new List<string>();
            cManager.sqlAbmVisibilidad.listaDeVisibilidades(cManager,visibilidades);
        //    this.comboBoxVisibilidad.Items.Add 

        }
        
        private void buttonPublicar_Click(object sender, EventArgs e)
        {

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
