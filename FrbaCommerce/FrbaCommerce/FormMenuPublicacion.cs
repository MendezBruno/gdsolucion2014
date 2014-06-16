using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Generar_Publicacion;
using FrbaCommerce.Modelo;
using Sistema;
using FrbaCommerce.Editar_Publicacion;

namespace FrbaCommerce
{
    public partial class FormMenuPublicacion : Form
    {
        SistemManager cManager;
       
        Cliente cliente;
        Empresa empresa;
        
        public FormMenuPublicacion(SistemManager cManager, Cliente cliente)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.cliente = cliente;
        }

        public FormMenuPublicacion(SistemManager cManager, Empresa empresa)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.empresa = empresa;

        }

        private void botonGenerarPublicacion_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormGenerarPublicacion formGenerarPublicacion;
            //  FormGenerarPublicacion formPublicacion;
            if (cliente == null) formGenerarPublicacion = new FormGenerarPublicacion(cManager, empresa);
            else formGenerarPublicacion = new FormGenerarPublicacion(cManager, cliente);
            formGenerarPublicacion.ShowDialog();
            this.Show();
        }

        
        private void buttonEditarPublicacion_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormBuscarPublicacion formBuscarPublicacion;
            if (cliente == null) formBuscarPublicacion = new FormBuscarPublicacion(cManager, empresa);
            else formBuscarPublicacion = new FormBuscarPublicacion(cManager, cliente);
            formBuscarPublicacion.ShowDialog();
            this.Show();
        }



    }
}
