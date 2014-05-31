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
        public FormAbmEmpresaAlta(SistemManager cManager)
        {
            InitializeComponent();
            this.cManager = cManager;
        }

        public FormAbmEmpresaAlta(SistemManager cManager, bool alta)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.alta = alta;
        }


        
    }
}
