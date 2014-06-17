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

namespace FrbaCommerce.Editar_Publicacion
{
    public partial class FormEditarPublicacion : Form
    {
        public FormEditarPublicacion(SistemManager cManager,Empresa empresa)
        {
            InitializeComponent();
        }

        public FormEditarPublicacion(SistemManager cManager, Cliente cliente)
        {
            InitializeComponent();
        }
    }
}
