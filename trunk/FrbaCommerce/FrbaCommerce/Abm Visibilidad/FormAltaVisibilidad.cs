using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Modelo;

namespace FrbaCommerce.Abm_Visibilidad
{
    public partial class FormAltaVisibilidad : Form
    {
        SistemManager cManager;
        bool modificacion;
        public FormAltaVisibilidad(SistemManager cManager)
        {
            InitializeComponent();
            this.cManager = cManager;
        }

        public FormAltaVisibilidad(SistemManager cManager,bool modificacion)
        {
            InitializeComponent();
            this.modificacion = modificacion;
            this.cManager = cManager;

        }

        private void buttonAlta_Click(object sender, EventArgs e)
        {

            bool dioAlta = false;
            
            if (modificacion)
            {
                dioAlta=cManager.sqlAbmVisibilidad.Ingresar_Datos_Modificacion(cManager, textBoxCodigo.Text, textBoxDescripcion.Text, textBoxPPP.Text, textBoxPorcentaje.Text, checkBoxHabilitado.Checked);
            }

            else
            dioAlta=cManager.sqlAbmVisibilidad.Ingresar_Datos(cManager, textBoxCodigo.Text, textBoxDescripcion.Text, textBoxPPP.Text, textBoxPorcentaje.Text);

            if (dioAlta==true)
                this.Hide();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {

            if (modificacion)
            {
                textBoxDescripcion.Text = "";
                textBoxPorcentaje.Text = "";
                textBoxPPP.Text = "";
            }
            else
            {
                textBoxCodigo.Text = "";
                textBoxDescripcion.Text = "";
                textBoxPorcentaje.Text = "";
                textBoxPPP.Text = "";
            }

        }

    }
}
