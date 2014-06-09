using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace FrbaCommerce.Modelo.Datos
{
    public class SqlAmbVisibilidad
    {
        internal void Ingresar_Datos(SistemManager cManager, string codigo, string descripcion, string precio, string porcentaje)
        {

            SqlCommand cmd;
            string sql_insert = "INSERT INTO Publicacion_Visibilidad(Visibilidad_Codigo,Visibilidad_Descripcion,Visibilidad_Precio,Visibilidad_Porcentaje) VALUES ('" + codigo+"','" +descripcion+"'," +precio+","+porcentaje+")";
            cmd = new SqlCommand(sql_insert, cManager.conexion.conn);
            cmd.ExecuteNonQuery();
        }
             
        internal void Buscar(SistemManager cManager, System.Windows.Forms.DataGridView dataGridView)
        {

            SqlDataAdapter adapComando = new SqlDataAdapter("SELECT * FROM Publicacion_Visibilidad" , cManager.conexion.conn);
            cManager.conexion.adaptarTablaAlComando(adapComando, dataGridView, true,4);
     

        }

        internal void cargarDatosDeModificacion(SistemManager cManager, FrbaCommerce.Abm_Visibilidad.FormAltaVisibilidad formAltaVisibilidad, string p)
        {
            throw new NotImplementedException();
        }

        internal void cargarDatosDeBaja(SistemManager cManager, FrbaCommerce.Abm_Visibilidad.FormBajaVisibilidad formBajaVisibilidad, string p)
        {
            throw new NotImplementedException();
        }

        internal void listaDeVisibilidades(SistemManager cManager, List<string> visibilidades)
        {
            throw new NotImplementedException();
        }
    }
}
