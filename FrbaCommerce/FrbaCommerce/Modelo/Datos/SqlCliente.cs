using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaCommerce.Modelo.Datos
{
    public class SqlCliente
    {
        internal void ObtenerCliente(Sistema.Usuario user, SistemManager cManager)
        {
            throw new NotImplementedException();
        }

        internal void darAlta(SistemManager cManager,string nombre, string ape, string tipo, string numero, string tel, string mail, string dir, string nPiso,string depto ,string localidad, string codPostal, string ciudad, string fecNac)
        {
            try
            {
             //   String ComandoInsert = @"INSERT INTO Rol(Rol_Nombre) VALUES('" + nombreRol + "')";
             //   SqlCommand MyCmd = new SqlCommand(ComandoInsert, cManager.conexion.conn);
                //  MyCmd.ExecuteScalar();
          //      MyCmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

            }
        }

        internal void Buscar(SistemManager cManager, string nombre, string apellido, string dni, string mail, System.Windows.Forms.DataGridView dataGridView)
        {
            throw new NotImplementedException();
        }

        internal void cargarDatosDeModificacion(SistemManager cManager, FrbaCommerce.Abm_Cliente.FormAbmClienteAlta formAltaCliente, string IDCliente)
        {
            //pasar a numero y cargar cliente
            throw new NotImplementedException();
        }

        internal void cargarDatosDeBaja(SistemManager cManager, string p)
        {
            DialogResult confirmarBaja = MessageBox.Show("Desea dar de baja" + p);
            if (DialogResult.Yes == confirmarBaja)
            {
                //BAJA LOGICA ACA
                MessageBox.Show("el rol " + p + " a sido deshabilitado");
            }
            if (DialogResult.No == confirmarBaja)
            {
                //No pasa nada, vuelve al menu principal
            }
        }

        internal void modificarCliente(SistemManager cManager, Sistema.Cliente cliente, string p, string p_4, string p_5, string p_6, string p_7, string p_8, string p_9, string p_10, string p_11, string p_12, string p_13, string p_14, string p_15)
        {
            throw new NotImplementedException();
        }
    }
}
