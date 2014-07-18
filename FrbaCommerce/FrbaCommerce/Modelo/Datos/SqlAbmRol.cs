using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace FrbaCommerce.Modelo.Datos
{
    public class SqlAbmRol
    {
        
            public SqlAbmRol() { }

        internal void altaRol(SistemManager cManager, string nombreRol, Control.ControlCollection funcionalidades)
        {
            try
            {
                SqlCommand MyCmd2;
                string ComandoInsertar;
                String ComandoInsert = "INSERT INTO NO_MORE_SQL.Rol(Rol_Nombre) VALUES('" + nombreRol + "')";
                SqlCommand MyCmd = new SqlCommand(ComandoInsert, cManager.conexion.conn);
                MyCmd.ExecuteNonQuery();

                ComandoInsertar = "UPDATE NO_MORE_SQL.Rol set Esta_Habilitada='SI' WHERE Rol_Nombre='" + nombreRol + "'";
                MyCmd2 = new SqlCommand(ComandoInsertar, cManager.conexion.conn);
                MyCmd2.ExecuteNonQuery();

                foreach (CheckBox chekBox in funcionalidades)
                {
                    if (chekBox.Checked)
                    {

                            ComandoInsertar = "INSERT INTO NO_MORE_SQL.Funcionalidad_Rol(Rol_ID,Funcionalidad_Tipo) VALUES((SELECT Rol_ID FROM NO_MORE_SQL.Rol WHERE Rol_Nombre ='" + nombreRol + "'),'" + chekBox.Name + "')";
                            MyCmd2 = new SqlCommand(ComandoInsertar, cManager.conexion.conn);
                            //   MyCmd2.ExecuteScalar();
                            MyCmd2.ExecuteNonQuery();

                        
                    }
                }
                MessageBox.Show("Rol creado exitosamente");
            }
            catch (SqlException ex)
            {

                switch (ex.Number)
                {
                 
                    case 8152:
                        MessageBox.Show("Cantidad de caracteres excedidos en el nombre del Rol");
                        break;
                    case 2627:
                        MessageBox.Show("Rol Ya Creado");
                        break;
                    default:
                        break;
                }
            }
            
        }
     

        internal void Buscar(SistemManager cManager, DataGridView gridViewFR)
        {
            SqlDataAdapter adapComando = new SqlDataAdapter("SELECT Rol_Nombre FROM NO_MORE_SQL.Rol", cManager.conexion.conn);
            adaptarTablaAlComando(adapComando, gridViewFR, true);
            
        }

        internal void BuscarSinHabilitados(SistemManager cManager, DataGridView gridViewFR)
        {
            SqlDataAdapter adapComando = new SqlDataAdapter("SELECT Rol_Nombre FROM NO_MORE_SQL.Rol WHERE Esta_Habilitada='SI'", cManager.conexion.conn);
            adaptarTablaAlComando(adapComando, gridViewFR, true);

        }

       
        private void adaptarTablaAlComando(SqlDataAdapter adapComando, DataGridView dataGridViewFR, bool filaSeleccion)
        {
            DataTable tabla = new DataTable();
            adapComando.Fill(tabla);
            dataGridViewFR.DataSource = tabla;
            adapComando.Update(tabla);
            dataGridViewFR.Columns[0].Visible = true;
            dataGridViewFR.Columns[0].DisplayIndex = 1;
            adapComando.Update(tabla);
        }

        internal void cargarDatosDeModificacion(SistemManager cManager, FrbaCommerce.ABM_Rol.FormAltaRol formAltaRol, string nombre)
        {
            SqlCommand cmd = new SqlCommand("NO_MORE_SQL.Enviar_Funcionalidades", cManager.conexion.conn);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.AddWithValue("@rol", nombre);
            /*      POSIBLE ADAPTACION
            SqlDataAdapter adapComando = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            */
            SqlDataReader dr = cmd.ExecuteReader();
            //formAltaRol.textBoxNombreRol.Text = dr["Rol_Nombre"].ToString();

            formAltaRol.textBoxNombreRol.Text = nombre;
            formAltaRol.rolActual.setNombre(nombre);

            while(dr.Read())
            {
                foreach (CheckBox chekBox in formAltaRol.groupBoxFuncionalidades.Controls)
                {
                    if (chekBox.Name.Equals(dr["Funcionalidad_Tipo"].ToString()))
                    {
                        chekBox.Checked = true;
                        formAltaRol.rolActual.setFuncionalidades(dr["Funcionalidad_Tipo"].ToString());
                    }
                }
            }

            dr.Close();

            cmd = new SqlCommand("Select Esta_Habilitada from NO_MORE_SQL.Rol WHERE Rol_Nombre='" + nombre + "'", cManager.conexion.conn);
            dr = cmd.ExecuteReader();
            dr.Read();
            if(dr["Esta_Habilitada"].ToString()=="SI")
            foreach (CheckBox chekBox in formAltaRol.groupBoxFuncionalidades.Controls)
                {
                    if (chekBox.Name.Equals("Habilitar_Rol"))
                    {
                        chekBox.Checked = true;
                    }
                }

            dr.Close();

        }

        internal void cargarDatosDeBaja(SistemManager cManager, string rol)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult confirmarBaja = MessageBox.Show("Desea dar de baja " +rol,"Baja de Rol",buttons);
            if (DialogResult.Yes == confirmarBaja)
            {
                //Habilitado pasa a ser false con una consulta Sql ACÀ
                SqlCommand comando;
                string bajastring = "UPDATE NO_MORE_SQL.Rol SET Esta_Habilitada='NO' WHERE Rol_Nombre='" + rol + "'";
                comando = new SqlCommand(bajastring, cManager.conexion.conn);
                comando.ExecuteNonQuery();

                bajastring = "UPDATE NO_MORE_SQL.Usuario SET Usuario_Rol_ID =NULL WHERE Usuario_Rol_ID=(SELECT Rol_ID FROM NO_MORE_SQL.Rol WHERE Rol_Nombre='" + rol + "')";
                comando = new SqlCommand(bajastring, cManager.conexion.conn);
                comando.ExecuteNonQuery();


                MessageBox.Show("el rol " + rol + " a sido deshabilitado");
            }
            if (DialogResult.No == confirmarBaja)
            {
                //No pasa nada, vuelve al menu principal
            }
        
        }

        internal void modificarRol(SistemManager cManager, string p, Control.ControlCollection controlCollection, Sistema.Rol rolActual)
        {

            String ComandoInsertar;
            String ComandoBorrar = "DELETE FROM NO_MORE_SQL.Funcionalidad_Rol WHERE Rol_ID=(SELECT Rol_ID FROM NO_MORE_SQL.Rol WHERE Rol_Nombre= '" + p + "')";
            SqlCommand MyCmd;

            if (p != rolActual.getNombre())
            {

                ComandoInsertar = "UPDATE NO_MORE_SQL.Rol SET Rol_Nombre =  '" + p + "' WHERE Rol_Nombre ='" + rolActual.getNombre() + "'";
                MyCmd = new SqlCommand(ComandoInsertar, cManager.conexion.conn);
                MyCmd.ExecuteNonQuery();


            }

            MyCmd = new SqlCommand(ComandoBorrar, cManager.conexion.conn);
            MyCmd.ExecuteNonQuery();

            foreach (CheckBox chekBox in controlCollection)
            {
                if (chekBox.Checked == true)
                {
                    if (chekBox.Name == "Habilitar_Rol")
                    {
                        ComandoInsertar = "UPDATE NO_MORE_SQL.Rol SET Esta_Habilitada='SI' WHERE Rol_Nombre='" + p + "'";
                        MyCmd = new SqlCommand(ComandoInsertar, cManager.conexion.conn);
                        MyCmd.ExecuteNonQuery();
                    }
                    else
                    {
                        ComandoInsertar = "INSERT INTO NO_MORE_SQL.Funcionalidad_Rol(Rol_ID,Funcionalidad_Tipo) VALUES ((SELECT Rol_ID FROM NO_MORE_SQL.Rol WHERE Rol_Nombre ='" + p + "'),'" + chekBox.Name.ToString() + "')";
                        MyCmd = new SqlCommand(ComandoInsertar, cManager.conexion.conn);
                        MyCmd.ExecuteNonQuery();
                    }
                }

            }
            MessageBox.Show("el rol " + rolActual.getNombre() + " a sido modificado");

        }

    }
}



    /*  si cambia nombre rol deberiamos hacer un update com nombre rol
                String ComandoInsert = @"INSERT INTO Rol(Rol_Nombre) VALUES('" + nombreRol + "')";
                SqlCommand MyCmd = new SqlCommand(ComandoInsert, cManager.conexion.conn);
                MyCmd.ExecuteScalar();
                */