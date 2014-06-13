using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Controller
{
    class Empresas
    {
        public static int ingresarNuevaEmpresa(String razonSocial, String cuit, String nombreContacto, String mail, String telefono, String calle, int pisoNro, Char depto, String localidad, int codPost, DateTime fecha,int usr, int estado)
        {
            try
            {
                Model.Empresas emp = new FrbaCommerce.Model.Empresas(razonSocial, cuit, nombreContacto, mail, telefono, calle, pisoNro, depto, localidad, codPost, fecha,usr,estado);
                DAL.EmpresaDAL empDAL = new FrbaCommerce.DAL.EmpresaDAL();

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
    }
}
