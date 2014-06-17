using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FrbaCommerce.Modelo.Datos
{
    public class SqlRol
    {
        internal void ObtenerRol(Sistema.Usuario user, SistemManager cManager)
        {
            //SqlCommand cmd = new SqlCommand("SELECT Count* Funcionalidad_Rol WHERE Rol_ID="+user.RolAsignado.idRol.ToString() 
            //                                +";SELECT * FROM Funcionalidad_Rol WHERE Rol_ID="+user.RolAsignado.idRol.ToString(), cManager.conexion.conn);
           // SqlDataAdapter adapComando = new SqlDataAdapter("SELECT * FROM Funcionalidad_Rol WHERE Rol_ID="+user.RolAsignado.idRol.ToString(), cManager.conexion.conn);
            SqlCommand cmd = new SqlCommand("SELECT * FROM NO_MORE_SQL.Funcionalidad_Rol WHERE Rol_ID=" + user.RolAsignado.idRol.ToString() +
                                            ";SELECT * FROM NO_MORE_SQL.Rol WHERE Rol_ID=" + user.RolAsignado.idRol.ToString(), cManager.conexion.conn);
            
            SqlDataReader dr = cmd.ExecuteReader();
          //  adapComando.SelectCommand.ExecuteScalar();
            while (dr.Read())
            {
                user.RolAsignado.setFuncionalidades(dr["Funcionalidad_Tipo"].ToString());
            }
            dr.NextResult();
            dr.Read();
            user.RolAsignado.setNombre(dr["Rol_Nombre"].ToString());
            if (dr["Esta_Habilitada"].ToString().Equals("SI")) user.RolAsignado.setHabilitado(true);
            else user.RolAsignado.setHabilitado(true);
            dr.Close();
        }
    }
}
