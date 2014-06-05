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
    public partial class FormBajaVisibilidad : Form
    {
        SistemManager cManager;
        public FormBajaVisibilidad(SistemManager cManager)
        {
            InitializeComponent();
            this.cManager = cManager;
        }
    }
}
