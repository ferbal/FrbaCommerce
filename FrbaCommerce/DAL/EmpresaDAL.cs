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

            comando.Parameters.Add("@RazonSocial",empresa.RazonSocial);
            comando.Parameters.Add("@Cuit",empresa.Cuit);
            comando.Parameters.Add("@NombreContacto",empresa.NombreContacto);
            comando.Parameters.Add("@Mail",empresa.Mail);
            comando.Parameters.Add("@Telefono",empresa.Telefono);
            comando.Parameters.Add("@Calle",empresa.Calle);
            comando.Parameters.Add("@PisoNro",empresa.PisoNro);
            comando.Parameters.Add("@Depto",empresa.Depto);
            comando.Parameters.Add("@Localidad",empresa.Localidad);
            comando.Parameters.Add("@CodigoPostal",empresa.CodigoPostal);
            comando.Parameters.Add("@FechaCreacion",empresa.FechaCreacion);

            return (int) comando.ExecuteNonQuery();
        }

        public int loadPorCuit(String Cuit)
        {
            SqlConnection conexion = DAL.Conexion.getConexion();
            DataTable dt = new DataTable();

            SqlCommand comando = new SqlCommand(@"SELECT IdEmpresa
                                                  FROM Empresas
                                                  WHERE Cuit = @Cuit", conexion);
            comando.Parameters.Add("@Cuit", Cuit);
            dt.Load(comando.ExecuteReader());

            return (int)dt.Rows[0][0];
        }
 
    }
}
