using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Modelo;
using FrbaCommerce.Login;
using FrbaCommerce.Registro_de_Usuario;
using FrbaCommerce.ABM_Rol;
using Sistema;
using FrbaCommerce.Abm_Cliente;
using FrbaCommerce.Generar_Publicacion;
using FrbaCommerce.Historial_Cliente;
using FrbaCommerce.Listado_Estadistico;
using FrbaCommerce.Calificar_Vendedor;
using FrbaCommerce.Comprar_Ofertar;
using FrbaCommerce.Facturar_Publicaciones;

namespace FrbaCommerce
{
    public partial class FormPrincipal : Form
    {
        SistemManager cManager;
        Usuario user;
        Cliente cliente;
        Empresa empresa;
        Administrador administrador;

        public FormPrincipal(SistemManager cManager, Usuario usuario)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.user =usuario;
            cargaManuSegunRol(user.RolAsignado);

        }

        public FormPrincipal(SistemManager cManager, Cliente cliente)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.cliente = cliente;
            cargaManuSegunRol(cliente.RolAsignado);
            
        }

        public FormPrincipal(SistemManager cManager, Empresa empresa)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.empresa = empresa;
            cargaManuSegunRol(empresa.RolAsignado);

        }

        public FormPrincipal(SistemManager cManager, Administrador administrador)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.administrador = administrador;
            cargaManuSegunRol(administrador.RolAsignado);

        }
        /*
        public FormPrincipal(SistemManager cManager, Usuario user)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.user = user;
            cargaManuSegunRol(user.RolAsignado);
        }
        */





        private void cargaManuSegunRol(Rol rol)
        {
            if (!rol.getListaFuncionalidades().Contains("Comprar")) { this.BotonComprar.Visible = false; this.buttonCalificar.Visible = false; }
            if (!rol.getListaFuncionalidades().Contains("Vender")) {this.buttonPublicaciones.Visible = false; this.buttonFacturar.Visible=false;}

            if (!rol.getListaFuncionalidades().Contains("Vender")) {this.buttonPublicaciones.Visible = false; this.buttonFacturar.Visible=false;}


            //if (!user.tipoUsuario.Equals("Administrador")) { this.buttonModificaciones.Visible = false; this.buttonCrearUsuario.Visible = false; }
            if (administrador == null) { this.buttonModificaciones.Visible = false;}
        }
           

        /*
         * ESTO DESAPARECE ME PARECE JUEZ
         * 
        private void buttonLoggin_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLoggin formLogin = new FormLoggin(cManager);
            formLogin.ShowDialog();
            this.Show();
            //aca va la logica si pasa o no pasa
        }
        */
        private void buttonCrearUsuario_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormAbmClienteAlta formClienteAlta = new FormAbmClienteAlta(cManager, false,false);
            formClienteAlta.ShowDialog();
            this.Show();

        }

        private void buttonModificaciones_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormModificaciones formModificaciones = new FormModificaciones(cManager, administrador);
            formModificaciones.ShowDialog();
            this.Show();
        }

        private void buttonPublicaciones_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormMenuPublicacion formPublicacion;
          //  FormGenerarPublicacion formPublicacion;
            if (cliente != null)
            {
                formPublicacion = new FormMenuPublicacion(cManager, cliente);
                formPublicacion.ShowDialog();
            }
            if (empresa != null)
            {
                formPublicacion = new FormMenuPublicacion(cManager, empresa);
                formPublicacion.ShowDialog();
            }
            if (cliente == null && empresa == null)
            {
                formPublicacion = new FormMenuPublicacion(cManager, administrador);
                formPublicacion.ShowDialog();

            }
            this.Show();
        }

        private void buttonHistorial_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            FormHistorialCliente formHistoria;
            if (cliente != null)
            {
                formHistoria = new FormHistorialCliente(cManager, cliente.getUsuario());
                formHistoria.ShowDialog();
                this.Show();
            }
            else
                if (empresa != null)
                {
                    formHistoria = new FormHistorialCliente(cManager, empresa.getUsuario());
                    formHistoria.ShowDialog();
                    this.Show();

                }

                else

                    if (cliente == null && empresa == null)
                    {

                       formHistoria = new FormHistorialCliente(cManager, administrador.getUsuario());
                       formHistoria.ShowDialog();
                       this.Show();


                    }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormListadoEstadistico formListado = new FormListadoEstadistico(cManager) ;
            formListado.ShowDialog();
            this.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void buttonCalificar_Click(object sender, EventArgs e)
        {
            this.Hide();
            BuscarCalificar formCalificar;
            //  FormGenerarPublicacion formPublicacion;
            if (cliente != null)                
                formCalificar = new BuscarCalificar(cManager, cliente.getUsuario());
            else 
            
            if(empresa != null)
                formCalificar = new BuscarCalificar(cManager, empresa.getUsuario());

            else 
                
                formCalificar = new BuscarCalificar(cManager, administrador.getUsuario());

            formCalificar.ShowDialog();
            this.Show();

        }

        private void BotonComprar_Click(object sender, EventArgs e)
        {

            this.Hide();

            FormComprarOfertar formComprarOferta = new FormComprarOfertar(cManager);

            formComprarOferta.ShowDialog();

            this.Show();

        }

        private void buttonFacturar_Click(object sender, EventArgs e)
        {
            this.Hide();

            FormFacturarPublicaciones formFacturar;

            if (empresa != null)
            {
                formFacturar = new FormFacturarPublicaciones(cManager, empresa.getUsuario());

                formFacturar.ShowDialog();
            }
            else
            if (cliente != null)
            {

                formFacturar = new FormFacturarPublicaciones(cManager, empresa.getUsuario());

                formFacturar.ShowDialog();

            }
            else
            if (cliente == null && empresa==null)
            {

                formFacturar = new FormFacturarPublicaciones(cManager, administrador.getUsuario());

                formFacturar.ShowDialog();

            }


        }

        

        

        
    }
}
