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
    public partial class FormAbmEmpresaAlta : Form
    {
        SistemManager cManager;
        bool alta;

        bool modificacion;

        string user, pass;

        public FormAbmEmpresaAlta(SistemManager cManager)
        
        {

            InitializeComponent();
            this.cManager = cManager;

        }

        public FormAbmEmpresaAlta(string user, string pass,SistemManager cManager, bool alta)
        
        {
            InitializeComponent();
            this.cManager = cManager;
            this.alta = alta;
            this.user = user;
            this.pass = pass;
        }

        private void botonAlta_Click(object sender, EventArgs e)
        
        {

            cManager.sqlEmpresa.darAlta(cManager, cuit.Text, razon.Text, mail.Text, telefono.Text, direccion.Text, nroDireccion.Text, depto.Text, localidad.Text, codPostal.Text, ciudad.Text, fechaCreacion.Text, piso.Text);
            
            



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

        private void label5_Click(object sender, EventArgs e)
        {
        
        }
        
    }
}
