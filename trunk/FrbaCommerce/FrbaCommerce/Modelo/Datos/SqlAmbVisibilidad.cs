using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FrbaCommerce.Modelo.Datos
{
    public class SqlAmbVisibilidad
    {
        internal void Ingresar_Datos(SistemManager cManager, string codigo, string descripcion, string precio, string porcentaje)
        {

            SqlCommand cmd;
            porcentaje = porcentaje.Replace(',', '.');
            precio = precio.Replace(',', '.');
            string sql_insert = "INSERT INTO NO_MORE_SQL.Publicacion_Visibilidad(Visibilidad_Codigo,Visibilidad_Descripcion,Visibilidad_Precio,Visibilidad_Porcentaje,Visibilidad_Esta_Habilitada) VALUES ('" + codigo + "','" + descripcion + "'," + precio + "," + porcentaje + ",'SI')";
            cmd = new SqlCommand(sql_insert, cManager.conexion.conn);
            cmd.ExecuteNonQuery();
        }

        internal void Ingresar_Datos_Modificacion(SistemManager cManager, string codigo, string descripcion, string precio, string porcentaje,bool habilitado)
        {

            SqlCommand cmd;
            porcentaje=porcentaje.Replace(',','.');
            precio=precio.Replace(',', '.');
            string sql_insert = "UPDATE NO_MORE_SQL.Publicacion_Visibilidad SET Visibilidad_Descripcion='" + descripcion + "',Visibilidad_Precio=" + precio + ",Visibilidad_Porcentaje=" + porcentaje + " WHERE Visibilidad_Codigo=" + codigo;
            cmd = new SqlCommand(sql_insert, cManager.conexion.conn);
            cmd.ExecuteNonQuery();
            if(habilitado==true)
            {
                sql_insert = "UPDATE NO_MORE_SQL.Publicacion_Visibilidad SET Visibilidad_Esta_Habilitada='SI' WHERE Visibilidad_Codigo=" + codigo;
                cmd = new SqlCommand(sql_insert, cManager.conexion.conn);
                cmd.ExecuteNonQuery();
            }
        }
             
        internal void Buscar(SistemManager cManager, DataGridView dataGridView)
        {

            SqlDataAdapter adapComando = new SqlDataAdapter("SELECT Visibilidad_Codigo,Visibilidad_Descripcion,Visibilidad_Precio,Visibilidad_Porcentaje FROM NO_MORE_SQL.Publicacion_Visibilidad", cManager.conexion.conn);
            cManager.conexion.adaptarTablaAlComando(adapComando, dataGridView, true,4);
     

        }
        internal void BuscarSinHabilitados(SistemManager cManager, DataGridView dataGridView)
        {

            SqlDataAdapter adapComando = new SqlDataAdapter("SELECT Visibilidad_Codigo,Visibilidad_Descripcion,Visibilidad_Precio,Visibilidad_Porcentaje FROM NO_MORE_SQL.Publicacion_Visibilidad WHERE Visibilidad_Esta_Habilitada='SI'", cManager.conexion.conn);
            cManager.conexion.adaptarTablaAlComando(adapComando, dataGridView, true, 4);

        }


        internal void cargarDatosDeModificacion(SistemManager cManager, FrbaCommerce.Abm_Visibilidad.FormAltaVisibilidad formAltaVisibilidad, string p)
        {
 
            
            SqlCommand cmd;
            string sql_tomar_datos = "SELECT * FROM NO_MORE_SQL.Publicacion_Visibilidad WHERE Visibilidad_Codigo=" + p;
            cmd = new SqlCommand(sql_tomar_datos,cManager.conexion.conn);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            dr.Read();
            formAltaVisibilidad.textBoxCodigo.Text = dr["Visibilidad_Codigo"].ToString();
            formAltaVisibilidad.textBoxDescripcion.Text = dr["Visibilidad_Descripcion"].ToString();
            formAltaVisibilidad.textBoxPorcentaje.Text = dr["Visibilidad_Porcentaje"].ToString();
            formAltaVisibilidad.textBoxPPP.Text = dr["Visibilidad_Precio"].ToString();
            formAltaVisibilidad.textBoxCodigo.ReadOnly = true;
            if(dr["Visibilidad_Esta_Habilitada"].ToString()=="NO")
                formAltaVisibilidad.checkBoxHabilitado.Checked=false;
            else
                formAltaVisibilidad.checkBoxHabilitado.Checked = true;
            dr.Close();

        }

        internal void cargarDatosDeBaja(SistemManager cManager, string p)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult confirmarBaja = MessageBox.Show("Desea dar de baja la visiblilidad " + p, "Baja de Visibilidad", buttons);
            if (DialogResult.Yes == confirmarBaja)
            {
                //Habilitado pasa a ser false con una consulta Sql ACÀ
                SqlCommand comando;
                string bajastring = "UPDATE NO_MORE_SQL.Publicacion_Visibilidad SET Visibilidad_Esta_Habilitada='NO' WHERE Visibilidad_Descripcion='" + p + "'";
                comando = new SqlCommand(bajastring, cManager.conexion.conn);
                comando.ExecuteNonQuery();


                MessageBox.Show("la visibilidad " + p + " a sido deshabilitado");
            }
            if (DialogResult.No == confirmarBaja)
            {
                //No pasa nada, vuelve al menu principal
            }
        }

        internal void listaDeVisibilidades(SistemManager cManager, ComboBox.ObjectCollection objectCollection)
        {
            SqlCommand cmd = new SqlCommand("SELECT Visibilidad_Descripcion FROM NO_MORE_SQL.Publicacion_Visibilidad", cManager.conexion.conn);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                objectCollection.Add(dr["Visibilidad_Descripcion"].ToString());
            }
            dr.Close();
        }

        internal int codigoSegunDescripcion(SistemManager cManager, string descripcion)
        {
            int res;
            SqlCommand cmd = new SqlCommand("SELECT Visibilidad_Codigo FROM NO_MORE_SQL.Publicacion_Visibilidad WHERE Visibilidad_Descripcion='" + descripcion + "'", cManager.conexion.conn);
            SqlDataReader dr = cmd.ExecuteReader();
            //dr.Read();
            if (dr.Read())
                res = Convert.ToInt32(dr[0]);
            else
                res = -1;
            dr.Close();
            return res;
        }
    }
}
