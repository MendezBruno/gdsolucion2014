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

namespace FrbaCommerce.Abm_Empresa
{
    public partial class FormAbmEmpresaAlta : Form
    {
        SistemManager cManager;

        bool esEmpresa, modificacion,registro,esCliente;

        public Empresa empresa;

        string user, pass;

        public FormAbmEmpresaAlta(SistemManager cManager,bool modificacion)
        
        {

            InitializeComponent();
            this.cManager = cManager;
            empresa = new Empresa();
            this.modificacion = modificacion;
            this.registro = false;

        }

        public FormAbmEmpresaAlta(string user, string pass,SistemManager cManager, bool esCliente)
        
        {
            InitializeComponent();
            this.cManager = cManager;
            this.user = user;
            this.pass = pass;
            this.registro = true;
            this.esCliente = esCliente;
            this.checkBoxHabilitacion.Visible = false;
        }

        private void botonAlta_Click(object sender, EventArgs e)
        
        {

            if (modificacion)
            {

                cManager.sqlEmpresa.modificarEmpresa(cManager, empresa, cuit.Text, razon.Text, mail.Text, telefono.Text, direccion.Text, nroDireccion.Text, departamento.Text, localidad.Text, codPostal.Text, ciudad.Text, fechaCreacion.Text, piso.Text, usuario.Text,checkBoxHabilitacion.Checked);

            
            }
            else
            if(this.registro== false)
            {
                cManager.sqlEmpresa.darAlta(cManager,esCliente, cuit.Text, razon.Text, mail.Text, telefono.Text, direccion.Text, nroDireccion.Text, departamento.Text, localidad.Text, codPostal.Text, ciudad.Text, fechaCreacion.Text, piso.Text, usuario.Text);
            }
                else
            {
                cManager.sqlEmpresa.darAlta(cManager,esCliente, cuit.Text, razon.Text, mail.Text, telefono.Text, direccion.Text, nroDireccion.Text, departamento.Text, localidad.Text, codPostal.Text, ciudad.Text, fechaCreacion.Text, piso.Text, usuario.Text, this.user, this.pass);
            }
            /*
                if (cuit.Text.Equals("") || razon.Text.Equals(""))
                {

                    if (cuit.Text.Equals(""))
                        MessageBox.Show("Cuit No Ingresado");
                    if (razon.Text.Equals(""))
                        MessageBox.Show("Razon Social No ingresada");

                }
                else
                {
                    cManager.sqlUsuario.darAltaEmpresa(cManager, cuit.Text);
                    cManager.sqlEmpresa.darAlta(cManager, cuit.Text, razon.Text, mail.Text, telefono.Text, direccion.Text, nroDireccion.Text, departamento.Text, localidad.Text, codPostal.Text, ciudad.Text, fechaCreacion.Text, piso.Text, usuario.Text);
                    MessageBox.Show("El nombre de usuario para ingresar al sistema es:" + cuit.Text + ".\nIngresar al sistema sin password y le pedira que cambie la contraseña");
                }
             
             */
            this.Hide();
        }
        

        private void botonLimpiar_Click(object sender, EventArgs e)

        {
            razon.Text="";
            cuit.Text = "";
            mail.Text = "";
            direccion.Text = "";
            nroDireccion.Text = "";
            piso.Text = "";
            localidad.Text = "";
            codPostal.Text = "";
            ciudad.Text = "";
            usuario.Text = "";
            fechaCreacion.Text = "";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.monthCalendarEmpresa.Visible == true)
                this.monthCalendarEmpresa.Visible = false;
            else
                this.monthCalendarEmpresa.Visible = true;

        }

        private void monthCalendarEmpresa_DateChanged(object sender, DateRangeEventArgs e)
        {
            this.fechaCreacion.Text = this.monthCalendarEmpresa.SelectionRange.Start.ToString();


        }

        
    }
}
