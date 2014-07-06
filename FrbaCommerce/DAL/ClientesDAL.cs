using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace FrbaCommerce.DAL
{
    class ClientesDAL
    {

/*  IdCliente INT IDENTITY(1,1) NOT NULL,
	Nombre NVARCHAR(255) NULL,
	Apellido NVARCHAR(255) NULL,
	NroDocumento NUMERIC(18,0) NULL,
	CUIL VARCHAR(11) NULL,
	IdTipoDoc INT NULL,
	Mail NVARCHAR(255) NULL,
	Telefono VARCHAR(15) NOT NULL,
	Calle NVARCHAR(255) NULL,
	NroCalle NUMERIC(18) NULL,
	PisoNro NUMERIC(18) NULL,
	Depto NVARCHAR(50) NULL,
	Localidad NVARCHAR(20) NULL,
	CodigoPostal NVARCHAR(50) NULL,
	FechaNacimiento DATETIME NOT NULL,
	idUsuario INT NOT NULL,
	idEstado INT NOT NULL
	CONSTRAINT PK_Clientes PRIMARY KEY (idCliente),
	CONSTRAINT FK_Clientes_TiposDocumentos FOREIGN KEY (IdTipoDoc) REFERENCES TiposDocumentos(IdTipoDocumento),
	CONSTRAINT FK_Clientes_Usuarios FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario),
	CONSTRAINT FK_Clientes_Estados FOREIGN KEY (IdEstado) REFERENCES Estados(IdEstado)
*/

        public DataTable listarClientes(String nombre, String apellido, String tipoDoc, String nroDoc, String email)
        {

            SqlConnection conexion = DAL.Conexion.getConexion();
            DataTable dt = new DataTable();
            try
            {
                String where = String.Empty;
                if (!String.IsNullOrEmpty(nombre))
                    {
                        where = " AND Nombre LIKE '%" + nombre + "%'";
                    }

                if (!String.IsNullOrEmpty(apellido))
                    {
                        where = where + " AND Apellido LIKE '%" + apellido + "%'";
                    }

                if (!String.IsNullOrEmpty(nroDoc))
                    {
                        where = where + " AND NroDocumento LIKE '%" + nroDoc + "%'";
                    }

                if (!String.IsNullOrEmpty(email))
                    {
                        where = where + " AND Mail LIKE '%" + email + "%'";
                    }

                if (!String.IsNullOrEmpty(tipoDoc))
                {
                    where = where + @" AND IdTipoDoc = (SELECT IdTipoDocumento 
                                                        FROM BAZINGUEANDO_EN_SLQ.TiposDocumentos 
                                                        WHERE Descripcion LIKE '%" + tipoDoc + "%')";
                }

                SqlCommand comando = new SqlCommand(@"  SELECT 
                                                            C.Nombre,
                                                            T.Descripcion,
                                                            C.NroDocumento,
                                                            C.Mail,
	                                                        C.Apellido,
	                                                        C.Telefono,
	                                                        C.Calle,
	                                                        C.PisoNro,
	                                                        C.Depto,
	                                                        C.Localidad,
	                                                        C.CodigoPostal,
	                                                        C.FechaNacimiento,
                                                            C.CUIL,
                                                            est.Descripcion,
                                                            C.IdCliente,
                                                            C.idEstado
                                                        FROM BAZINGUEANDO_EN_SLQ.Clientes C
														INNER JOIN BAZINGUEANDO_EN_SLQ.Estados Est
                                                            ON C.idEstado = Est.idEstado
                                                        inner join BAZINGUEANDO_EN_SLQ.TiposDocumentos T 
                                                            ON idTipoDocumento = C.idTipoDoc 
                                                        " + where, conexion);


                dt.Load(comando.ExecuteReader());

                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertarCliente(Model.Clientes cliente)
        {
            SqlConnection conexion = DAL.Conexion.getConexion();

            try
            {
                SqlCommand commando = new SqlCommand(@"INSERT INTO BAZINGUEANDO_EN_SLQ.Clientes 
                                                        (
                                                            Nombre,
                                                            Apellido,
                                                            NroDocumento,
                                                            CUIL,
                                                            IdTipoDoc,
                                                            Mail,
                                                            Telefono,
                                                            Calle,
                                                            PisoNro,
                                                            Depto,
                                                            Localidad,
                                                            CodigoPostal,
                                                            FechaNacimiento,
                                                            IdEstado
                                                        )
                                                        VALUES 
                                                        (
                                                            @Nombre,
                                                            @Apellido,
                                                            @NroDocumento,
                                                            @CUIL,
                                                            @IdTipoDoc,
                                                            @Mail,
                                                            @Telefono,
                                                            @Calle,
                                                            @PisoNro,
                                                            @Depto,
                                                            @Localidad,
                                                            @CodigoPostal,
                                                            @FechaNacimiento,
                                                            @IdEstado
                                                        )", conexion);
                commando.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                commando.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                commando.Parameters.AddWithValue("@NroDocumento", cliente.NroDocumento);
                commando.Parameters.AddWithValue("@CUIL", cliente.Cuil);
                commando.Parameters.AddWithValue("@IdTipoDoc", cliente.IdTipoDocumento);
                commando.Parameters.AddWithValue("@Mail", cliente.mail);
                commando.Parameters.AddWithValue("@Telefono", cliente.telefono);
                commando.Parameters.AddWithValue("@Calle", cliente.Calle);
                commando.Parameters.AddWithValue("@PisoNro", cliente.PisoNro);
                commando.Parameters.AddWithValue("@Depto", cliente.Depto);
                commando.Parameters.AddWithValue("@Localidad", cliente.Localidad);
                commando.Parameters.AddWithValue("@CodigoPostal", cliente.CodigoPostal);
                commando.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
                commando.Parameters.AddWithValue("@IdUsuario", cliente.IdUsuario);
                commando.Parameters.AddWithValue("@IdEstado", cliente.IdEstado);

                commando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int actualizarCliente(int idCliente, Model.Clientes cliente)
        {
            SqlConnection conexion = DAL.Conexion.getConexion();

            try
            {

                SqlCommand comando = new SqlCommand(@"UPDATE BAZINGUEANDO_EN_SLQ.Clientes 
                                                      SET  
                                                            Nombre = @Nombre,
                                                            Cuil = @Cuil,
                                                            Apellido = @Apellido,
                                                            Mail = @Mail,
                                                            IdTipoDoc = @idTipoDocumento,
                                                            NroDocumento = @NroDocumento,
                                                            Telefono = @Telefono,
                                                            Calle = @Calle,
                                                            PisoNro = @PisoNro,
                                                            Depto = @Depto,
                                                            Localidad = @Localidad,
                                                            CodigoPostal = @CodigoPostal,
                                                            FechaNacimiento = @FechaNacimiento,
                                                            idEstado = @estado

                                                    WHERE idCliente = @idCliente"
                                                            , conexion);

                comando.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                comando.Parameters.AddWithValue("@Cuil", cliente.Cuil);
                comando.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                comando.Parameters.AddWithValue("@Mail", cliente.mail);
                comando.Parameters.AddWithValue("@IdTipoDocumento", cliente.IdTipoDocumento);
                comando.Parameters.AddWithValue("@NroDocumento", cliente.NroDocumento);
                comando.Parameters.AddWithValue("@Telefono", cliente.telefono);
                comando.Parameters.AddWithValue("@Calle", cliente.Calle);
                comando.Parameters.AddWithValue("@PisoNro", cliente.PisoNro);
                comando.Parameters.AddWithValue("@Depto", cliente.Depto);
                comando.Parameters.AddWithValue("@Localidad", cliente.Localidad);
                comando.Parameters.AddWithValue("@CodigoPostal", cliente.CodigoPostal);
                comando.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
                comando.Parameters.AddWithValue("@estado", cliente.IdEstado);
                comando.Parameters.AddWithValue("@idCliente", cliente.IdCliente);

                return (int)comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int BajaLogicaCliente(int idCliente, Model.Clientes cliente)
        {
            SqlConnection conexion = DAL.Conexion.getConexion();

            try
            {

                SqlCommand comando = new SqlCommand(@"UPDATE BAZINGUEANDO_EN_SLQ.Clientes 
                                                      SET  
                                                            idEstado = @estado
                                                    WHERE idCliente = @idCliente"
                                                            , conexion);

                comando.Parameters.AddWithValue("@estado", cliente.IdEstado);
                comando.Parameters.AddWithValue("@idCliente", cliente.IdCliente);

                return (int)comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int loadPorNroDoc(long nroDoc)
        {
            SqlConnection conexion = DAL.Conexion.getConexion();
            try
            {

                DataTable dt = new DataTable();

                SqlCommand comando = new SqlCommand(@"  SELECT IdCliente
                                                        FROM BAZINGUEANDO_EN_SLQ.Clientes
                                                        WHERE NroDocumento = @NroDocumento", conexion);
                comando.Parameters.AddWithValue("@NroDocumento", nroDoc);
                dt.Load(comando.ExecuteReader());

                return (int)dt.Rows[0][0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Boolean existeClientePorNroDoc(int nroDoc,int idTipoDoc)
        {
            SqlConnection conexion = DAL.Conexion.getConexion();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand comando = new SqlCommand(@"SELECT *                                                            
                                                        FROM BAZINGUEANDO_EN_SLQ.Clientes
                                                        WHERE NroDocumento = @NroDocumento
                                                        AND IdTipoDoc = @IdTipoDocumento", conexion);

                comando.Parameters.AddWithValue("@NroDocumento", nroDoc);
                comando.Parameters.AddWithValue("@IdTipoDocumento",idTipoDoc);
                dt.Load(comando.ExecuteReader());

                return (dt.Rows.Count>0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int obtenerTipoDoc(string TipoDoc)
        {

            SqlConnection conexion = DAL.Conexion.getConexion();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand comando = new SqlCommand(@"SELECT idTipoDocumento                                                            
                                                        FROM BAZINGUEANDO_EN_SLQ.TiposDocumentos
                                                        WHERE Descripcion = @TipoDoc
                                                        ", conexion);

                comando.Parameters.AddWithValue("@TipoDoc", TipoDoc);
                //comando.Parameters.AddWithValue("@IdTipoDocumento", idTipoDoc);
                dt.Load(comando.ExecuteReader());

                return (int)dt.Rows[0][0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
