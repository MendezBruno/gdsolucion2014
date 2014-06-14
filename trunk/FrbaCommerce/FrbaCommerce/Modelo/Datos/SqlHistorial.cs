using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace FrbaCommerce.Modelo.Datos
{
    public class SqlHistorial
    {

        internal void cargarDatos(SistemManager cManager, System.Windows.Forms.DataGridView dataGridView, string nombre)
        {


            SqlCommand cmd = new SqlCommand("Historial_Ofertas", cManager.conexion.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nombre", nombre);
            SqlDataAdapter adapComando = new SqlDataAdapter(cmd);
            cManager.conexion.adaptarTablaAlComando(adapComando, dataGridView, true, 7);
            

        }


    }
}
