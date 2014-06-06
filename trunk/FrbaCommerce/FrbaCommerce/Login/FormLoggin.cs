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
using FrbaCommerce.Registro_de_Usuario;

namespace FrbaCommerce.Login
{
    public partial class FormLoggin : Form
    {
        //SistemManagerSingleton classManagerSingleton = SistemManagerSingleton.Instance;
        SistemManager cManager;
        public FormLoggin(SistemManager cManager)
        {
            InitializeComponent();
            this.cManager = cManager;
        }

        private void buttonIngresar_Click(object sender, EventArgs e)
        {
            //cManager.sqlAbmLogin.cargarUsuario(user, cManager); 
            Usuario user = new Usuario();
            cManager.traerUsuario(this.textBoxUsuario.Text, user);

           
            
            if (user != null && user.habilitado )  //aca agrego si quiero si quiero chequear el rol
            {
                bool res = cManager.verificarCodificacionContraseña(user, this.textBoxUsuario.Text, this.textBoxContraseña.Text);

                if (res)
                {
                    this.Hide();
                    FormPrincipal formPrincipal = new FormPrincipal(cManager, user);
                    formPrincipal.ShowDialog();
                    this.Show();
                }
                else
                {
                    user.Dispose();
                    this.labelContraseñaincorrecta.Visible = true;
                }
                //si res es true ingresa y si es false suma una chance de inHabilitacion; si llego a tres muere.

            }
            else
            {
                if (user.habilitado) this.labelUsuarioInexistente.Visible = true;
                else this.labelUsuarioDeshabilitado.Visible = true;
            }
        }
        
        private void linkLabelRegistrarse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            FormRegistroDeUsuario formRegistroDeUsuario = new FormRegistroDeUsuario(cManager);
            formRegistroDeUsuario.ShowDialog();
            this.Show();
        }

        

        

    }
}



/*if (user.RolAsignado.getNombre().Equals("Empresa"))
                {
                    //Interfaz De Empresa
                }
                if (user.RolAsignado.getNombre().Equals("Empresa"))
                {
                    //Interfaz de Usuario
                }
                else
                {
                    MessageBox.Show("Ocurrio un error a cargar la interfaz Del Rol Revisar formLoggin.cs Metodo boton Ingresar");
                }
*/