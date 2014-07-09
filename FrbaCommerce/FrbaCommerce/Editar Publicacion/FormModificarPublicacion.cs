using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Modelo;
using FrbaCommerce.Generar_Publicacion;
using Sistema;

namespace FrbaCommerce.Editar_Publicacion
{
    public partial class FormModificarPublicacion : Form
    {
        SistemManager cManager;
        string publicCodigo;
        Cliente cliente;
        Empresa empresa;
        Administrador administrador;
        bool modificacion;
        string tipo_public;


        public FormModificarPublicacion(SistemManager cManager,string publicCodigo,Cliente cliente,string tipo_public)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.publicCodigo = publicCodigo;
            this.cliente = cliente;
            this.modificacion = false;
            this.tipo_public = tipo_public;


        }
        public FormModificarPublicacion(SistemManager cManager, string publicCodigo, Empresa empresa, string tipo_public)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.publicCodigo = publicCodigo;
            this.empresa = empresa;
            this.modificacion = false;
            this.tipo_public = tipo_public;
  


        }
        public FormModificarPublicacion(SistemManager cManager, string publicCodigo, Administrador administrador, string tipo_public)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.publicCodigo = publicCodigo;
            this.administrador = administrador;
            this.modificacion = false;
            this.tipo_public = tipo_public;

        }

        private void Activar_Click(object sender, EventArgs e)
        {

            cManager.sqlPublicacion.CambiarAActiva(cManager, publicCodigo);
            this.Hide();


        }

        private void Pausar_Click(object sender, EventArgs e)
        {

            cManager.sqlPublicacion.CambiarAPausada(cManager, publicCodigo);
            this.Hide();
        }

        private void Finalizar_Click(object sender, EventArgs e)
        {
            cManager.sqlPublicacion.CambiarAFinalizada(cManager, publicCodigo);
            if(tipo_public.Equals("Subasta"))
            {
                cManager.sqlPublicacion.RegistrarSubasta(cManager, publicCodigo, tipo_public);
            }
            this.Hide();
        }

        private void modifStock_Click(object sender, EventArgs e)
        {

            if(cliente!=null)
            {
                FormGenerarPublicacion formGenerarPublicacion = new FormGenerarPublicacion(cManager, cliente.getUsuario(),true,this.publicCodigo);
                formGenerarPublicacion.Text = "Modificar Stock y Descripcion";
                cManager.sqlPublicacion.cargarDatosGenerar(cManager, formGenerarPublicacion, publicCodigo);
                formGenerarPublicacion.comboBoxVisibilidad.Visible=false;
                formGenerarPublicacion.comboBoxTipoPublicacion.Visible = false;
                formGenerarPublicacion.comboBoxAceptaPregunta.Visible = false;
                formGenerarPublicacion.textBoxPrecio.Visible = false;
                formGenerarPublicacion.label2.Visible = false;
                formGenerarPublicacion.label5.Visible = false;
                formGenerarPublicacion.label6.Visible = false;
                formGenerarPublicacion.label7.Visible = false;
                formGenerarPublicacion.labelprecio.Visible = false;
                formGenerarPublicacion.checkedListBoxRubro.Visible = false;
                formGenerarPublicacion.ShowDialog();

               

        

            }

            else
            if(empresa!=null)
            {
                FormGenerarPublicacion formGenerarPublicacion = new FormGenerarPublicacion(cManager, empresa.getUsuario(), true, this.publicCodigo);
                formGenerarPublicacion.Text = "Modificar Stock y Descripcion";
            cManager.sqlPublicacion.cargarDatosGenerar(cManager, formGenerarPublicacion, publicCodigo);
            formGenerarPublicacion.textBoxPrecio.ReadOnly = true;
            formGenerarPublicacion.comboBoxVisibilidad.Visible = false;
            formGenerarPublicacion.comboBoxTipoPublicacion.Visible = false;
            formGenerarPublicacion.comboBoxAceptaPregunta.Visible = false;
            formGenerarPublicacion.textBoxPrecio.Visible = false;
            formGenerarPublicacion.label2.Visible = false;
            formGenerarPublicacion.label5.Visible = false;
            formGenerarPublicacion.label6.Visible = false;
            formGenerarPublicacion.label7.Visible = false;
            formGenerarPublicacion.labelprecio.Visible = false;
            formGenerarPublicacion.checkedListBoxRubro.Visible = false;
            formGenerarPublicacion.ShowDialog();

            }

            else
                if (cliente == null && empresa == null)
                {
                    FormGenerarPublicacion formGenerarPublicacion = new FormGenerarPublicacion(cManager, administrador.getUsuario(), true, this.publicCodigo);
                    formGenerarPublicacion.Text = "Modificar Stock y Descripcion";
                    cManager.sqlPublicacion.cargarDatosGenerar(cManager, formGenerarPublicacion, publicCodigo);
                    formGenerarPublicacion.textBoxPrecio.ReadOnly = true;
                    formGenerarPublicacion.comboBoxVisibilidad.Visible = false;
                    formGenerarPublicacion.comboBoxTipoPublicacion.Visible = false;
                    formGenerarPublicacion.comboBoxAceptaPregunta.Visible = false;
                    formGenerarPublicacion.textBoxPrecio.Visible = false;
                    formGenerarPublicacion.label2.Visible = false;
                    formGenerarPublicacion.label5.Visible = false;
                    formGenerarPublicacion.label6.Visible = false;
                    formGenerarPublicacion.label7.Visible = false;
                    formGenerarPublicacion.labelprecio.Visible = false;
                    formGenerarPublicacion.checkedListBoxRubro.Visible = false;
                    formGenerarPublicacion.ShowDialog();
                }

          
        }

   
    }
}
