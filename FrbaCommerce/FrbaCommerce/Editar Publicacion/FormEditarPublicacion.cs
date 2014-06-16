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

namespace FrbaCommerce.Buscar_Publicaciones
{
    public partial class FormEditarPublicacion : Form
    {
        SistemManager cManager;
        Cliente cliente;
        Empresa empresa;

        public FormEditarPublicacion(SistemManager cManager, Cliente cliente)
        {
            InitializeComponent();
             this.cManager = cManager;
            this.cliente = cliente;
            
        }

        

        public FormEditarPublicacion(SistemManager cManager, Empresa empresa)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.empresa = empresa;
            

        }

        
        

       
    }
}
