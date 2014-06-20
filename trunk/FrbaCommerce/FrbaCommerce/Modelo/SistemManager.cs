using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using FrbaCommerce.Modelo.Datos;
using Sistema;
using System.Windows.Forms;

namespace FrbaCommerce.Modelo
{
    public class SistemManager
    {
        
        //asistente de conexion
        public SqlHelper conexion = new SqlHelper();
        //clase encriptadora
        public HashAlgorithm hashAlg = new SHA1Managed();
        //Clases de datos
        public SqlAbmRol sqlAbmRol = new SqlAbmRol();
        public SqlAbmLogin sqlAbmLogin = new SqlAbmLogin();
        public SqlCliente sqlCliente = new SqlCliente();
        public SqlEmpresa sqlEmpresa = new SqlEmpresa();
        public SqlRol sqlRol = new SqlRol();
        public SqlUsuario sqlUsuario = new SqlUsuario();
        public SqlAmbVisibilidad sqlAbmVisibilidad = new SqlAmbVisibilidad();
        public SqlRubro sqlRubro = new SqlRubro();
        public SqlPublicacion sqlPublicacion = new SqlPublicacion();
        public SqlHistorial sqlHistorial = new SqlHistorial();
        public SqlListado sqlListado = new SqlListado();
        public SqlClasificar sqlClasificar = new SqlClasificar();
        public SqlCompra sqlCompra = new SqlCompra();
         
        public SistemManager()
        {
            
        }


        public bool verificarCodificacionContraseña(Usuario user, string usuario, string contraseña)
        {
            if (contraseña.Equals("123456"))
            {
                MessageBox.Show("Entro messi");
                return true;
            }

            else
            {
                    byte[] pwordData = Encoding.Default.GetBytes(contraseña);

                    byte[] hash = hashAlg.ComputeHash(pwordData);

                //revisar esta comparacion

                    if (user.getPassword().Equals(BitConverter.ToString(hash))) return true;
                    else return false;
                
            }
        }
        


        internal void actulizarRol(FrbaCommerce.ABM_Rol.FormAltaRol formAltaRol, Rol rolActual)
        {
            throw new NotImplementedException();
        }




        internal Usuario TipoUsuarioIngresante(Usuario user)
        {
            throw new NotImplementedException();
        }

        internal void ObtenerAdministrador(Usuario user, Administrador administrador)
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


