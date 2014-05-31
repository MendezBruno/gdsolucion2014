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
                String ComandoInsert = @"INSERT INTO Rol(Rol_Nombre) VALUES('" + nombreRol + "')";
                SqlCommand MyCmd = new SqlCommand(ComandoInsert, cManager.conexion.conn);
              //  MyCmd.ExecuteScalar();
               MyCmd.ExecuteNonQuery();

                foreach (CheckBox chekBox in funcionalidades)
                {
                    if (chekBox.Checked)
                    {
                       // ComandoInsert = @"INSERT INTO Funcionalidad_Rol(Rol_Nombre,Funcionalidad_Tipo) VALUES('" + nombreRol + "','" + chekBox.Name + "')";
                        ComandoInsertar = @"INSERT INTO Funcionalidad_Rol(Rol_Nombre,Funcionalidad_Tipo) VALUES ('" + nombreRol + "','" + chekBox.Name.ToString() + "')";
                        MyCmd2 = new SqlCommand(ComandoInsertar, cManager.conexion.conn);
                     //   MyCmd2.ExecuteScalar();
                        MyCmd2.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Rol creado exitosamente");
            }
            catch (SqlException ex)
            {
                //MessageBox.Show(ex.Number.ToString());
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
     

        internal void Buscar(SistemManager cManager, string NombreRol, string Funcionalidad, DataGridView gridViewFR)
        {
            SqlDataAdapter adapComando = new SqlDataAdapter("SELECT DISTINCT * FROM Funcionalidad_Rol as F WHERE F.Rol_Nombre LIKE '%' + '" + NombreRol + "'+ '%' AND Funcionalidad_Tipo LIKE '%' +'" + Funcionalidad + "'+ '%'", cManager.conexion.conn);
            adaptarTablaAlComando(adapComando, gridViewFR, true);
            
        }
       
        private void adaptarTablaAlComando(SqlDataAdapter adapComando, DataGridView dataGridViewFR, bool filaSeleccion)
        {
            DataTable tabla = new DataTable();
            adapComando.Fill(tabla);
            dataGridViewFR.DataSource = tabla;
            adapComando.Update(tabla);
            dataGridViewFR.Columns[0].Visible = true;
            dataGridViewFR.Columns[0].DisplayIndex = 2;
            adapComando.Update(tabla);
        }

        internal void cargarDatosDeModificacion(SistemManager cManager, FrbaCommerce.ABM_Rol.FormAltaRol formAltaRol, string nombre)
        {
            SqlCommand cmd = new SqlCommand("Enviar_Funcionalidades", cManager.conexion.conn);
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
        }

        internal void cargarDatosDeBaja(SistemManager cManager, FrbaCommerce.ABM_Rol.FormBajaRol formBajaRol, string rol)
        {
            DialogResult confirmarBaja = MessageBox.Show("Desea dar de baja" + rol);
            if (DialogResult.Yes == confirmarBaja)
            {
                //Habilitado pasa a ser false con una consulta Sql ACÀ
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
            String ComandoBorrar = @"DELETE FROM Funcionalidad_Rol WHERE Rol_Nombre='" + p + "'";
            SqlCommand MyCmd = new SqlCommand(ComandoBorrar, cManager.conexion.conn);
            MyCmd.ExecuteNonQuery();
            foreach (CheckBox chekBox in controlCollection)
            {
                if (chekBox.Checked == true)
                {
                    ComandoInsertar = @"INSERT INTO Funcionalidad_Rol(Rol_Nombre,Funcionalidad_Tipo) VALUES ('" + p + "','" + chekBox.Name.ToString() + "')";
                    SqlCommand Cmd = new SqlCommand(ComandoInsertar, cManager.conexion.conn);
                    Cmd.ExecuteNonQuery();
                }
            }
        }
        /* 
         internal void modificarRol(SistemManager cManager, string nombreRol, Control.ControlCollection funcionalidades, Sistema.Rol rolActual)
         {
             string ComandoInsert;
             try
             {
                
                  
                 foreach (CheckBox chekBox in funcionalidades)
                 {
                     if (chekBox.Checked)
                     {
                         if (!rolActual.poseeFuncionalidad(chekBox.Name))
                         {
                             ComandoInsert = @"INSERT INTO Funcionalidad_Rol(Rol_Nombre,Funcionalidad_Tipo) VALUES('" + nombreRol + "','" + chekBox.Name + "')";
                             SqlCommand MyCmd = new SqlCommand(ComandoInsert, cManager.conexion.conn);
                             MyCmd = new SqlCommand(ComandoInsert, cManager.conexion.conn);
                             MyCmd.ExecuteScalar();
                             MyCmd.Dispose();
                         }

                     }
                     else
                     {
                         if (rolActual.poseeFuncionalidad(chekBox.Name))
                         {
                             ComandoInsert = @"DELETE FROM Funcionalidad_Rol WHERE Rol_Nombre='" + nombreRol + "' AND Funcionalidad_Tipo='" + chekBox.Name + "'";
                             SqlCommand MyCmd = new SqlCommand(ComandoInsert, cManager.conexion.conn);
                             MyCmd = new SqlCommand(ComandoInsert, cManager.conexion.conn);
                             MyCmd.ExecuteScalar();
                             MyCmd.Dispose();
                         }
                     }

                 }
                 MessageBox.Show("Rol actualizado correctamente");
             }
             catch (SqlException ex)
             {
                 //MessageBox.Show(ex.Number.ToString());
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
         }*/
    }
}



    /*  si cambia nombre rol deberiamos hacer un update com nombre rol
                String ComandoInsert = @"INSERT INTO Rol(Rol_Nombre) VALUES('" + nombreRol + "')";
                SqlCommand MyCmd = new SqlCommand(ComandoInsert, cManager.conexion.conn);
                MyCmd.ExecuteScalar();
                */