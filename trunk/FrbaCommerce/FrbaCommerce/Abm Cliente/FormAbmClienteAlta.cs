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
        bool esCliente,modificacion;
        string user, pass;
        Cliente cliente;
        public FormAbmClienteAlta(string user,string pass,SistemManager cManager, bool esCliente)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.esCliente = esCliente;
            this.user = user;
            this.pass = pass;
        }

        public FormAbmClienteAlta(SistemManager cManager,bool modificacion)
        {
            InitializeComponent();
            this.cManager = cManager;
            cliente = new Cliente();
            this.modificacion = modificacion;
        }

        private void buttonAlta_Click(object sender, EventArgs e)
        {
            if (esCliente)
            {
                cManager.sqlCliente.darAlta(cManager, textBoxNombre.Text, textBoxApe.Text, comboBoxTipo.Text, textBoxNumero.Text, textBoxTel.Text, textBoxMail.Text, textBoxDirec.Text, textBoxNumeroCalle.Text, textBoxNroPiso.Text, textBoxDepto.Text, textBoxLocalidad.Text, textBoxCodPos.Text, textBoxCiudad.Text, textBoxFecNac.Text);
                cManager.sqlUsuario.darAlta(cManager, textBoxNumero.Text, comboBoxTipo.Text);
            }
            else
            {
                if (!modificacion)
                {
                    MessageBox.Show("esto es de prueba para saber que entre a alta desde administrador");
                    cManager.sqlCliente.darAlta(cManager, textBoxNombre.Text, textBoxApe.Text, comboBoxTipo.Text, textBoxNumero.Text, textBoxTel.Text, textBoxMail.Text, textBoxDirec.Text, textBoxNumeroCalle.Text, textBoxNroPiso.Text, textBoxDepto.Text, textBoxLocalidad.Text, textBoxCodPos.Text, textBoxCiudad.Text, textBoxFecNac.Text);
                    cManager.sqlUsuario.darAlta(cManager, textBoxNumero.Text, comboBoxTipo.Text);
                    //cManager.sqlUsuario.darAlta(cManager, textBoxNombre.Text, "null");
                }
                else cManager.sqlCliente.modificarCliente(cManager, cliente, textBoxNombre.Text, textBoxApe.Text, comboBoxTipo.Text, textBoxNumero.Text, textBoxTel.Text, textBoxMail.Text, textBoxDirec.Text, textBoxNroPiso.Text, textBoxDepto.Text, textBoxLocalidad.Text, textBoxCodPos.Text, textBoxCiudad.Text, textBoxFecNac.Text);
            }
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
            textBoxNumeroCalle.Text = "";
            textBoxNroPiso.Text="";
            textBoxLocalidad.Text="";
            textBoxCodPos.Text="";
            textBoxCiudad.Text="";
            textBoxFecNac.Text = "";
        }

    }
}
