using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Controller
{
    class Respuestas
    {
        //GENERA LA RESPUESTA A UNA PREGUNTA
        public static void ResponderPregunta(int idPregunta,String respuesta)
        {
            try
            {
                DAL.RespuestasDAL respDAL = new FrbaCommerce.DAL.RespuestasDAL();

                respDAL.GenerarRespuesta(idPregunta,respuesta,Controller.Validaciones.ObtenerFechaSistema());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
