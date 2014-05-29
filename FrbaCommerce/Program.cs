using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Vista.AM_de_Empresa.Form1());
            //Application.Run(new Vista.Registro_de_Usuario.Form1());
            
            //Form vtnUsuario = new Vista.Registro_de_Usuario.Form1();
            //vtnUsuario.Show();
            /*
            Model.Usuarios usr = new Model.Usuarios();
            usr.AltaUsuarios(1,2,"fballarini");
            
            DAL.UsuariosDAL usrDAL = new FrbaCommerce.DAL.UsuariosDAL();
            usrDAL.InsertarUsuario(usr);
            */
        }
    }
}
