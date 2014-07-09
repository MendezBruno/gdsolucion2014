using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FrbaCommerce.Modelo.Datos
{
     public class SqlUsuario
    {
        internal void darAlta(SistemManager cManager,bool esCliente,String dni,String tipo)
        {
           
           SqlCommand cmd;
           String ComandoInsert;

            
            if (esCliente == true)


                ComandoInsert = "INSERT INTO NO_MORE_SQL.Usuario(Usuario_Nombre,Esta_Habilitado,Usuario_Rol_ID) VALUES('" + dni + "','SI',(SELECT Rol_ID FROM NO_MORE_SQL.Rol WHERE Rol_Nombre='Cliente'))";

            
            else

                ComandoInsert = "INSERT INTO NO_MORE_SQL.Usuario(Usuario_Nombre,Esta_Habilitado,Usuario_Rol_ID) VALUES('" + dni + "','SI',(SELECT Rol_ID FROM NO_MORE_SQL.Rol WHERE Rol_Nombre='Cliente'))";


           
            
           cmd = new SqlCommand(ComandoInsert, cManager.conexion.conn);
           cmd.ExecuteNonQuery();
        
           
        }

        internal void eliminar(SistemManager cManager,bool esCliente,string usuario)
        {

            SqlCommand cmd;

            string comando = "DELETE FROM NO_MORE_SQL.Usuario WHERE Usuario_Nombre='"+usuario+"'";

            cmd = new SqlCommand(comando, cManager.conexion.conn);

            cmd.ExecuteNonQuery();


        }

        internal bool darAltaUsuario(SistemManager cManager, bool esCliente, string user, string pass)
        {

            SqlCommand cmd;
            String ComandoInsert;

            try
            {

                if (esCliente == true)


                    ComandoInsert = "INSERT INTO NO_MORE_SQL.Usuario(Usuario_Nombre,Esta_Habilitado,Usuario_Rol_ID) VALUES('" + user + "','SI',(SELECT Rol_ID FROM NO_MORE_SQL.Rol WHERE Rol_Nombre='Cliente'))";


                else

                    ComandoInsert = "INSERT INTO NO_MORE_SQL.Usuario(Usuario_Nombre,Esta_Habilitado,Usuario_Rol_ID) VALUES('" + user + "','SI',(SELECT Rol_ID FROM NO_MORE_SQL.Rol WHERE Rol_Nombre='Empresa'))";


                cmd = new SqlCommand(ComandoInsert, cManager.conexion.conn);
                cmd.ExecuteNonQuery();
                cManager.sqlAbmLogin.agregarContraseñaPorPrimerIngreso(cManager, pass, user);
                return true;
            }
            catch (SqlException e)
            {

                if (e.Number.ToString().Equals("2627"))
                {
                    MessageBox.Show("Usuario ya ingresado");

                }
                return false;

            }
        }



        internal void darAltaEmpresa(SistemManager cManager, String cuit)
        {
            SqlCommand cmd;
            String ComandoInsert = "INSERT INTO NO_MORE_SQL.Usuario(Usuario_Nombre,Esta_Habilitado,Usuario_Rol_ID) VALUES('" + cuit + "','SI',(SELECT Rol_ID FROM NO_MORE_SQL.Rol WHERE Rol_Nombre='Empresa') )";
            cmd = new SqlCommand(ComandoInsert, cManager.conexion.conn);
            cmd.ExecuteNonQuery();

        }

        internal void buscarUsuarios(SistemManager cManager, DataGridView dataGridViewUsuarios, string usuario)
        {
            SqlDataAdapter adapComando = new SqlDataAdapter("SELECT Usuario_Nombre FROM NO_MORE_SQL.Usuario WHERE Cliente_Nombre LIKE '%"+ usuario +"%'", cManager.conexion.conn);
            cManager.conexion.adaptarTablaAlComando(adapComando, dataGridViewUsuarios, true, 5);
           
        }
    }
}
