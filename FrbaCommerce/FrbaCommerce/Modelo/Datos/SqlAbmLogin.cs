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
            
            SqlCommand cmd = new SqlCommand("SELECT * FROM Usuario WHERE Usuario_Nombre='"+usuario+"'", cManager.conexion.conn);
            SqlDataReader dr = cmd.ExecuteReader();

            //dr["Usuario_Cliente_ID"].ToString()==null && dr["Usuario_Empresa_ID"].ToString().null
            
            if (dr.Read())
            {
                if (dr["Esta_Habilitado"].ToString().Equals("SI")) user.habilitado = true; else user.habilitado = false; 

                if (dr.IsDBNull(3) && dr.IsDBNull(4))
                {
                    user.habilitado = true;
                    user.tipoUsuario = "Administrador";
                    MessageBox.Show("ingresando como Administrador");
                    
                    //user.setWithTipoAdministrador
                }
                else
                {
                    if (dr.IsDBNull(3))
                    {
                        user.usuarioId=Convert.ToInt32(dr["Usuario_Empresa_ID"]);
                        user.tipoUsuario = "Empresa";
                    }
                    if (dr.IsDBNull(4))
                    {
                        user.usuarioId=Convert.ToInt32(dr["Usuario_Cliente_ID"]);
                        user.tipoUsuario = "Cliente";
                    }
                }
                user.RolAsignado.idRol = Convert.ToInt32(dr["Usuario_Rol_ID"]);
               
                user.setUsuario(dr["Usuario_Nombre"].ToString());

                if (dr.IsDBNull(dr.GetOrdinal("Usuario_Contraseña")) ) 
                {
                    dr.Close();
                    FormAgregarContraseña agregarContraseña = new FormAgregarContraseña(cManager,user);
                    agregarContraseña.ShowDialog();
                    agregarContraseña.Close();
                   
                }
                else user.setPassword(dr["Usuario_Contraseña"].ToString());                        
                
            }
            dr.Close();
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
            String Comando = "UPDATE Usuario SET Usuario_Contraseña='" + passToSave + "' WHERE Usuario_Nombre='" + usuario + "'";

            Cmd = new SqlCommand(Comando, cManager.conexion.conn);
            Cmd.ExecuteNonQuery();

            return passToSave;
            
        }
    }
}



/*
Rol empresa = new Rol();
empresa.setNombre("empresa");
user.RolAsignado = empresa;
*/