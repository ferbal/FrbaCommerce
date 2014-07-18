using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace FrbaCommerce
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        ///         
        [STAThread]
        static void Main()
        {
            //String password = Controller.Usuarios.encriptarPassword("12345678");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);                       

            View.Login.LoginForm vtnLogin = new FrbaCommerce.View.Login.LoginForm();
            vtnLogin.cargarDatos(Convert.ToDateTime(LeerFechaArchConfig()));
            Application.Run(vtnLogin);            
        }

        private static String LeerFechaArchConfig()
        {
            String str = String.Empty;

            StreamReader or = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\config.txt");

            str = or.ReadLine();


            str = or.ReadLine();

            if (!String.IsNullOrEmpty(str))
            {
                while (str.Substring(0, 6).CompareTo("Fecha=") != 0)                            
                {
                    str = or.ReadLine();
                }
                if (str.Substring(0, 6).CompareTo("Fecha=") == 0)
                    str = str.Substring(6);
            }
            return str;
        }
    }
}
