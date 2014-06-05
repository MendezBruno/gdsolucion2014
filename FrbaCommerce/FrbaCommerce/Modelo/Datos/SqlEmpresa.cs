using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace FrbaCommerce.Modelo.Datos
{
    public class SqlEmpresa
    {
        internal void ObtenerEmpresa(Sistema.Usuario user, SistemManager cManager)
        {
            throw new NotImplementedException();
        }

        internal void darAlta(SistemManager cManager, string cuit, string razon_social, string mail, string telefono, string dom_calle, string nro_calle, string depto, string localidad, string codPostal, string ciudad, string fecCreacion, string piso)
        {

            SqlCommand Cmd;

            String Comando = "INSERT INTO Empresa(Empresa_Razon_Social,Empresa_Mail,Empresa_Telefono,Empresa_Dom_Calle,Empresa_Nro_Calle,Empresa_Piso,Empresa_Depto,Empresa_Localidad,Empresa_Codigo_Postal,Empresa_Ciudad,Empresa_CUIT,Empresa_Fecha_Creacion,Empresa_Esta_Habilitada) VALUES ('" + razon_social + "','" + mail + "'," + telefono + ",'" + dom_calle + "','" + nro_calle + ",'" + piso + ",'" + depto + "','" + localidad + "','" + codPostal + "','" + ciudad + "','" + cuit + "','" + fecCreacion + "','SI'";

            Cmd = new SqlCommand(Comando, cManager.conexion.conn);

        }

        internal void BuscarEmpresa(SistemManager cManager, String razon_social, String mail, String cuit, DataGridView dataGridView)
        {

            SqlDataAdapter adapComando = new SqlDataAdapter("SELECT Empresa_Razon_Social,Empresa_CUIT,Empresa_Mail FROM Empresa WHERE Empresa_Razon_Social LIKE '%" + razon_social + "%' AND Empresa_Mail='" + cuit + "',Empresa_Cuit='%" + cuit + "%'", cManager.conexion.conn);
            cManager.conexion.adaptarTablaAlComando(adapComando, dataGridView, true,3);
            
            
        }

        private void adaptarTablaAlComando(SqlDataAdapter adapComando, DataGridView dataGridViewFR, bool filaSeleccion)
        {
            DataTable tabla = new DataTable();
            adapComando.Fill(tabla);
            dataGridViewFR.DataSource = tabla;
            adapComando.Update(tabla);
            dataGridViewFR.Columns[0].Visible = true;
            dataGridViewFR.Columns[0].DisplayIndex = 3;
            adapComando.Update(tabla);
        }
        /*
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
        */
    }
}
