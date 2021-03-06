﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FrbaCommerce.Controller
{
    class Preguntas
    {
        //GENERA UN LISTADO DE PREGUNTAS SIN RESPUESTA POR USUARIO
        public static DataTable ObtenerPregSinRespuesta(int usuario)
        {
            try
            {
                DAL.PreguntasDAL pregDAL = new FrbaCommerce.DAL.PreguntasDAL();

                return pregDAL.ObtenerPreguntasSinRespuestas(usuario);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //GENERA UN LISTADO DE PREGUNTAS CON RESPUESTA POR USUARIO
        public static DataTable ObtenerPregConRespuesta(int usuario)
        {
            try
            {
                DAL.PreguntasDAL pregDAL = new FrbaCommerce.DAL.PreguntasDAL();

                return pregDAL.ObtenerPreguntasConRespuestas(usuario);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //GENERA UNA PREGUNTA NUEVA
        public static void GenerarPregunta(int usuario, int publicacion, String pregunta)
        {
            try
            {
                DAL.PreguntasDAL pregDAL = new FrbaCommerce.DAL.PreguntasDAL();

                pregDAL.IngresarNuevaPregunta(usuario,publicacion,pregunta,Controller.Validaciones.ObtenerFechaSistema());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
