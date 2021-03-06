﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using FrbaCommerce.Comprar_Ofertar;
using Sistema;

namespace FrbaCommerce.Modelo.Datos
{
    public class SqlCompra
    {

        public DataTable buscarCompras(SistemManager cManager, CheckedListBox.CheckedItemCollection checkeados, string descripcion, DataGridView dataGridView,string usuario)
        {
            /* genero una tabla temporal para guardar los datos */

            string comando = "CREATE TABLE NO_MORE_SQL.#AuxiliarCompra (Visibilidad_descripcion NVARCHAR(255),Rubro NVARCHAR(255),Descripcion_Public NVARCHAR (255),Publicacion_Cod NUMERIC(18,0),Visibilidad_codigo NUMERIC(18,0));";

            SqlCommand cmd;

            cmd=new SqlCommand(comando,cManager.conexion.conn);

            cmd.ExecuteNonQuery();
            
            foreach (string check in checkeados)
            {

                comando = " INSERT INTO NO_MORE_SQL.#AuxiliarCompra(Visibilidad_descripcion,Rubro,Descripcion_Public,Publicacion_Cod,Visibilidad_codigo) SELECT Visibilidad_Descripcion, Rubro_Descripcion, Publicacion_Descripcion,Publicacion.Publicacion_Codigo,Visibilidad_Codigo FROM NO_MORE_SQL.Publicacion INNER JOIN NO_MORE_SQL.Publicacion_Visibilidad ON NO_MORE_SQL.Publicacion.Publicacion_Visibilidad_Cod=NO_MORE_SQL.Publicacion_Visibilidad.Visibilidad_Codigo INNER JOIN NO_MORE_SQL.Rubro_Publicacion ON NO_MORE_SQL.Publicacion.Publicacion_Codigo=NO_MORE_SQL.Rubro_Publicacion.Publicacion_Codigo INNER JOIN NO_MORE_SQL.Rubro ON NO_MORE_SQL.Rubro_Publicacion.Rubro_Codigo=NO_MORE_SQL.Rubro.Rubro_Codigo WHERE Rubro_Descripcion='" + check + "' AND Publicacion_Descripcion LIKE '%" + descripcion + "%' AND Publicacion_Usuario_Nombre <>'" + usuario + "' AND Publicacion_Estado_Publicacion_ID<>(SELECT Estado_Publicacion_iD FROM NO_MORE_SQL.Estado_Publicacion WHERE Estado_Publicacion_Desc='Borrador') AND Publicacion_Estado_Publicacion_ID<>(SELECT Estado_Publicacion_iD FROM NO_MORE_SQL.Estado_Publicacion WHERE Estado_Publicacion_Desc='Finalizado')  ";

                cmd=new SqlCommand(comando,cManager.conexion.conn);

                cmd.ExecuteNonQuery();

            }
            if (checkeados.Count == 0)
            {

                comando = " INSERT INTO NO_MORE_SQL.#AuxiliarCompra(Visibilidad_descripcion,Rubro,Descripcion_Public,Publicacion_Cod,Visibilidad_codigo) SELECT Visibilidad_Descripcion, Rubro_Descripcion, Publicacion_Descripcion,Publicacion.Publicacion_Codigo,Visibilidad_Codigo FROM NO_MORE_SQL.Publicacion INNER JOIN NO_MORE_SQL.Publicacion_Visibilidad ON NO_MORE_SQL.Publicacion.Publicacion_Visibilidad_Cod=NO_MORE_SQL.Publicacion_Visibilidad.Visibilidad_Codigo INNER JOIN NO_MORE_SQL.Rubro_Publicacion ON NO_MORE_SQL.Publicacion.Publicacion_Codigo=NO_MORE_SQL.Rubro_Publicacion.Publicacion_Codigo INNER JOIN NO_MORE_SQL.Rubro ON NO_MORE_SQL.Rubro_Publicacion.Rubro_Codigo=NO_MORE_SQL.Rubro.Rubro_Codigo WHERE Publicacion_Descripcion LIKE '%" + descripcion + "%' AND Publicacion_Usuario_Nombre <>'" + usuario + "'AND Publicacion_Estado_Publicacion_ID<>(SELECT Estado_Publicacion_iD FROM NO_MORE_SQL.Estado_Publicacion WHERE Estado_Publicacion_Desc='Borrador') AND Publicacion_Estado_Publicacion_ID<>(SELECT Estado_Publicacion_iD FROM NO_MORE_SQL.Estado_Publicacion WHERE Estado_Publicacion_Desc='Finalizado') ";

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

        public string Ver_Minimo(SistemManager cManager, string public_Codigo)
        {

            SqlCommand cmd;

            SqlDataReader dr;

            string monto;

            string comando = "SELECT STR(MAX(Oferta_Monto),18,0) AS Monto FROM NO_MORE_SQL.Oferta INNER JOIN NO_MORE_SQL.Publicacion ON  NO_MORE_SQL.Oferta.Oferta_Publicacion_Codigo=NO_MORE_SQL.Publicacion.Publicacion_Codigo WHERE Publicacion_Codigo=" + public_Codigo;

            cmd = new SqlCommand(comando, cManager.conexion.conn);

            dr = cmd.ExecuteReader();

            if (dr.Read())
            {

                monto =dr["Monto"].ToString();
                
                dr.Close();

                return monto;

            }
            else
                return "0";

        }
        public string BuscarPublicacion(SistemManager cManager, FormMostrarPublicacion publicacion, string public_Cod)
 
        {

             SqlCommand cmd;

             SqlDataReader dr;

             string publicacion_Estado_Publicacion_ID;

             string comando = "SELECT Tipo_Publicacion_Desc,Publicacion_Descripcion,STR(Publicacion_Precio,18,2) as PrcioUni, Publicacion_Usuario_Nombre,Publicacion_Puede_Preguntar FROM NO_MORE_SQL.Publicacion INNER JOIN NO_MORE_SQL.Tipo_Publicacion ON NO_MORE_SQL.Publicacion.Publicacion_Tipo_ID=NO_MORE_SQL.Tipo_Publicacion.Tipo_Publicacion_ID WHERE Publicacion_Codigo =" + public_Cod;

             cmd=new SqlCommand(comando,cManager.conexion.conn);

             dr=cmd.ExecuteReader();

             dr.Read();

             publicacion.tipo.Text = dr["Tipo_Publicacion_Desc"].ToString();

             publicacion.descripcion.Text = dr["Publicacion_Descripcion"].ToString();

             publicacion.precio.Text = dr["PrcioUni"].ToString();

             publicacion.labelVendedor.Text = dr["Publicacion_Usuario_Nombre"].ToString();

             if (dr["Publicacion_Puede_Preguntar"].ToString().Equals("NO"))

                 publicacion.buttonPreguntar.Visible = false;

             dr.Close();

             comando = "SELECT (Publicacion_Stock -isnull(SUM(Compra_Cantidad),0)) AS StockActual FROM NO_MORE_SQL.Publicacion LEFT JOIN NO_MORE_SQL.Compra ON Publicacion.Publicacion_Codigo=Compra.Compra_Publicacion WHERE Publicacion_Codigo=" + public_Cod + " GROUP BY Publicacion_Stock";

             cmd = new SqlCommand(comando, cManager.conexion.conn);

             dr = cmd.ExecuteReader();

             dr.Read();

             publicacion.stock.Text = dr["StockActual"].ToString();

             dr.Close();

             comando = "SELECT Estado_Publicacion_Desc FROM NO_MORE_SQL.Publicacion INNER JOIN NO_MORE_SQL.Estado_Publicacion ON NO_MORE_SQL.Publicacion.Publicacion_Estado_Publicacion_ID=NO_MORE_SQL.Estado_Publicacion.Estado_Publicacion_ID WHERE Publicacion_Codigo =" + public_Cod;

             cmd = new SqlCommand(comando, cManager.conexion.conn);

             dr = cmd.ExecuteReader();

             dr.Read();

             publicacion_Estado_Publicacion_ID = dr["Estado_Publicacion_Desc"].ToString();

            dr.Close();

            return publicacion_Estado_Publicacion_ID;







        }

        public void confirmo_oferta(SistemManager cManager, string usuario, string publicCod,string monto)
        {
            SqlCommand cmd;

            string comando = "INSERT INTO NO_MORE_SQL.Oferta(Oferta_Fecha,Oferta_Monto,Oferta_Publicacion_Codigo,Oferta_Usuario_Nombre) VALUES ('" + Configuracion.Default.FechaHoy.ToShortDateString() + "'," + monto + "," + publicCod + ",'" + usuario + "')";

            cmd = new SqlCommand(comando, cManager.conexion.conn);

            cmd.ExecuteNonQuery();

        }

        internal void mostrarVendedor(SistemManager cManager, FormMostrarVendedor formOfertar, string public_Codigo)
        {

            SqlCommand cmd;

            SqlDataReader dr;

            string comando = "SELECT * FROM NO_MORE_SQL.Usuario LEFT JOIN NO_MORE_SQL.Cliente ON NO_MORE_SQL.Usuario.Usuario_Nombre=NO_MORE_SQL.Cliente.Cliente_Usuario_Nombre LEFT JOIN NO_MORE_SQL.Empresa ON NO_MORE_SQL.Usuario.Usuario_Nombre=NO_MORE_SQL.Empresa.Empresa_Usuario_Nombre INNER JOIN NO_MORE_SQL.Publicacion ON NO_MORE_SQL.Usuario.Usuario_Nombre=NO_MORE_SQL.Publicacion.Publicacion_Usuario_Nombre WHERE Publicacion_Codigo='" + public_Codigo + "'";

            cmd = new SqlCommand(comando, cManager.conexion.conn);

            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                
                
                if (!dr["Cliente_Usuario_Nombre"].ToString().Equals(""))
                {

                    formOfertar.label6.Text=dr["Cliente_Usuario_Nombre"].ToString();

                    formOfertar.label7.Text =dr["Cliente_Nombre"].ToString();

                    formOfertar.label8.Text =dr["Cliente_Apellido"].ToString();

                    formOfertar.label10.Text =dr["Cliente_Telefono"].ToString();
 

                }
                else

                if (!dr["Empresa_Usuario_Nombre"].ToString().Equals(""))
                {

                    formOfertar.label4.Text = "Razon_Social:";

                    formOfertar.label5.Text = "Contacto:";
                    
                    formOfertar.label6.Text = dr["Empresa_Usuario_Nombre"].ToString();

                    formOfertar.label7.Text = dr["Empresa_Razon_Social"].ToString();

                    formOfertar.label8.Text = dr["Empresa_Nombre_Contacto"].ToString();

                    formOfertar.label10.Text = dr["Empresa_Telefono"].ToString();

                }
                else
                {
                    formOfertar.label6.Text="";

                    formOfertar.label7.Text="";

                    formOfertar.label8.Text="";

                    formOfertar.label10.Text="";
                }

            
            }

            dr.Close();

        }
        
        internal bool DeshabilitarPorCalificacion(SistemManager cManager,string usuario)
        {

            Usuario user;
            
            SqlCommand cmd;

            SqlDataReader dr;

            string cuenta;

            string comando = "SELECT COUNT(*) AS Cuenta FROM NO_MORE_SQL.Compra WHERE Compra_Usuario='"+usuario+"' AND Compra_Calificacion_Codigo IS NULL";

            cmd = new SqlCommand(comando, cManager.conexion.conn);

            dr=cmd.ExecuteReader();

            if (dr.Read())
            {

                cuenta = dr["Cuenta"].ToString();

                if (Convert.ToInt16(cuenta) >= 5)
                {

                    dr.Close();

                    comando="UPDATE NO_MORE_SQL.Usuario SET Puede_Comprar='NO' WHERE Usuario_Nombre='"+usuario+"'";

                    cmd = new SqlCommand(comando, cManager.conexion.conn);

                    cmd.ExecuteNonQuery();
                    return true;

                }
                else
                {
                    dr.Close();
                    return false;
                }
                dr.Close();
                return false;

            }
            dr.Close();
            return false;



        }

        internal void confirmo_Compra(SistemManager cManager, string public_Codigo, string usuario, string cantidad)
        {
            
            SqlCommand cmd;

            string comando = "INSERT INTO NO_MORE_SQL.Compra(Compra_Fecha,Compra_Cantidad,Compra_Usuario,Compra_Publicacion,Compra_Cobrada) VALUES ('" + Configuracion.Default.FechaHoy.ToShortDateString() + "'," + cantidad + ",'" + usuario + "'," + public_Codigo + ",'NO')";

            cmd = new SqlCommand(comando, cManager.conexion.conn);

            cmd.ExecuteNonQuery();

        }
    }
}
