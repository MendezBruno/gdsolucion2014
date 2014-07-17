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


            bool usuarioExiste=false;
            
            if (this.textBoxUser.Text.Equals(""))
            MessageBox.Show("Nombre de Usuario no ingresado");
            else
            if(this.textBoxPass.Text.Equals(""))
            MessageBox.Show("Contraseña no ingresada");
            else
                usuarioExiste = cManager.sqlUsuario.existe_Usuario(cManager, textBoxUser.Text, textBoxPass.Text);
            if (usuarioExiste== false)
            crearUsuarioConTalRol(this.comboBoxRol.Text,this.textBoxUser.Text,this.textBoxPass.Text);

        }

        private void crearUsuarioConTalRol(string rol,string user,string pass)
        {
            switch (rol)
            {
                case "Cliente":
                    this.Hide();
                    FormAbmClienteAlta formAbmCliente = new FormAbmClienteAlta(user,pass,cManager, true);
                    formAbmCliente.ShowDialog();
                    this.Hide();
                    break;
                case "Empresa":
                    this.Hide();
                    FormAbmEmpresaAlta formAbmEmpresa = new FormAbmEmpresaAlta(user,pass,cManager, false);
                    formAbmEmpresa.ShowDialog();
                    this.Hide();
                    break;
            }
        }
      
    }
}







