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
        internal void darAlta(SistemManager cManager,bool esCliente,string nombre)
        {
           
           SqlCommand cmd;
           String ComandoInsert;

            
            if (esCliente == true)


                ComandoInsert = "INSERT INTO NO_MORE_SQL.Usuario(Usuario_Nombre,Esta_Habilitado,Usuario_Rol_ID,Puede_Comprar) VALUES('" + nombre + "','SI',(SELECT Rol_ID FROM NO_MORE_SQL.Rol WHERE Rol_Nombre='Cliente'),'SI')";

            
            else

                ComandoInsert = "INSERT INTO NO_MORE_SQL.Usuario(Usuario_Nombre,Esta_Habilitado,Usuario_Rol_ID,Puede_Comprar) VALUES('" + nombre + "','SI',(SELECT Rol_ID FROM NO_MORE_SQL.Rol WHERE Rol_Nombre='Empresa'),'SI')";


           
            
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

        internal void darAltaUsuario(SistemManager cManager, bool esCliente, string user, string pass)
        {

            SqlCommand cmd;
            String ComandoInsert; 
                
                if (esCliente == true)


                    ComandoInsert = "INSERT INTO NO_MORE_SQL.Usuario(Usuario_Nombre,Esta_Habilitado,Usuario_Rol_ID,Puede_Comprar) VALUES('" + user + "','SI',(SELECT Rol_ID FROM NO_MORE_SQL.Rol WHERE Rol_Nombre='Cliente'),'SI')";


                else

                    ComandoInsert = "INSERT INTO NO_MORE_SQL.Usuario(Usuario_Nombre,Esta_Habilitado,Usuario_Rol_ID,Puede_Comprar) VALUES('" + user + "','SI',(SELECT Rol_ID FROM NO_MORE_SQL.Rol WHERE Rol_Nombre='Empresa'),'SI')";


                cmd = new SqlCommand(ComandoInsert, cManager.conexion.conn);
                cmd.ExecuteNonQuery();
                cManager.sqlAbmLogin.agregarContraseñaPorPrimerIngreso(cManager, pass, user);
            
           
            
         
        }



        internal void darAltaEmpresa(SistemManager cManager, String cuit)
        {
            SqlCommand cmd;
            String ComandoInsert = "INSERT INTO NO_MORE_SQL.Usuario(Usuario_Nombre,Esta_Habilitado,Usuario_Rol_ID,Puede_Comprar) VALUES('" + cuit + "','SI',(SELECT Rol_ID FROM NO_MORE_SQL.Rol WHERE Rol_Nombre='Empresa'),'SI' )";
            cmd = new SqlCommand(ComandoInsert, cManager.conexion.conn);
            cmd.ExecuteNonQuery();

        }

        internal void buscarUsuarios(SistemManager cManager, DataGridView dataGridViewUsuarios, string usuario)
        {
            SqlDataAdapter adapComando = new SqlDataAdapter("SELECT Usuario_Nombre FROM NO_MORE_SQL.Usuario WHERE Usuario_Nombre LIKE '%"+ usuario +"%'", cManager.conexion.conn);
            cManager.conexion.adaptarTablaAlComando(adapComando, dataGridViewUsuarios, true, 1);
           
        }

        internal void darAltaCliente(SistemManager cManager,bool esCliente, string dni, string tipo_doc)
        {


            SqlCommand cmd;
            String ComandoInsert;

            ComandoInsert = "INSERT INTO NO_MORE_SQL.Usuario(Usuario_Nombre,Esta_Habilitado,Usuario_Rol_ID,Puede_Comprar) VALUES('" + dni + tipo_doc+ "','SI',(SELECT Rol_ID FROM NO_MORE_SQL.Rol WHERE Rol_Nombre='Cliente'),'SI')";

            cmd = new SqlCommand(ComandoInsert, cManager.conexion.conn);
            cmd.ExecuteNonQuery();





        }

        internal bool existe_Usuario(SistemManager cManager, string usuario, string password)
        {
            SqlCommand cmd;
            string comando;
            SqlDataReader dr;
            comando= "SELECT * FROM NO_MORE_SQL.Usuario WHERE Usuario_Nombre='"+usuario+"'";
            cmd = new SqlCommand(comando, cManager.conexion.conn);
            dr=cmd.ExecuteReader();

            if (dr.Read())
            {
                dr.Close();

                MessageBox.Show("Usuario ya ingresado, Ingresar otro nombre");

                return true; 

            }

                dr.Close();

               return false;
        }
    }
}
