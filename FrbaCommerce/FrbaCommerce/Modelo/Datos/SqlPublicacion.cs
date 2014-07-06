using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema;
using System.Data.SqlClient;
using System.Windows.Forms;
using FrbaCommerce.Generar_Publicacion;

namespace FrbaCommerce.Modelo.Datos
{
    public class SqlPublicacion
    {
        internal void publicar(SistemManager cManager, string tipoPublicacion, string descripcion, string stockInicial, string precio, int visibilidad, string aceptaPregunta, string userName,CheckedListBox.CheckedItemCollection checkeados)
        {
            SqlCommand Cmd;
            SqlDataReader dr;
            string pub_codigo;
            String Comando = "INSERT INTO NO_MORE_SQL.Publicacion(Publicacion_Descripcion,Publicacion_Stock,Publicacion_Fecha_Vencimiento,Publicacion_Fecha_Inicio,Publicacion_Precio,Publicacion_Tipo_ID,Publicacion_Estado_Edicion,Publicacion_Estado_Publicacion_ID,Publicacion_Puede_Preguntar,Publicacion_Usuario_Nombre,Publicacion_Visibilidad_Cod) VALUES ('" + descripcion + "'," + stockInicial + ",NO_MORE_SQL.fecha_segun_publicacion(" + visibilidad.ToString() + ",'" + Configuracion.Default.FechaHoy + "'),'" + Configuracion.Default.FechaHoy + "'," + precio.ToString() + ",'" + tipoPublicacion + "','Publicada','Activa','" + aceptaPregunta + "','" + userName + "'," + visibilidad.ToString() + ")";
            Cmd = new SqlCommand(Comando, cManager.conexion.conn);
            Cmd.ExecuteNonQuery();

            Comando = "SELECT TOP 1 Publicacion_Codigo FROM NO_MORE_SQL.Publicacion ORDER BY Publicacion_Codigo DESC";
            Cmd = new SqlCommand(Comando, cManager.conexion.conn);
            dr=Cmd.ExecuteReader();
            dr.Read();
            pub_codigo=dr["Publicacion_Codigo"].ToString();
            dr.Close();
            
            
            foreach (string check in checkeados)
            {
                Comando = "INSERT INTO NO_MORE_SQL.Rubro_Publicacion(Publicacion_Codigo,Rubro_Codigo) VALUES (" + pub_codigo + ",(SELECT Rubro_Codigo FROM NO_MORE_SQL.Rubro WHERE Rubro_Descripcion='" + check.ToString() + "'))";
                Cmd = new SqlCommand(Comando, cManager.conexion.conn);
                Cmd.ExecuteNonQuery();
            }

        }


        internal void buscarBorradas(SistemManager cManager, string usuario, DataGridView dataGridViewContinuar)
        {

            SqlDataAdapter adapComando = new SqlDataAdapter("SELECT * FROM Publicacion JOIN Estado_Publicacion ON Publicacion.Publicacion_Estado_Publicacion_ID=Estado_Publicacion.Estado_Publicacion_ID WHERE Estado='Borrador' AND Publicacion_Usuario_Nombre ='" + usuario+"'", cManager.conexion.conn);
            cManager.conexion.adaptarTablaAlComando(adapComando, dataGridViewContinuar, true, 3);

        }

        internal void buscarModificar(SistemManager cManager, string usuario, DataGridView dataGridViewModificar)
        {

            SqlDataAdapter adapComando = new SqlDataAdapter("SELECT * FROM NO_MORE_SQL.Publicacion JOIN NO_MORE_SQL.Estado_Publicacion ON NO_MORE_SQL.Publicacion.Publicacion_Estado_Publicacion_ID=NO_MORE_SQL.Estado_Publicacion.Estado_Publicacion_ID WHERE Estado='Activa' AND Publicacion_Usuario_Nombre ='" + usuario + "'", cManager.conexion.conn);
            cManager.conexion.adaptarTablaAlComando(adapComando, dataGridViewModificar, true, 3);

        }

