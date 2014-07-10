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
            SqlCommand cmd = new SqlCommand("SELECT * FROM NO_MORE_SQL.Empresa WHERE Empresa_Usuario_Nombre='" + user.getUsuario()+"'", cManager.conexion.conn); 
                                          //  +";SELECT * FROM Rol WHERE Rol_ID=" + user.RolAsignado.idRol.ToString(), cManager.conexion.conn);

            SqlDataReader dr = cmd.ExecuteReader();
            
            empresa.RolAsignado = user.RolAsignado;
            empresa.tipoUsuario = user.tipoUsuario;
            empresa.setUsuario(user.getUsuario());
            empresa.setPassword(user.getPassword());
            empresa.puedeComprar = user.puedeComprar;
            
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
             // if (dr["Empresa_Esta_Habilitada"].ToString().Equals("SI")) empresa.habilitado = true; else empresa.habilitado = false; 

            }
            
            dr.Close();
        }

        internal void darAlta(SistemManager cManager,bool esCliente, string cuit, string razon_social, string mail, string telefono, string dom_calle, string nro_calle, string depto, string localidad, string codPostal, string ciudad, string fecCreacion, string piso,string contacto)
        {
            try
            {

                if (cuit.Equals("") || razon_social.Equals(""))
                {

                    if (cuit.Equals(""))
                        MessageBox.Show("Cuit No Ingresado");
                    if (razon_social.Equals(""))
                        MessageBox.Show("Razon Social No ingresada");
                    return;
                }
                else
                {
                    cManager.sqlUsuario.darAltaEmpresa(cManager, cuit);

                    SqlCommand Cmd;

                    String Comando = "INSERT INTO NO_MORE_SQL.Empresa(Empresa_Usuario_Nombre,Empresa_Razon_Social,Empresa_Mail,Empresa_Telefono,Empresa_Dom_Calle,Empresa_Nro_Calle,Empresa_Piso,Empresa_Depto,Empresa_Localidad,Empresa_Codigo_Postal,Empresa_Ciudad,Empresa_CUIT,Empresa_Fecha_Creacion,Empresa_Nombre_Contacto) VALUES ('" + cuit + "','" + razon_social + "','" + mail + "', @telefono ,'" + dom_calle + "',@nrocalle ,@piso ,'" + depto + "','" + localidad + "','" + codPostal + "','" + ciudad + "','" + cuit + "','" + fecCreacion + "','" + contacto + "')";

                    Cmd = new SqlCommand(Comando, cManager.conexion.conn);

                    if (telefono == "")
                        Cmd.Parameters.AddWithValue("@telefono", DBNull.Value);
                    else
                        Cmd.Parameters.AddWithValue("@telefono", telefono);

                    if (piso == "")
                        Cmd.Parameters.AddWithValue("@piso", DBNull.Value);
                    else
                        Cmd.Parameters.AddWithValue("@piso", piso);

                    if (nro_calle == "")
                        Cmd.Parameters.AddWithValue("@nrocalle", DBNull.Value);
                    else
                        Cmd.Parameters.AddWithValue("@nrocalle", nro_calle);

                    Cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException e)
            {

                cManager.sqlUsuario.eliminar(cManager, esCliente, cuit);

                if (e.Number.ToString().Equals("8114"))
                {
                    MessageBox.Show("Nro de calle, Nro de piso o Telefono Mal ingresados");

                }
                if (e.Number.ToString().Equals("207"))
                {
                    MessageBox.Show("Razon Social o Cuit mal ingresados");

                }
                if (e.Number.ToString().Equals("2627"))
                {
                    MessageBox.Show("Razon Social o Cuit ya ingresados");

                }


            }

            MessageBox.Show("El nombre de usuario para ingresar al sistema es:" + cuit + ".\nIngresar al sistema sin password y le pedira que cambie la contraseña");

        }

        internal void darAlta(SistemManager cManager, bool esCliente, string cuit, string razon_social, string mail, string telefono, string dom_calle, string nro_calle, string depto, string localidad, string codPostal, string ciudad, string fecCreacion, string piso, string contacto,string user,string pass)
        {

            bool dioAlta;
            
            try
            {

                if (cuit.Equals("") || razon_social.Equals(""))
                {

                    if (cuit.Equals(""))
                        MessageBox.Show("Cuit No Ingresado");
                    if (razon_social.Equals(""))
                        MessageBox.Show("Razon Social No ingresada");
                }
                else
                {
                    dioAlta=cManager.sqlUsuario.darAltaUsuario(cManager, esCliente, user, pass);

                    if (dioAlta == true)
                    {
                        SqlCommand Cmd;

                        String Comando = "INSERT INTO NO_MORE_SQL.Empresa(Empresa_Usuario_Nombre,Empresa_Razon_Social,Empresa_Mail,Empresa_Telefono,Empresa_Dom_Calle,Empresa_Nro_Calle,Empresa_Piso,Empresa_Depto,Empresa_Localidad,Empresa_Codigo_Postal,Empresa_Ciudad,Empresa_CUIT,Empresa_Fecha_Creacion,Empresa_Nombre_Contacto) VALUES ('" + user + "','" + razon_social + "','" + mail + "', @telefono ,'" + dom_calle + "',@nrocalle ,@piso ,'" + depto + "','" + localidad + "','" + codPostal + "','" + ciudad + "','" + cuit + "','" + fecCreacion + "','" + contacto + "')";

                        Cmd = new SqlCommand(Comando, cManager.conexion.conn);

                        if (telefono == "")
                            Cmd.Parameters.AddWithValue("@telefono", DBNull.Value);
                        else
                            Cmd.Parameters.AddWithValue("@telefono", telefono);

                        if (piso == "")
                            Cmd.Parameters.AddWithValue("@piso", DBNull.Value);
                        else
                            Cmd.Parameters.AddWithValue("@piso", piso);

                        if (nro_calle == "")
                            Cmd.Parameters.AddWithValue("@nrocalle", DBNull.Value);
                        else
                            Cmd.Parameters.AddWithValue("@nrocalle", nro_calle);

                        Cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException e)
            {

                cManager.sqlUsuario.eliminar(cManager, esCliente, user);

                if (e.Number.ToString().Equals("8114"))
                {
                    MessageBox.Show("Nro de calle, Nro de piso o Telefono Mal ingresados");

                }
                if (e.Number.ToString().Equals("207"))
                {
                    MessageBox.Show("Razon Social o Cuit mal ingresados");

                }
                if (e.Number.ToString().Equals("2627"))
                {
                    MessageBox.Show("Razon Social o Cuit ya ingresados");

                }


            }

        }

        internal void BuscarEmpresa(SistemManager cManager, String razon_social, String mail, String cuit, DataGridView dataGridView)
        {

            SqlDataAdapter adapComando = new SqlDataAdapter("SELECT Empresa_Razon_Social,Empresa_CUIT,Empresa_Mail FROM NO_MORE_SQL.Empresa WHERE Empresa_Razon_Social LIKE '%" + razon_social + "%' AND Empresa_Mail LIKE '%" + mail + "%' AND Empresa_Cuit ='" + cuit + "'", cManager.conexion.conn);
            cManager.conexion.adaptarTablaAlComando(adapComando, dataGridView, true,3);
            
            
        }
        internal void BuscarEmpresaHabilitada(SistemManager cManager, String razon_social, String mail, String cuit, DataGridView dataGridView)
        {

            SqlDataAdapter adapComando = new SqlDataAdapter("SELECT Empresa_Razon_Social,Empresa_CUIT,Empresa_Mail FROM NO_MORE_SQL.Empresa INNER JOIN NO_MORE_SQL.Usuario ON NO_MORE_SQL.Empresa.Empresa_Usuario_Nombre=NO_MORE_SQL.Usuario.Usuario_Nombre WHERE Empresa_Razon_Social LIKE '%" + razon_social + "%' AND Empresa_Mail LIKE'%" + mail + "%'AND Empresa_Cuit LIKE'%" + cuit + "%' AND Esta_Habilitado='SI'", cManager.conexion.conn);
            cManager.conexion.adaptarTablaAlComando(adapComando, dataGridView, true, 3);


        }

        internal void cargarDatosDeModificacion(SistemManager cManager, FrbaCommerce.Abm_Empresa.FormAbmEmpresaAlta fromAbmEmpresaAlta, string cuit)
        {

            SqlCommand cmd;
            SqlDataReader dr;
            string insertDataEmpresa = "SELECT * FROM NO_MORE_SQL.Empresa WHERE Empresa_CUIT = '" + cuit + "'";
            cmd = new SqlCommand(insertDataEmpresa, cManager.conexion.conn);
            dr = cmd.ExecuteReader();
            dr.Read();
            fromAbmEmpresaAlta.razon.Text = dr["Empresa_Razon_Social"].ToString();
            fromAbmEmpresaAlta.mail.Text = dr["Empresa_Mail"].ToString();
            fromAbmEmpresaAlta.telefono.Text = dr["Empresa_Telefono"].ToString();
            fromAbmEmpresaAlta.direccion.Text = dr["Empresa_Dom_Calle"].ToString();
            fromAbmEmpresaAlta.nroDireccion.Text = dr["Empresa_Nro_Calle"].ToString();
            fromAbmEmpresaAlta.piso.Text = dr["Empresa_Piso"].ToString();
            fromAbmEmpresaAlta.departamento.Text = dr["Empresa_Depto"].ToString();
            fromAbmEmpresaAlta.localidad.Text = dr["Empresa_Localidad"].ToString();
            fromAbmEmpresaAlta.codPostal.Text = dr["Empresa_Codigo_Postal"].ToString();
            fromAbmEmpresaAlta.ciudad.Text = dr["Empresa_Ciudad"].ToString();
            fromAbmEmpresaAlta.cuit.Text = dr["Empresa_CUIT"].ToString();
            fromAbmEmpresaAlta.fechaCreacion.Text = dr["Empresa_Fecha_Creacion"].ToString();
            fromAbmEmpresaAlta.usuario.Text = dr["Empresa_Nombre_Contacto"].ToString();
    //        fromAbmEmpresaAlta.empresa.idEmpresa = dr["Empresa_Usuario_Nombre"].ToString();
            dr.Close();
            insertDataEmpresa = "SELECT Esta_Habilitado FROM NO_MORE_SQL.Usuario INNER JOIN NO_MORE_SQL.Empresa ON NO_MORE_SQL.Usuario.Usuario_Nombre=NO_MORE_SQL.Empresa.Empresa_Usuario_Nombre WHERE Empresa_CUIT='"+cuit+"'";
            cmd = new SqlCommand(insertDataEmpresa, cManager.conexion.conn);
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr["Esta_Habilitado"].ToString().Equals("NO"))
                fromAbmEmpresaAlta.checkBoxHabilitacion.Checked = false;
            else
                fromAbmEmpresaAlta.checkBoxHabilitacion.Checked = true;
            dr.Close();

           
            
            //throw new NotImplementedException();


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

        internal void modificarEmpresa(SistemManager cManager, Sistema.Empresa empresa, string cuit, string razon, string mail, string telefono, string direccion, string nroDireccion, string depto, string localidad, string codPostal, string ciudad, string fechaCreacion, string piso, string usuario, bool habilitacion)
        {

            try
            {
                SqlCommand cmd;
                string comando;
                string empresaId;

                comando = "SELECT Empresa_Usuario_Nombre FROM NO_MORE_SQL.Empresa WHERE Empresa_Usuario_Nombre='" + empresa.getUsuario() + "'";
                cmd = new SqlCommand(comando, cManager.conexion.conn);
                SqlDataReader dr = cmd.ExecuteReader();
                 dr.Read();
                    empresaId = dr["Empresa_Usuario_Nombre"].ToString();
                    dr.Close();
                    comando = "UPDATE NO_MORE_SQL.Empresa SET Empresa_CUIT='" + cuit + "',Empresa_Razon_Social='" + razon + "',Empresa_Mail='" + mail + "',Empresa_Telefono=@telefono,Empresa_Dom_Calle='" + direccion + "',Empresa_Nro_Calle=@nrocalle,Empresa_Depto='" + depto + "',Empresa_Localidad='" + localidad + "',Empresa_Codigo_Postal='" + codPostal + "',Empresa_Ciudad='" + ciudad + "',Empresa_Fecha_Creacion='" + fechaCreacion + "',Empresa_Piso=@piso,Empresa_Nombre_Contacto='" + usuario + "' WHERE Empresa_Usuario_Nombre='" + empresaId + "'";
                    cmd = new SqlCommand(comando, cManager.conexion.conn);
                    if (telefono == "")
                        cmd.Parameters.AddWithValue("@telefono", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@telefono", telefono);

                    if (piso == "")
                        cmd.Parameters.AddWithValue("@piso", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@piso", piso);

                    if (nroDireccion == "")
                        cmd.Parameters.AddWithValue("@nrocalle", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@nrocalle", nroDireccion);

                    cmd.ExecuteNonQuery();

                    if (habilitacion == true)
                    {
                        comando = "UPDATE NO_MORE_SQL.Usuario SET Esta_Habilitado='SI' WHERE Usuario_Nombre='" + empresaId + "'";
                        cmd = new SqlCommand(comando, cManager.conexion.conn);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Cliente con CUIT: " + cuit + " fue modificado");

                    cmd.ExecuteNonQuery();
                
            }
            catch (SqlException e)
            {


                if (e.Number.ToString().Equals("8114"))
                {
                    MessageBox.Show("Nro de calle, Nro de piso o Telefono Mal ingresados");

                }
                if (e.Number.ToString().Equals("207"))
                {
                    MessageBox.Show("Razon Social o Cuit mal ingresados");

                }
                if (e.Number.ToString().Equals("2627"))
                {
                    MessageBox.Show("Razon Social o Cuit ya ingresados");

                }


            }



        }
        

        internal void cargarDatosDeBaja(SistemManager cManager, string p)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult confirmarBaja = MessageBox.Show("Desea deshabilitar a la Empresa con CUIT: " + p , "Baja de Empresa", buttons);

            if (DialogResult.Yes == confirmarBaja)
            {
                //BAJA LOGICA ACA

                SqlCommand comando;
                string bajastring = "UPDATE NO_MORE_SQL.Usuario SET Esta_Habilitado='NO' WHERE Usuario_Nombre=(SELECT Empresa_Usuario_Nombre FROM NO_MORE_SQL.Empresa WHERE Empresa_CUIT='"+p+"')";
                comando = new SqlCommand(bajastring, cManager.conexion.conn);
                comando.ExecuteNonQuery();

                MessageBox.Show("la Empresa con CUIT: " + p + " a sido deshabilitado");
            }
            if (DialogResult.No == confirmarBaja)
            {
                //No pasa nada, vuelve al menu principal
            }
            
            
        }
        /*
        internal void modificarCliente(SistemManager cManager, Sistema.Cliente cliente, string p, string p_4, string p_5, string p_6, string p_7, string p_8, string p_9, string p_10, string p_11, string p_12, string p_13, string p_14, string p_15)
        {
            throw new NotImplementedException();
        }
        */

        
    }
}
