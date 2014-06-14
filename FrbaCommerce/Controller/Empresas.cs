﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Controller
{
    class Empresas
    {
<<<<<<< HEAD
        public static int ingresarNuevaEmpresa(String razonSocial, String cuit, String nombreContacto, String mail, String telefono, String calle, int pisoNro, Char depto, String localidad, int codPost, DateTime fecha,int usr, int estado)
        {
            try
            {
                Model.Empresas emp = new FrbaCommerce.Model.Empresas(razonSocial, cuit, nombreContacto, mail, telefono, calle, pisoNro, depto, localidad, codPost, fecha,usr,estado);
                DAL.EmpresaDAL empDAL = new FrbaCommerce.DAL.EmpresaDAL();
=======
        public static int ingresarNuevaEmpresa(String razonSocial, String cuit, String nombreContacto, String mail, String telefono, String calle, int pisoNro, Char depto, String localidad, int codPost, DateTime fecha, int estado)
        {
            try
            {
                Model.Empresas emp = new FrbaCommerce.Model.Empresas(0,razonSocial, cuit, nombreContacto, mail, telefono, calle, pisoNro, depto, localidad, codPost, fecha, estado);
                DAL.EmpresasDAL empDAL = new FrbaCommerce.DAL.EmpresasDAL();
>>>>>>> 6d7830e8900e4de3da80f2cac7bdcbefcb0ab6bc

                if (empDAL.ExisteEmpresaPorCuit(cuit))
                    throw new Exception("La Empresa ya existe.");

                empDAL.insertarEmpresa(emp);

                return empDAL.loadPorCuit(emp.Cuit);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static void modificarEmpresa(int idEmpresa, String razonSocial, String cuit, String nombreContacto, String mail, String telefono, String calle, int pisoNro, Char depto, String localidad, int codPost, DateTime fecha, int estado)
        {
            try
            {
                Model.Empresas emp = new FrbaCommerce.Model.Empresas(idEmpresa,razonSocial, cuit, nombreContacto, mail, telefono, calle, pisoNro, depto, localidad, codPost, fecha, estado);
                DAL.EmpresasDAL empDAL = new FrbaCommerce.DAL.EmpresasDAL();

                //if (empDAL.ExisteEmpresaPorCuit(cuit))
                //    throw new Exception("La Empresa ya existe.");

                empDAL.actualizarEmpresa(idEmpresa, emp);

                //return empDAL.loadPorCuit(emp.Cuit);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void BajaEmpresa(int idEmpresa, String razonSocial, String cuit, String nombreContacto, String mail, String telefono, String calle, int pisoNro, Char depto, String localidad, int codPost, DateTime fecha, int estado)
        {
            try
            {
                Model.Empresas emp = new FrbaCommerce.Model.Empresas(idEmpresa, razonSocial, cuit, nombreContacto, mail, telefono, calle, pisoNro, depto, localidad, codPost, fecha, estado);
                DAL.EmpresasDAL empDAL = new FrbaCommerce.DAL.EmpresasDAL();

                //if (empDAL.ExisteEmpresaPorCuit(cuit))
                //    throw new Exception("La Empresa ya existe.");

                empDAL.BajaLogicaEmpresa(idEmpresa, emp);

                //return empDAL.loadPorCuit(emp.Cuit);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
