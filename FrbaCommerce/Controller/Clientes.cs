﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Controller
{
    class Clientes
    {
        //INGRESA UN NUEVO CLIENTE VERFICANDO SI EL MISMO YA EXISTE.
        //LA VERIFICACION SE REALIZA POR NRO DE DOCUMENTO.
        public static int ingresarClienteNuevo(String nombre,String apellido,int tipoDoc, int nroDoc,String nroCuil,String mail,DateTime fecha,String telefono,String calle,int pisoNro,Char depto, int codPost,String localidad,int usr,int estado)
        {
            try
            {                
                Model.Clientes cli = new FrbaCommerce.Model.Clientes(usr,nombre, apellido, tipoDoc, nroDoc, nroCuil, mail, fecha, telefono, calle, pisoNro, depto, codPost, localidad,estado);
                DAL.ClientesDAL cliDAL = new FrbaCommerce.DAL.ClientesDAL();

                if (cliDAL.existeClientePorNroDoc(nroDoc, tipoDoc))
                    throw new Exception("El Cliente ya existe.");

                cliDAL.InsertarCliente(cli);

                return cliDAL.loadPorNroDoc(cli.NroDocumento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //PERMITE MODIFICAR LOS DATOS DE UN CLIENTE
        public static void modificarCliente(int idCliente, String nombre, String apellido, int tipoDoc, int nroDoc, String nroCuil, String mail, DateTime fecha, String telefono, String calle, int pisoNro, Char depto, int codPost, String localidad, int estado)
        {
            try
            {
                Model.Clientes cli = new FrbaCommerce.Model.Clientes(idCliente, nombre, apellido, tipoDoc, nroDoc, nroCuil, mail, fecha, telefono, calle, pisoNro, depto, codPost, localidad,0, estado);
                DAL.ClientesDAL cliDAL = new FrbaCommerce.DAL.ClientesDAL();
                
                cliDAL.actualizarCliente(idCliente,cli);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        //GENERA LA BAJA LOGICA DEL CLIENTE CAMBIANDO EL ESTADO DEL MISMO
        public static void BajaCliente(int idCliente, String nombre, String apellido, int tipoDoc, int nroDoc, String nroCuil, String mail, DateTime fecha, String telefono, String calle, int pisoNro, Char depto, int codPost, String localidad, int estado)
        {
            try
            {
                Model.Clientes cli = new FrbaCommerce.Model.Clientes(nombre, apellido, tipoDoc, nroDoc, nroCuil, mail, fecha, telefono, calle, pisoNro, depto, codPost, localidad, estado);
                DAL.ClientesDAL cliDAL = new FrbaCommerce.DAL.ClientesDAL();

                cliDAL.BajaLogicaCliente(idCliente, cli);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
