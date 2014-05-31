using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Sistema;

namespace FrbaCommerce.Modelo.Datos
{
    public class SqlAbmLogin
    {

        public Usuario ObtenerUsuario(string usuario, SistemManager cManager)
        {
            Usuario user = new Usuario();
            SqlCommand cmd = new SqlCommand("SELECT Usuario_Nombre FROM Usuario WHERE ", cManager.conexion.conn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
              
                
                if (dr["Usuario_Cliente_ID"]==null)
                {
                //user.setIdUsuario(Convert.ToInt32(dr["Usuario_Empresa_ID"]));
                cManager.sqlEmpresa.ObtenerEmpresa(user,cManager);
                }
                else
                {
                //user.setIdUsuario(Convert.ToInt32(dr["Usuario_Cliente_ID"]));
                cManager.sqlCliente.ObtenerCliente(user, cManager);
                }
                cManager.sqlRol.ObtenerRol(user, cManager);
                user.setUsuario(dr["Usuario_Nombre"].ToString());
                user.setPassword(dr["Usuario_Contraseña"].ToString());                        
                
            }

            return user;
        }

        /*
        internal void cargarUsuario(Usuario user, SistemManager cManager)
        {
            
            SqlCommand cmd = new SqlCommand("SELECT * FROM ", cManager.conexion.conn);
            SqlDataReader dr = cmd.ExecuteReader();

            
        }
         * */
    }
}



/*
Rol empresa = new Rol();
empresa.setNombre("empresa");
user.RolAsignado = empresa;
*/