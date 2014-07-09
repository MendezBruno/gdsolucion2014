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
        string usuario;

        public FormPrincipal(SistemManager cManager, Usuario usuario)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.user =usuario;
            cargaManuSegunRol(user.RolAsignado,usuario.puedeComprar);

        }

        public FormPrincipal(SistemManager cManager, Cliente cliente)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.cliente = cliente;
            cargaManuSegunRol(cliente.RolAsignado,cliente.puedeComprar);
            this.usuario = cliente.getUsuario();
            
        }

        public FormPrincipal(SistemManager cManager, Empresa empresa)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.empresa = empresa;
            cargaManuSegunRol(empresa.RolAsignado, empresa.puedeComprar);
            this.usuario = empresa.getUsuario();

        }

        public FormPrincipal(SistemManager cManager, Administrador administrador)
        {
            InitializeComponent();
            this.cManager = cManager;
            this.administrador = administrador;
            cargaManuSegunRol(administrador.RolAsignado, administrador.puedeComprar);
            this.usuario = administrador.getUsuario();

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





        private void cargaManuSegunRol(Rol rol,bool puede_Comprar)
        {
            if (!rol.getListaFuncionalidades().Contains("Comprar")) { this.BotonComprar.Visible = false; this.buttonCalificar.Visible = false; }
            if (!rol.getListaFuncionalidades().Contains("Vender")) {this.buttonPublicaciones.Visible = false; this.buttonFacturar.Visible=false;}
            
            if (existen_Modificaciones(rol)==true)
                this.buttonModificaciones.Visible = true;
            else
                this.buttonModificaciones.Visible = false;

            if (puede_Comprar == true)
                this.BotonComprar.Visible = true;
            else
                this.BotonComprar.Visible = false;




            //if (!user.tipoUsuario.Equals("Administrador")) { this.buttonModificaciones.Visible = false; this.buttonCrearUsuario.Visible = false; }
         //   if (administrador == null) { this.buttonModificaciones.Visible = false;}


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

        private bool existen_Modificaciones(Rol rol)
        {

            if (rol.getListaFuncionalidades().Contains("Crear_Cliente")) { return true; }
            else
            if (rol.getListaFuncionalidades().Contains("Modificar_Cliente")) { return true; }
            else
            if (rol.getListaFuncionalidades().Contains("Eliminar__Cliente")) { return true; }
            else
            if(rol.getListaFuncionalidades().Contains("Crear_Rubro")) { return true; }
            else
            if(rol.getListaFuncionalidades().Contains("Modificar_Rubro")) { return true; }
            else
            if(rol.getListaFuncionalidades().Contains("Eliminar_Rubro")) { return true; }
            else
            if(rol.getListaFuncionalidades().Contains("Crear_Empresa")) { return true; }
            else
            if(rol.getListaFuncionalidades().Contains("Modificar_Empresa")) { return true; }
            else
            if(rol.getListaFuncionalidades().Contains("Eliminar_Empresa")) { return true; }
            else
            if(rol.getListaFuncionalidades().Contains("Crear_Visibilidad")){ return true; }
            else
            if(rol.getListaFuncionalidades().Contains("Modificar_Visibilidad")){ return true; }
            else
            if(rol.getListaFuncionalidades().Contains("Eliminar_Visibilidad")){ return true; }
            else
            if(rol.getListaFuncionalidades().Contains("Crear_Rol")){ return true; }
            else
            if(rol.getListaFuncionalidades().Contains("Modificar_Rol")){ return true; }
            else
            if (rol.getListaFuncionalidades().Contains("Eliminar_Rol")) { return true; }
            else return false;
            


        }

        private void buttonModificaciones_Click(object sender, EventArgs e)
        {
            this.Hide();

            if (empresa != null)
            {
                FormModificaciones formModificaciones = new FormModificaciones(cManager, empresa);
                formModificaciones.ShowDialog();
                this.Show();

            }
            if (cliente != null)
            {
                FormModificaciones formModificaciones = new FormModificaciones(cManager, cliente);
                formModificaciones.ShowDialog();
                this.Show();

            }

            if (cliente == null && empresa == null)
            {
                FormModificaciones formModificaciones = new FormModificaciones(cManager, administrador);
                formModificaciones.ShowDialog();
                this.Show();
            }

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

            FormComprarOfertar formComprarOferta = new FormComprarOfertar(cManager,this.usuario);

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

                formFacturar = new FormFacturarPublicaciones(cManager, cliente.getUsuario());

                formFacturar.ShowDialog();

            }
            else
            if (cliente == null && empresa==null)
            {

                formFacturar = new FormFacturarPublicaciones(cManager, administrador.getUsuario());

                formFacturar.ShowDialog();

            }


        }

        private void buttoncambiarContraseña_Click(object sender, EventArgs e)
        {
            FormAgregarContraseña formAgregarContraseña;
            this.Hide();
            if (empresa != null)
            {
               formAgregarContraseña = new FormAgregarContraseña(cManager, empresa);
               formAgregarContraseña.ShowDialog();
            }
            else
                if (cliente != null)
                {

                    formAgregarContraseña = new FormAgregarContraseña(cManager, cliente);
                    formAgregarContraseña.ShowDialog();

                }
                else
                    if (cliente == null && empresa == null)
                    {

                       formAgregarContraseña = new FormAgregarContraseña(cManager, administrador);
                       formAgregarContraseña.ShowDialog();

                    }
            
            
            
            this.Show();
        }

        

        

        
    }
}
