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
        HashAlgorithm hashAlg = new SHA1Managed();
        //Clases de datos
        public SqlAbmRol sqlAbmRol = new SqlAbmRol();
        public SqlAbmLogin sqlAbmLogin = new SqlAbmLogin();
        public SqlCliente sqlCliente = new SqlCliente();
        public SqlEmpresa sqlEmpresa = new SqlEmpresa();
        public SqlRol sqlRol = new SqlRol();
        public SqlUsuario sqlUsuario = new SqlUsuario();

        public SistemManager()
        {
            
        }

        
        public bool verificarCodificacionContraseña(Usuario user, string usuario, string contraseña)
        {
            byte[] pwordData = Encoding.Default.GetBytes(contraseña);

            byte[] hash = hashAlg.ComputeHash(pwordData);

            Console.WriteLine(BitConverter.ToString(hash));

            if (user.getPassword().Equals(BitConverter.ToString(hash))) return true;
            else return false;
        }

        public Usuario traerUsuario(string usuario,Usuario user)
        {
         return sqlAbmLogin.ObtenerUsuario(usuario, this, user);
        }


        internal void actulizarRol(FrbaCommerce.ABM_Rol.FormAltaRol formAltaRol, Rol rolActual)
        {
            throw new NotImplementedException();
        }
        

        
    }
}


