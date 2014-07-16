using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FrbaCommerce.Controller
{
    class Validaciones
    {
        private static DateTime fechaSistema = DateTime.MinValue;

        public static DateTime ObtenerFechaSistema()
        {
            if (fechaSistema == DateTime.MinValue)
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

                fechaSistema = Convert.ToDateTime(str);
            }
            return fechaSistema;
        }
    }           
}
