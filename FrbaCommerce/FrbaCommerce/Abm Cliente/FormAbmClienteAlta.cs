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

namespace FrbaCommerce.Abm_Cliente
{
    public partial class FormAbmClienteAlta : Form
    {
        SistemManager cManager;
        bool alta;
        Cliente cliente;
        public FormAbmClienteAlta(SistemManager cManager, bool alta)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.alta = alta;
        }

        public FormAbmClienteAlta(SistemManager cManager)
        {
            InitializeComponent();
            this.cManager = cManager;
            cliente = new Cliente();
            
        }

        private void buttonAlta_Click(object sender, EventArgs e)
        {
            if (alta) cManager.sqlCliente.darAlta(cManager, textBoxNombre.Text, textBoxApe.Text, comboBoxTipo.Text, textBoxNumero.Text, textBoxTel.Text, textBoxMail.Text, textBoxDirec.Text, textBoxNroPiso.Text, textBoxDepto.Text, textBoxLocalidad.Text, textBoxCodPos.Text, textBoxCiudad.Text, textBoxFecNac.Text);
            else cManager.sqlCliente.modificarCliente(cManager,cliente, textBoxNombre.Text, textBoxApe.Text, comboBoxTipo.Text, textBoxNumero.Text, textBoxTel.Text, textBoxMail.Text, textBoxDirec.Text, textBoxNroPiso.Text, textBoxDepto.Text, textBoxLocalidad.Text, textBoxCodPos.Text, textBoxCiudad.Text, textBoxFecNac.Text);
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textBoxNombre.Text="";
            textBoxApe.Text="";
            comboBoxTipo.Text="";
            textBoxNumero.Text="";
            textBoxTel.Text="";
            textBoxMail.Text="";
            textBoxDirec.Text="";
            textBoxNroPiso.Text="";
            textBoxLocalidad.Text="";
            textBoxCodPos.Text="";
            textBoxCiudad.Text="";
            textBoxFecNac.Text = "";
        }
    }
}
