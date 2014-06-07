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
using FrbaCommerce.ABM_Rol;
using FrbaCommerce.Abm_Cliente;
using FrbaCommerce.Abm_Visibilidad;
using FrbaCommerce.Abm_Empresa;

namespace FrbaCommerce
{
    public partial class FormModificaciones : Form
    {
        SistemManager cManager;
        Usuario user;
        public FormModificaciones(SistemManager cManager, Usuario user)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.user = user;
            deshabilitarBotonesSegunFuncionalidadRol(user.RolAsignado.getListaFuncionalidades());
        }

        private void deshabilitarBotonesSegunFuncionalidadRol(List<string> funcionalidades)
        {
            foreach (Button boton in this.Controls)
            {
                if(funcionalidades.Contains(boton.Name)) boton.Visible = true;
            }
        }

        private void buttonModificarEmpresa_Click(object sender, EventArgs e)
        {
            this.Hide();

            FormModificacionEmpresa fromModificacionEmpresa = new FormModificacionEmpresa(cManager);
            fromModificacionEmpresa.ShowDialog();
            
            this.Show();
        }

     

        private void buttonModificarRol_Click(object sender, EventArgs e)
        {
            this.Hide();
            Modificacion_Rol formModificacionRol = new Modificacion_Rol(cManager);
            formModificacionRol.ShowDialog();
            this.Show();
        }

        private void buttonCrearCliente_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAbmClienteAlta formClienteAlta = new FormAbmClienteAlta(cManager, false);
            formClienteAlta.ShowDialog();
            this.Show();
        }

        private void buttonHabilitarRol_Click(object sender, EventArgs e)
        {

        }

        private void buttonDeshabilitarRol_Click(object sender, EventArgs e)
        {

        }

        private void buttonBajaVisibilidad_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormModificacionVisibilidad formModificacionVisibilidad = new FormModificacionVisibilidad(cManager);
            formModificacionVisibilidad.Text = "Baja";
            formModificacionVisibilidad.ShowDialog();
            this.Show();
        }

        private void buttonModificarVisibilidad_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormModificacionVisibilidad formModificacionVisibilidad = new FormModificacionVisibilidad(cManager);
            formModificacionVisibilidad.ShowDialog();
            this.Show();
        }

        private void buttonBajaRol_Click(object sender, EventArgs e)
        {
            this.Hide();
            Modificacion_Rol formModificacionRol = new Modificacion_Rol(cManager);
            formModificacionRol.Text = "Baja";
            formModificacionRol.ShowDialog();
            this.Show();
        }

        private void buttonDesbloquearUsuario_Click(object sender, EventArgs e)
        {

        }

        private void buttonAltaVisibilidad_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAltaVisibilidad formAltaVisibilidad = new FormAltaVisibilidad(cManager);
            formAltaVisibilidad.ShowDialog();
            this.Show();
        }

        private void buttonBajaEmpresa_Click(object sender, EventArgs e)
        {
            this.Hide();

            FormModificacionEmpresa fromModificacionEmpresa = new FormModificacionEmpresa(cManager);
            fromModificacionEmpresa.ShowDialog();

            this.Show();
        }

        private void buttonCrearEmpresa_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAbmEmpresaAlta formEmpresaAlta = new FormAbmEmpresaAlta(cManager, false);
            formEmpresaAlta.ShowDialog();
            this.Show();
        }

        private void buttonBloquearUsuario_Click(object sender, EventArgs e)
        {

        }

        private void buttonBajaCliente_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAbmModificacionCliente formModificacionCliente = new FormAbmModificacionCliente(cManager);
            formModificacionCliente.Text = "Baja";
            formModificacionCliente.ShowDialog();
            this.Show();
        }

        

        private void buttonModificarCliente_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAbmModificacionCliente formModificacionCliente = new FormAbmModificacionCliente(cManager);
            formModificacionCliente.ShowDialog();
            this.Show();
        }

        private void buttonCrearRol_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAltaRol formAltaRol = new FormAltaRol(cManager);
            formAltaRol.ShowDialog();
            this.Show();
        }

        private void buttonModificarRol_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Modificacion_Rol formModificacionRol = new Modificacion_Rol(cManager);
            formModificacionRol.ShowDialog();
            this.Show();

        }
    }
}
