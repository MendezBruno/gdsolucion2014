using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Modelo;

namespace FrbaCommerce.Abm_Empresa
{
    public partial class FormModificacionEmpresa : Form
    {
        SistemManager cManager;

        public FormModificacionEmpresa(SistemManager cManager)
        {
            InitializeComponent();
            this.cManager = cManager;

        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            
            cManager.sqlEmpresa.BuscarEmpresa(cManager, textBoxRazonSocial.Text, textBoxMail.Text, textBoxCuit.Text, this.dataGridViewEmpresa);
            dataGridViewEmpresa.Update();
        }

    }
}
