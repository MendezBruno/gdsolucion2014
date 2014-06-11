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

        }

        private void buttonAlta_Click(object sender, EventArgs e)
        {

            if (modificacion)
            {
                //cManager.sqlAbmVisibilidad
            }

            else
            cManager.sqlAbmVisibilidad.Ingresar_Datos(cManager, textBoxCodigo.Text, textBoxDescripcion.Text, textBoxPPP.Text, textBoxPorcentaje.Text);
        }

    }
}
