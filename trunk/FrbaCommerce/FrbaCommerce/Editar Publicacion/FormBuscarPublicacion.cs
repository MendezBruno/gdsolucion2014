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
using FrbaCommerce.Generar_Publicacion;

namespace FrbaCommerce.Editar_Publicacion
{
    public partial class FormBuscarPublicacion : Form
    {
        SistemManager cManager;
        Cliente cliente;
        Empresa empresa;
        Administrador administrador;
              
        
        public FormBuscarPublicacion(SistemManager cManager, Cliente cliente)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.cliente = cliente;
            cargarPublicaciones(cliente.getUsuario());
        }

        public FormBuscarPublicacion(SistemManager cManager, Empresa empresa)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.empresa = empresa;
            cargarPublicaciones(empresa.getUsuario());

        }

        public FormBuscarPublicacion(SistemManager cManager, Administrador administrador)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.administrador=administrador;
            cargarPublicaciones(administrador.getUsuario());

        }

        private void cargarPublicaciones(string userName)
        {
            cManager.sqlPublicacion.ObtenerPublicacionesSegunUsuario(cManager, userName, this.dataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Hide();

            if(this.Text.Equals("Eliminar Publicacion"))
            {

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                DialogResult confirmarBaja = MessageBox.Show("Desea deshabilitar al cliente con ", "Baja de Rol", buttons);
                
                if(DialogResult.Yes==confirmarBaja)
                cManager.sqlPublicacion.eliminarPublicacion(cManager, dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                return;

            }

            if (this.dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString().Equals("Borrador") || this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString().Equals("Borrada"))
            {
                
                FormGenerarPublicacion formGenerarPublicacion;

                if (cliente != null)
                {
                    formGenerarPublicacion = new FormGenerarPublicacion(cManager, cliente.getUsuario(), false, dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    formGenerarPublicacion.Text = "Modificar Publicacion";
                    cManager.sqlPublicacion.cargarDatosGenerar(cManager, formGenerarPublicacion, dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    formGenerarPublicacion.ShowDialog();
                }
                else
                    if (empresa != null)
                    {
                        formGenerarPublicacion = new FormGenerarPublicacion(cManager, empresa.getUsuario(), false, dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                        formGenerarPublicacion.Text = "Modificar Publicacion";
                        cManager.sqlPublicacion.cargarDatosGenerar(cManager, formGenerarPublicacion, dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                        formGenerarPublicacion.ShowDialog();
                    }
                    else
                        if (empresa == null && cliente == null)
                        {
                            formGenerarPublicacion = new FormGenerarPublicacion(cManager, administrador.getUsuario(), false, dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                            formGenerarPublicacion.Text = "Modificar Publicacion";
                            cManager.sqlPublicacion.cargarDatosGenerar(cManager, formGenerarPublicacion, dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                            formGenerarPublicacion.ShowDialog();
                        }

                this.Hide();

            }
            if (this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString().Equals("Publicada"))
            {
                if (this.dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString().Equals("Activa"))
                {

                    this.Hide();
                    if (cliente != null)
                    {
                        FormModificarPublicacion formModif = new FormModificarPublicacion(cManager, dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(), cliente, dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                        if (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString().Equals("Subasta"))
                        {

                            formModif.modifStock.Visible = false;

                        }
                        formModif.Activar.Visible = false;
                        formModif.ShowDialog();
                    }
                    else
                        if (empresa != null)
                        {
                            FormModificarPublicacion formModif = new FormModificarPublicacion(cManager, dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(), empresa, dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                            if (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString().Equals("Subasta"))
                            {

                                formModif.modifStock.Visible = false;

                            }
                            formModif.Activar.Visible = false;
                            formModif.ShowDialog();
                        }
                        else
                            if (empresa == null && cliente == null)
                            {
                                FormModificarPublicacion formModif = new FormModificarPublicacion(cManager, dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(), administrador, dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                                if (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString().Equals("Subasta"))
                                {

                                    formModif.modifStock.Visible = false;

                                }
                                formModif.Activar.Visible = false;
                                formModif.ShowDialog();
                            }

                    this.Hide();

                }
                if (this.dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString().Equals("Pausada"))
                {

                    this.Hide();
                    if (cliente != null)
                    {
                        FormModificarPublicacion formModif = new FormModificarPublicacion(cManager, dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(), cliente, dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                        formModif.modifStock.Visible = false;
                        formModif.Pausar.Visible = false;
                        formModif.ShowDialog();
                    }
                    else
                        if (empresa != null)
                        {
                            FormModificarPublicacion formModif = new FormModificarPublicacion(cManager, dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(), empresa, dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                            formModif.modifStock.Visible = false;
                            formModif.Pausar.Visible = false;
                            formModif.ShowDialog();
                        }
                        else
                            if (empresa == null && cliente == null)
                            {
                                FormModificarPublicacion formModif = new FormModificarPublicacion(cManager, dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(), administrador, dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                                formModif.modifStock.Visible = false;
                                formModif.Pausar.Visible = false;
                                formModif.ShowDialog();
                            }

                    this.Hide();

                }
            }


 
           
        }
    }
}
