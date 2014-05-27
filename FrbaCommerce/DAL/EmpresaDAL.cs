using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace FrbaCommerce.DAL
{
    class EmpresaDAL
    {
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
                
                SqlCommand comando = new SqlCommand(@"INSERT INTO Empresas 
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
                                                            FechaCreacion
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
                                                            @FechaCreacion
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
                                                  FROM Empresas
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
                                                      FROM Empresas
                                                      WHERE Cuit = @Cuit", conexion);
                
                comando.Parameters.AddWithValue("@Cuit", Cuit);
                dt.Load(comando.ExecuteReader());

                return (dt.Rows.Count>0);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
