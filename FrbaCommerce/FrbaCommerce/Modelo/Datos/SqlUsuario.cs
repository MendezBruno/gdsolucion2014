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
           MessageBox.Show("El nombre de usuario para ingresar al sistema es:" +dni+".\nIngresar al sistema sin password y le pedira que cambie la contraseña" );
        
           
        }

        internal void darAltaUsuario(SistemManager cManager, bool esCliente, string user, string pass)
        {

            SqlCommand cmd;
            String ComandoInsert;


            if (esCliente == true)


                ComandoInsert = "INSERT INTO NO_MORE_SQL.Usuario(Usuario_Nombre,Esta_Habilitado,Usuario_Rol_ID) VALUES('" + user + "','SI',(SELECT Rol_ID FROM NO_MORE_SQL.Rol WHERE Rol_Nombre='Cliente'))";


            else

                ComandoInsert = "INSERT INTO NO_MORE_SQL.Usuario(Usuario_Nombre,Esta_Habilitado,Usuario_Rol_ID) VALUES('" + user + "','SI',(SELECT Rol_ID FROM NO_MORE_SQL.Rol WHERE Rol_Nombre='Empresa'))";


            cmd = new SqlCommand(ComandoInsert, cManager.conexion.conn);
            cmd.ExecuteNonQuery();
            cManager.sqlAbmLogin.agregarContraseñaPorPrimerIngreso(cManager, pass, user);
            MessageBox.Show("El nombre de usuario para ingresar al sistema es:" + user + ".\n la contraseña es:"+pass);


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
