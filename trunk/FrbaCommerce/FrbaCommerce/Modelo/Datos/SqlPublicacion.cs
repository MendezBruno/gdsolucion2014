using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FrbaCommerce.Modelo.Datos
{
    public class SqlPublicacion
    {
        internal void publicar(SistemManager cManager, string tipoPublicacion, string descripcion, string stockInicial, string precio, int visibilidad, string aceptaPregunta, string userName)
        {
            SqlCommand Cmd;
            MessageBox.Show(DateTime.Now.ToString());
            String Comando = "INSERT INTO Publicacion(Publicacion_Descripcion,Publicacion_Stock,Publicacion_Fecha_Vencimiento,Publicacion_Fecha_Inicio,Publicacion_Precio,Publicacion_Tipo,Publicacion_Estado,Publicacion_Estado_Publicacion_ID,Publicacion_Puede_Preguntar,Publicacion_Usuario_Nombre,Publicacion_Visibilidad_Cod) VALUES ('" + descripcion + "'," + stockInicial + ",Null,'" + DateTime.Now.ToString() + "'," + precio.ToString() + ",'" + tipoPublicacion + "','Publicada',2,'" + aceptaPregunta + "','" + userName + "'," + visibilidad.ToString() + ")";
            Cmd = new SqlCommand(Comando, cManager.conexion.conn);
            Cmd.ExecuteNonQuery();
        }


        internal void buscarBorradas(SistemManager cManager, string usuario, DataGridView dataGridViewContinuar)
        {

            SqlDataAdapter adapComando = new SqlDataAdapter("SELECT * FROM Publicacion JOIN Estado_Publicacion ON Publicacion.Publicacion_Estado_Publicacion_ID=Estado_Publicacion.Estado_Publicacion_ID WHERE Estado='Borrador' AND Publicacion_Usuario_Nombre ='" + usuario+"'", cManager.conexion.conn);
            cManager.conexion.adaptarTablaAlComando(adapComando, dataGridViewContinuar, true, 3);

        }

        internal void buscarModificar(SistemManager cManager, string usuario, DataGridView dataGridViewModificar)
        {

            SqlDataAdapter adapComando = new SqlDataAdapter("SELECT * FROM Publicacion JOIN Estado_Publicacion ON Publicacion.Publicacion_Estado_Publicacion_ID=Estado_Publicacion.Estado_Publicacion_ID WHERE Estado='Activa' AND Publicacion_Usuario_Nombre ='" + usuario + "'", cManager.conexion.conn);
            cManager.conexion.adaptarTablaAlComando(adapComando, dataGridViewModificar, true, 3);

        }

        internal void buscarPausada(SistemManager cManager, string usuario, DataGridView dataGridPausada)
        {
            SqlDataAdapter adapComando = new SqlDataAdapter("SELECT * FROM Publicacion JOIN Estado_Publicacion ON Publicacion.Publicacion_Estado_Publicacion_ID=Estado_Publicacion.Estado_Publicacion_ID WHERE Estado='Activa' AND Publicacion_Usuario_Nombre ='" + usuario + "'", cManager.conexion.conn);
            cManager.conexion.adaptarTablaAlComando(adapComando, dataGridPausada, true, 3);


        }

        internal void buscarFinalizada(SistemManager cManager, string usuario, DataGridView dataGridViewFinalizada)
        {
            SqlDataAdapter adapComando = new SqlDataAdapter("SELECT * FROM Publicacion JOIN Estado_Publicacion ON Publicacion.Publicacion_Estado_Publicacion_ID=Estado_Publicacion.Estado_Publicacion_ID WHERE Estado='Activa' AND Publicacion_Usuario_Nombre ='" + usuario + "'", cManager.conexion.conn);
            cManager.conexion.adaptarTablaAlComando(adapComando, dataGridViewFinalizada, true, 3);



        }

        internal void pasarBorrador(SistemManager cManager, string tipoPublicacion, string descripcion, string stockInicial, string precio, int visibilidad, string aceptaPregunta, string userName)
        {


            SqlCommand cmd;
            String Comando = "INSERT INTO Publicacion(Publicacion_Descripcion,Publicacion_Stock,Publicacion_Fecha_Vencimiento,Publicacion_Fecha_Inicio,Publicacion_Precio,Publicacion_Tipo,Publicacion_Estado,Publicacion_Estado_Publicacion_ID,Publicacion_Puede_Preguntar,Publicacion_Usuario_Nombre,Publicacion_Visibilidad_Cod) VALUES ('" + descripcion + "'," +stockInicial +",Null,'" + DateTime.Now.ToString() + "',@precio,'" + tipoPublicacion + "','Publicada',1,'" + aceptaPregunta + "','" + userName + "',@visibilidad)";
            cmd = new SqlCommand(Comando, cManager.conexion.conn);
            if (precio == "")
                cmd.Parameters.AddWithValue("@precio", DBNull.Value);
            if (visibilidad == -1)
                cmd.Parameters.AddWithValue("@visibilidad", DBNull.Value);
            
            cmd.ExecuteNonQuery();




        }


        internal void ObtenerPublicacionesSegunUsuario(SistemManager cManager, string userName, DataGridView dataGridView)
        {
            SqlDataAdapter adapComando = new SqlDataAdapter("select * from Publicacion WHERE Publicacion_Usuario_Nombre= '" + userName + "'", cManager.conexion.conn);
            cManager.conexion.adaptarTablaAlComando(adapComando, dataGridView, true, 3);
        }
    }

}





/*
            if (tipoPublicacion.Equals("SUBASTA")) publicacion.tipoPublicacion = new Subasta();
            else publicacion.tipoPublicacion = new StockComun();
            */