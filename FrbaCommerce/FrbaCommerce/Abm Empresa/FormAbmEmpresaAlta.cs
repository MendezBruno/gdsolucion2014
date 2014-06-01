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


        
    }
}
