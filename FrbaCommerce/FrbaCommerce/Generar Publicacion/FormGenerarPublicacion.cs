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

namespace FrbaCommerce.Generar_Publicacion
{
    public partial class FormGenerarPublicacion : Form
    {
        SistemManager cManager;
        Empresa empresa;
        Cliente cliente;
        Administrador administrador;
        bool publico;
        string usuario;
        bool salir;
        bool modificacion;
        bool esUpdate = false;
        bool esStock = false;
        public string stock_Inicial{get;set;}
        public string public_Codigo;



        public FormGenerarPublicacion(SistemManager cManager, string usuario,bool modificacion,string public_Codigo,bool esStock)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.cManager = cManager;
            this.labelUserName.Text = usuario; 
            this.publico = false;
            this.salir = false;
            this.modificacion = modificacion;
            this.public_Codigo = public_Codigo;
            cargarForm();
            this.stock_Inicial = this.numericUpDownStockInicial.Value.ToString();
            if(!esStock) this.esUpdate = true;
        }
        
 
        public FormGenerarPublicacion(SistemManager cManager, Cliente cliente,bool modificacion)
        {
            InitializeComponent();
            this.cliente = cliente;
            this.cManager = cManager;
            this.labelUserName.Text = cliente.getUsuario();
            this.publico = false;
            this.salir = false;
            cargarForm();
            this.modificacion = modificacion;
            numericUpDownStockInicial.Value = 1;
            this.esUpdate = false;
        }



        public FormGenerarPublicacion(SistemManager cManager, Empresa empresa, bool modificacion)
        {
            InitializeComponent();
            this.empresa = empresa;
            this.cManager = cManager;
            this.labelUserName.Text = empresa.getUsuario();
            this.publico = false;
            this.salir = false;
            this.stock_Inicial = this.numericUpDownStockInicial.Value.ToString();
            cargarForm();
            this.stock_Inicial = this.numericUpDownStockInicial.Value.ToString();
            this.modificacion = modificacion;
            numericUpDownStockInicial.Value = 1;
            this.esUpdate = false;

        }
        public FormGenerarPublicacion(SistemManager cManager, Administrador administrador, bool modificacion)
        {
            InitializeComponent();
            this.administrador = administrador;
            this.cManager = cManager;
            this.labelUserName.Text = administrador.getUsuario();
            this.publico = false;
            cargarForm();
            this.stock_Inicial = this.numericUpDownStockInicial.Value.ToString();
            this.modificacion = modificacion;
            numericUpDownStockInicial.Value = 1;
            this.esUpdate = false;
        }

        private void cargarForm()
        {
            
            cManager.sqlAbmVisibilidad.listaDeVisibilidades(cManager, this.comboBoxVisibilidad.Items);
            cManager.sqlRubro.listaDeRubro(cManager, this.checkedListBoxRubro.Items);

        }
        
        private void buttonPublicar_Click(object sender, EventArgs e)
        {
            
            if (this.modificacion == false)
            {

                if (comboBoxVisibilidad.Text.Equals("Gratis"))
                {
                    if (cManager.sqlPublicacion.tieneMasDeTresGratis(cManager, this.labelUserName.Text))
                    {


                        cManager.sqlPublicacion.publicar(cManager, this.comboBoxTipoPublicacion.Text, this.textBoxDescripcion.Text, this.numericUpDownStockInicial.Value.ToString(), this.textBoxPrecio.Text, cManager.sqlAbmVisibilidad.codigoSegunDescripcion(cManager, this.comboBoxVisibilidad.Text), this.comboBoxAceptaPregunta.Text, this.labelUserName.Text, this.checkedListBoxRubro.CheckedItems,this.Text,this.public_Codigo);
 
                        this.publico = true;

                    }
                    else
                    {


                        MessageBox.Show("No Es posible cargar la publicacion porque tiene mas de 3 publicaciones Gratis Activas, Pausee o Fianlize alguna para poder continuar");
                        return;
                    
                    }

                }

                else
                {
                    
                    
                    
                    cManager.sqlPublicacion.publicar(cManager, this.comboBoxTipoPublicacion.Text, this.textBoxDescripcion.Text, this.numericUpDownStockInicial.Value.ToString(), this.textBoxPrecio.Text, cManager.sqlAbmVisibilidad.codigoSegunDescripcion(cManager, this.comboBoxVisibilidad.Text), this.comboBoxAceptaPregunta.Text, this.labelUserName.Text, this.checkedListBoxRubro.CheckedItems,this.Text,this.public_Codigo);

                    this.publico = true;


                }

            }
            else
            {

             //  if (esUpdate) cManager.sqlPublicacion.modificarPublicacionCompleta(cManager, this.comboBoxTipoPublicacion.Text, this.textBoxDescripcion.Text, this.numericUpDownStockInicial.Value.ToString(), this.textBoxPrecio.Text, cManager.sqlAbmVisibilidad.codigoSegunDescripcion(cManager, this.comboBoxVisibilidad.Text), this.comboBoxAceptaPregunta.Text, this.labelUserName.Text, this.checkedListBoxRubro.CheckedItems, this.Text, this.public_Codigo);
                cManager.sqlPublicacion.ModificarPublic(cManager, this.numericUpDownStockInicial.Value.ToString(), textBoxDescripcion.Text,this.public_Codigo);

              
            }
         

            this.Hide();
        
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            this.comboBoxTipoPublicacion.Text = "";
            this.comboBoxVisibilidad.Text = "";
            this.comboBoxAceptaPregunta.Text = "";
        }

