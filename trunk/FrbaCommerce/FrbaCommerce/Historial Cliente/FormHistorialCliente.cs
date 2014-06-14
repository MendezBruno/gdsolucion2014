using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Modelo;

namespace FrbaCommerce.Historial_Cliente
{
    public partial class FormHistorialCliente : Form
    {

        SistemManager cManager;

        public FormHistorialCliente(SistemManager cManager,String nombre)
        {
            InitializeComponent();
            this.cManager = cManager;
            cManager.sqlHistorial.cargarDatos(cManager, dataGridViewHistorial, nombre);
            dataGridViewHistorial.Update();

        }

    }
}
