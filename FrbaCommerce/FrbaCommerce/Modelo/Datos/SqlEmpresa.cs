using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using Sistema;


namespace FrbaCommerce.Modelo.Datos
{
    public class SqlEmpresa
    {
        internal void ObtenerEmpresa(Sistema.Usuario user,Empresa empresa, SistemManager cManager)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Empresa WHERE Empresa_ID=" + user.RolAsignado.idRol.ToString(), cManager.conexion.conn); 
                                          //  +";SELECT * FROM Rol WHERE Rol_ID=" + user.RolAsignado.idRol.ToString(), cManager.conexion.conn);

            SqlDataReader dr = cmd.ExecuteReader();
            
            empresa.usuarioId = user.usuarioId;
            empresa.RolAsignado = user.RolAsignado;
            empresa.tipoUsuario = user.tipoUsuario;
            empresa.setUsuario(user.getUsuario());
            empresa.setPassword(user.getPassword());
            
            //user.tipoUsuario.
            //  adapComando.SelectCommand.ExecuteScalar();
            if (dr.Read())
            {
              empresa.Razonsocial =(dr["Empresa_Razon_Social"].ToString());
              empresa.Mail = (dr["Empresa_Mail"].ToString());
              if(!dr.IsDBNull(dr.GetOrdinal("Empresa_Telefono")))empresa.Telefono = (Convert.ToInt64(dr["Empresa_Telefono"]));
              empresa.Direccion = (dr["Empresa_Dom_Calle"].ToString());
              if (!dr.IsDBNull(dr.GetOrdinal("Empresa_Nro_Calle"))) empresa.numeroCalle = (Convert.ToInt32(dr["Empresa_Nro_Calle"]));
              if (!dr.IsDBNull(dr.GetOrdinal("Empresa_Piso"))) empresa.NroPiso = (Convert.ToInt32(dr["Empresa_Piso"]));
              empresa.Depto = (Convert.ToChar(dr["Empresa_Depto"]));
              empresa.localidad = (dr["Empresa_Localidad"].ToString());
              if (!dr.IsDBNull(dr.GetOrdinal("Empresa_Codigo_Postal"))) empresa.codigoPostal = (Convert.ToInt32((dr["Empresa_Codigo_Postal"])));
              empresa.ciudad = (dr["Empresa_Ciudad"].ToString());
              empresa.CUIT = (dr["Empresa_CUIT"].ToString());
              empresa.fechaDeCreacion = dr.GetDateTime(dr.GetOrdinal("Empresa_Fecha_Creacion"));
              //empresa.nombreDeContacto = (dr["Empresa_CUIT"].ToString());      
              if (dr["Empresa_Esta_Habilitada"].ToString().Equals("SI")) empresa.habilitado = true; else empresa.habilitado = false; 

            }
            
            dr.Close();
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