        internal void buscarPausada(SistemManager cManager, string usuario, DataGridView dataGridPausada)
        {
            SqlDataAdapter adapComando = new SqlDataAdapter("SELECT * FROM NO_MORE_SQL.Publicacion JOIN NO_MORE_SQL.Estado_Publicacion ON NO_MORE_SQL.Publicacion.Publicacion_Estado_Publicacion_ID=NO_MORE_SQL.Estado_Publicacion.Estado_Publicacion_ID WHERE Estado='Activa' AND Publicacion_Usuario_Nombre ='" + usuario + "'", cManager.conexion.conn);
            cManager.conexion.adaptarTablaAlComando(adapComando, dataGridPausada, true, 3);


        }

        internal void buscarFinalizada(SistemManager cManager, string usuario, DataGridView dataGridViewFinalizada)
        {
            SqlDataAdapter adapComando = new SqlDataAdapter("SELECT * FROM NO_MORE_SQL.Publicacion JOIN Estado_Publicacion ON Publicacion.Publicacion_Estado_Publicacion_ID=Estado_Publicacion.Estado_Publicacion_ID WHERE Estado='Activa' AND Publicacion_Usuario_Nombre ='" + usuario + "'", cManager.conexion.conn);
            cManager.conexion.adaptarTablaAlComando(adapComando, dataGridViewFinalizada, true, 3);



        }

        internal bool tieneMasDeTresGratis(SistemManager cManager, string usuario)
        {

            SqlCommand cmd;

            SqlDataReader dr;

            string command = "SELECT COUNT(*) AS contadorGratis FROM NO_MORE_SQL.Publicacion WHERE Publicacion_Usuario_Nombre='"+usuario+"' AND Publicacion_Estado_Edicion='Publicada' AND Publicacion_Estado_Publicacion_ID='Activa'";

            cmd = new SqlCommand(command, cManager.conexion.conn);

            dr = cmd.ExecuteReader();

            dr.Read();

            if (Convert.ToInt16(dr["contadorGratis"].ToString()) <= 3)
                return true;

            return false;

        }

