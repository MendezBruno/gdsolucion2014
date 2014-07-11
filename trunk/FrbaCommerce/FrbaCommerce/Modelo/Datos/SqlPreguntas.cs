using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FrbaCommerce.Modelo.Datos
{
    public class SqlPreguntas
    {
        internal bool insertarPregunta(SistemManager cManager, string p, int codigoPublicacion,string usuarioNombre)
        {
            if (p.Length > 255)
            {
                MessageBox.Show("Maximo de caracteres exedidos");
                return false;
            }
            else
            {
                string comandoInsert = "INSERT INTO NO_MORE_SQL.Pregunta(Pregunta_descripcion,Pregunta_Publicacion_Cod,Pregunta_Respuesta_ID,Pregunta_Usuario_Nombre) VALUES ('" + p + "'," + codigoPublicacion.ToString() + ",null,'"+usuarioNombre+"')";
                SqlCommand MyCmd = new SqlCommand(comandoInsert, cManager.conexion.conn);
                MyCmd.ExecuteNonQuery();
                return true;
            }
        }

        internal void CargarPreguntas(System.Windows.Forms.DataGridView dataGridViewPreguntas, int codigoPublicacion, SistemManager cManager)
        {                                                               
            SqlDataAdapter adapComando = new SqlDataAdapter("SELECT * FROM NO_MORE_SQL.Pregunta LEFT JOIN NO_MORE_SQL.Respuesta ON NO_MORE_SQL.Pregunta.Pregunta_Respuesta_ID=NO_MORE_SQL.Respuesta.Respuesta_ID   WHERE Pregunta_Publicacion_cod="+ codigoPublicacion.ToString(), cManager.conexion.conn);
            cManager.conexion.adaptarTablaAlComando(adapComando, dataGridViewPreguntas, true, 5);
        }

        internal bool insertarRespuesta(SistemManager cManager, string p, int codigoPublicacion,string preguntaId)
        {
            if (p.Length>255 || p.Length==0)
            {
                if (p.Length > 255) MessageBox.Show("Maximo de caracteres exedidos");
                else MessageBox.Show("Debe escribir una respuesta para poder responder");
                return false;
            }
            else
            {
                string comandoInsert = "INSERT INTO NO_MORE_SQL.Respuesta(Respuesta_Fecha,Respuesta_Respuesta) VALUES ('"+Configuracion.Default.FechaHoy.ToShortDateString()+"','" + p + "')";
                SqlCommand MyCmd = new SqlCommand(comandoInsert, cManager.conexion.conn);
                MyCmd.ExecuteNonQuery();
                ActualizarPregunta(cManager, codigoPublicacion, preguntaId);
                return true;
                
            }
        }

        void ActualizarPregunta(SistemManager cManager,int codigoPublicacion, string preguntaId)
        {

            SqlCommand cmd;
            SqlDataReader dr;
            string insertDataMod = "SELECT TOP 1 * FROM NO_MORE_SQL.Respuesta ORDER BY Respuesta_ID DESC" ;
            cmd = new SqlCommand(insertDataMod, cManager.conexion.conn);
            dr = cmd.ExecuteReader();
            dr.Read();

            SqlCommand MyCmd2;
            string ComandoInsertar;
            ComandoInsertar = @"UPDATE NO_MORE_SQL.Pregunta set Pregunta_Respuesta_ID='"+ dr["Respuesta_ID"].ToString() +"' WHERE Pregunta_Publicacion_cod=" + codigoPublicacion.ToString()+"AND Pregunta_ID="+preguntaId;
            MyCmd2 = new SqlCommand(ComandoInsertar, cManager.conexion.conn);
            //tal vez necesito cerra el dr
            dr.Close();
            MyCmd2.ExecuteNonQuery();
        }

        

        internal string buscarRespuesta(SistemManager cManager, object p)
        {
            int idRespuesta = Convert.ToInt32(p);
            SqlCommand cmd;
            SqlDataReader dr;
            string insertDataMod = "SELECT Respuesta_Respuesta FROM NO_MORE_SQL.Respuesta WHERE Respuesta_ID=" + idRespuesta.ToString();
            cmd = new SqlCommand(insertDataMod, cManager.conexion.conn);
            dr = cmd.ExecuteReader();
            dr.Read();

            return dr["Respuesta_Respuesta"].ToString();
        }
    }
}
