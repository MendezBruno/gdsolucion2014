using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FrbaCommerce.Modelo.Datos
{
    public class SqlRubro
    {
        internal void listaDeRubro(SistemManager cManager, ComboBox.ObjectCollection objectCollection)
        {
            SqlCommand cmd = new SqlCommand("SELECT Rubro_Descripcion FROM Rubro" , cManager.conexion.conn);

            SqlDataReader dr = cmd.ExecuteReader();
            
            while (dr.Read())
            {
                objectCollection.Add(dr["Rubro_Descripcion"].ToString());
            }
            dr.Close();
        }
    }
}
