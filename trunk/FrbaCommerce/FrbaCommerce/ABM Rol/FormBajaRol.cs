﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Modelo;

namespace FrbaCommerce.ABM_Rol
{
    public partial class FormBajaRol : Form
    {
        SistemManager cManager;
        public FormBajaRol(SistemManager cManager)
        {
            InitializeComponent();
            this.cManager = cManager;
        }


    }
}
