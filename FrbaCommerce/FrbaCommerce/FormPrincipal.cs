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

namespace FrbaCommerce
{
    public partial class FormPrincipal : Form
    {
        SistemManager cManager;
        public FormPrincipal(SistemManager cManager)
        {
            InitializeComponent();
            this.cManager = cManager;
        }

        private void buttonLoggin_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLoggin formLogin = new FormLoggin(cManager);
            formLogin.ShowDialog();
            this.Show();
            //aca va la logica si pasa o no pasa
        }

        private void buttonCrearUsuario_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormRegistroDeUsuario formRegistroDeUsuario = new FormRegistroDeUsuario(cManager);
            formRegistroDeUsuario.ShowDialog();
            this.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormABMRol formABMRol = new FormABMRol(cManager);
            formABMRol.ShowDialog();
            this.Show();
        }

        
    }
}
