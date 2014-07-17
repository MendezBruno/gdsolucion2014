using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

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

            string comando = "SELECT  1 AS Compra_Cantidad ,Visibilidad_Precio,Publicacion_Codigo,'Visibilidad_Publicacion' AS Tipo,Publicacion_Codigo FROM NO_MORE_SQL.Publicacion INNER JOIN NO_MORE_SQL.Publicacion_Visibilidad ON NO_MORE_SQL.Publicacion.Publicacion_Visibilidad_Cod=NO_MORE_SQL.Publicacion_Visibilidad.Visibilidad_Codigo WHERE Publicacion_Usuario_Nombre='" + usuario + "' AND Publicacion_Visibilidad_Cobrada='NO' UNION ALL (SELECT Compra_Cantidad,STR(Compra_Cantidad*Publicacion_Precio*Visibilidad_Porcentaje,18,2) AS Visibilidad_Precio,Publicacion_Codigo,'Item',Publicacion_Codigo FROM NO_MORE_SQL.Publicacion INNER JOIN NO_MORE_SQL.Compra ON NO_MORE_SQL.Publicacion.Publicacion_Codigo=NO_MORE_SQL.Compra.Compra_Publicacion INNER JOIN NO_MORE_SQL.Publicacion_Visibilidad ON NO_MORE_SQL.Publicacion.Publicacion_Visibilidad_Cod=NO_MORE_SQL.Publicacion_Visibilidad.Visibilidad_Codigo WHERE Publicacion_Usuario_Nombre='" + usuario + "' AND Compra_Cobrada='NO' AND Publicacion_Contador_Bonificacion <> 10) ;";

            cmd=new SqlCommand(comando,cManager.conexion.conn);

            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                
                dr.Close();

                comando = "SELECT 1 AS Compra_Cantidad ,Visibilidad_Precio,Publicacion_Codigo,'Visibilidad_Publicacion' AS Tipo,Publicacion_Codigo FROM NO_MORE_SQL.Publicacion INNER JOIN NO_MORE_SQL.Publicacion_Visibilidad ON NO_MORE_SQL.Publicacion.Publicacion_Visibilidad_Cod=NO_MORE_SQL.Publicacion_Visibilidad.Visibilidad_Codigo WHERE Publicacion_Usuario_Nombre='" + usuario + "' AND Publicacion_Visibilidad_Cobrada='NO'";

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

            string comando = "SELECT Compra_Cantidad,Compra_Cantidad*Publicacion_Precio*Visibilidad_Porcentaje AS Visibilidad_Precio,Compra_ID AS Publicacion_Codigo,'Item' AS Tipo,Publicacion_Codigo FROM NO_MORE_SQL.Publicacion INNER JOIN NO_MORE_SQL.Compra ON NO_MORE_SQL.Publicacion.Publicacion_Codigo=NO_MORE_SQL.Compra.Compra_Publicacion INNER JOIN NO_MORE_SQL.Publicacion_Visibilidad ON NO_MORE_SQL.Publicacion.Publicacion_Visibilidad_Cod=NO_MORE_SQL.Publicacion_Visibilidad.Visibilidad_Codigo WHERE Publicacion_Usuario_Nombre='" + usuario + "' AND Compra_Cobrada='NO'   ;";

            cmd = new SqlCommand(comando, cManager.conexion.conn);

            dr = cmd.ExecuteReader();

            if (dr.Read())
            {

                dr.Close();

                comando = "SELECT Compra_Cantidad,CAST(Compra_Cantidad*Publicacion_Precio*Visibilidad_Porcentaje AS NUMERIC(18,2)) AS Visibilidad_Precio,Compra_ID AS Publicacion_Codigo,'Item' AS Tipo,Publicacion_Codigo FROM NO_MORE_SQL.Publicacion INNER JOIN NO_MORE_SQL.Compra ON NO_MORE_SQL.Publicacion.Publicacion_Codigo=NO_MORE_SQL.Compra.Compra_Publicacion INNER JOIN NO_MORE_SQL.Publicacion_Visibilidad ON NO_MORE_SQL.Publicacion.Publicacion_Visibilidad_Cod=NO_MORE_SQL.Publicacion_Visibilidad.Visibilidad_Codigo WHERE Publicacion_Usuario_Nombre='" + usuario + "' AND Compra_Cobrada='NO' ORDER BY Compra_Fecha ;";

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

        internal void CargarVisibilidad(SistemManager cManager, string public_Cod,string precio,string cantidad, string nroFactura)
        {

            SqlCommand cmd;

            string comando;

            comando = "INSERT INTO NO_MORE_SQL.Item(Item_Monto,Item_Cantidad,Item_Factura_Codigo,Item_Publicacion_Codigo) VALUES ("+precio+","+cantidad+","+nroFactura+","+public_Cod+")";

            cmd = new SqlCommand(comando, cManager.conexion.conn);

            cmd.ExecuteNonQuery();

            comando = "UPDATE NO_MORE_SQL.Publicacion SET Publicacion_Visibilidad_Cobrada='SI' WHERE Publicacion_Codigo=" + public_Cod;

            cmd = new SqlCommand(comando, cManager.conexion.conn);

            cmd.ExecuteNonQuery();
           
        }

        internal void CargarCompra(SistemManager cManager, string compra_id,string publicacion_Cod,string cantidad,string precio,string nroFactura)
        {

            SqlCommand cmd;

            precio = precio.Replace(',', '.');

            string comando = "INSERT INTO NO_MORE_SQL.Item(Item_Monto,Item_Cantidad,Item_Factura_Codigo,Item_Publicacion_Codigo) VALUES (" + precio + "," + cantidad + "," + nroFactura + "," + publicacion_Cod + ")";

            cmd = new SqlCommand(comando, cManager.conexion.conn);

            cmd.ExecuteNonQuery();

            comando = "UPDATE NO_MORE_SQL.Compra SET Compra_Cobrada='SI' WHERE Compra_ID=" + compra_id;

            cmd = new SqlCommand(comando, cManager.conexion.conn);

            cmd.ExecuteNonQuery();

         
        }

        internal string Cargar_Factura(SistemManager cManager, string monto_Total,string forma)
        {
            SqlCommand cmd;

            SqlDataReader dr;

            string nroFactura;

            monto_Total=monto_Total.Replace(',', '.');

            string comando = "INSERT INTO NO_MORE_SQL.Factura(Factura_Fecha,Factura_Total,Factura_Forma_De_Pago_ID) VALUES ('" + Configuracion.Default.FechaHoy.ToShortDateString() + "'," + monto_Total + ",(SELECT Forma_DE_Pago_ID FROM NO_MORE_SQL.Forma_De_Pago WHERE Forma_DE_Pago_Desc='"+forma+"'))";

            MessageBox.Show(comando);
            
            cmd = new SqlCommand(comando, cManager.conexion.conn);

            cmd.ExecuteNonQuery();

            comando = "SELECT TOP 1 Factura_Nro FROM NO_MORE_SQL.Factura ORDER BY Factura_Nro DESC";

            cmd = new SqlCommand(comando, cManager.conexion.conn);

            dr = cmd.ExecuteReader();

            dr.Read();

            nroFactura = dr["Factura_Nro"].ToString();

            dr.Close();

            return nroFactura;



        }
    }
}
