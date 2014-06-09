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
        

        internal void darAlta(SistemManager cManager,string nombre, string ape, string tipo, string numero, string tel, string mail, string dir,string calleNum ,string nPiso,string depto ,string localidad, string codPostal, string ciudad, string fecNac)
        {
            try
            {
                
                String ComandoInsert = @"INSERT INTO Cliente(Cliente_Nombre,Cliente_Apellido,Cliente_Tipo_Doc,Cliente_DNI,Cliente_Mail,Cliente_Telefono,Cliente_Dom_Calle,Cliente_Numero_Calle,Cliente_Piso,Cliente_Departamento,Cliente_Localidad,Cliente_Codigo_Postal,Cliente_Fecha_De_Nacimiento,Cliente_Esta_Habilitada) VALUES('" + nombre + "','" + ape + "','" + tipo + "'," + numero + ",'" + mail + "'," + tel + ",'" + dir + "',@callenum,@piso,'" + depto + "','" + localidad + "','" + codPostal + "','" + fecNac + "','SI')";
                SqlCommand MyCmd = new SqlCommand(ComandoInsert, cManager.conexion.conn);
                if (calleNum == "")
                    MyCmd.Parameters.AddWithValue("@callenum", DBNull.Value);
                else
                    MyCmd.Parameters.AddWithValue("@callenum", calleNum);

                if (nPiso == "")
                    MyCmd.Parameters.AddWithValue("@piso", DBNull.Value);
                else
                    MyCmd.Parameters.AddWithValue("@piso", nPiso);

  


             
             //     MyCmd.ExecuteScalar();
               MyCmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                cManager.conexion.errorDeSql(e);
            }
        }

        internal void Buscar(SistemManager cManager, string nombre, string apellido, string dni, string mail, System.Windows.Forms.DataGridView dataGridView)
        {
            SqlDataAdapter adapComando = new SqlDataAdapter("SELECT Cliente_DNI,Cliente_Nombre,Cliente_Apellido,Cliente_Mail FROM Cliente WHERE Cliente_Nombre LIKE '%" + nombre + "%' AND Cliente_Apellido LIKE '%" + apellido + "%' AND Cliente_DNI LIKE '%" + dni + "%' AND Cliente_Mail LIKE '%" + mail + "%'", cManager.conexion.conn);
            cManager.conexion.adaptarTablaAlComando(adapComando, dataGridView, true,4);
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

        internal void ObtenerCliente(Sistema.Cliente cliente, Sistema.Usuario user, SistemManager cManager)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Cliente WHERE Cliente_ID=" + user.RolAsignado.idRol.ToString(), cManager.conexion.conn);
            //  +";SELECT * FROM Rol WHERE Rol_ID=" + user.RolAsignado.idRol.ToString(), cManager.conexion.conn);

            SqlDataReader dr = cmd.ExecuteReader();

            cliente.usuarioId = user.usuarioId;
            cliente.RolAsignado = user.RolAsignado;
            cliente.tipoUsuario = user.tipoUsuario;
            cliente.setUsuario(user.getUsuario());
            cliente.setPassword(user.getPassword());

            //user.tipoUsuario.
            //  adapComando.SelectCommand.ExecuteScalar();
            if (dr.Read())
            {
                cliente.apellido = (dr["Cliente_Apellido"].ToString());
                cliente.nombre = (dr["Cliente_Nombre"].ToString());
                cliente.TipoDeDocumento = (dr["Cliente_Tipo_Doc"].ToString());
                cliente.Mail = (dr["Cliente_Mail"].ToString());
                if (!dr.IsDBNull(dr.GetOrdinal("Cliente_Telefono"))) cliente.Telefono = (Convert.ToInt64(dr["Cliente_Telefono"]));
                cliente.Direccion = (dr["Cliente_Dom_Calle"].ToString());
                if (!dr.IsDBNull(dr.GetOrdinal("Cliente_Numero_Calle"))) cliente.numeroCalle = (Convert.ToInt32(dr["Cliente_Nro_Calle"]));
                if (!dr.IsDBNull(dr.GetOrdinal("Cliente_Piso"))) cliente.nroPiso = (Convert.ToInt32(dr["Cliente_Piso"]));
                cliente.depto = (Convert.ToChar(dr["Cliente_Departamento"]));
                cliente.localidad = (dr["Cliente_Localidad"].ToString());
                if (!dr.IsDBNull(dr.GetOrdinal("Cliente_Codigo_Postal"))) cliente.codigoPostal = (Convert.ToInt32((dr["Cliente_Codigo_Postal"])));
              //  cliente.ciudad = (dr["Cliente_Ciudad"].ToString());
                if (!dr.IsDBNull(dr.GetOrdinal("Cliente_DNI"))) cliente.numeroDoc = (Convert.ToInt32((dr["Cliente_DNI"])));
                cliente.fechaDeNacimiento = dr.GetDateTime(dr.GetOrdinal("Cliente_Fecha_De_Nacimiento"));
                //cliente.nombreDeContacto = (dr["Cliente_CUIT"].ToString());      
                if (dr["Cliente_Esta_Habilitada"].ToString().Equals("SI")) cliente.habilitado = true; else cliente.habilitado = false;

            }

            dr.Close();
        }
    }
}
