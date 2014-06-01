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
    public partial class FormModificaciones : Form
    {
        SistemManager cManager;
        Usuario user;
        public FormModificaciones(SistemManager cManager, Usuario user)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.user = user;
        }

        private void buttonModificarEmpresa_Click(object sender, EventArgs e)
        {

        }

        private void buttonModificarRol_Click(object sender, EventArgs e)
        {

        }
    }
}
