using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Modelo;
using FrbaCommerce.Abm_Cliente;
using FrbaCommerce.Abm_Empresa;

namespace FrbaCommerce.Registro_de_Usuario
{
    public partial class FormRegistroDeUsuario : Form
    {
        SistemManager cManager;

        public FormRegistroDeUsuario(SistemManager cManager)
        {
            InitializeComponent();
            this.cManager=cManager;
        }

        private void buttonRegistrar_Click(object sender, EventArgs e)
        {
        //  cManager.conexion.registrarUsuario(this.textBoxUser.Text, this.textBoxPass.Text,this.comboBoxRol.Text , this.textBoxTipo.Text, this.textBoxNumero.Text);
            crearUsuarioConTalRol(this.comboBoxRol.Text);
        }

        private void crearUsuarioConTalRol(string rol)
        {
            switch (rol)
            {
                case "Cliente":
                    this.Hide();
                    FormAbmClienteAlta formAbmCliente = new FormAbmClienteAlta(cManager,true);
                    formAbmCliente.ShowDialog();
                    this.Show();
                    break;
                case "Empresa":
                    this.Hide();
                    FormAbmEmpresaAlta formAbmEmpresa = new FormAbmEmpresaAlta(cManager,true);
                    formAbmEmpresa.ShowDialog();
                    this.Show();
                    break;
            }
        }
      
    }
}







