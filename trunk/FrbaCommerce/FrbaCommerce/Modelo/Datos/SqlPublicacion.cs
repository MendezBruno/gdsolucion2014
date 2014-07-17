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
        internal void publicar(SistemManager cManager, string tipoPublicacion, string descripcion, string stockInicial, string precio, int visibilidad, string aceptaPregunta, string userName,CheckedListBox.CheckedItemCollection checkeados,string accion,string public_Cod)
        {
            SqlCommand Cmd;
            SqlDataReader dr;
            string pub_codigo;
            precio = precio.Replace(',', '.');
            if (!tipoPublicacion.Equals("") && !descripcion.Equals("") && !precio.Equals("") && !visibilidad.Equals("") && !aceptaPregunta.Equals("") && !(checkeados.Count==0))
            {
/*
                try
                {*/
                    if (accion.Equals("Generar Publicacion"))
                    {

                        String Comando = "INSERT INTO NO_MORE_SQL.Publicacion(Publicacion_Descripcion,Publicacion_Stock,Publicacion_Fecha_Vencimiento,Publicacion_Fecha_Inicio,Publicacion_Precio,Publicacion_Tipo_ID,Publicacion_Estado_Publicacion_ID,Publicacion_Puede_Preguntar,Publicacion_Usuario_Nombre,Publicacion_Visibilidad_Cod,Publicacion_Visibilidad_Cobrada) VALUES ('" + descripcion + "'," + stockInicial + ",NO_MORE_SQL.fecha_segun_publicacion(" + visibilidad.ToString() + ",'" + Configuracion.Default.FechaHoy.ToShortDateString() + "'),'" + Configuracion.Default.FechaHoy.ToShortDateString() + "'," + precio.ToString() + ",(SELECT Tipo_Publicacion_ID FROM NO_MORE_SQL.Tipo_Publicacion WHERE Tipo_Publicacion_Desc='" + tipoPublicacion + "'),(SELECT Estado_Publicacion_ID FROM NO_MORE_SQL.Estado_Publicacion WHERE Estado_Publicacion_Desc='Publicada'),'" + aceptaPregunta + "','" + userName + "'," + visibilidad.ToString() + ",'NO')";
                        Cmd = new SqlCommand(Comando, cManager.conexion.conn);
                        Cmd.ExecuteNonQuery();

                        Comando = "SELECT TOP 1 Publicacion_Codigo FROM NO_MORE_SQL.Publicacion ORDER BY Publicacion_Codigo DESC";
                        Cmd = new SqlCommand(Comando, cManager.conexion.conn);
                        dr = Cmd.ExecuteReader();
                        dr.Read();
                        pub_codigo = dr["Publicacion_Codigo"].ToString();
                        dr.Close();


                        foreach (string check in checkeados)
                        {
                            Comando = "INSERT INTO NO_MORE_SQL.Rubro_Publicacion(Publicacion_Codigo,Rubro_Codigo) VALUES (" + pub_codigo + ",(SELECT Rubro_Codigo FROM NO_MORE_SQL.Rubro WHERE Rubro_Descripcion='" + check.ToString() + "'))";
                            Cmd = new SqlCommand(Comando, cManager.conexion.conn);
                            Cmd.ExecuteNonQuery();
                        }

                        Comando = "UPDATE NO_MORE_SQL.Publicacion SET Publicacion_Contador_Bonificacion=(SELECT COUNT(*)%10 FROM NO_MORE_SQL.Publicacion INNER JOIN NO_MORE_SQL.Publicacion_Visibilidad ON Publicacion_Visibilidad_Cod=Visibilidad_Codigo WHERE Publicacion_Usuario_Nombre='" + userName + "' AND Publicacion_Visibilidad_Cod=" + visibilidad + " GROUP BY Visibilidad_Descripcion HAVING COUNT(*)%10!=0) WHERE Publicacion_Codigo=" + pub_codigo;

                        Cmd = new SqlCommand(Comando, cManager.conexion.conn);
                        Cmd.ExecuteNonQuery();
                        MessageBox.Show("Publicacion Creada con Exito");
                        return;

                    }
                    if (accion.Equals("Modificar Publicacion"))
                    {
                        
                        String Comando = "UPDATE NO_MORE_SQL.Publicacion SET Publicacion_Descripcion='" + descripcion + "',Publicacion_Stock=" + stockInicial + ",Publicacion_Fecha_Vencimiento=NO_MORE_SQL.fecha_segun_publicacion(" + visibilidad.ToString() + ",'" + Configuracion.Default.FechaHoy.ToShortDateString() + "'),Publicacion_Fecha_Inicio='" + Configuracion.Default.FechaHoy.ToShortDateString() + "',Publicacion_Precio=" + precio.ToString() + ",Publicacion_Tipo_ID=(SELECT Tipo_Publicacion_ID FROM NO_MORE_SQL.Tipo_Publicacion WHERE Tipo_Publicacion_Desc='" + tipoPublicacion + "'),Publicacion_Estado_Publicacion_ID=(SELECT Estado_Publicacion_ID FROM NO_MORE_SQL.Estado_Publicacion WHERE Estado_Publicacion_Desc='Publicada'),Publicacion_Puede_Preguntar='" + aceptaPregunta + "',Publicacion_Usuario_Nombre='" + userName + "',Publicacion_Visibilidad_Cod=" + visibilidad.ToString() + ",Publicacion_Visibilidad_Cobrada='NO' WHERE Publicacion_Codigo=" + public_Cod;
                        Cmd = new SqlCommand(Comando, cManager.conexion.conn);
                        Cmd.ExecuteNonQuery();

                        Comando = "DELETE FROM NO_MORE_SQL.Rubro_Publicacion WHERE Publicacion_Codigo=" + public_Cod;
                        Cmd = new SqlCommand(Comando, cManager.conexion.conn);
                        Cmd.ExecuteNonQuery();

                        foreach (string check in checkeados)
                        {
                            Comando = "INSERT INTO NO_MORE_SQL.Rubro_Publicacion(Publicacion_Codigo,Rubro_Codigo) VALUES (" + public_Cod + ",(SELECT Rubro_Codigo FROM NO_MORE_SQL.Rubro WHERE Rubro_Descripcion='" + check.ToString() + "'))";
                            Cmd = new SqlCommand(Comando, cManager.conexion.conn);
                            Cmd.ExecuteNonQuery();
                        }

                        Comando = "UPDATE NO_MORE_SQL.Publicacion SET Publicacion_Contador_Bonificacion=(SELECT COUNT(*)%10 FROM NO_MORE_SQL.Publicacion INNER JOIN NO_MORE_SQL.Publicacion_Visibilidad ON Publicacion_Visibilidad_Cod=Visibilidad_Codigo WHERE Publicacion_Usuario_Nombre='" + userName + "' AND Publicacion_Visibilidad_Cod=" + visibilidad + " GROUP BY Visibilidad_Descripcion HAVING COUNT(*)%10!=0) WHERE Publicacion_Codigo=" + public_Cod;

                        Cmd = new SqlCommand(Comando, cManager.conexion.conn);
                        Cmd.ExecuteNonQuery();
                        MessageBox.Show("Publicacion Publicada con Exito");
                        return;



                    }
            /*    }
            
                catch (SqlException e)
                {

               
                    
                    if (e.Number.ToString().Equals("207"))
                    {
                        MessageBox.Show("Precio Mal Ingresado");

                    }

                    if (e.Number.ToString().Equals("8115"))
                    {

                        MessageBox.Show("Uno o mas campos tienen mayores caracteres de los que se pueden ingresar");
                    }

                    if (e.Number.ToString().Equals("1007"))
                    {

                        MessageBox.Show("El campo precio tiene mayores caracteres de los que puede ingresar");

                    }

                    return;



                }*/
            }
            else
            {

                MessageBox.Show("No se puede publicar porque falta uno de los campos, llenelos y vuelva a intentarlo");

            }


        }


        internal void buscarBorradas(SistemManager cManager, string usuario, DataGridView dataGridViewContinuar)
        {

            SqlDataAdapter adapComando = new SqlDataAdapter("SELECT * FROM Publicacion JOIN Estado_Publicacion ON Publicacion.Publicacion_Estado_Publicacion_ID=Estado_Publicacion.Estado_Publicacion_ID WHERE Estado='Borrador' AND Publicacion_Usuario_Nombre ='" + usuario+"'", cManager.conexion.conn);
            cManager.conexion.adaptarTablaAlComando(adapComando, dataGridViewContinuar, true, 3);

        }

        internal void buscarModificar(SistemManager cManager, string usuario, DataGridView dataGridViewModificar)
        {

            SqlDataAdapter adapComando = new SqlDataAdapter("SELECT * FROM NO_MORE_SQL.Publicacion INNER JOIN NO_MORE_SQL.Estado_Publicacion ON NO_MORE_SQL.Publicacion.Publicacion_Estado_Publicacion_ID=NO_MORE_SQL.Estado_Publicacion.Estado_Publicacion_ID WHERE Estado='Activa' AND Publicacion_Usuario_Nombre ='" + usuario + "'", cManager.conexion.conn);
            cManager.conexion.adaptarTablaAlComando(adapComando, dataGridViewModificar, true, 3);

        }

        internal void buscarPausada(SistemManager cManager, string usuario, DataGridView dataGridPausada)
        {
            SqlDataAdapter adapComando = new SqlDataAdapter("SELECT * FROM NO_MORE_SQL.Publicacion INNER JOIN NO_MORE_SQL.Estado_Publicacion ON NO_MORE_SQL.Publicacion.Publicacion_Estado_Publicacion_ID=NO_MORE_SQL.Estado_Publicacion.Estado_Publicacion_ID WHERE Estado='Activa' AND Publicacion_Usuario_Nombre ='" + usuario + "'", cManager.conexion.conn);
            cManager.conexion.adaptarTablaAlComando(adapComando, dataGridPausada, true, 3);


        }

        internal void buscarFinalizada(SistemManager cManager, string usuario, DataGridView dataGridViewFinalizada)
        {
    
            SqlDataAdapter adapComando = new SqlDataAdapter("SELECT * FROM NO_MORE_SQL.Publicacion JOIN Estado_Publicacion ON Publicacion.Publicacion_Estado_Publicacion_ID=Estado_Publicacion.Estado_Publicacion_ID WHERE Estado='Activa' AND Publicacion_Usuario_Nombre ='" + usuario + "'", cManager.conexion.conn);
            cManager.conexion.adaptarTablaAlComando(adapComando, dataGridViewFinalizada, true, 3);

        }

        internal void DeshabilitarDiezCompras(SistemManager cManager, string public_Codigo)
        {

           SqlCommand cmd;

           SqlDataReader dr;

           string usuario_publico;

           string comando="SELECT Publicacion_Usuario_Nombre FROM NO_MORE_SQL.Publicacion WHERE Publicacion_Codigo="+public_Codigo;

           cmd=new SqlCommand(comando,cManager.conexion.conn);

           dr=cmd.ExecuteReader();

           dr.Read();

           usuario_publico=dr["Publicacion_Usuario_Nombre"].ToString();

           dr.Close();

           comando = "SELECT COUNT(*) AS Cuenta FROM NO_MORE_SQL.Publicacion INNER JOIN NO_MORE_SQL.Compra ON NO_MORE_SQL.Publicacion.Publicacion_Codigo=NO_MORE_SQL.Compra.Compra_Publicacion WHERE Publicacion_Usuario_Nombre='" + usuario_publico + "' AND Compra_Cobrada='NO'";

           cmd = new SqlCommand(comando, cManager.conexion.conn);

           dr = cmd.ExecuteReader();

           dr.Read();

           if (Convert.ToInt16(dr["Cuenta"].ToString()) == 10)
           {


               dr.Close();

               comando = "UPDATE NO_MORE_SQL.Usuario SET Esta_Habilitado='NO' WHERE Usuario_Nombre='" + usuario_publico + "'";

               cmd = new SqlCommand(comando, cManager.conexion.conn);

               cmd.ExecuteNonQuery();

               comando = "UPDATE NO_MORE_SQL.Publicacion SET Publicacion_Estado_Publicacion_ID=(SELECT Estado_Publicacion_ID FROM NO_MORE_SQL.Estado_Publicacion WHERE Estado_Publicacion_Desc='Pausada') WHERE Publicacion_Usuario_Nombre='" + usuario_publico + "' AND Publicacion_Estado_Publicacion_ID='Activa'";

               cmd = new SqlCommand(comando, cManager.conexion.conn);

               cmd.ExecuteNonQuery();


           }
           else
           {

               dr.Close();

           }


        }
        internal bool tieneMasDeTresGratis(SistemManager cManager, string usuario)
        {

            SqlCommand cmd;

            SqlDataReader dr;

            string command = "SELECT COUNT(*) AS contadorGratis FROM NO_MORE_SQL.Publicacion INNER JOIN NO_MORE_SQL.Publicacion_Visibilidad ON NO_MORE_SQL.Publicacion.Publicacion_Visibilidad_Cod=NO_MORE_SQL.Publicacion_Visibilidad.Visibilidad_Codigo  WHERE Publicacion_Usuario_Nombre='" + usuario + "' AND Publicacion_Estado_Publicacion_ID=(SELECT Estado_Publicacion_ID FROM NO_MORE_SQL.Estado_Publicacion WHERE Estado_Publicacion_Desc='Activa') AND Visibilidad_Descripcion='Gratis'";

            cmd = new SqlCommand(command, cManager.conexion.conn);

            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                if (Convert.ToInt16(dr["contadorGratis"].ToString()) < 3)
                {
                    dr.Close();
                    return true;
                }
            }
            dr.Close();
            return false;

        }

        internal void pasarBorrador(SistemManager cManager, string tipoPublicacion, string descripcion, string stockInicial, string precio, int visibilidad, string aceptaPregunta, string userName,CheckedListBox.CheckedItemCollection checkeados)
        {


            SqlCommand cmd;
            SqlDataReader dr;
            string pub_codigo;
            MessageBox.Show(tipoPublicacion.ToString());
            String Comando = "INSERT INTO NO_MORE_SQL.Publicacion(Publicacion_Descripcion,Publicacion_Stock,Publicacion_Precio,Publicacion_Tipo_ID,Publicacion_Estado_Publicacion_ID,Publicacion_Puede_Preguntar,Publicacion_Usuario_Nombre,Publicacion_Visibilidad_Cod) VALUES ('" + descripcion + "'," + stockInicial + ",@precio,(SELECT Tipo_Publicacion_ID FROM NO_MORE_SQL.Tipo_Publicacion WHERE Tipo_Publicacion_Desc=@Tipo_Publica),(SELECT Estado_Publicacion_ID FROM NO_MORE_SQL.Estado_Publicacion WHERE Estado_Publicacion_Desc='Borrador'),'" + aceptaPregunta + "','" + userName + "',@visibilidad)";
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

        internal void eliminarPublicacion(SistemManager cManager, string cod_Public)
        {

            string comando;
            SqlCommand cmd;
            comando = "UPDATE NO_MORE_SQL.Publicacion SET Publicacion_Estado_Publicacion_ID=(SELECT Estado_Publicacion_ID FROM NO_MORE_SQL.Estado_Publicacion WHERE Estado_Publicacion_Desc= 'Borrador') WHERE Publicacion_Codigo=" + cod_Public;
            cmd = new SqlCommand(comando, cManager.conexion.conn);
            cmd.ExecuteNonQuery();
        
    
        }
        
        internal void ObtenerPublicacionesSegunUsuario(SistemManager cManager, string userName, DataGridView dataGridView)
        {
            SqlDataAdapter adapComando = new SqlDataAdapter("SELECT Publicacion_Codigo,Tipo_Publicacion_Desc,Publicacion_Descripcion,Estado_Publicacion_Desc FROM NO_MORE_SQL.Publicacion INNER JOIN NO_MORE_SQL.Estado_Publicacion ON NO_MORE_SQL.Publicacion.Publicacion_Estado_Publicacion_ID=NO_MORE_SQL.Estado_Publicacion.Estado_Publicacion_ID INNER JOIN NO_MORE_SQL.Tipo_Publicacion ON NO_MORE_SQL.Publicacion.Publicacion_Tipo_ID=NO_MORE_SQL.Tipo_Publicacion.Tipo_Publicacion_ID WHERE Publicacion_Usuario_Nombre='" + userName + "'", cManager.conexion.conn);
            cManager.conexion.adaptarTablaAlComando(adapComando, dataGridView, true, 4);
            dataGridView.Columns["Publicacion_Codigo"].Visible = true;

        }

        internal void CambiarAActiva(SistemManager cManager, string public_Codigo)
        {

            string comando;
            SqlCommand cmd;
            comando = "UPDATE NO_MORE_SQL.Publicacion SET Publicacion_Estado_Publicacion_ID=(SELECT Estado_Publicacion_ID FROM NO_MORE_SQL.Estado_Publicacion WHERE Estado_Publicacion_Desc ='Publicada') WHERE Publicacion_Codigo=" + public_Codigo;
            cmd = new SqlCommand(comando, cManager.conexion.conn);
            cmd.ExecuteNonQuery();


        }

        internal void CambiarAPausada(SistemManager cManager, string public_Codigo)
        {
            string comando;
            SqlCommand cmd;
            comando = "UPDATE NO_MORE_SQL.Publicacion SET Publicacion_Estado_Publicacion_ID=(SELECT Estado_Publicacion_ID FROM NO_MORE_SQL.Estado_Publicacion WHERE Estado_Publicacion_Desc ='Pausada') WHERE Publicacion_Codigo=" + public_Codigo;
            cmd = new SqlCommand(comando, cManager.conexion.conn);
            cmd.ExecuteNonQuery();


        }

        internal string RegistrarSubasta(SistemManager cManager, string publicCodigo, string tipo_public)
        {
            string comando;

            SqlCommand cmd;

            SqlDataReader dr;

            string usuario;

            try
            {

                comando = "INSERT INTO NO_MORE_SQL.Compra(Compra_Fecha,Compra_Cantidad,Compra_Usuario,Compra_Publicacion,Compra_Cobrada) VALUES ('" + Configuracion.Default.FechaHoy.ToShortDateString() + "',1,(SELECT TOP 1 Oferta_Usuario_Nombre FROM NO_MORE_SQL.Oferta WHERE Oferta_Publicacion_Codigo=" + publicCodigo + " ORDER BY Oferta_Monto DESC)," + publicCodigo + ",'NO')";

                cmd = new SqlCommand(comando, cManager.conexion.conn);

                cmd.ExecuteNonQuery();

                comando = "SELECT TOP 1 Oferta_Usuario_Nombre FROM NO_MORE_SQL.Oferta WHERE Oferta_Publicacion_Codigo=" + publicCodigo + " ORDER BY Oferta_Monto DESC";

                cmd = new SqlCommand(comando, cManager.conexion.conn);

                dr=cmd.ExecuteReader();

                if (dr.Read())
                {

                    usuario = dr["Oferta_Usuario_Nombre"].ToString();
                    dr.Close();
                    cManager.sqlPublicacion.DeshabilitarDiezCompras(cManager, publicCodigo);
                    return usuario;
                }
                dr.Close();

                MessageBox.Show("No se registro ninguna oferta");

                return "-1";


            }

            catch (SqlException e)
            {
                MessageBox.Show("No se registro ninguna oferta");
                return "-1";
            }
        

         

        }
        
        internal void CambiarAFinalizada(SistemManager cManager, string public_Codigo)
        {

            string comando;
            SqlCommand cmd;
            comando = "UPDATE NO_MORE_SQL.Publicacion SET Publicacion_Estado_Publicacion_ID=(SELECT Estado_Publicacion_ID FROM NO_MORE_SQL.Estado_Publicacion WHERE Estado_Publicacion_Desc='Finalizado') WHERE Publicacion_Codigo=" + public_Codigo;
            cmd = new SqlCommand(comando, cManager.conexion.conn);
            cmd.ExecuteNonQuery();

        }

        internal void ModificarPublic(SistemManager cManager, string valor, string descripcion,string public_Codigo )
        {
            string comando;
            SqlCommand cmd;
            comando = "UPDATE NO_MORE_SQL.Publicacion SET Publicacion_Descripcion='"+descripcion+"', Publicacion_Stock=" + valor+ "WHERE Publicacion_Codigo=" + public_Codigo;
                        cmd = new SqlCommand(comando, cManager.conexion.conn);
            cmd.ExecuteNonQuery();

        }

        internal void pasarBorradorUpdate(SistemManager cManager, string tipoPublicacion, string descripcion, string stockInicial, string precio, int visibilidad, string aceptaPregunta, string userName, CheckedListBox.CheckedItemCollection checkeados,string public_Codigo)
        {

            SqlCommand cmd;
            MessageBox.Show(tipoPublicacion.ToString());
            String Comando = "UPDATE NO_MORE_SQL.Publicacion SET Publicacion_Descripcion='" + descripcion + "',Publicacion_Stock=" + stockInicial + ",Publicacion_Precio=@precio,Publicacion_Tipo_ID=(SELECT Tipo_Publicacion_ID FROM NO_MORE_SQL.Tipo_Publicacion WHERE Tipo_Publicacion_Desc=@Tipo_Publica),Publicacion_Estado_Publicacion_ID=(SELECT Estado_Publicacion_ID FROM NO_MORE_SQL.Estado_Publicacion WHERE Estado_Publicacion_Desc='Borrador'),Publicacion_Puede_Preguntar='" + aceptaPregunta + "',Publicacion_Usuario_Nombre='" + userName + "',Publicacion_Visibilidad_Cod=@visibilidad WHERE Publicacion_Codigo="+public_Codigo;
            cmd = new SqlCommand(Comando, cManager.conexion.conn);
            if (precio == "")
                cmd.Parameters.AddWithValue("@precio", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@precio", Convert.ToDecimal(precio));
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

            Comando = "DELETE FROM NO_MORE_SQL.Rubro_Publicacion WHERE Publicacion_Codigo=" + public_Codigo;
            cmd = new SqlCommand(Comando, cManager.conexion.conn);
            cmd.ExecuteNonQuery();



                
                
            foreach (string check in checkeados)
                {
                    Comando = "INSERT INTO NO_MORE_SQL.Rubro_Publicacion(Publicacion_Codigo,Rubro_Codigo) VALUES (" + public_Codigo + ",(SELECT Rubro_Codigo FROM NO_MORE_SQL.Rubro WHERE Rubro_Descripcion='" + check.ToString() + "'))";
                    cmd = new SqlCommand(Comando, cManager.conexion.conn);
                    cmd.ExecuteNonQuery();
                }


        }

        internal void cargarDatosGenerar(SistemManager cManager, FormGenerarPublicacion formGenerarPublicacion, string publicacion_cod)
        {

           string comando;
            
           SqlCommand cmd;

           SqlDataReader dr;

           comando = "SELECT Tipo_Publicacion_Desc,Publicacion_Descripcion,Publicacion_Precio,Publicacion_Stock,Publicacion_Puede_Preguntar,Visibilidad_Descripcion FROM NO_MORE_SQL.Publicacion LEFT JOIN NO_MORE_SQL.Publicacion_Visibilidad ON NO_MORE_SQL.Publicacion.Publicacion_Visibilidad_Cod=NO_MORE_SQL.Publicacion_Visibilidad.Visibilidad_Codigo LEFT JOIN NO_MORE_SQL.Tipo_Publicacion ON Publicacion_Tipo_ID=Tipo_Publicacion_ID WHERE Publicacion_Codigo=" + publicacion_cod;

           cmd = new SqlCommand(comando, cManager.conexion.conn);

           dr = cmd.ExecuteReader();

           dr.Read();

           formGenerarPublicacion.comboBoxTipoPublicacion.Text = dr["Tipo_Publicacion_Desc"].ToString();

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
            SqlDataAdapter adapComando = new SqlDataAdapter("SELECT Publicacion_Codigo,Tipo_Publicacion_Desc,Publicacion_Descripcion,Estado_Publicacion_Desc FROM NO_MORE_SQL.Publicacion INNER JOIN NO_MORE_SQL.Pregunta ON NO_MORE_SQL.Publicacion.Publicacion_Codigo=NO_MORE_SQL.Pregunta.Pregunta_Publicacion_Cod INNER JOIN NO_MORE_SQL.Estado_Publicacion ON NO_MORE_SQL.Publicacion.Publicacion_Estado_Publicacion_ID=NO_MORE_SQL.Estado_Publicacion.Estado_Publicacion_ID INNER JOIN NO_MORE_SQL.Tipo_Publicacion ON NO_MORE_SQL.Publicacion.Publicacion_Tipo_ID=NO_MORE_SQL.Tipo_Publicacion.Tipo_Publicacion_ID  WHERE Publicacion_Usuario_Nombre= '" + userName + "' AND Pregunta_Respuesta_ID IS NULL", cManager.conexion.conn);
            cManager.conexion.adaptarTablaAlComando(adapComando, dataGridView, true, 3);
            dataGridView.Columns["Publicacion_Codigo"].Visible = true;
        }

        internal void modificarPublicacionCompleta(SistemManager cManager, string tipoPublicacion, string descripcion, string stockInicial, string precio, int visibilidad, string aceptaPregunta, string userName, CheckedListBox.CheckedItemCollection checkeados, string accion, string public_Cod)
        {
            SqlCommand Cmd;
            String Comando = "UPDATE NO_MORE_SQL.Publicacion SET Publicacion_Descripcion='" + descripcion + "',Publicacion_Stock=" + stockInicial + ",Publicacion_Fecha_Vencimiento=NO_MORE_SQL.fecha_segun_publicacion(" + visibilidad.ToString() + ",'" + Configuracion.Default.FechaHoy.ToShortDateString() + "'),Publicacion_Fecha_Inicio='" + Configuracion.Default.FechaHoy.ToShortDateString() + "',Publicacion_Precio=" + precio.ToString() + ",Publicacion_Tipo_ID='" + tipoPublicacion + "',Publicacion_Estado_Edicion='Publicada',Publicacion_Estado_Publicacion_ID='Activa',Publicacion_Puede_Preguntar='" + aceptaPregunta + "',Publicacion_Usuario_Nombre='" + userName + "',Publicacion_Visibilidad_Cod=" + visibilidad.ToString() + ",Publicacion_Visibilidad_Cobrada='NO') WHERE Publicacion_Codigo=" + public_Cod; 
            Cmd = new SqlCommand(Comando, cManager.conexion.conn);
            Cmd.ExecuteNonQuery();
        }

        internal void ObtenerPublicacionesSegunUsuarioYPreguntasConRespuestas(SistemManager cManager, string userName, DataGridView dataGridView)
        {

            SqlDataAdapter adapComando = new SqlDataAdapter("SELECT Pregunta_Usuario_Nombre,Publicacion_Codigo,Tipo_Publicacion_Desc,Publicacion_Descripcion,Publicacion_Estado_Publicacion_ID,Pregunta_Descripcion,Publicacion_Usuario_Nombre,Pregunta_Respuesta_ID,Respuesta_Fecha FROM NO_MORE_SQL.Publicacion INNER JOIN NO_MORE_SQL.Pregunta ON NO_MORE_SQL.Publicacion.Publicacion_Codigo=NO_MORE_SQL.Pregunta.Pregunta_Publicacion_Cod INNER JOIN NO_MORE_SQL.Respuesta ON NO_MORE_SQL.Pregunta.Pregunta_Respuesta_ID=NO_MORE_SQL.Respuesta.Respuesta_ID INNER JOIN NO_MORE_SQL.Tipo_Publicacion ON NO_MORE_SQL.Publicacion.Publicacion_Tipo_ID=NO_MORE_SQL.Tipo_Publicacion.Tipo_Publicacion_ID WHERE Pregunta_Usuario_Nombre= '" + userName + "' AND Pregunta_Respuesta_ID IS NOT NULL", cManager.conexion.conn);
            cManager.conexion.adaptarTablaAlComando(adapComando, dataGridView, true, 3);
            dataGridView.Columns["Publicacion_Codigo"].Visible = false;
            dataGridView.Columns["Pregunta_Respuesta_ID"].Visible = false;
            dataGridView.Columns["Respuesta_Fecha"].Visible = false;
        }

        internal void volverLogin3Compras(SistemManager cManager, string usuario)
        {
            throw new NotImplementedException();
        }

        internal void volverLogin5Compras(SistemManager cManager, string usuario)
        {

        }
    }

}





/*
            if (tipoPublicacion.Equals("SUBASTA")) publicacion.tipoPublicacion = new Subasta();
            else publicacion.tipoPublicacion = new StockComun();
            */