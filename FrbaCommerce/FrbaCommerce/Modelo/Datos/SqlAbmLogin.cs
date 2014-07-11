using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Sistema;
using System.Windows.Forms;

namespace FrbaCommerce.Modelo.Datos
{
    public class SqlAbmLogin
    {

        public Usuario ObtenerUsuario(string usuario, SistemManager cManager,Usuario user)
        {

            SqlCommand cmd = new SqlCommand("SELECT * FROM NO_MORE_SQL.Usuario LEFT JOIN NO_MORE_SQL.Empresa ON NO_MORE_SQL.Usuario.Usuario_Nombre=NO_MORE_SQL.Empresa.Empresa_Usuario_Nombre LEFT JOIN NO_MORE_SQL.Cliente ON NO_MORE_SQL.Usuario.Usuario_Nombre=NO_MORE_SQL.Cliente.Cliente_Usuario_Nombre  WHERE Usuario_Nombre='"+usuario+"'", cManager.conexion.conn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {   
                
                if (dr["Esta_Habilitado"].ToString().Equals("SI")) 
                    
                user.habilitado = true; 
                
                else user.habilitado = false;

                if (!dr["Usuario_Rol_ID"].ToString().Equals(""))

                    user.RolAsignado.idRol = Convert.ToInt32(dr["Usuario_Rol_ID"]);

                else

                    user.RolAsignado.idRol = -1;

                user.setUsuario(dr["Usuario_Nombre"].ToString());

                   if (dr.IsDBNull(dr.GetOrdinal("Empresa_Usuario_Nombre")))
                    {
                        //  user.usuarioId = Convert.ToInt32(dr["Usuario_Empresa_ID"]);
                        user.tipoUsuario = "Cliente";
                    }
                    if (dr.IsDBNull(dr.GetOrdinal("Cliente_Usuario_Nombre")))
                    {
                        // user.usuarioId = Convert.ToInt32(dr["Usuario_Cliente_ID"]);
                        user.tipoUsuario = "Empresa";
                    }
                    if ((dr.IsDBNull(dr.GetOrdinal("Empresa_Usuario_Nombre")) && dr.IsDBNull(dr.GetOrdinal("Cliente_Usuario_Nombre"))))
                    {
                        user.tipoUsuario = "Administrador";

                    }

                    if (dr["Puede_Comprar"].ToString() == "SI")
                    {

                        user.puedeComprar = true;

                    }

                    else
                    {


                        user.puedeComprar = false;
                    
                    
                    }


                    if (dr.IsDBNull(dr.GetOrdinal("Usuario_Contraseña")))
                    {
                        dr.Close();
                        FormAgregarContraseña agregarContraseña = new FormAgregarContraseña(cManager, user);
                        agregarContraseña.ShowDialog();
                        agregarContraseña.Close();
                        user.cambioContrasena(true);

                    }
                    else

                        user.setPassword(dr["Usuario_Contraseña"].ToString());
                        dr.Close();

                 
                

            }
            else
            {
                dr.Close();
                user = null;
                return user;
            }
     
            cManager.sqlRol.ObtenerRol(user, cManager);
            return user;
        }
               

        /*
        internal void cargarUsuario(Usuario user, SistemManager cManager)
        {
            
            SqlCommand cmd = new SqlCommand("SELECT * FROM ", cManager.conexion.conn);
            SqlDataReader dr = cmd.ExecuteReader();

            
        }
         * */

        internal string agregarContraseñaPorPrimerIngreso(SistemManager cManager,string contraseña ,string usuario)
        {
            SqlCommand Cmd;

            byte[] pwordData = Encoding.Default.GetBytes(contraseña);

            byte[] hash = cManager.hashAlg.ComputeHash(pwordData);

            string passToSave = BitConverter.ToString(hash);
            String Comando = "UPDATE NO_MORE_SQL.Usuario SET Usuario_Contraseña='" + passToSave + "' WHERE Usuario_Nombre='" + usuario + "'";

            Cmd = new SqlCommand(Comando, cManager.conexion.conn);
            Cmd.ExecuteNonQuery();

            return passToSave;
            
        }

        internal void deshabilitarUsuario(Usuario user,SistemManager cManager)
        {
            SqlCommand Cmd;
            
            String Comando = "UPDATE NO_MORE_SQL.Usuario SET Esta_Habilitado='NO' WHERE Usuario_Nombre='" +user.getUsuario()+ "'";

            Cmd = new SqlCommand(Comando, cManager.conexion.conn);
            Cmd.ExecuteNonQuery();


        }

        internal void ingresarUsuarioAdministrador(SistemManager cManager,string administrador, string contraseña)
        {
            
            
            SqlCommand cmd;

            SqlDataReader dr;
            
            string buscarAdmin = "SELECT * FROM NO_MORE_SQL.Usuario WHERE Usuario_Nombre='admin'";

            cmd = new SqlCommand(buscarAdmin, cManager.conexion.conn);

            dr = cmd.ExecuteReader();

            if (!dr.Read())
            {

                dr.Close();
                
                string insertarAdmin = "INSERT INTO NO_MORE_SQL.Usuario(Usuario_Nombre,Usuario_Rol_ID,Esta_Habilitado,Puede_Comprar) VALUES ('admin',(SELECT Rol_ID FROM NO_MORE_SQL.Rol WHERE Rol_Nombre='Administrador General'),'SI','SI')";

                cmd = new SqlCommand(insertarAdmin, cManager.conexion.conn);

                cmd.ExecuteNonQuery();

                agregarContraseñaPorPrimerIngreso(cManager , contraseña, administrador);
            }
            else
            dr.Close();
        }

    }
}


