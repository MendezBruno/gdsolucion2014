using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace FrbaCommerce.Modelo.Datos
{
    public class SqlListado
    {
        internal void CargarDatosMayorFacturados(SistemManager cManager, DataGridView dataGridView, string anio, string trimestre)
        {

            SqlCommand cmd = new SqlCommand("Vendedores_Mayor_Facturacion", cManager.conexion.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@trimestre", trimestre);
            cmd.Parameters.AddWithValue("@anio", anio);
            SqlDataAdapter adapComando = new SqlDataAdapter(cmd);
            cManager.conexion.adaptarTablaAlComando(adapComando, dataGridView, true, 1);

        }

        internal void CargarDatosMayorCalificacion(SistemManager cManager, DataGridView dataGridView,string trimestre,string anio)
        {

            SqlCommand cmd = new SqlCommand("Vendedores_Mayor_Calificacion", cManager.conexion.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@trimestre", trimestre);
            cmd.Parameters.AddWithValue("@anio", anio);
            SqlDataAdapter adapComando = new SqlDataAdapter(cmd);
            cManager.conexion.adaptarTablaAlComando(adapComando, dataGridView, true, 1);


        }

        internal void CargarDatosSinClasificar(SistemManager cManager, DataGridView dataGridView, string trimestre, string anio)
        {
            SqlCommand cmd = new SqlCommand("Vendedores_Mayor_Publicaciones_Sin_Clasificar", cManager.conexion.conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@trimestre", trimestre);
            cmd.Parameters.AddWithValue("@anio", anio);
            SqlDataAdapter adapComando = new SqlDataAdapter(cmd);
            cManager.conexion.adaptarTablaAlComando(adapComando, dataGridView, true, 1);

        }


    }
}
