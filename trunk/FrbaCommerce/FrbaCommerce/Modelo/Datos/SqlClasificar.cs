using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaCommerce.Modelo.Datos
{
    public class SqlClasificar
    {
        internal void buscarClasificar(SistemManager cManager,string usuario,DataGridView dataGrid )
        {

            SqlDataAdapter adapComando = new SqlDataAdapter("SELECT Compra_ID,Publicacion_Usuario_Nombre,Publicacion_Descripcion FROM NO_MORE_SQL.Publicacion JOIN NO_MORE_SQL.Compra ON NO_MORE_SQL.Publicacion.Publicacion_Codigo= NO_MORE_SQL.Compra.Compra_Publicacion WHERE Compra_Usuario='" + usuario + "' AND Compra_Calificacion_Codigo IS NULL", cManager.conexion.conn);
            cManager.conexion.adaptarTablaAlComando(adapComando, dataGrid, true, 2);
            dataGrid.Columns["Compra_ID"].Visible = false;

        }

        internal void IngresarClasificacion(SistemManager cManager, string compra_id,string calificacion, string descripcion)
        {

            SqlCommand cmd;
            string command = "UPDATE NO_MORE_SQL.Calificacion SET Calificacion_Cantidad_Estrellas=" + calificacion + ",Calificacion_Descripcion='" + descripcion + "'";
            cmd = new SqlCommand(command,cManager.conexion.conn);
            cmd.ExecuteNonQuery();

            command = "UPDATE NO_MORE_SQL.Compra SET Compra_Calificacion_Codigo=(SELECT TOP 1 Calificacion_Codigo FROM Calificacion ORDER BY Calificacion_Codigo)";
            cmd = new SqlCommand(command,cManager.conexion.conn);
            cmd.ExecuteNonQuery();


        }

    }
}
