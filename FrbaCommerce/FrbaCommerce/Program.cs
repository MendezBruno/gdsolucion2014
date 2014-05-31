using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.OleDb;
using FrbaCommerce.Modelo;


namespace FrbaCommerce
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
           // SistemManagerSingleton classManagerSingleton = SistemManagerSingleton.Instance;
            SistemManager classManager = new SistemManager(); 
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormPrincipal(classManager));
        }
    }
}
