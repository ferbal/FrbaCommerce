using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace FrbaCommerce.DAL
{
    class EmpresasDAL
    {

        public DataTable listarEmpresas(String razonSocial,String cuit,String email)
        {

            SqlConnection conexion = DAL.Conexion.getConexion();
            DataTable dt = new DataTable();
            try
            {
                String where = String.Empty;
                if(!String.IsNullOrEmpty(razonSocial) && !String.IsNullOrEmpty(cuit) && !String.IsNullOrEmpty(email)){
                    where = " AND RazonSocial LIKE '%" + razonSocial + "%' AND CUIT LIKE '%" + cuit + "%' AND Mail LIKE '%" + email + "%'";
                }else{
                    if(!String.IsNullOrEmpty(razonSocial) && !String.IsNullOrEmpty(cuit)){
                        where = " AND RazonSocial LIKE '%" + razonSocial + "%' AND CUIT LIKE '%" + cuit + "%'";
                    }else{
                        if (!String.IsNullOrEmpty(cuit) && !String.IsNullOrEmpty(email)){
                            where = " AND CUIT LIKE '%" + cuit + "%' AND Mail LIKE '%" + email + "%'";
                        }else{
                            if (!String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(razonSocial)){
                                where = " AND RazonSocial LIKE '%" + razonSocial + "%' AND Mail LIKE '%" + email + "%'";
                            }else{
                                if (!String.IsNullOrEmpty(cuit)){
                                    where = " AND CUIT LIKE '%" + cuit + "%'";
                                }else{
                                    if (!String.IsNullOrEmpty(razonSocial)){
                                        where = " AND RazonSocial LIKE '%" + razonSocial + "%'";
                                    }else{
                                        if (!String.IsNullOrEmpty(email)){
                                            where = " AND Mail LIKE '%" + email + "%'";
                                        }else{
                                            where = "";
                                        }
                                    }    
                                }
                            }
                        }
                    }
                }

                SqlCommand comando = new SqlCommand(@"  SELECT 
                                                        E.RazonSocial,
                                                        E.CUIT,
                                                        E.Mail,
	                                                    E.NombreContacto,
	                                                    E.Telefono,
	                                                    E.Calle,
	                                                    E.PisoNro,
	                                                    E.Depto,
	                                                    E.Localidad,
	                                                    E.CodigoPostal,
	                                                    E.FechaCreacion,
                                                        est.Descripcion,
                                                        E.IdEmpresa,
                                                        E.idEstado

                                                        FROM BAZINGUEANDO_EN_SLQ.Empresas E
														INNER JOIN BAZINGUEANDO_EN_SLQ.Estados Est
                                                        ON E.idEstado = Est.idEstado

                                                        WHERE E.IdEstado = Est.idEstado
                                                        " + where, conexion);                


                dt.Load(comando.ExecuteReader());

                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*
 * 	IdEmpresa INT IDENTITY(1,1) NOT NULL,
                        RazonSocial VARCHAR(50) NULL,
                        CUIT VARCHAR(11) NULL,
                        NombreContacto VARCHAR(20) NULL,
                        Mail VARCHAR(25) NULL,
                        Telefono VARCHAR(15) NOT NULL,
                        Calle VARCHAR(20) NULL,
                        PisoNro INT NULL,
                        Depto VARCHAR(1) NULL,
                        Localidad VARCHAR(20) NULL,
                        CodigoPostal INT NULL,
                        FechaCreacion DATE NOT NULL,

 * */
        public int insertarEmpresa(Model.Empresas empresa)
        {
            SqlConnection conexion = DAL.Conexion.getConexion();

            try
            {

                SqlCommand comando = new SqlCommand(@"INSERT INTO BAZINGUEANDO_EN_SLQ.Empresas 
                                                        (
                                                            RazonSocial,
                                                            Cuit,
                                                            NombreContacto,
                                                            Mail,
                                                            Telefono,
                                                            Calle,
                                                            PisoNro,
                                                            Depto,
                                                            Localidad,
                                                            CodigoPostal,
                                                            FechaCreacion,
                                                            idEstado
                                                        )
                                                    VALUES
                                                        (
                                                            @RazonSocial,
                                                            @Cuit,
                                                            @NombreContacto,
                                                            @Mail,
                                                            @Telefono,
                                                            @Calle,
                                                            @PisoNro,
                                                            @Depto,
                                                            @Localidad,
                                                            @CodigoPostal,
                                                            @FechaCreacion,
                                                            @estado
                                                        )"
                                                            , conexion);

                comando.Parameters.AddWithValue("@RazonSocial", empresa.RazonSocial);
                comando.Parameters.AddWithValue("@Cuit", empresa.Cuit);
                comando.Parameters.AddWithValue("@NombreContacto", empresa.NombreContacto);
                comando.Parameters.AddWithValue("@Mail", empresa.Mail);
                comando.Parameters.AddWithValue("@Telefono", empresa.Telefono);
                comando.Parameters.AddWithValue("@Calle", empresa.Calle);
                comando.Parameters.AddWithValue("@PisoNro", empresa.PisoNro);
                comando.Parameters.AddWithValue("@Depto", empresa.Depto);
                comando.Parameters.AddWithValue("@Localidad", empresa.Localidad);
                comando.Parameters.AddWithValue("@CodigoPostal", empresa.CodigoPostal);
                comando.Parameters.AddWithValue("@FechaCreacion", empresa.FechaCreacion);
                comando.Parameters.AddWithValue("@estado", empresa.IdEstado);

                return (int)comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int loadPorCuit(String Cuit)
        {
            SqlConnection conexion = DAL.Conexion.getConexion();

            try
            {

                DataTable dt = new DataTable();

                SqlCommand comando = new SqlCommand(@"SELECT IdEmpresa
                                                  FROM BAZINGUEANDO_EN_SLQ.Empresas
                                                  WHERE Cuit = @Cuit", conexion);
                comando.Parameters.AddWithValue("@Cuit", Cuit);
                dt.Load(comando.ExecuteReader());

                return (int)dt.Rows[0][0];

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean ExisteEmpresaPorCuit(String Cuit)
        {
            SqlConnection conexion = DAL.Conexion.getConexion();

            try
            {

                DataTable dt = new DataTable();

                SqlCommand comando = new SqlCommand(@"SELECT *
                                                      FROM BAZINGUEANDO_EN_SLQ.Empresas
                                                      WHERE Cuit = @Cuit", conexion);

                comando.Parameters.AddWithValue("@Cuit", Cuit);
                dt.Load(comando.ExecuteReader());

                return (dt.Rows.Count > 0);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int actualizarEmpresa(int idEmpresa, Model.Empresas empresa)
        {
            SqlConnection conexion = DAL.Conexion.getConexion();

            try
            {

                SqlCommand comando = new SqlCommand(@"UPDATE BAZINGUEANDO_EN_SLQ.Empresas 
                                                      SET  
                                                            RazonSocial = @RazonSocial,
                                                            Cuit = @Cuit,
                                                            NombreContacto = @NombreContacto,
                                                            Mail = @Mail,
                                                            Telefono = @Telefono,
                                                            Calle = @Calle,
                                                            PisoNro = @PisoNro,
                                                            Depto = @Depto,
                                                            Localidad = @Localidad,
                                                            CodigoPostal = @CodigoPostal,
                                                            FechaCreacion = @FechaCreacion,
                                                            idEstado = @estado

                                                    WHERE idEmpresa = @idEmpresa"
                                                            , conexion);

                comando.Parameters.AddWithValue("@RazonSocial", empresa.RazonSocial);
                comando.Parameters.AddWithValue("@Cuit", empresa.Cuit);
                comando.Parameters.AddWithValue("@NombreContacto", empresa.NombreContacto);
                comando.Parameters.AddWithValue("@Mail", empresa.Mail);
                comando.Parameters.AddWithValue("@Telefono", empresa.Telefono);
                comando.Parameters.AddWithValue("@Calle", empresa.Calle);
                comando.Parameters.AddWithValue("@PisoNro", empresa.PisoNro);
                comando.Parameters.AddWithValue("@Depto", empresa.Depto);
                comando.Parameters.AddWithValue("@Localidad", empresa.Localidad);
                comando.Parameters.AddWithValue("@CodigoPostal", empresa.CodigoPostal);
                comando.Parameters.AddWithValue("@FechaCreacion", empresa.FechaCreacion);
                comando.Parameters.AddWithValue("@estado", empresa.IdEstado);
                comando.Parameters.AddWithValue("@idEmpresa", empresa.IdEmpresa);

                return (int)comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int BajaLogicaEmpresa(int idEmpresa, Model.Empresas empresa)
        {
            SqlConnection conexion = DAL.Conexion.getConexion();

            try
            {

                SqlCommand comando = new SqlCommand(@"UPDATE BAZINGUEANDO_EN_SLQ.Empresas 
                                                      SET  
                                                            idEstado = @estado
                                                    WHERE idEmpresa = @idEmpresa"
                                                            , conexion);

                comando.Parameters.AddWithValue("@estado", empresa.IdEstado);
                comando.Parameters.AddWithValue("@idEmpresa", empresa.IdEmpresa);

                return (int)comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
