using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using FrbaCommerce.Comprar_Ofertar;

namespace FrbaCommerce.Modelo.Datos
{
    public class SqlCompra
    {

        public DataTable buscarCompras(SistemManager cManager, CheckedListBox.CheckedItemCollection checkeados, string descripcion, DataGridView dataGridView)
        {
            /* genero una tabla temporal para guardar los datos */

            string comando = "CREATE TABLE NO_MORE_SQL.#AuxiliarCompra (Visibilidad_descripcion NVARCHAR(255),Rubro NVARCHAR(255),Descripcion_Public NVARCHAR (255),Publicacion_Cod NUMERIC(18,0),Visibilidad_codigo NUMERIC(18,0));";

            SqlCommand cmd;

            cmd=new SqlCommand(comando,cManager.conexion.conn);

            cmd.ExecuteNonQuery();
            
            foreach (string check in checkeados)
            {

                comando = " INSERT INTO NO_MORE_SQL.#AuxiliarCompra(Visibilidad_descripcion,Rubro,Descripcion_Public,Publicacion_Cod,Visibilidad_codigo) SELECT Visibilidad_Descripcion, Rubro_Descripcion, Publicacion_Descripcion,Publicacion.Publicacion_Codigo,Visibilidad_Codigo FROM NO_MORE_SQL.Publicacion INNER JOIN NO_MORE_SQL.Publicacion_Visibilidad ON NO_MORE_SQL.Publicacion.Publicacion_Visibilidad_Cod=NO_MORE_SQL.Publicacion_Visibilidad.Visibilidad_Codigo INNER JOIN NO_MORE_SQL.Rubro_Publicacion ON NO_MORE_SQL.Publicacion.Publicacion_Codigo=NO_MORE_SQL.Rubro_Publicacion.Publicacion_Codigo INNER JOIN NO_MORE_SQL.Rubro ON NO_MORE_SQL.Rubro_Publicacion.Rubro_Codigo=NO_MORE_SQL.Rubro.Rubro_Codigo WHERE Rubro_Descripcion='" + check + "' AND Publicacion_Descripcion LIKE '%" + descripcion + "%'";

                cmd=new SqlCommand(comando,cManager.conexion.conn);

                cmd.ExecuteNonQuery();

            }
            if (checkeados.Count == 0)
            {

                comando = " INSERT INTO NO_MORE_SQL.#AuxiliarCompra(Visibilidad_descripcion,Rubro,Descripcion_Public,Publicacion_Cod,Visibilidad_codigo) SELECT Visibilidad_Descripcion, Rubro_Descripcion, Publicacion_Descripcion,Publicacion.Publicacion_Codigo,Visibilidad_Codigo FROM NO_MORE_SQL.Publicacion INNER JOIN NO_MORE_SQL.Publicacion_Visibilidad ON NO_MORE_SQL.Publicacion.Publicacion_Visibilidad_Cod=NO_MORE_SQL.Publicacion_Visibilidad.Visibilidad_Codigo INNER JOIN NO_MORE_SQL.Rubro_Publicacion ON NO_MORE_SQL.Publicacion.Publicacion_Codigo=NO_MORE_SQL.Rubro_Publicacion.Publicacion_Codigo INNER JOIN NO_MORE_SQL.Rubro ON NO_MORE_SQL.Rubro_Publicacion.Rubro_Codigo=NO_MORE_SQL.Rubro.Rubro_Codigo WHERE Publicacion_Descripcion LIKE '%" + descripcion + "%'";

                cmd = new SqlCommand(comando, cManager.conexion.conn);

                cmd.ExecuteNonQuery();
            }


            SqlDataAdapter adapComando = new SqlDataAdapter("SELECT * FROM NO_MORE_SQL.#AuxiliarCompra ORDER BY Visibilidad_Codigo", cManager.conexion.conn);
            DataTable tabla = new DataTable();
            adapComando.Fill(tabla);



            comando = "IF OBJECT_ID(N'tempdb..#AuxiliarCompra', N'U') IS NOT NULL DROP TABLE #AuxiliarCompra;";

            cmd=new SqlCommand(comando,cManager.conexion.conn);

            cmd.ExecuteNonQuery();

            return tabla;



        }

        public void BuscarPublicacion(SistemManager cManager, FormMostrarPublicacion publicacion, string public_Cod)
 
        {

             SqlCommand cmd;

             SqlDataReader dr;

             string comando = "SELECT Publicacion_Tipo,Publicacion_Descripcion,STR((Publicacion_Precio/Publicacion_Stock),18,2) as PrcioUni FROM NO_MORE_SQL.Publicacion WHERE Publicacion_Codigo =" + public_Cod;

             cmd=new SqlCommand(comando,cManager.conexion.conn);

             dr=cmd.ExecuteReader();

             dr.Read();

             publicacion.tipo.Text=dr["Publicacion_Tipo"].ToString();

             publicacion.descripcion.Text = dr["Publicacion_Descripcion"].ToString();

             publicacion.precio.Text = dr["PrcioUni"].ToString();

             dr.Close();

             comando = "SELECT (SUM(Compra_Cantidad)-Publicacion_Stock) AS StockActual FROM NO_MORE_SQL.Publicacion INNER JOIN NO_MORE_SQL.Compra ON Publicacion.Publicacion_Codigo=Compra.Compra_Publicacion WHERE Publicacion_Codigo="+public_Cod+" GROUP BY Publicacion_Stock";

             cmd = new SqlCommand(comando, cManager.conexion.conn);

             dr = cmd.ExecuteReader();

             dr.Read();

             publicacion.stock.Text = dr["StockActual"].ToString();

             dr.Close();


        }



    }
}
