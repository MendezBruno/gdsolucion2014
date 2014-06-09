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
            FormPrincipal formPrincipal;
            cManager.sqlAbmLogin.ObtenerUsuario(this.textBoxUsuario.Text,cManager ,user);

           
            
            if (user != null && user.habilitado )  //aca agrego si quiero si quiero chequear el rol
            {
                bool res = cManager.verificarCodificacionContraseña(user, this.textBoxUsuario.Text, this.textBoxContraseña.Text);

                MessageBox.Show(this.textBoxContraseña.Text);

                if (res)
                {
                    this.Hide();
                    switch (user.tipoUsuario)
                    {
                        case "Cliente":
                            Cliente cliente = new Cliente();
                            cManager.sqlCliente.ObtenerCliente(cliente,user, cManager);
                            formPrincipal = new FormPrincipal(cManager, cliente);
                            formPrincipal.ShowDialog();
                            this.Show();
                            break;
                        case "Administrador":
                            Administrador administrador = new Administrador();
                            cManager.ObtenerAdministrador(user, administrador);
                            formPrincipal = new FormPrincipal(cManager, administrador);
                            formPrincipal.ShowDialog();
                            this.Show();
                            break;
                        case "Empresa":
                            Empresa empresa = new Empresa();
                            cManager.sqlEmpresa.ObtenerEmpresa(user,empresa, cManager);
                            formPrincipal = new FormPrincipal(cManager, empresa);
                            formPrincipal.ShowDialog();
                            this.Show();
                            break;
                    }

                    
                }
                else
                {
                    user.Dispose();
                    if (!this.textBoxContraseña.Text.Equals("")) this.labelContraseñaincorrecta.Visible = true;
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