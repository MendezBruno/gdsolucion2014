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
        public FormPrincipal(SistemManager cManager, Usuario user)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.user = user;
            cargaManuSegunRol(user.RolAsignado, this);
        }

        private void cargaManuSegunRol(Rol rol, FormPrincipal formPrincipal)
        {
            throw new NotImplementedException();
        }

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
