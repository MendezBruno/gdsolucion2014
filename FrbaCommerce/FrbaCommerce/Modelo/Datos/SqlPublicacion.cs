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
        internal void publicar(SistemManager cManager, string tipoPublicacion, string rubro, string descripcion, decimal stockInicial, decimal precio, int visibilidad, string aceptaPregunta, string userName)
        {
            SqlCommand Cmd;
            MessageBox.Show(DateTime.Now.ToString());
          // String Comando = "INSERT INTO Publicacion(Publicacion_Descripcion,Publicacion_Stock,Publicacion_Fecha_Vencimiento,Publicacion_Fecha_Inicio,Publicacion_Precio,Publicacion_Tipo,Publicacion_Estado,Publicacion_Estado_Publicacion_ID,Publicacion_Puede_Preguntar,Publicacion_Usuario_Nombre,Publicacion_Visibilidad_Cod) VALUES ('"+ descripcion +"',"+ stockInicial.ToString() +","+ DateTime.Now.AddDays(7).ToString() +"," + DateTime.Now.ToString() + ","+ precio.ToString()+",'"+ tipoPublicacion +"','Publicada',1,'"+aceptaPregunta+"','"+ userName +"',"+visibilidad.ToString()+")";
            String Comando = "INSERT INTO Publicacion(Publicacion_Descripcion,Publicacion_Stock,Publicacion_Fecha_Vencimiento,Publicacion_Fecha_Inicio,Publicacion_Precio,Publicacion_Tipo,Publicacion_Estado,Publicacion_Estado_Publicacion_ID,Publicacion_Puede_Preguntar,Publicacion_Usuario_Nombre,Publicacion_Visibilidad_Cod) VALUES ('" + descripcion + "'," + stockInicial.ToString() + ",Null,"+ DateTime.Now.ToString() +"," + precio.ToString() + ",'" + tipoPublicacion + "','Publicada',1,'" + aceptaPregunta + "','" + userName + "'," + visibilidad.ToString() + ")";

            Cmd = new SqlCommand(Comando, cManager.conexion.conn);
            Cmd.ExecuteNonQuery();
        }
    }
}






/*
            if (tipoPublicacion.Equals("SUBASTA")) publicacion.tipoPublicacion = new Subasta();
            else publicacion.tipoPublicacion = new StockComun();
            */