        private void FormGenerarPublicacion_FormClosing(object sender, FormClosingEventArgs e)
        {


            if (this.modificacion == false)
            {
                if (this.salir == false)
                {
                    if (publico == false)
                    {

                        if (esUpdate == false)
                        {

                            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                            DialogResult confirmarGuardado = MessageBox.Show("Desea Guardar la publicacion no finalizada?", "Guardar Publicacion", buttons);

                            if (DialogResult.Yes == confirmarGuardado)

                            cManager.sqlPublicacion.pasarBorrador(cManager, this.comboBoxTipoPublicacion.Text, this.textBoxDescripcion.Text, this.numericUpDownStockInicial.Value.ToString(), this.textBoxPrecio.Text, cManager.sqlAbmVisibilidad.codigoSegunDescripcion(cManager, this.comboBoxVisibilidad.Text), this.comboBoxAceptaPregunta.Text, this.labelUserName.Text, this.checkedListBoxRubro.CheckedItems);

                        }
                        else
                        {

                            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                            DialogResult confirmarGuardado = MessageBox.Show("Desea Guardar la publicacion no finalizada?", "Guardar Publicacion", buttons);

                            if (DialogResult.Yes == confirmarGuardado)

                                cManager.sqlPublicacion.pasarBorradorUpdate(cManager, this.comboBoxTipoPublicacion.Text, this.textBoxDescripcion.Text, this.numericUpDownStockInicial.Value.ToString(), this.textBoxPrecio.Text, cManager.sqlAbmVisibilidad.codigoSegunDescripcion(cManager, this.comboBoxVisibilidad.Text), this.comboBoxAceptaPregunta.Text, this.labelUserName.Text, this.checkedListBoxRubro.CheckedItems, this.public_Codigo);



                        }

                        
                        
                    }

                }
            }
       }

        private void comboBoxTipoPublicacion_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(this.comboBoxTipoPublicacion.Text.Equals("Subasta"))
            {
               this.numericUpDownStockInicial.Value=1;
               this.numericUpDownStockInicial.Visible=false;
               this.labelstock.Visible=false;
               this.labelprecio.Text="Precio Inicial";
            }
            else
            {
               this.numericUpDownStockInicial.Visible=true;
               this.labelstock.Visible=true;
               this.labelprecio.Text="Precio";
               
            }
        }

        private void linkLabelSalir_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (this.modificacion == false)
            {

                if (this.salir == false)
                {

                    if (publico == false)
                    {

                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;

                        DialogResult confirmarGuardado = MessageBox.Show("Desea Guardar la publicacion no finalizada?", "Guardar Publicacion", buttons);

                        if (DialogResult.Yes == confirmarGuardado)

                            cManager.sqlPublicacion.pasarBorrador(cManager, this.comboBoxTipoPublicacion.Text, this.textBoxDescripcion.Text, this.numericUpDownStockInicial.Value.ToString(), this.textBoxPrecio.Text, cManager.sqlAbmVisibilidad.codigoSegunDescripcion(cManager, this.comboBoxVisibilidad.Text), this.comboBoxAceptaPregunta.Text, this.labelUserName.Text, this.checkedListBoxRubro.CheckedItems);
                    }
                    this.salir = true;

                }
            }
            this.Hide();
        }

        private void comboBoxVisibilidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDownStockInicial_ValueChanged(object sender, EventArgs e)
        {
            
            if (this.modificacion == true)
            {

                if(numericUpDownStockInicial.Value<Convert.ToInt16(this.stock_Inicial))
                {
                     
                    numericUpDownStockInicial.Value=Convert.ToInt16(this.stock_Inicial);

                }


            }
            if(this.modificacion==false)

            if (numericUpDownStockInicial.Value < 1)
            {

                numericUpDownStockInicial.Value = 1;

            }



        }

    }
}
