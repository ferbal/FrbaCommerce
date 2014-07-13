using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FrbaCommerce.Controller
{
    class Validaciones
    {
        public static DateTime ObtenerFechaSistema()
        {     
            String str = String.Empty;

            StreamReader or = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\config.txt");
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
            return Convert.ToDateTime(str);
        }
    }           
}
