using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Modelo;

namespace FrbaCommerce.Generar_Publicacion
{
    public partial class Continuar_Publicacion : Form
    {
        SistemManager cManager;
        
        public Continuar_Publicacion(SistemManager cManager,string usuario,string boton)
        {
            InitializeComponent();

            this.cManager=cManager;

            switch (boton)
            {
                case "Continuar":
                    buscarBorradas(usuario);
                    break;

                case "Modificar":
                    buscarModificar(usuario);
                    break;

                case "Pausar":
                    buscarPausada(usuario);
                    break;

                case "Finalizar":
                    buscarFinalizada(usuario);
                    break;


            }

        }

        public void buscarBorradas(string usuario)
        {

            cManager.sqlPublicacion.buscarBorradas(cManager,usuario, dataGridViewContinuar);
            dataGridViewContinuar.Update();
   
        }

        public void buscarModificar(string usuario)
        {

            cManager.sqlPublicacion.buscarModificar(cManager,usuario, dataGridViewContinuar);
            dataGridViewContinuar.Update();

        }

        public void buscarPausada(string usuario)
        {
            cManager.sqlPublicacion.buscarPausada(cManager,usuario, dataGridViewContinuar);
            dataGridViewContinuar.Update();

        }

        public void buscarFinalizada(string usuario)
        {
            cManager.sqlPublicacion.buscarFinalizada(cManager,usuario, dataGridViewContinuar);
            dataGridViewContinuar.Update();

        }


    }
}
