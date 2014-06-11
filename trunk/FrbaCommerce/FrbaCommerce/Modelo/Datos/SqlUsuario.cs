using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace FrbaCommerce.Modelo.Datos
{
     public class SqlUsuario
    {
        internal void darAlta(SistemManager cManager,String dni,String tipo)
        {
           
           SqlCommand cmd;
           String ComandoInsert = "INSERT INTO Cliente_Usuario(Cliente_Tipo_Doc,Cliente_DNI) VALUES('" +tipo+ "'," + dni+")";
           cmd = new SqlCommand(ComandoInsert, cManager.conexion.conn);
           cmd.ExecuteNonQuery();
           ComandoInsert = "INSERT INTO Usuario(Usuario_Nombre,Usuario_Cliente_ID) VALUES('" + dni + "', (SELECT Cliente_ID FROM Cliente_Usuario WHERE Cliente_Tipo_Doc='" + tipo + "' AND Cliente_DNI =" + dni + "))";
           cmd = new SqlCommand(ComandoInsert, cManager.conexion.conn);
           cmd.ExecuteNonQuery();
           
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
