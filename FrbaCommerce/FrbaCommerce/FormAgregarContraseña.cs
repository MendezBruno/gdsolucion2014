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

namespace FrbaCommerce
{
    public partial class FormAgregarContraseña : Form
    {
        SistemManager cManager;
        Usuario user;
        public FormAgregarContraseña(SistemManager cManager, Usuario user)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.user = user;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxContraseña.Text.Equals(textBoxReContraseña.Text))
            {
                user.setPassword(cManager.sqlAbmLogin.agregarContraseñaPorPrimerIngreso(cManager, textBoxContraseña.Text, user.getUsuario()));
                this.Close();
            }
            else
            {
                this.labelNoCoincide.Visible = true;
            }
        }
    }
}
