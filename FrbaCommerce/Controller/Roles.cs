using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Controller
{
    class Roles
    {
        public static void IngresarNuevoRol(String nombre)
        {
            try
            {
                DAL.RolesDAL rolDAL = new FrbaCommerce.DAL.RolesDAL();

                rolDAL.InsertarRol(nombre);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ActualizarRol(int id, String nombre)
        {
            try
            {
                DAL.RolesDAL rolDAL = new FrbaCommerce.DAL.RolesDAL();

                rolDAL.ActualizarRol(id,nombre);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void EliminarRol(int id)
        {
            try
            {
                DAL.RolesDAL rolDAL = new FrbaCommerce.DAL.RolesDAL();

                rolDAL.EliminarRol(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
