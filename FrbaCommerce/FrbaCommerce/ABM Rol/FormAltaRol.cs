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

namespace FrbaCommerce.ABM_Rol
{
    public partial class FormAltaRol : Form
    {
        SistemManager cManager;
        public Rol rolActual; 
        bool modificacion;
       // SistemManagerSingleton classManagerSingleton = SistemManagerSingleton.Instance;
        public FormAltaRol(SistemManager cManager)
        {
            InitializeComponent();
            this.cManager= cManager;
        }

        public FormAltaRol(SistemManager cManager, bool modificacion)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.rolActual = new Rol();
            this.modificacion = modificacion;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            if (modificacion) cManager.sqlAbmRol.modificarRol(cManager, this.textBoxNombreRol.Text, this.groupBoxFuncionalidades.Controls, rolActual);
            else cManager.sqlAbmRol.altaRol(cManager,this.textBoxNombreRol.Text, this.groupBoxFuncionalidades.Controls);
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            foreach (CheckBox chekBox in this.groupBoxFuncionalidades.Controls)
            {
                chekBox.Checked = false;
            }
            this.textBoxNombreRol.Text = "";
        }

    }
}
