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
        Administrador administrador;
        
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

        public FormMenuPublicacion(SistemManager cManager, Administrador administrador)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.administrador=administrador;

        }

        private void botonGenerarPublicacion_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormGenerarPublicacion formGenerarPublicacion;
            //  FormGenerarPublicacion formPublicacion;
            if (cliente != null)
            {
                formGenerarPublicacion = new FormGenerarPublicacion(cManager,cliente,false);
                formGenerarPublicacion.ShowDialog();
            }
            else
                if (empresa != null)
                {
                    formGenerarPublicacion = new FormGenerarPublicacion(cManager, empresa,false);
                    formGenerarPublicacion.ShowDialog();
                }
                else
                    if (empresa == null && cliente == null)
                    {
                        formGenerarPublicacion = new FormGenerarPublicacion(cManager,administrador,false);
                        formGenerarPublicacion.ShowDialog();
                    }
                this.Show();
        }

        
        private void buttonEditarPublicacion_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormBuscarPublicacion formBuscarPublicacion;
            if (cliente != null)
            {
                formBuscarPublicacion = new FormBuscarPublicacion(cManager, cliente);
                formBuscarPublicacion.Text = "Modificar Publicacion"; 
                formBuscarPublicacion.ShowDialog();
                 
            }
            else
                if (empresa != null)
                {
                    formBuscarPublicacion = new FormBuscarPublicacion(cManager, empresa);
                    formBuscarPublicacion.Text = "Modificar Publicacion"; 
                    formBuscarPublicacion.ShowDialog();
                    
                }
                else
                    if (empresa == null && cliente == null)
                    {
                        formBuscarPublicacion = new FormBuscarPublicacion(cManager, administrador);
                        formBuscarPublicacion.Text = "Modificar Publicacion"; 
                        formBuscarPublicacion.ShowDialog();
                   
                    }

            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormBuscarPublicacion formBuscarPublicacion;
            if (cliente != null)
            {
                formBuscarPublicacion = new FormBuscarPublicacion(cManager, cliente);
                formBuscarPublicacion.Text = "Eliminar Publicacion";
                formBuscarPublicacion.ShowDialog();
                
            }
            else
                if (empresa != null)
                {
                    formBuscarPublicacion = new FormBuscarPublicacion(cManager, empresa);
                    formBuscarPublicacion.Text = "Eliminar Publicacion";
                    formBuscarPublicacion.ShowDialog();
                   
                }
                else
                    if (empresa == null && cliente == null)
                    {
                        formBuscarPublicacion = new FormBuscarPublicacion(cManager, administrador);
                        formBuscarPublicacion.Text = "Eliminar Publicacion";
                        formBuscarPublicacion.ShowDialog();
                    }

            this.Show();

        }



    }
}
