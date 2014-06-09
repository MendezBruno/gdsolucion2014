using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Modelo;
using FrbaCommerce.Login;
using FrbaCommerce.Registro_de_Usuario;
using FrbaCommerce.ABM_Rol;
using Sistema;
using FrbaCommerce.Abm_Cliente;

namespace FrbaCommerce
{
    public partial class FormPrincipal : Form
    {
        SistemManager cManager;
        Usuario user;
        Cliente cliente;
        Empresa empresa;

        public FormPrincipal(SistemManager cManager, Cliente cliente)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.cliente = cliente;
            cargaManuSegunRol(cliente.RolAsignado);
            
        }

        public FormPrincipal(SistemManager cManager, Empresa empresa)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.empresa = empresa;
            cargaManuSegunRol(empresa.RolAsignado);

        }

        public FormPrincipal(SistemManager cManager, Usuario user)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.user = user;
            cargaManuSegunRol(cliente.RolAsignado);

        }
        /*
        public FormPrincipal(SistemManager cManager, Usuario user)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.user = user;
            cargaManuSegunRol(user.RolAsignado);
        }
        */
        




        private void cargaManuSegunRol(Rol rol)
        {
            if (!rol.getListaFuncionalidades().Contains("Comprar")) { this.BotonComprar.Visible = false; this.BotonOfertar.Visible = false; }
            if (!rol.getListaFuncionalidades().Contains("Vender")) this.buttonPublicaciones.Visible = false;
            //if (!user.tipoUsuario.Equals("Administrador")) { this.buttonModificaciones.Visible = false; this.buttonCrearUsuario.Visible = false; }
            if (user==null) { this.buttonModificaciones.Visible = false; this.buttonCrearUsuario.Visible = false; }
           

        /*
         * ESTO DESAPARECE ME PARECE JUEZ
         * 
        private void buttonLoggin_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLoggin formLogin = new FormLoggin(cManager);
            formLogin.ShowDialog();
            this.Show();
            //aca va la logica si pasa o no pasa
        }
        */
        private void buttonCrearUsuario_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAbmClienteAlta formClienteAlta = new FormAbmClienteAlta(cManager, false);
            formClienteAlta.ShowDialog();
            this.Show();

        }

        private void buttonModificaciones_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormModificaciones formModificaciones = new FormModificaciones(cManager, user);
            formModificaciones.ShowDialog();
            this.Show();
        }

        

        

        
    }
}
