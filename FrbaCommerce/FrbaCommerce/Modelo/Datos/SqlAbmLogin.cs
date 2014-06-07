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
                if (dr.IsDBNull(3) && dr.IsDBNull(4))
                {
                    user.habilitado = true;
                    user.tipoUsuario = "Administrador";
                    MessageBox.Show("ingresando como Administrador");
                    
                    //user.setWithTipoAdministrador
                }
                else
                {
                    if (dr["Usuario_Cliente_ID"] == null)
                    {
                        user.usuarioId=Convert.ToInt32(dr["Usuario_Empresa_ID"]);
                        //cManager.sqlEmpresa.ObtenerEmpresa(user, cManager);
                        user.tipoUsuario = "Cliente";
                    }
                    if (dr["Usuario_Empresa_ID"] == null)
                    {
                        user.usuarioId=Convert.ToInt32(dr["Usuario_Cliente_ID"]);
                        //cManager.sqlCliente.ObtenerCliente(user, cManager);
                        user.tipoUsuario = "Empresa";
                    }
                }
                user.RolAsignado.idRol = Convert.ToInt32(dr["Usuario_Rol_ID"]);
               
                user.setUsuario(dr["Usuario_Nombre"].ToString());

                if (dr["Usuario_Contraseña"] == null) 
                {

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

        internal void agregarContraseñaPorPrimerIngreso(SistemManager cManager,string contraseña ,string usuario)
        {
            SqlCommand Cmd;

            String Comando = "UPDATE Usuario SET Usuario_Contraseña='" + contraseña + "' WHERE Usuario_Nombre='" + usuario + "'";

            Cmd = new SqlCommand(Comando, cManager.conexion.conn);
            Cmd.ExecuteNonQuery();
            
        }
    }
}



/*
Rol empresa = new Rol();
empresa.setNombre("empresa");
user.RolAsignado = empresa;
*/