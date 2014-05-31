using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace FrbaCommerce.Modelo
{
    public class SqlHelper
    {
        public SqlConnection conn;
        public SqlDataReader lector;
        HashAlgorithm hashAlg = new SHA1Managed();
        public string strSql = "Selec * From TablePrueba";

        public SqlHelper()
        {
            conectar();
            probarConexion();
        }
        
        //SqlConnection con = new SqlConnection("Data Source=  ; initial                catalog= Northwind ; User Id=  ; Password=  '");

           // con.open();
        private void conectar()
        {
            try
            {
                conn = new SqlConnection("Data Source=localhost\\SQLSERVER2008; initial catalog=GD1C2014 ; User Id=gd ; Password=gd2014");
                conn.Open();
                Console.WriteLine("se pudo conectar");
            }
            catch
            {
                Console.WriteLine("no se pudo conectar");
            }
        }

        public void probarConexion()
        {
            
            MessageBox.Show("el dato es: " + conn.ConnectionString+ "  " + conn.Database+"   " + conn.DataSource);
        }

        public void insertarEnTabla()
        {
            String MyString = @"INSERT INTO TablePrueba(columnaPrueba) VALUES('otroPepo')";
            SqlCommand MyCmd = new SqlCommand(MyString, conn);
            MyCmd.ExecuteScalar();
        }



        internal void registrarUsuario(string user, string pass, string rol, string tipo, string numero)
        {
            byte[] pwordData = Encoding.Default.GetBytes(pass);

            byte[] hash = hashAlg.ComputeHash(pwordData);

            
            String MyString = @"INSERT INTO Usuario(Usuario_Nombre,Usuario_Contraseña,Usuario_Rol_Nombre) VALUES('" + user + "','"+ pass +"','"+ rol +"')"; //,'" + tipo + "','" + numero + "')";
            SqlCommand MyCmd = new SqlCommand(MyString, conn);
            MyCmd.ExecuteScalar();
            
        }

        
    }
}


//