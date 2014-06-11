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
            string sql_insert = "INSERT INTO Publicacion_Visibilidad(Visibilidad_Codigo,Visibilidad_Descripcion,Visibilidad_Precio,Visibilidad_Porcentaje,Visibilidad_Esta_Habilitada) VALUES ('" + codigo+"','" +descripcion+"'," +precio+","+porcentaje+",'SI')";
            cmd = new SqlCommand(sql_insert, cManager.conexion.conn);
            cmd.ExecuteNonQuery();
        }
             
        internal void Buscar(SistemManager cManager, DataGridView dataGridView)
        {

            SqlDataAdapter adapComando = new SqlDataAdapter("SELECT * FROM Publicacion_Visibilidad", cManager.conexion.conn);
            cManager.conexion.adaptarTablaAlComando(adapComando, dataGridView, true,4);
     

        }

        internal void cargarDatosDeModificacion(SistemManager cManager, FrbaCommerce.Abm_Visibilidad.FormAltaVisibilidad formAltaVisibilidad, string p)
        {
 
            
            SqlCommand cmd;
            string sql_tomar_datos = "SELECT * FROM Publicacion_Visibilidad WHERE Visibilidad_Codigo="+p;
            cmd = new SqlCommand(sql_tomar_datos,cManager.conexion.conn);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            dr.Read();
            formAltaVisibilidad.textBoxCodigo.Text = dr["Visibilidad_Codigo"].ToString();
            formAltaVisibilidad.textBoxDescripcion.Text = dr["Visibilidad_Descripcion"].ToString();
            formAltaVisibilidad.textBoxPorcentaje.Text = dr["Visibilidad_Porcentaje"].ToString();
            formAltaVisibilidad.textBoxPPP.Text = dr["Visibilidad_Precio"].ToString();
            
            dr.Close();

        }

        internal void actualizar_Datos(SistemManager cManager,Sistema.VisibilidadPublicacion visibilidad, string codigo, string descripcion, string precio, string porcentaje)
        {

            SqlCommand cmd;

            //int c[];

            string instruccion = "SELECT Publicacion_Codigo From Publicacion WHERE Publicacion_Visibilidad_Codigo ='" ;  


        }

        internal void cargarDatosDeBaja(SistemManager cManager, FrbaCommerce.Abm_Visibilidad.FormBajaVisibilidad formBajaVisibilidad, string p)
        {
            throw new NotImplementedException();
        }

        internal void listaDeVisibilidades(SistemManager cManager, ComboBox.ObjectCollection objectCollection)
        {
            SqlCommand cmd = new SqlCommand("SELECT Visibilidad_Descripcion FROM Publicacion_Visibilidad", cManager.conexion.conn);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                objectCollection.Add(dr["Visibilidad_Descripcion"].ToString());
            }
            dr.Close();
        }

        internal int codigoSegunDescripcion(SistemManager cManager, string descripcion)
        {
            SqlCommand cmd = new SqlCommand("SELECT Visibilidad_Codigo FROM Publicacion_Visibilidad WHERE Visibilidad_Descripcion='"+descripcion+"'", cManager.conexion.conn);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            int res = Convert.ToInt32(dr[0]);
            dr.Close();
            return res;
        }
    }
}
