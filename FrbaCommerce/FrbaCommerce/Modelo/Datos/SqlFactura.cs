using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace FrbaCommerce.Modelo.Datos
{
    public class SqlFactura
    {

        public DataTable buscarFactura(SistemManager cManager, string usuario, string cantidad)
        {

            SqlDataAdapter adapComando;

            SqlCommand cmd;

            SqlDataReader dr;

            DataTable tabla= new DataTable();

            string comando = "SELECT  1 AS Compra_Cantidad ,Visibilidad_Precio,Publicacion_Codigo,'Visibilidad_Publicacion' FROM NO_MORE_SQL.Publicacion INNER JOIN NO_MORE_SQL.Publicacion_Visibilidad ON NO_MORE_SQL.Publicacion.Publicacion_Visibilidad_Cod=NO_MORE_SQL.Publicacion_Visibilidad.Visibilidad_Codigo WHERE Publicacion_Usuario_Nombre='" + usuario + "' AND Publicacion_Visibilidad_Cobrada='SI' UNION ALL (SELECT Compra_Cantidad,STR(Compra_Cantidad*Publicacion_Precio*Visibilidad_Porcentaje,18,2) AS Visibilidad_Precio,Publicacion_Codigo,'Item' FROM NO_MORE_SQL.Publicacion INNER JOIN NO_MORE_SQL.Compra ON NO_MORE_SQL.Publicacion.Publicacion_Codigo=NO_MORE_SQL.Compra.Compra_Publicacion INNER JOIN NO_MORE_SQL.Publicacion_Visibilidad ON NO_MORE_SQL.Publicacion.Publicacion_Visibilidad_Cod=NO_MORE_SQL.Publicacion_Visibilidad.Visibilidad_Codigo WHERE Publicacion_Usuario_Nombre='" + usuario + "' AND Compra_Cobrada='SI' AND Publicacion_Contador_Bonificacion <> 10) ;";

            cmd=new SqlCommand(comando,cManager.conexion.conn);

            dr = cmd.ExecuteReader();

            if (dr.Read())
            {

                dr.Close();

                comando = "SELECT 1 AS Compra_Cantidad ,Visibilidad_Precio,Publicacion_Codigo,'Visibilidad_Publicacion' FROM NO_MORE_SQL.Publicacion INNER JOIN NO_MORE_SQL.Publicacion_Visibilidad ON NO_MORE_SQL.Publicacion.Publicacion_Visibilidad_Cod=NO_MORE_SQL.Publicacion_Visibilidad.Visibilidad_Codigo WHERE Publicacion_Usuario_Nombre='" + usuario + "' AND Publicacion_Visibilidad_Cobrada='SI'";

                adapComando = new SqlDataAdapter(comando, cManager.conexion.conn);

                adapComando.Fill(tabla);
/*
                comando = "SELECT Compra_Cantidad,STR(Compra_Cantidad*Publicacion_Precio*Visibilidad_Porcentaje,18,2) AS Visibilidad_Precio,Publicacion_Codigo,'Item' FROM NO_MORE_SQL.Publicacion INNER JOIN NO_MORE_SQL.Compra ON NO_MORE_SQL.Publicacion.Publicacion_Codigo=NO_MORE_SQL.Compra.Compra_Publicacion INNER JOIN NO_MORE_SQL.Publicacion_Visibilidad ON NO_MORE_SQL.Publicacion.Publicacion_Visibilidad_Cod=NO_MORE_SQL.Publicacion_Visibilidad.Visibilidad_Codigo WHERE Publicacion_Usuario_Nombre='" + usuario + "' AND Compra_Cobrada='SI'";

                adapComando = new SqlDataAdapter(comando, cManager.conexion.conn);

                adapComando.Fill(tabla);
   */             
                return tabla;

            }
            else
            {
                dr.Close();
                return tabla;
            }

        }

        public DataTable buscarCompras(SistemManager cManager, string usuario, string cantidad)
        {

            SqlDataAdapter adapComando;

            SqlCommand cmd;

            SqlDataReader dr;

            DataTable tabla = new DataTable();

            string comando = "SELECT Compra_Cantidad,Compra_Cantidad*Publicacion_Precio*Visibilidad_Porcentaje AS Visibilidad_Precio,Publicacion_Codigo,'Item' FROM NO_MORE_SQL.Publicacion INNER JOIN NO_MORE_SQL.Compra ON NO_MORE_SQL.Publicacion.Publicacion_Codigo=NO_MORE_SQL.Compra.Compra_Publicacion INNER JOIN NO_MORE_SQL.Publicacion_Visibilidad ON NO_MORE_SQL.Publicacion.Publicacion_Visibilidad_Cod=NO_MORE_SQL.Publicacion_Visibilidad.Visibilidad_Codigo WHERE Publicacion_Usuario_Nombre='" + usuario + "' AND Compra_Cobrada='SI'  ;";

            cmd = new SqlCommand(comando, cManager.conexion.conn);

            dr = cmd.ExecuteReader();

            if (dr.Read())
            {

                dr.Close();

                comando = "SELECT Compra_Cantidad,CAST(Compra_Cantidad*Publicacion_Precio*Visibilidad_Porcentaje AS NUMERIC(18,2)) AS Visibilidad_Precio,Publicacion_Codigo,'Item' FROM NO_MORE_SQL.Publicacion INNER JOIN NO_MORE_SQL.Compra ON NO_MORE_SQL.Publicacion.Publicacion_Codigo=NO_MORE_SQL.Compra.Compra_Publicacion INNER JOIN NO_MORE_SQL.Publicacion_Visibilidad ON NO_MORE_SQL.Publicacion.Publicacion_Visibilidad_Cod=NO_MORE_SQL.Publicacion_Visibilidad.Visibilidad_Codigo WHERE Publicacion_Usuario_Nombre='" + usuario + "' AND Compra_Cobrada='SI' ORDER BY Compra_Fecha ;";

                adapComando = new SqlDataAdapter(comando, cManager.conexion.conn);

                adapComando.Fill(tabla);

                return tabla;

            }
            else
            {
                dr.Close();
                return tabla;
            }


        }
    }
}
