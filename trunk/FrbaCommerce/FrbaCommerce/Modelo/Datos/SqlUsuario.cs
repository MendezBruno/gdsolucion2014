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
        

               ComandoInsert = "INSERT INTO Usuario(Usuario_Nombre,Usuario_Cliente_ID,Esta_Habilitado) VALUES('" + dni + "', (SELECT Cliente_ID FROM Cliente WHERE Cliente_Tipo_Doc='" + tipo + "' AND Cliente_DNI =" + dni + "),'SI')";

           
           else
               ComandoInsert = "INSERT INTO Usuario(Usuario_Nombre,Usuario_Cliente_ID) VALUES('" + dni + "', (SELECT Cliente_ID FROM Cliente WHERE Cliente_Tipo_Doc='" + tipo + "' AND Cliente_DNI =" + dni + "))";


           cmd = new SqlCommand(ComandoInsert, cManager.conexion.conn);
           cmd.ExecuteNonQuery();
           MessageBox.Show("El nombre de usuario para ingresar al sistema es:" +dni+".\nIngresar al sistema sin password y le pedira que cambie la contraseña" );
           
           
        }
        internal void darAltaEmpresa(SistemManager cManager, String cuit)
        {
            SqlCommand cmd;
            String ComandoInsert = "INSERT INTO Usuario(Usuario_Nombre,Usuario_Empresa_ID) VALUES('" + cuit + "', (SELECT Empresa_ID FROM Empresa WHERE Empresa_CUIT='" + cuit + "'))";
            cmd = new SqlCommand(ComandoInsert, cManager.conexion.conn);
            cmd.ExecuteNonQuery();

        }
    }
}
