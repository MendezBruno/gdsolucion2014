using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema;

namespace FrbaCommerce.Modelo.Datos
{
    public class SqlAdministrador
    {

        internal void ObtenerAdministrador(Usuario user, Administrador administrador,SistemManager cManager)
        {

          
            administrador.usuarioId = user.usuarioId;
            administrador.habilitado = user.habilitado;
            administrador.RolAsignado = user.RolAsignado;
            administrador.setUsuario(user.getUsuario());
            administrador.setPassword(user.getPassword());
            administrador.tipoUsuario = user.tipoUsuario;
        }



    }
}
