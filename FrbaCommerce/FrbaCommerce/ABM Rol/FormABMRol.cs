using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Modelo;

namespace FrbaCommerce.ABM_Rol
{
    public partial class FormABMRol : Form
    {
        SistemManager cManager;
        
        public FormABMRol(SistemManager cManager)
        {
            InitializeComponent();
            this.cManager = cManager;
        }

        private void buttonCrearRol_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAltaRol formAltaRol = new FormAltaRol(cManager);
            formAltaRol.ShowDialog();
            this.Show();
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Modificacion_Rol formModificacionRol = new Modificacion_Rol(cManager);
            formModificacionRol.ShowDialog();
            this.Show();
        }

        private void buttonBaja_Click(object sender, EventArgs e)
        {

            this.Hide();
            Modificacion_Rol formModificacionRol = new Modificacion_Rol(cManager);
            formModificacionRol.Text = "Baja";
            formModificacionRol.ShowDialog();
            this.Show();

            /*
            this.Hide();
            FormBajaRol formBajaRol = new FormBajaRol(cManager);
            formBajaRol.ShowDialog();
            this.Show();
             */ 
        }
    }
}
