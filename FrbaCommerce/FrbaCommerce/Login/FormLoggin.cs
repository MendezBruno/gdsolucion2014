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
            
            Usuario user = cManager.traerUsuario(this.textBoxUsuario.Text);

            //Ver si user no Es null

            bool res = cManager.verificarCodificacionContraseña(user,this.textBoxUsuario.Text, this.textBoxUsuario.Text);

            if (res)
            {
                switch(user.RolAsignado.getNombre())
                {
                    case "Empresa":
                   // Interfaz empresa 

                    break;

                    case "Cliente":
                        //interfaz cliente
                        break;

                    case "Administrador":
                        //interfaz administrador
                        break;
                    default: 
                        MessageBox.Show("Nombre de rol sin Interfaz designa u incorrecto");
                        break;
                 }
               //cManager.sqlAbmLogin.cargarUsuario(user, cManager); 
 
            }
            else
            {
                user.Dispose();
                MessageBox.Show("Contraseña Incorrecta");
            }
            //si res es true ingresa y si es false suma una chance de inHabilitacion; si llego a tres muere.
        }

        private void FormLoggin_Load(object sender, EventArgs e)
        {

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