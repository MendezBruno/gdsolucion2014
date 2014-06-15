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
using System.Data.SqlClient;

namespace FrbaCommerce.Generar_Publicacion
{
    public partial class FormGenerarInicial : Form
    {

        SistemManager cManager;
        Cliente cliente;
        Empresa empresa;
        string usuario;

        public FormGenerarInicial(SistemManager cManager,Cliente cliente)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.cliente = cliente;
            usuario = cliente.getUsuario();

        }

        public FormGenerarInicial(SistemManager cManager, Empresa empresa)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.empresa = empresa;
            usuario = empresa.getUsuario();

        }

        private void botonGenerarPublicacion_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormGenerarPublicacion formPublicacion;
            if (cliente == null) formPublicacion = new FormGenerarPublicacion(cManager, empresa);
            else formPublicacion = new FormGenerarPublicacion(cManager, cliente);
            formPublicacion.ShowDialog();
            this.Show();

        }

        private void botonContinuarPublicacion_Click(object sender, EventArgs e)
        {
            this.Hide();

            Continuar_Publicacion continua = new Continuar_Publicacion(cManager,usuario,"Continuar");

            continua.Text="Continuar Publicacion";
            
            continua.ShowDialog();

            this.Show();

        }

        private void botonModificarPublicacion_Click(object sender, EventArgs e)
        {

            this.Hide();

            Continuar_Publicacion continua = new Continuar_Publicacion(cManager, usuario,"Modificar");

            continua.Text = "Modificar Publicacion";

            continua.ShowDialog();

            this.Show();




        }

        private void botonPausarPublicacion_Click(object sender, EventArgs e)
        {

            this.Hide();

            Continuar_Publicacion continua = new Continuar_Publicacion(cManager, usuario,"Pausar");

            continua.Text = "Pausar Publicacion";

            continua.ShowDialog();

            this.Show();


        }

        private void botonFinalizarPublicacion_Click(object sender, EventArgs e)
        {
            this.Hide();

            Continuar_Publicacion continua = new Continuar_Publicacion(cManager, usuario,"Finalizar");

            continua.Text = "Finalizar Publicacion";

            continua.ShowDialog();

            this.Show();

        }



    }
}