        internal void pasarBorrador(SistemManager cManager, string tipoPublicacion, string descripcion, string stockInicial, string precio, int visibilidad, string aceptaPregunta, string userName,CheckedListBox.CheckedItemCollection checkeados)
        {


            SqlCommand cmd;
            SqlDataReader dr;
            string pub_codigo;
            MessageBox.Show(tipoPublicacion.ToString());
            String Comando = "INSERT INTO NO_MORE_SQL.Publicacion(Publicacion_Descripcion,Publicacion_Stock,Publicacion_Fecha_Vencimiento,Publicacion_Fecha_Inicio,Publicacion_Precio,Publicacion_Tipo_ID,Publicacion_Estado_Publicacion_ID,Publicacion_Puede_Preguntar,Publicacion_Usuario_Nombre,Publicacion_Visibilidad_Cod) VALUES ('" + descripcion + "'," + stockInicial + ",Null,'" + Configuracion.Default.FechaHoy.ToString() + "',@precio,@Tipo_Publica,'Borrador','" + aceptaPregunta + "','" + userName + "',@visibilidad)";
            cmd = new SqlCommand(Comando, cManager.conexion.conn);
            if (precio == "")
                cmd.Parameters.AddWithValue("@precio", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@precio", precio);
            if (visibilidad == -1)
                cmd.Parameters.AddWithValue("@visibilidad", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@visibilidad", visibilidad);

            if (tipoPublicacion.Equals(""))
            {
                cmd.Parameters.AddWithValue("@Tipo_Publica", DBNull.Value);
            }
            else
                cmd.Parameters.AddWithValue("@Tipo_Publica", tipoPublicacion);

            cmd.ExecuteNonQuery();

            if (visibilidad != -1)
            {
                Comando = "SELECT TOP 1 Publicacion_Codigo FROM NO_MORE_SQL.Publicacion ORDER BY Publicacion_Codigo DESC";
                cmd = new SqlCommand(Comando, cManager.conexion.conn);
                dr = cmd.ExecuteReader();
                dr.Read();
                pub_codigo = dr["Publicacion_Codigo"].ToString();
                dr.Close();


                foreach (string check in checkeados)
                {
                    Comando = "INSERT INTO NO_MORE_SQL.Rubro_Publicacion(Publicacion_Codigo,Rubro_Codigo) VALUES (" + pub_codigo + ",(SELECT Rubro_Codigo FROM NO_MORE_SQL.Rubro WHERE Rubro_Descripcion='" + check.ToString() + "'))";
                    cmd = new SqlCommand(Comando, cManager.conexion.conn);
                    cmd.ExecuteNonQuery();
                }


            }

        }

        internal void eliminarPublicacion(SistemManager cManager, string cod_Public)
        {

            string comando;
            SqlCommand cmd;
            comando = "UPDATE NO_MORE_SQL.Publicacion SET Publicacion_Estado_Edicion='Borrada' WHERE Publicacion_Codigo=" + cod_Public;
            cmd = new SqlCommand(comando, cManager.conexion.conn);
            cmd.ExecuteNonQuery();
        
    
        }
        
        internal void ObtenerPublicacionesSegunUsuario(SistemManager cManager, string userName, DataGridView dataGridView)
        {
            SqlDataAdapter adapComando = new SqlDataAdapter("SELECT Publicacion_Codigo,Publicacion_Tipo_ID,Publicacion_Descripcion,Publicacion_Estado_Publicacion_ID,Publicacion_Estado_Edicion FROM NO_MORE_SQL.Publicacion WHERE Publicacion_Usuario_Nombre= '" + userName + "'", cManager.conexion.conn);
            cManager.conexion.adaptarTablaAlComando(adapComando, dataGridView, true, 3);
            dataGridView.Columns["Publicacion_Codigo"].Visible = true;

        }

        internal void CambiarAActiva(SistemManager cManager, string public_Codigo)
        {

            string comando;
            SqlCommand cmd;
            comando = "UPDATE NO_MORE_SQL.Publicacion SET Publicacion_Estado_Publicacion_ID='Activa' WHERE Publicacion_Codigo=" + public_Codigo;
            cmd = new SqlCommand(comando, cManager.conexion.conn);
            cmd.ExecuteNonQuery();


        }

        internal void CambiarAPausada(SistemManager cManager, string public_Codigo)
        {
            string comando;
            SqlCommand cmd;
            comando = "UPDATE NO_MORE_SQL.Publicacion SET Publicacion_Estado_Publicacion_ID='Pausada' WHERE Publicacion_Codigo=" + public_Codigo;
            cmd = new SqlCommand(comando, cManager.conexion.conn);
            cmd.ExecuteNonQuery();


        }

        internal void CambiarAFinalizada(SistemManager cManager, string public_Codigo)
        {
            string comando;
            SqlCommand cmd;
            comando = "UPDATE NO_MORE_SQL.Publicacion SET Publicacion_Estado_Publicacion_ID='Finalizado' WHERE Publicacion_Codigo=" + public_Codigo;
            cmd = new SqlCommand(comando, cManager.conexion.conn);
            cmd.ExecuteNonQuery();

        }

        internal void ModificarPublic(SistemManager cManager, string valor, string descripcion,string public_Codigo )
        {
            string comando;
            SqlCommand cmd;
            comando = "UPDATE NO_MORE_SQL.Publicacion SET Publicacion_Descripcion='"+descripcion+"', Publicacion_Stock=" + valor+ "WHERE Publicacion_Codigo='" + public_Codigo+"'";
                        cmd = new SqlCommand(comando, cManager.conexion.conn);
            cmd.ExecuteNonQuery();

        }


        internal void cargarDatosGenerar(SistemManager cManager, FormGenerarPublicacion formGenerarPublicacion, string publicacion_cod)
        {

           string comando;
            
           SqlCommand cmd;

           SqlDataReader dr;

           comando = "SELECT Publicacion_Tipo_ID,Publicacion_Descripcion,Publicacion_Precio,Publicacion_Stock,Publicacion_Puede_Preguntar,Visibilidad_Descripcion FROM NO_MORE_SQL.Publicacion LEFT JOIN NO_MORE_SQL.Publicacion_Visibilidad ON NO_MORE_SQL.Publicacion.Publicacion_Visibilidad_Cod=NO_MORE_SQL.Publicacion_Visibilidad.Visibilidad_Codigo WHERE Publicacion_Codigo=" + publicacion_cod;

           cmd = new SqlCommand(comando, cManager.conexion.conn);

           dr = cmd.ExecuteReader();

           dr.Read();

           formGenerarPublicacion.comboBoxTipoPublicacion.Text = dr["Publicacion_Tipo_ID"].ToString();

           formGenerarPublicacion.comboBoxAceptaPregunta.Text = dr["Publicacion_Puede_Preguntar"].ToString();

           formGenerarPublicacion.textBoxDescripcion.Text = dr["Publicacion_Descripcion"].ToString();

           formGenerarPublicacion.textBoxPrecio.Text = dr["Publicacion_Precio"].ToString();

           formGenerarPublicacion.numericUpDownStockInicial.Value = Convert.ToInt32(dr["Publicacion_Stock"].ToString());

           formGenerarPublicacion.comboBoxVisibilidad.Text = dr["Visibilidad_Descripcion"].ToString();

           formGenerarPublicacion.stock_Inicial = dr["Publicacion_Stock"].ToString();

           dr.Close();

           comando = "SELECT Rubro_Descripcion FROM NO_MORE_SQL.Rubro JOIN NO_MORE_SQL.Rubro_Publicacion ON NO_MORE_SQL.Rubro.Rubro_Codigo=NO_MORE_SQL.Rubro_Publicacion.Rubro_Codigo WHERE Publicacion_Codigo=" + publicacion_cod;

           cmd = new SqlCommand(comando, cManager.conexion.conn);

           dr = cmd.ExecuteReader();
            
            while (dr.Read())
           {
                
                for (int i = 0; i < formGenerarPublicacion.checkedListBoxRubro.Items.Count - 1; i++)
               {

                   if(formGenerarPublicacion.checkedListBoxRubro.Items[i].ToString().Equals(dr["Rubro_Descripcion"]))
                   formGenerarPublicacion.checkedListBoxRubro.SetItemChecked(i, true);

               }

           }

           dr.Close();



        
        }

        internal void ObtenerPublicacionesSegunUsuarioYPreguntasSinResponder(SistemManager cManager, string userName, DataGridView dataGridView)
        {
            SqlDataAdapter adapComando = new SqlDataAdapter("SELECT Publicacion_Codigo,Publicacion_Tipo_ID,Publicacion_Descripcion,Publicacion_Estado_Publicacion_ID,Publicacion_Estado_Edicion FROM NO_MORE_SQL.Publicacion INNER JOIN NO_MORE_SQL.Pregunta ON NO_MORE_SQL.Publicacion.Publicacion_Codigo=NO_MORE_SQL.Pregunta.Pregunta_Publicacion_Cod WHERE Publicacion_Usuario_Nombre= '" + userName + "' AND Pregunta_Respuesta_ID IS NULL", cManager.conexion.conn);
            cManager.conexion.adaptarTablaAlComando(adapComando, dataGridView, true, 3);
            dataGridView.Columns["Publicacion_Codigo"].Visible = true;
        }
    }

}





/*
            if (tipoPublicacion.Equals("SUBASTA")) publicacion.tipoPublicacion = new Subasta();
            else publicacion.tipoPublicacion = new StockComun();
            */