using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;


namespace FrbaCommerce.Controller
{
    class Roles
    {
        //INGRESAR UN NUEVO ROL
        public static void IngresarNuevoRol(String nombre,List<int> listaFunc)
        {
            SqlConnection conexion = DAL.Conexion.getConexion();
            //SqlTransaction ts = conexion.BeginTransaction();
            CommittableTransaction ts = new CommittableTransaction();
            conexion.EnlistTransaction(ts);
            try
            {                                
                DAL.RolesDAL rolDAL = new FrbaCommerce.DAL.RolesDAL();
                DAL.RolesFuncionalidadesDAL rfDAL = new FrbaCommerce.DAL.RolesFuncionalidadesDAL();

                rolDAL.InsertarRol(nombre);

                int idRol = rolDAL.ObtenerRolPorNombre(nombre);

                foreach (int i in listaFunc)
                {
                    rfDAL.InsertarFuncionalidadRol(idRol, i);
                }

                ts.Commit();
                
                ts.Dispose();
            }
            catch (Exception ex)
            {
                ts.Rollback();
                ts.Dispose();
                throw ex;                
            }
        }
        //ACTUALIZAR UN ROL EXISTENTE
        public static void ActualizarRol(int id, String nombre, List<int> listaFunc)
        {
            SqlConnection conexion = DAL.Conexion.getConexion();
            //SqlTransaction ts = conexion.BeginTransaction();
            CommittableTransaction ts = new CommittableTransaction();
            conexion.EnlistTransaction(ts);

            try
            {               
                DAL.RolesDAL rolDAL = new FrbaCommerce.DAL.RolesDAL();
                DAL.RolesFuncionalidadesDAL rfDAL = new FrbaCommerce.DAL.RolesFuncionalidadesDAL();

                rfDAL.EliminarFuncionalidadDeRol(id);

                rolDAL.ActualizarRol(id,nombre);

                foreach (int i in listaFunc)
                {
                    rfDAL.InsertarFuncionalidadRol(id, i);
                }

                ts.Commit();

                ts.Dispose();
            }
            catch (Exception ex)
            {
                ts.Rollback();
                ts.Dispose();
                throw ex;
            }
        }
        //ELIMINAR UN ROL EXISTENTE
        public static void EliminarRol(int id)
        {
            try
            {
                DAL.RolesDAL rolDAL = new FrbaCommerce.DAL.RolesDAL();
                DAL.RolesFuncionalidadesDAL rfDAL = new FrbaCommerce.DAL.RolesFuncionalidadesDAL();

                rfDAL.EliminarFuncionalidadDeRol(id);
                rolDAL.EliminarRol(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
