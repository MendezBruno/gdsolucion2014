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

        bool esEmpresa, modificacion;

        public Empresa empresa;

        string user, pass;

        public FormAbmEmpresaAlta(SistemManager cManager,bool modificacion)
        
        {

            InitializeComponent();
            this.cManager = cManager;
            empresa = new Empresa();
            this.modificacion = modificacion;

        }

        public FormAbmEmpresaAlta(string user, string pass,SistemManager cManager, bool alta)
        
        {
            InitializeComponent();
            this.cManager = cManager;
            this.user = user;
            this.pass = pass;
        }

        private void botonAlta_Click(object sender, EventArgs e)
        
        {

            if (modificacion)
            {

                cManager.sqlEmpresa.modificarEmpresa(cManager, empresa, cuit.Text, razon.Text, mail.Text, telefono.Text, direccion.Text, nroDireccion.Text, departamento.Text, localidad.Text, codPostal.Text, ciudad.Text, fechaCreacion.Text, piso.Text, usuario.Text,checkBoxHabilitacion.Checked);

            
            }
            else
            {
                cManager.sqlEmpresa.darAlta(cManager, cuit.Text, razon.Text, mail.Text, telefono.Text, direccion.Text, nroDireccion.Text, departamento.Text, localidad.Text, codPostal.Text, ciudad.Text, fechaCreacion.Text, piso.Text, usuario.Text);
                cManager.sqlUsuario.darAltaEmpresa(cManager,cuit.Text);

            }
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
