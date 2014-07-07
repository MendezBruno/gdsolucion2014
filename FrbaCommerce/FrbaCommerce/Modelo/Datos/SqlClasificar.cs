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

        internal void permitirComprar(SistemManager cManager,string usuario)
        {

            SqlCommand cmd;

            SqlDataReader dr;

            string command = "SELECT COUNT (*) as Cuenta FROM NO_MORE_SQL.Compra WHERE Compra_Calificacion_Codigo IS NULL AND Compra_Usuario='"+usuario+"'";
 
            cmd=new SqlCommand(command,cManager.conexion.conn);

            dr=cmd.ExecuteReader();

            dr.Read();

            if(Convert.ToInt16(dr["Cuenta"].ToString())==0)
            {

                dr.Close();
                
                command = "UPDATE NO_MORE_SQL.Usuario SET Puede_Comprar='SI' WHERE Usuario_Nombre='" + usuario + "'";

                cmd = new SqlCommand(command, cManager.conexion.conn);
                
                cmd.ExecuteNonQuery();

            }
            dr.Close();

        }

        internal void IngresarClasificacion(SistemManager cManager, string compra_id,string calificacion, string descripcion)
        {

            SqlCommand cmd;
            string command = "INSERT INTO NO_MORE_SQL.Calificacion(Calificacion_Cantidad_Estrellas,Calificacion_Descripcion) VALUES( " + calificacion + ",'" + descripcion + "')";
            cmd = new SqlCommand(command,cManager.conexion.conn);
            cmd.ExecuteNonQuery();

            command = "UPDATE NO_MORE_SQL.Compra SET Compra_Calificacion_Codigo=(SELECT TOP 1 Calificacion_Codigo FROM NO_MORE_SQL.Calificacion ORDER BY Calificacion_Codigo DESC) WHERE Compra_ID="+compra_id;
            cmd = new SqlCommand(command,cManager.conexion.conn);
            cmd.ExecuteNonQuery();


        }

    }
}
