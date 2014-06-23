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

            string comando = "(SELECT 1 AS Compra_Cantidad ,Visibilidad_Precio,Publicacion_Codigo,'Visibilidad_Publicacion' FROM NO_MORE_SQL.Publicacion INNER JOIN NO_MORE_SQL.Publicacion_Visibilidad ON NO_MORE_SQL.Publicacion.Publicacion_Visibilidad_Cod=NO_MORE_SQL.Publicacion_Visibilidad.Visibilidad_Codigo WHERE Publicacion_Usuario_Nombre='10593988' UNION ALL SELECT Compra_Cantidad,STR(Compra_Cantidad*(Publicacion_Precio/Publicacion_Stock)*Visibilidad_Porcentaje,18,2) AS Visibilidad_Precio,Publicacion_Codigo,'Item' FROM NO_MORE_SQL.Publicacion INNER JOIN NO_MORE_SQL.Compra ON NO_MORE_SQL.Publicacion.Publicacion_Codigo=NO_MORE_SQL.Compra.Compra_Publicacion INNER JOIN NO_MORE_SQL.Publicacion_Visibilidad ON NO_MORE_SQL.Publicacion.Publicacion_Visibilidad_Cod=NO_MORE_SQL.Publicacion_Visibilidad.Visibilidad_Codigo WHERE Publicacion_Usuario_Nombre='10593988') ORDER BY Publicacion_Codigo ;";

            adapComando = new SqlDataAdapter(comando, cManager.conexion.conn);

            DataTable tabla = new DataTable();
            
            adapComando.Fill(tabla);

            return tabla;


        }
    }
}
