﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaCommerce.Modelo.Datos
{
    public class SqlCliente
    {
        
        internal void darAlta(SistemManager cManager,bool esCliente,string nombre, string ape, string tipo, string numero, string tel, string mail, string dir,string calleNum ,string nPiso,string depto ,string localidad, string codPostal, string fecNac)
        {
            try
            {
                string comandoInsert = "INSERT INTO Cliente(Cliente_Nombre,Cliente_Apellido,Cliente_Tipo_Doc,Cliente_DNI,Cliente_Mail,Cliente_Telefono,Cliente_Dom_Calle,Cliente_Numero_Calle,Cliente_Piso,Cliente_Departamento,Cliente_Localidad,Cliente_Codigo_Postal,Cliente_Fecha_De_Nacimiento) VALUES('" + nombre + "','" + ape + "','" + tipo + "'," + numero + ",'" + mail + "'," + tel + ",'" + dir + "',@callenum,@piso,'" + depto + "','" + localidad + "','" + codPostal + "','" + fecNac + "')";
                SqlCommand MyCmd = new SqlCommand(comandoInsert, cManager.conexion.conn);
                if (calleNum == "")
                    MyCmd.Parameters.AddWithValue("@callenum", DBNull.Value);
                else
                    MyCmd.Parameters.AddWithValue("@callenum", calleNum);

                if (nPiso == "")
                    MyCmd.Parameters.AddWithValue("@piso", DBNull.Value);
                else
                    MyCmd.Parameters.AddWithValue("@piso", nPiso);

               MyCmd.ExecuteNonQuery();
               
               cManager.sqlUsuario.darAlta(cManager,esCliente, numero, tipo);
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Number.ToString());
                cManager.conexion.errorDeSql(e);
            }
        }

        internal void Buscar(SistemManager cManager, string nombre, string apellido, string dni,string tipo, string mail, System.Windows.Forms.DataGridView dataGridView)
        {
            SqlDataAdapter adapComando = new SqlDataAdapter("SELECT Cliente_Tipo_Doc,Cliente_DNI,Cliente_Nombre,Cliente_Apellido,Cliente_Mail FROM Cliente WHERE Cliente_Nombre LIKE '%" + nombre + "%' AND Cliente_Apellido LIKE '%" + apellido + "%' AND Cliente_DNI LIKE '%" + dni + "%' AND Cliente_Mail LIKE '%" + mail + "%' AND Cliente_Tipo_Doc LIKE '%"+tipo+"%'", cManager.conexion.conn);
            cManager.conexion.adaptarTablaAlComando(adapComando, dataGridView, true,5);
        }

        internal void BuscarSinHabilitados(SistemManager cManager, string nombre, string apellido, string dni, string tipo, string mail, System.Windows.Forms.DataGridView dataGridView)
        {
            SqlDataAdapter adapComando = new SqlDataAdapter("SELECT Cliente_Tipo_Doc,Cliente_DNI,Cliente_Nombre,Cliente_Apellido,Cliente_Mail FROM Cliente JOIN Usuario ON Cliente.Cliente_ID=Usuario.Usuario_Cliente_ID WHERE Cliente_Nombre LIKE '%" + nombre + "%' AND Cliente_Apellido LIKE '%" + apellido + "%' AND Cliente_DNI LIKE '%" + dni + "%' AND Cliente_Mail LIKE '%" + mail + "%' AND Cliente_Tipo_Doc LIKE '%" + tipo + "%' AND Esta_Habilitado='SI'", cManager.conexion.conn);
            cManager.conexion.adaptarTablaAlComando(adapComando, dataGridView, true, 5);
        }

        internal void cargarDatosDeModificacion(SistemManager cManager, FrbaCommerce.Abm_Cliente.FormAbmClienteAlta formAltaCliente, string IDCliente,string tipo)
        {

            SqlCommand cmd;
            SqlDataReader dr;
            string insertDataMod = "SELECT * FROM Cliente WHERE Cliente_DNI="+ IDCliente +" AND Cliente_Tipo_Doc='" + tipo +"'";
            cmd = new SqlCommand(insertDataMod, cManager.conexion.conn);
            dr=cmd.ExecuteReader();
            dr.Read();
            formAltaCliente.textBoxApe.Text = dr["Cliente_Apellido"].ToString();
            formAltaCliente.textBoxNombre.Text = dr["Cliente_Nombre"].ToString();
            formAltaCliente.textBoxCodPos.Text = dr["Cliente_Codigo_Postal"].ToString();
            formAltaCliente.textBoxDepto.Text = dr["Cliente_Departamento"].ToString();
            formAltaCliente.textBoxDirec.Text = dr["Cliente_Dom_Calle"].ToString();
            formAltaCliente.textBoxDNI.Text = dr["Cliente_DNI"].ToString();
            formAltaCliente.textBoxFecNac.Text = dr["Cliente_Fecha_De_Nacimiento"].ToString();
            formAltaCliente.textBoxLocalidad.Text = dr["Cliente_Localidad"].ToString();
            formAltaCliente.textBoxMail.Text = dr["Cliente_Mail"].ToString();
            formAltaCliente.textBoxNroPiso.Text = dr["Cliente_Piso"].ToString();
            formAltaCliente.textBoxNumeroCalle.Text = dr["Cliente_Numero_Calle"].ToString();
            formAltaCliente.textBoxTel.Text = dr["Cliente_Telefono"].ToString();
            formAltaCliente.comboBoxTipo.Text = dr["Cliente_Tipo_Doc"].ToString();
            dr.Close();
            insertDataMod="SELECT Esta_Habilitado FROM Usuario WHERE Usuario_Cliente_ID=(SELECT Cliente_ID FROM Cliente WHERE Cliente_DNI=" + IDCliente + "AND Cliente_Tipo_Doc='" + tipo + "')";
            cmd = new SqlCommand(insertDataMod, cManager.conexion.conn);
            dr=cmd.ExecuteReader();
            dr.Read();
            if(dr["Esta_Habilitado"].ToString().Equals("NO"))
                formAltaCliente.checkBoxHabilitacion.Checked = false;
            else
                formAltaCliente.checkBoxHabilitacion.Checked = true;

            formAltaCliente.cliente.setTipoDni(formAltaCliente.comboBoxTipo.Text);
            formAltaCliente.cliente.setdni(formAltaCliente.textBoxDNI.Text);

            dr.Close();

            


            
            //pasar a numero y cargar cliente
           // throw new NotImplementedException();
        }

        internal void cargarDatosDeBaja(SistemManager cManager, string tipo,string dni)
        {

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult confirmarBaja = MessageBox.Show("Desea deshabilitar al cliente con "+tipo+ " igual a" + dni, "Baja de Rol", buttons);
            
            if (DialogResult.Yes == confirmarBaja)
            {
                //BAJA LOGICA ACA

                SqlCommand comando;
                string bajastring = "UPDATE Usuario SET Esta_Habilitado='NO' WHERE (SELECT Cliente_ID FROM Cliente WHERE Cliente_DNI='" + dni + "' AND Cliente_Tipo_Doc='" + tipo + "')=Usuario_Cliente_ID";
                comando = new SqlCommand(bajastring, cManager.conexion.conn);
                comando.ExecuteNonQuery();

                MessageBox.Show("el Cliente con "+tipo+" igual a "+ dni + " a sido deshabilitado");
            }
            if (DialogResult.No == confirmarBaja)
            {
                //No pasa nada, vuelve al menu principal
            }
        }

        internal void modificarCliente(SistemManager cManager, Sistema.Cliente cliente, string nombre, string apellido, string tipo_doc, string dni, string tel, string mail, string direc, string nroCalle, string piso, string depto, string localidad, string cod_pos,string fech_nac,bool habilitacion)
        {
            SqlCommand cmd;
            string comando;
            string clienteId;

            comando = "SELECT Cliente_ID FROM Cliente WHERE Cliente_DNI=" + cliente.getDNI() + "AND Cliente_Tipo_Doc='" + cliente.getTipoDni()+"'";
            cmd = new SqlCommand(comando, cManager.conexion.conn);
            SqlDataReader dr=cmd.ExecuteReader();
            dr.Read();
            clienteId = dr["Cliente_ID"].ToString();
            dr.Close();

            comando = "UPDATE Cliente SET Cliente_Nombre='" + nombre + "',Cliente_Apellido='" + apellido + "',Cliente_Mail='" + mail + "',Cliente_Telefono='" + tel + "',Cliente_Dom_Calle='" + direc + "',Cliente_Numero_Calle=@numeroCalle,Cliente_Piso=@piso,Cliente_Departamento='" + depto + "',Cliente_Localidad='" + localidad + "',Cliente_Codigo_Postal='" + cod_pos + "',Cliente_Fecha_De_Nacimiento='" + fech_nac + "',Cliente_Tipo_Doc='" + tipo_doc + "', Cliente_DNI=" + dni + "WHERE Cliente_ID=" +clienteId ;
            cmd = new SqlCommand(comando, cManager.conexion.conn);
            
            if (nroCalle == "")
                 cmd.Parameters.AddWithValue("@numeroCalle", DBNull.Value);
            else
                 cmd.Parameters.AddWithValue("@numeroCalle", nroCalle);
            if (piso == "")
                 cmd.Parameters.AddWithValue("@piso", DBNull.Value);
            else
                 cmd.Parameters.AddWithValue("@piso", piso);
            
            cmd.ExecuteNonQuery();

            if (habilitacion==true)
            {
                comando = "UPDATE Usuario SET Esta_Habilitado='SI' WHERE Usuario_Cliente_ID='" + clienteId + "'";
                cmd = new SqlCommand(comando, cManager.conexion.conn);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Cliente con: " + tipo_doc + " nro: " + dni + " fue modificado"); 
            
            
            
           
        }

        internal void ObtenerCliente(Sistema.Cliente cliente, Sistema.Usuario user, SistemManager cManager)
        {
            SqlCommand cmd = new SqlCommand("select * from Usuario JOIN Cliente ON Usuario.Usuario_Cliente_ID=Cliente.Cliente_ID WHERE Cliente_ID=" + user.RolAsignado.idRol.ToString(), cManager.conexion.conn);
           // SqlCommand cmd = new SqlCommand("SELECT * FROM Cliente WHERE Cliente_ID=" + user.RolAsignado.idRol.ToString(), cManager.conexion.conn);
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
                if (!dr.IsDBNull(dr.GetOrdinal("Cliente_Numero_Calle"))) cliente.numeroCalle = (Convert.ToInt32(dr["Cliente_Numero_Calle"]));
                if (!dr.IsDBNull(dr.GetOrdinal("Cliente_Piso"))) cliente.nroPiso = (Convert.ToInt32(dr["Cliente_Piso"]));
                cliente.depto = (Convert.ToChar(dr["Cliente_Departamento"]));
                cliente.localidad = (dr["Cliente_Localidad"].ToString());
                if (!dr.IsDBNull(dr.GetOrdinal("Cliente_Codigo_Postal"))) cliente.codigoPostal = (Convert.ToInt32((dr["Cliente_Codigo_Postal"])));
              //  cliente.ciudad = (dr["Cliente_Ciudad"].ToString());
                if (!dr.IsDBNull(dr.GetOrdinal("Cliente_DNI"))) cliente.numeroDoc = (Convert.ToInt32((dr["Cliente_DNI"])));
                cliente.fechaDeNacimiento = dr.GetDateTime(dr.GetOrdinal("Cliente_Fecha_De_Nacimiento"));
                //cliente.nombreDeContacto = (dr["Cliente_CUIT"].ToString());      
                if (dr["Esta_Habilitado"].ToString().Equals("SI")) cliente.habilitado = true; else cliente.habilitado = false;

            }

            dr.Close();
        }
    }
}