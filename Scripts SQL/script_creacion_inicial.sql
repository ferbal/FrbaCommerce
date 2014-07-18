
/*Eliminar Tablas Existentes
DROP TABLE BAZINGUEANDO_EN_SLQ.CALIFICACIONES
DROP TABLE BAZINGUEANDO_EN_SLQ.COMPRAS
DROP TABLE BAZINGUEANDO_EN_SLQ.FACTURASITEMS
DROP TABLE BAZINGUEANDO_EN_SLQ.DatosTarjetas
DROP TABLE BAZINGUEANDO_EN_SLQ.FACTURAS
DROP TABLE BAZINGUEANDO_EN_SLQ.UsuariosRoles
DROP TABLE BAZINGUEANDO_EN_SLQ.PUBLICACIONESRUBROS
DROP TABLE BAZINGUEANDO_EN_SLQ.RolesFuncionalidades
DROP TABLE BAZINGUEANDO_EN_SLQ.Roles
DROP TABLE BAZINGUEANDO_EN_SLQ.Funcionalidades
DROP TABLE BAZINGUEANDO_EN_SLQ.FORMASPAGO
DROP TABLE BAZINGUEANDO_EN_SLQ.Ofertas
DROP TABLE BAZINGUEANDO_EN_SLQ.RESPUESTAS
DROP TABLE BAZINGUEANDO_EN_SLQ.PREGUNTAS
DROP TABLE BAZINGUEANDO_EN_SLQ.HISTORIALES
DROP TABLE BAZINGUEANDO_EN_SLQ.PUBLICACIONES
DROP TABLE BAZINGUEANDO_EN_SLQ.Visibilidades
DROP TABLE BAZINGUEANDO_EN_SLQ.RUBROS
DROP TABLE BAZINGUEANDO_EN_SLQ.TIPOSPUBLICACIONES
DROP TABLE BAZINGUEANDO_EN_SLQ.Empresas
DROP TABLE BAZINGUEANDO_EN_SLQ.Clientes
DROP TABLE BAZINGUEANDO_EN_SLQ.Usuarios
DROP TABLE BAZINGUEANDO_EN_SLQ.TiposPersonas
DROP TABLE BAZINGUEANDO_EN_SLQ.TiposDocumentos
DROP TABLE BAZINGUEANDO_EN_SLQ.Estados
DROP TABLE BAZINGUEANDO_EN_SLQ.EstadosPublicacion
DROP TABLE BAZINGUEANDO_EN_SLQ.EstadosCompras

DROP PROCEDURE BAZINGUEANDO_EN_SLQ.SP_ListarComprasAFacturar
DROP PROCEDURE BAZINGUEANDO_EN_SLQ.SP_ObtenerCompraDesde
DROP PROCEDURE BAZINGUEANDO_EN_SLQ.SP_ObtenerComprasHasta
DROP PROCEDURE BAZINGUEANDO_EN_SLQ.SP_GENERAR_FACTURA
DROP PROCEDURE BAZINGUEANDO_EN_SLQ.SP_INGRESAR_CALIFICACIONES
DROP PROCEDURE BAZINGUEANDO_EN_SLQ.SP_COMPRAS_A_CALIFICAR
DROP PROCEDURE BAZINGUEANDO_EN_SLQ.SP_CALIFICACIONES_REALIZADAS
DROP PROCEDURE BAZINGUEANDO_EN_SLQ.SP_CALIFICACIONES_RECIBIDAS
DROP PROCEDURE BAZINGUEANDO_EN_SLQ.SP_OFERTAS_USUARIO
DROP PROCEDURE BAZINGUEANDO_EN_SLQ.SP_COMPRAS_USUARIO
DROP PROCEDURE BAZINGUEANDO_EN_SLQ.SP_RESPONDER_PREGUNTAS_USUARIO
DROP PROCEDURE BAZINGUEANDO_EN_SLQ.SP_RESPUESTAS_USUARIO
DROP PROCEDURE BAZINGUEANDO_EN_SLQ.SP_CONVERTIR_OFERTA_EN_COMPRA

DROP TRIGGER BAZINGUEANDO_EN_SLQ.TGR_COMPRAS
DROP TRIGGER BAZINGUEANDO_EN_SLQ.TGR_ACTUALIZAR_REPUTACION
DROP TRIGGER BAZINGUEANDO_EN_SLQ.TGR_COMPRAS_SIN_CALIFICAR_FACTURAR
DROP TRIGGER TRIGGER_CLIENTES_USUARIOS
DROP TRIGGER TRIGGER_EMPRESAS_USUARIOS

DROP SCHEMA BAZINGUEANDO_EN_SLQ
*/

----------------------
--CREACION DE SCHEMA--
----------------------
CREATE SCHEMA BAZINGUEANDO_EN_SLQ AUTHORIZATION gd
Go
---------Dar permisos de creacion de tabla al usuario---------------------

--GRANT CREATE TABLE ON SCHEMA :: BAZINGUEANDO_EN_SLQ TO gd
GRANT INSERT ON SCHEMA :: BAZINGUEANDO_EN_SLQ TO gd
GRANT SELECT ON SCHEMA :: BAZINGUEANDO_EN_SLQ TO gd
GRANT UPDATE ON SCHEMA :: BAZINGUEANDO_EN_SLQ TO gd
GRANT EXECUTE ON SCHEMA :: BAZINGUEANDO_EN_SLQ TO gd

GO

--DENY CREATE TABLE TO gd
GO


begin transaction

CREATE TABLE BAZINGUEANDO_EN_SLQ.Estados
(
	idEstado INT IDENTITY(1,1) NOT NULL,
	Descripcion NVARCHAR(255) NOT NULL,
	CONSTRAINT PK_Estados PRIMARY KEY (idEstado ASC) on [PRIMARY]
)

CREATE TABLE BAZINGUEANDO_EN_SLQ.EstadosPublicacion
(
	idEstadoPublicacion INT IDENTITY(1,1) NOT NULL,
	Descripcion NVARCHAR(255) NOT NULL,
	CONSTRAINT PK_EstadosPublicacion PRIMARY KEY (idEstadoPublicacion ASC)
)

CREATE TABLE BAZINGUEANDO_EN_SLQ.EstadosCompras
(
	IdEstadoCompra INT IDENTITY(1,1) NOT NULL,
	Descripcion NVARCHAR(255) NOT NULL,
	CONSTRAINT PK_EstadosCompra PRIMARY KEY (IdEstadoCompra ASC)
)

CREATE TABLE BAZINGUEANDO_EN_SLQ.Funcionalidades
(
	idFuncionalidad INT IDENTITY(1,1) NOT NULL,
	Descripcion NVARCHAR(255) NULL
	CONSTRAINT PK_Funcionalidades PRIMARY KEY (idFuncionalidad ASC) ON [PRIMARY]
)

CREATE TABLE BAZINGUEANDO_EN_SLQ.Roles
(
	IdRol INT IDENTITY(1,1) NOT NULL,
	Nombre VARCHAR(20) NOT NULL,
	IdEstado INT NOT NULL,
	CONSTRAINT PK_Roles PRIMARY KEY (idRol ASC) ON [PRIMARY],
	CONSTRAINT FK_RolesEstados FOREIGN KEY (idEstado) REFERENCES BAZINGUEANDO_EN_SLQ.Estados(idEstado)
)

CREATE TABLE BAZINGUEANDO_EN_SLQ.RolesFuncionalidades
(
	IdRol INT NOT NULL,
	IdFuncionalidad INT NOT NULL,
	CONSTRAINT FK_RolesFuncionalidades_Roles FOREIGN KEY (IdRol) REFERENCES BAZINGUEANDO_EN_SLQ.Roles(IdRol),
	CONSTRAINT FK_RolesFuncionalidades_Funcionalidades FOREIGN KEY (IdFuncionalidad) REFERENCES BAZINGUEANDO_EN_SLQ.Funcionalidades(IdFuncionalidad)
)

CREATE TABLE BAZINGUEANDO_EN_SLQ.TiposPersonas
(
	idTipoPersona INT IDENTITY(1,1) NOT NULL,
	Descripcion VARCHAR(20) NOT NULL,
	CONSTRAINT PK_TiposPersonas PRIMARY KEY CLUSTERED (idTipoPersona ASC) ON [PRIMARY]
)

CREATE TABLE BAZINGUEANDO_EN_SLQ.Usuarios
(
	idUsuario INT IDENTITY(1,1) NOT NULL,
	idTipoPersona INT NULL,
	--idNumeroTabla INT NOT NULL,
	login NVARCHAR(255) NOT NULL,
	password NVARCHAR(255) NULL,
	fallos INT NULL,
	reputacion INT NULL,
	idEstado INT NULL,
	CONSTRAINT PK_Usuarios PRIMARY KEY CLUSTERED (idUsuario ASC) ON [PRIMARY],
	CONSTRAINT FK_Usuarios_TiposPersonas FOREIGN KEY (idTipoPersona) REFERENCES BAZINGUEANDO_EN_SLQ.TiposPersonas(idTipoPersona),
	CONSTRAINT FK_Usuarios_Estados FOREIGN KEY (IdEstado) REFERENCES BAZINGUEANDO_EN_SLQ.Estados(IdEstado)
)

CREATE TABLE BAZINGUEANDO_EN_SLQ.Rubros
(
	IdRubro INT IDENTITY(1,1) NOT NULL,
	Descripcion NVARCHAR(255) NOT NULL,
	CONSTRAINT PK_Rubros PRIMARY KEY (idRubro)
)

CREATE TABLE BAZINGUEANDO_EN_SLQ.UsuariosRoles
(
	IdUsuario INT NOT NULL,
	IdRol INT NOT NULL,
	CONSTRAINT FK_UsuariosRoles_Usuarios FOREIGN KEY (IdUsuario) REFERENCES BAZINGUEANDO_EN_SLQ.Usuarios(IdUsuario),
	CONSTRAINT FK_UsuariosRoles_Roles FOREIGN KEY (IdRol) REFERENCES BAZINGUEANDO_EN_SLQ.Roles(IdRol)
)

CREATE TABLE BAZINGUEANDO_EN_SLQ.TiposDocumentos
(
	IdTipoDocumento INT IDENTITY(1,1) NOT NULL,
	Descripcion VARCHAR(10) NOT NULL,
	CONSTRAINT PK_TiposDocumentos PRIMARY KEY (IdTipoDocumento)
)

CREATE TABLE BAZINGUEANDO_EN_SLQ.Clientes
(
	IdCliente INT IDENTITY(1,1) NOT NULL,
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
	CONSTRAINT FK_Clientes_TiposDocumentos FOREIGN KEY (IdTipoDoc) REFERENCES BAZINGUEANDO_EN_SLQ.TiposDocumentos(IdTipoDocumento),
	CONSTRAINT FK_Clientes_Usuarios FOREIGN KEY (IdUsuario) REFERENCES BAZINGUEANDO_EN_SLQ.Usuarios(IdUsuario),
	CONSTRAINT FK_Clientes_Estados FOREIGN KEY (IdEstado) REFERENCES BAZINGUEANDO_EN_SLQ.Estados(IdEstado)
)

CREATE TABLE BAZINGUEANDO_EN_SLQ.Empresas
(
	IdEmpresa INT IDENTITY(1,1) NOT NULL,
	RazonSocial NVARCHAR(255) NULL,
	CUIT NVARCHAR(50) NULL,
	NombreContacto NVARCHAR(20) NULL,
	Mail NVARCHAR(50) NULL,
	Telefono NVARCHAR(15) NOT NULL,
	Calle NVARCHAR(100) NULL,
	NroCalle NUMERIC(18) NULL,
	PisoNro NUMERIC(18) NULL,
	Depto NVARCHAR(50) NULL,
	Localidad NVARCHAR(20) NULL,
	CodigoPostal NVARCHAR(50) NULL,
	FechaCreacion DATETIME NOT NULL,
	idUsuario INT,
	idEstado INT NOT NULL
	
	
	CONSTRAINT PK_Empresas PRIMARY KEY (idEmpresa),
	CONSTRAINT FK_Empresas_Usuarios FOREIGN KEY (IdUsuario) REFERENCES BAZINGUEANDO_EN_SLQ.Usuarios(IdUsuario),
	CONSTRAINT FK_Empresas_Estados FOREIGN KEY (IdEstado) REFERENCES BAZINGUEANDO_EN_SLQ.Estados(IdEstado)
)

CREATE TABLE BAZINGUEANDO_EN_SLQ.Visibilidades
(
	IdVisibilidad INT IDENTITY(1,1) NOT NULL,
	Codigo NUMERIC(18) NOT NULL,
	Descripcion NVARCHAR(255) NOT NULL,
	Duracion NUMERIC(18) NOT NULL,
	PrecioPorPublicar NUMERIC(18,2) NOT NULL,
	PorcentajeVenta NUMERIC(18,2) NOT NULL,
	IdEstado INT NOT NULL,
	CONSTRAINT PK_Visibilidades PRIMARY KEY (idVisibilidad),
	CONSTRAINT FK_Visibilidades_Estados FOREIGN KEY (IdEstado) REFERENCES BAZINGUEANDO_EN_SLQ.Estados(IdEstado)
	
)

CREATE TABLE BAZINGUEANDO_EN_SLQ.TiposPublicaciones
(	
	IdTipoPublicacion INT IDENTITY(1,1) NOT NULL,
	Descripcion NVARCHAR(255) NOT NULL,
	CONSTRAINT PK_TiposPublicaciones PRIMARY KEY (IdTipoPublicacion)
)

CREATE TABLE BAZINGUEANDO_EN_SLQ.Publicaciones
(
	IdPublicacion INT IDENTITY (1,1) NOT NULL,
	CodPublicacion NUMERIC(18) NOT NULL,
	IdTipoPublicacion INT NOT NULL,
	IdVisibilidad INT NOT NULL,
	--Valor NUMERIC(15,2) NOT NULL,
	IdEstado INT NOT NULL,
	FechaInicio DATETIME NOT NULL,
	FechaFin DATETIME NOT NULL,
	Descripcion NVARCHAR(255) NULL,
	Stock NUMERIC(18) NOT NULL,
	Precio NUMERIC (18,2) NOT NULL,
	IdRubro INT NOT NULL,
	IdUsuario INT NOT NULL,
	PermiteRealizarPreguntas BIT NOT NULL DEFAULT(1),
	Facturada BIT NOT NULL DEFAULT(0),
	CONSTRAINT PK_Publicaciones PRIMARY KEY (IdPublicacion),
	CONSTRAINT FK_Publicaciones_Usuarios FOREIGN KEY (IdUsuario) REFERENCES BAZINGUEANDO_EN_SLQ.Usuarios(IdUsuario),
	CONSTRAINT FK_Publicaciones_TipoPublicaciones FOREIGN KEY (IdTipoPublicacion) REFERENCES BAZINGUEANDO_EN_SLQ.TiposPublicaciones(IdTipoPublicacion),
	CONSTRAINT FK_Publicaciones_Visibilidad FOREIGN KEY (IdVisibilidad) REFERENCES BAZINGUEANDO_EN_SLQ.Visibilidades(IdVisibilidad),
	CONSTRAINT FK_Publicaciones_EstadosPublicacion FOREIGN KEY (IdEstado) REFERENCES BAZINGUEANDO_EN_SLQ.EstadosPublicacion(IdEstadoPublicacion),
	CONSTRAINT FK_Publicaciones_Rubros FOREIGN KEY (IdRubro) REFERENCES BAZINGUEANDO_EN_SLQ.Rubros(IdRubro)
)

CREATE TABLE BAZINGUEANDO_EN_SLQ.PublicacionesRubros
(
	IdPublicacion INT NOT NULL,
	IdRubro INT NOT NULL,
	CONSTRAINT FK_PublicacionesRubros_Publicaciones FOREIGN KEY (IdPublicacion) REFERENCES BAZINGUEANDO_EN_SLQ.Publicaciones(IdPublicacion),
	CONSTRAINT FK_PublicacionesRubros_Rubros FOREIGN KEY (IdRubro) REFERENCES BAZINGUEANDO_EN_SLQ.Rubros(IdRubro)
)

CREATE TABLE BAZINGUEANDO_EN_SLQ.Preguntas
(
	IdPregunta INT IDENTITY(1,1) NOT NULL,
	IdPublicacion INT NOT NULL,
	IdUsuario INT NOT NULL,
	Descripcion VARCHAR(50) NULL,
	Fecha DATETIME NOT NULL,
	CONSTRAINT PK_Preguntas PRIMARY KEY (IdPregunta),
	CONSTRAINT FK_Preguntas_Publicaciones FOREIGN KEY (IdPublicacion) REFERENCES BAZINGUEANDO_EN_SLQ.Publicaciones(IdPublicacion),
	CONSTRAINT FK_Preguntas_Usuario FOREIGN KEY (IdUsuario) REFERENCES BAZINGUEANDO_EN_SLQ.Usuarios(IdUsuario)
)

CREATE TABLE BAZINGUEANDO_EN_SLQ.Respuestas
(
	IdRespuesta INT IDENTITY(1,1) NOT NULL,
	IdPregunta INT NOT NULL,
	--IdPublicacion INT NOT NULL,
	--IdUsuario INT NOT NULL,
	Descripcion VARCHAR(50) NULL,
	Fecha DATETIME NOT NULL,
	CONSTRAINT PK_Respuestas PRIMARY KEY (IdRespuesta),
	CONSTRAINT FK_Respuestas_Preguntas FOREIGN KEY (IdPregunta) REFERENCES BAZINGUEANDO_EN_SLQ.Preguntas(IdPregunta)
	--CONSTRAINT FK_Respuestas_Publicaciones FOREIGN KEY (IdPublicacion) REFERENCES Publicaciones(IdPublicacion),
	--CONSTRAINT FK_Respuestas_Usuario FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario)
)


CREATE TABLE BAZINGUEANDO_EN_SLQ.Compras
(
	IdCompra INT IDENTITY(1,1) NOT NULL,
	IdUsrComprador INT NOT NULL,
	IdPublicacion INT NOT NULL,
	Fecha DATETIME,
	Cantidad NUMERIC (18),
	--Precio NUMERIC(10,2) NOT NULL,
	IdEstadoCompra INT NOT NULL,
	CONSTRAINT PK_Compras PRIMARY KEY (IdCompra),
	CONSTRAINT FK_Compras_Usuarios FOREIGN KEY (IdUsrComprador) REFERENCES BAZINGUEANDO_EN_SLQ.Usuarios(IdUsuario),
	CONSTRAINT FK_Compras_Publicaciones FOREIGN KEY (IdPublicacion) REFERENCES BAZINGUEANDO_EN_SLQ.Publicaciones(IdPublicacion),
	CONSTRAINT FK_Compras_EstadosCompras FOREIGN KEY (IdEstadoCompra) REFERENCES BAZINGUEANDO_EN_SLQ.EstadosCompras(IdEstadoCompra)
)

CREATE TABLE BAZINGUEANDO_EN_SLQ.Ofertas
(
	IdOferta INT IDENTITY (1,1) NOT NULL,
	IdPublicacion INT NOT NULL,
	IdUsrOfertante INT NOT NULL,
	Oferta_Fecha DATETIME,
	Oferta_Monto NUMERIC(18,2),
	CONSTRAINT PK_Ofertas PRIMARY KEY (IdOferta),
	CONSTRAINT FK_Ofertas_Usuarios FOREIGN KEY (IdUsrOfertante) REFERENCES BAZINGUEANDO_EN_SLQ.Usuarios(idUsuario),
	CONSTRAINT FK_Ofertas_Publicaciones FOREIGN KEY (IdPublicacion) REFERENCES BAZINGUEANDO_EN_SLQ.Publicaciones(IdPublicacion)
	
)	

CREATE TABLE BAZINGUEANDO_EN_SLQ.Calificaciones
(
	IdCalificacion INT IDENTITY(1,1) NOT NULL,
	IdCompra INT NOT NULL,
	Codigo NUMERIC(18) NOT NULL,
	Calificacion NUMERIC(18) NOT NULL,
	Detalle NVARCHAR(255) NULL,
	CONSTRAINT PK_Calificaciones PRIMARY KEY (IdCalificacion),
	CONSTRAINT FK_Calificaciones_Compras FOREIGN KEY (IdCompra) REFERENCES BAZINGUEANDO_EN_SLQ.Compras(IdCompra)
)

CREATE TABLE BAZINGUEANDO_EN_SLQ.Historiales
(
	IdHistorial INT IDENTITY(1,1) NOT NULL,
	IdUsuario INT NOT NULL,
	IdTabla INT NOT NULL,
	IdNumero INT NOT NULL,
	FechaAlta DATE NOT NULL,
	CONSTRAINT PK_Historiales PRIMARY KEY (IdHistorial),
	CONSTRAINT FK_Historiales_Usuarios FOREIGN KEY (IdUsuario) REFERENCES BAZINGUEANDO_EN_SLQ.Usuarios(IdUsuario)
)

CREATE TABLE BAZINGUEANDO_EN_SLQ.FormasPago
(
	IdFormaPago INT IDENTITY (1,1) NOT NULL,
	Descripcion NVARCHAR(255) NULL,
	CONSTRAINT PK_FormasPago PRIMARY KEY (IdFormaPago)
)

CREATE TABLE BAZINGUEANDO_EN_SLQ.Facturas
(
	IdFactura INT IDENTITY(1,1) NOT NULL,
	NroSucursal INT NOT NULL,
	NroFactura NUMERIC(18,0) NOT NULL,
	Fecha DATETIME NOT NULL,
	IdUsuario INT NOT NULL,
	IdFormaPago INT NOT NULL,
	IdEstado INT NOT NULL,
	Total NUMERIC(18,2) NOT NULL,
	CONSTRAINT PK_Facturas PRIMARY KEY (IdFactura),
	CONSTRAINT FK_Facturas_Usuarios FOREIGN KEY (IdUsuario) REFERENCES BAZINGUEANDO_EN_SLQ.Usuarios(IdUsuario),
	CONSTRAINT FK_Facturas_FormasPago FOREIGN KEY (IdFormaPago) REFERENCES BAZINGUEANDO_EN_SLQ.FormasPago(IdFormaPago),
	CONSTRAINT FK_Facturas_Estados FOREIGN KEY (IdEstado) REFERENCES BAZINGUEANDO_EN_SLQ.Estados(IdEstado)
)

CREATE TABLE BAZINGUEANDO_EN_SLQ.FacturasItems
(
	IdFacturaItem INT IDENTITY(1,1) NOT NULL,
	IdFactura INT NOT NULL,
	IdPublicacion INT NOT NULL,
	Precio NUMERIC(18,2) NOT NULL,
	Comision NUMERIC(18,2) NOT NULL,
	CantVendida NUMERIC(18) NOT NULL,
	CONSTRAINT PK_FacturasItems PRIMARY KEY (IdFacturaItem),
	CONSTRAINT FK_FacturasItems_Facturas FOREIGN KEY (IdFactura) REFERENCES BAZINGUEANDO_EN_SLQ.Facturas(IdFactura),
	CONSTRAINT FK_FacturasItems_Publicaciones FOREIGN KEY (IdPublicacion) REFERENCES BAZINGUEANDO_EN_SLQ.Publicaciones(IdPublicacion)
)
CREATE TABLE BAZINGUEANDO_EN_SLQ.DatosTarjetas
(
	IdFactura INT NOT NULL,
	NroTarjeta NUMERIC(18,0) NULL,
	FechaVencTarjeta DATETIME NULL,
	CodigoSeguridad INT NULL,
	TitularTarjeta VARCHAR(30) NULL,
	CONSTRAINT FK_DatosTarjetas_Facturas FOREIGN KEY (IdFactura) REFERENCES BAZINGUEANDO_EN_SLQ.Facturas(IdFactura)
)	

Commit transaction
go
create trigger TRIGGER_CLIENTES_USUARIOS
  on BAZINGUEANDO_EN_SLQ.Usuarios
  for insert
  as
  INSERT INTO BAZINGUEANDO_EN_SLQ.Clientes
   (Nombre,
	Apellido,
	NroDocumento,
	CUIL,
	IdTipoDoc,
	Mail,
	Telefono,
	Calle,
	NroCalle,
	PisoNro,
	Depto,
	Localidad,
	CodigoPostal,
	FechaNacimiento,
	IdUsuario,
	IdEstado
	)
	SELECT 
			Cli_Nombre,
			Cli_Apeliido,
			Cli_Dni,
			NULL CUIL,
			1 idTipoDocumento,
			Cli_Mail,
			'1111-1111' Telefono,
			Cli_Dom_Calle, 
			Cli_Nro_Calle,
			Cli_Piso,
			Cli_Depto,
			'Inicial' Localidad,
			Cli_Cod_Postal,
			Cli_Fecha_Nac,
			inserted.idUsuario,
			'1' idEstado			
	FROM gd_esquema.Maestra,inserted
	WHERE Cli_Mail=inserted.login
	Group by	Cli_Dni,
				Cli_Nombre,
				Cli_Apeliido,
				Cli_Mail,
				Cli_Dom_Calle,
				Cli_Nro_Calle,
				Cli_Piso,
				Cli_Depto,
				Cli_Cod_Postal,
				Cli_Fecha_Nac,
				inserted.idUsuario,
				idEstado
	order by Cli_Apeliido 

go
	
create trigger TRIGGER_EMPRESAS_USUARIOS
  on BAZINGUEANDO_EN_SLQ.Usuarios
  for insert
  as
  INSERT INTO BAZINGUEANDO_EN_SLQ.Empresas
   (RazonSocial,
	CUIT,
	NombreContacto,
	Mail,
	Telefono,
	Calle,
	NroCalle,
	PisoNro,
	Depto,
	Localidad,
	CodigoPostal,
	FechaCreacion,
	IdUsuario,
	IdEstado
	)
select  Publ_Empresa_Razon_Social,
	    Publ_Empresa_Cuit,
	    'Contacto' NombreContacto,
	    Publ_Empresa_Mail,
	    '1111-1111' Telefono,
		Publ_Empresa_Dom_Calle,
		Publ_Empresa_Nro_Calle,
		Publ_Cli_Piso,
		Publ_Empresa_Depto,
		'inicial' Localidad,
		Publ_Empresa_Cod_Postal,
		Publ_Empresa_Fecha_Creacion,
		inserted.IdUsuario,
		'1' IdEstado
	FROM gd_esquema.Maestra,inserted
	WHERE Publ_Empresa_Mail=inserted.login
	group by	Publ_Empresa_Cuit,
				Publ_Empresa_Razon_Social,
				Publ_Empresa_Fecha_Creacion,
				Publ_Empresa_Mail,
				Publ_Empresa_Dom_Calle,
				Publ_Empresa_Nro_Calle,
				Publ_Cli_Piso,
				Publ_Empresa_Depto,
				Publ_Empresa_Cod_Postal,
				inserted.idUsuario,
				idEstado

	order by Publ_Empresa_Razon_Social
go
;

--------Carga de Datos iniciales

INSERT BAZINGUEANDO_EN_SLQ.TiposPersonas
(Descripcion) VALUES ('Fisica'),('Juridica')

INSERT BAZINGUEANDO_EN_SLQ.FormasPago 
(Descripcion) VALUES ('Efectivo'),('Tarjeta de Credito'),('Tarjeta de Debito')

INSERT BAZINGUEANDO_EN_SLQ.TiposPublicaciones
(Descripcion) VALUES ('Compra Inmediata'),('Subasta')

INSERT BAZINGUEANDO_EN_SLQ.TiposDocumentos 
(Descripcion) VALUES ('DNI'),('LE'),('LC')

INSERT BAZINGUEANDO_EN_SLQ.Estados
(Descripcion) VALUES ('Habilitado'),('Deshabilitado'),('Inicial'),('Bloqueado Compras/Ofertas')

INSERT BAZINGUEANDO_EN_SLQ.EstadosCompras
(Descripcion) VALUES ('Facturada'),('No Facturada')


INSERT BAZINGUEANDO_EN_SLQ.EstadosPublicacion
		(Descripcion)
	VALUES
		('Borrador'),('Publicada'),('Pausada'),('Finalizada')

INSERT BAZINGUEANDO_EN_SLQ.Funcionalidades
		(Descripcion) 
	VALUES  
		('Login y seguridad'),
		('ABM de Rol'),
		('Registro de Usuario'),
		('ABM de Cliente'),
		('ABM de Empresa'),
		('ABM de Rubro'),
		('ABM visibilidad'),
		('Generar Publicación'),
		('Editar Publicación'),
		('Gestión de Preg'),
		('Comprar/Ofertar'),
		('Historial del cli'),
		('Calificar al Vend'),
		('Facturar Publi'),
		('Listado Estadístico')

INSERT BAZINGUEANDO_EN_SLQ.Roles
		(Nombre,IdEstado) 
	VALUES	
		('Cliente','1'),
		('Empresa','1'),
		('Administrativo','1')

INSERT BAZINGUEANDO_EN_SLQ.RolesFuncionalidades
		(IdRol,IdFuncionalidad)
Select '1',F.IdFuncionalidad
from BAZINGUEANDO_EN_SLQ.Funcionalidades F
where F.idFuncionalidad in (1,8,9,10,11,12,13,14)


INSERT BAZINGUEANDO_EN_SLQ.RolesFuncionalidades
		(IdRol,IdFuncionalidad)

Select '2',F.IdFuncionalidad
from BAZINGUEANDO_EN_SLQ.Funcionalidades F
where F.idFuncionalidad in (1,8,9,10,12,14)


INSERT BAZINGUEANDO_EN_SLQ.RolesFuncionalidades
		(IdRol,IdFuncionalidad)
	select
		'3',IdFuncionalidad 
	from BAZINGUEANDO_EN_SLQ.Funcionalidades


INSERT BAZINGUEANDO_EN_SLQ.Usuarios
		(idTipoPersona,
		login,
		password,
		fallos,
		reputacion,
		idEstado)
	VALUES
		('1','admin','EF797C8118F02DFB64967DD5D3F8C762348C9C63D532CC95C5ED7A898A64F','0','0','3')  
/*
INSERT BAZINGUEANDO_EN_SLQ.UsuariosRoles
		(IdRol,IdUsuario) 
	VALUES 
		(3,1)
*/


--------MIGRACION---------------------------------------------------------------------------------------

INSERT INTO BAZINGUEANDO_EN_SLQ.Visibilidades
		(Codigo,
		Descripcion,
		Duracion,
		PrecioPorPublicar,
		PorcentajeVenta,
		IdEstado)
	select	Publicacion_Visibilidad_Cod,
			Publicacion_Visibilidad_Desc,
			DATEDIFF(DD, Publicacion_Fecha,Publicacion_Fecha_Venc), 
			Publicacion_Visibilidad_Precio, 
			Publicacion_Visibilidad_Porcentaje,
			'1' IdEstado
	from gd_esquema.Maestra
	group by	Publicacion_Visibilidad_Cod,
				Publicacion_Visibilidad_Desc,
				DATEDIFF(DD, Publicacion_Fecha,Publicacion_Fecha_Venc),
				Publicacion_Visibilidad_Precio, 
				Publicacion_Visibilidad_Porcentaje
	order by Publicacion_Visibilidad_Cod


--Reputacion Clientes (divide por Operaciones realizadas? aunque no esten calificadas? )
/*select *--Publ_Cli_Dni,Calificacion_Cant_Estrellas--AVG(Calificacion_Cant_Estrellas)Reputacion
from gd_esquema.Maestra 
where Compra_Fecha is not NULL and Calificacion_Cant_Estrellas is not NULL and Publ_Cli_Dni is not NULL
--group by Publ_Cli_Dni
order by Publ_Cli_Dni
*/
--INSERT RUBROS
INSERT INTO BAZINGUEANDO_EN_SLQ.Rubros
	(
		Descripcion
	)
	select	Publicacion_Rubro_Descripcion 
	from gd_esquema.Maestra 
	group by Publicacion_Rubro_Descripcion 
	order by Publicacion_Rubro_Descripcion



--INSERT USUARIOS CLIENTE
INSERT INTO BAZINGUEANDO_EN_SLQ.Usuarios
	(
		idTipoPersona,
		login,
		password,
		fallos,
		reputacion,
		idEstado
	)
	select	'1' idTipoPersona,
			g.Cli_Mail,
			'EF797C8118F02DFB64967DD5D3F8C762348C9C63D532CC95C5ED7A898A64F'password,
			'0'fallos,
			 (select AVG(g2.Calificacion_Cant_Estrellas)Reputacion
			  from gd_esquema.Maestra g2 
			  where g2.Compra_Fecha is not NULL and g2.Calificacion_Cant_Estrellas is not NULL 
			  and g2.Publ_Cli_Dni = g.Cli_Dni)reputacion,
			'3'idEstado
	from gd_esquema.Maestra g
	where g.Cli_Dni is not null
	group by	g.Cli_Dni,
				g.Cli_Mail,
				g.Cli_Apeliido
	order by g.Cli_Apeliido
		
--INSERT USUARIOS EMPRESA
INSERT INTO BAZINGUEANDO_EN_SLQ.Usuarios
	(
		idTipoPersona,
		login,
		password,
		fallos,
		reputacion,
		idEstado
	)
	select	'2' idTipoPersona,
			g.Publ_Empresa_Mail,
			'EF797C8118F02DFB64967DD5D3F8C762348C9C63D532CC95C5ED7A898A64F'password,
			'0'fallos,
			(select AVG(g2.Calificacion_Cant_Estrellas)Reputacion
			  from gd_esquema.Maestra g2 
			  where g2.Compra_Fecha is not NULL and g2.Calificacion_Cant_Estrellas is not NULL 
			  and g2.Publ_Empresa_Cuit = g.Publ_Empresa_Cuit)reputacion,
			'3'idEstado
	from gd_esquema.Maestra g
	where g.Publ_Empresa_Cuit is not null
	group by g.Publ_Empresa_Cuit,g.Publ_Empresa_Mail,g.Publ_Empresa_Razon_Social
	order by g.Publ_Empresa_Razon_Social
	
	
--INSERT USUARIOS ROLES---
--------------------------
INSERT INTO BAZINGUEANDO_EN_SLQ.UsuariosRoles
(IdUsuario,
IdRol)
select U.idUsuario,
CASE WHEN U.idTipoPersona='1' and U.login='admin' THEN '3'
ELSE CASE WHEN U.idTipoPersona='2' THEN '2'
ELSE  '1'END
END  
from BAZINGUEANDO_EN_SLQ.Usuarios U
			
--------------------------------
--INSERT PUBLICACIONES

INSERT INTO BAZINGUEANDO_EN_SLQ.Publicaciones
	(
		CodPublicacion,
		IdTipoPublicacion,
		IdVisibilidad,
		--Valor,
		IdEstado,
		FechaInicio,
		FechaFin,
		Descripcion,
		Stock,
		Precio,
		--Oferta_Fecha,
		--Oferta_Monto,
		IdRubro,
		IdUsuario,
		PermiteRealizarPreguntas,
		Facturada
	)
	select	Publicacion_Cod,
			(select TiposPublicaciones.IdTipoPublicacion  
				from BAZINGUEANDO_EN_SLQ.TiposPublicaciones 
				where Publicacion_Tipo like TiposPublicaciones.Descripcion) tipo,
			(select Visibilidades.IdVisibilidad 
				from BAZINGUEANDO_EN_SLQ.Visibilidades 
				where  Publicacion_Visibilidad_Cod =Visibilidades.Codigo) IdVisibilidad,
			(select idEstadoPublicacion 
				from BAZINGUEANDO_EN_SLQ.EstadosPublicacion
				where Publicacion_Estado = Descripcion)IdEstado,
			Publicacion_Fecha,
			Publicacion_Fecha_Venc,
			Publicacion_Descripcion,
			Publicacion_Stock,
			Publicacion_Precio,

			(select Rubros.IdRubro 
				from BAZINGUEANDO_EN_SLQ.Rubros 
				where Publicacion_Rubro_Descripcion like Rubros.Descripcion)IdRubro ,
			(select Usuarios.idUsuario 
				from BAZINGUEANDO_EN_SLQ.Usuarios 
				where (Publ_Empresa_Mail like Usuarios.login or Publ_Cli_Mail like Usuarios.login))IdUsuario,
			'1' PermiteRealizarPreguntas,
			'1' Facturada

	from gd_esquema.Maestra 
	group by	Publicacion_Cod,
				Publicacion_Tipo,
				Publicacion_Visibilidad_Cod,
				Publicacion_Estado,
				Publicacion_Fecha,
				Publicacion_Fecha_Venc,
				Publicacion_Descripcion,
				Publicacion_Stock,
				Publicacion_Precio,
				Publicacion_Rubro_Descripcion,
				Publ_Empresa_Mail,
				Publ_Cli_Mail
	order by Publicacion_Cod


------ INSERT COMPRAS

INSERT INTO BAZINGUEANDO_EN_SLQ.Compras
	(
		IdUsrComprador,
		IdPublicacion,
		Fecha,
		Cantidad,
		IdEstadoCompra
	)
	select
		(select Usuarios.idUsuario from BAZINGUEANDO_EN_SLQ.Usuarios where Cli_Mail like Usuarios.login),
		(select Publicaciones.IdPublicacion from BAZINGUEANDO_EN_SLQ.Publicaciones where g.Publicacion_Cod = Publicaciones.CodPublicacion),
		--g.Publicacion_Stock,
		g.Compra_Fecha,
		g.Compra_Cantidad,
		2 IdEstadoCompra--NO FACTUDADA
		--select Publicacion_Cod,Publicacion_Stock,Cli_Dni,Oferta_Fecha ,Compra_Fecha,Compra_Cantidad,g.Calificacion_Codigo
	from gd_esquema.Maestra g
	where	g.Compra_Fecha is not NULL 
			AND g.Calificacion_Codigo is NULL
	order by g.Publicacion_Cod

---INSERT OFERTAS

INSERT INTO BAZINGUEANDO_EN_SLQ.Ofertas
	(
		IdPublicacion,
		IdUsrOfertante,
		Oferta_Fecha,
		Oferta_Monto
	)
	select
		(select Publicaciones.IdPublicacion from BAZINGUEANDO_EN_SLQ.Publicaciones where Publicacion_Cod = Publicaciones.CodPublicacion)IdPublicacion,
		(select Usuarios.idUsuario from BAZINGUEANDO_EN_SLQ.Usuarios where (Cli_Mail like Usuarios.login))IdUsr,
		Oferta_Fecha,
		Oferta_Monto
		--select Publicacion_Cod,Oferta_Fecha,Oferta_Monto, Calificacion_Codigo
	from gd_esquema.Maestra
	where Oferta_Fecha is NOT NULL
	order by Publicacion_Cod, Oferta_Monto

---INSERT CALIFICACIONES
----------------------------
--MIGRACION CALIFICACIONES--
----------------------------
--MODIFICAMOS LA TABLA PARA QUE ADMITA NULL EN IDCOMPRA
ALTER TABLE BAZINGUEANDO_EN_SLQ.CALIFICACIONES ALTER COLUMN IDCOMPRA INT NULL;

--INSERTAMOS LOS CODIGOS DE CALIFICACIONES EXISTENTES EN LA TABLA MAESTRA
INSERT INTO BAZINGUEANDO_EN_SLQ.Calificaciones
	(
		Codigo,
		Calificacion
	)
	SELECT DISTINCT Calificacion_Codigo,1
	FROM gd_esquema.Maestra
	WHERE Calificacion_Codigo IS NOT NULL
	GROUP BY Calificacion_Codigo
	ORDER BY Calificacion_Codigo

--ACTUALIZAMOS LAS CALIFICACIONES CRUZANDO POR CODIGO DE CALIFICACION PARA COMPLETAR LOS DATOS FALTANTES
UPDATE BAZINGUEANDO_EN_SLQ.Calificaciones
SET IdCompra = (SELECT MIN(COMP.IdCompra)
				FROM BAZINGUEANDO_EN_SLQ.Compras COMP			
				WHERE	CALIF.IdCompra IS NULL
						AND COMP.IdPublicacion= PUB.IdPublicacion
						AND COMP.Fecha = G.Compra_Fecha
						AND COMP.IdUsrComprador = USR.idUsuario					
						AND COMP.Cantidad = G.Compra_Cantidad
				GROUP BY COMP.IdPublicacion), 
	Calificacion=G.Calificacion_Cant_Estrellas, 
	Detalle= G.Calificacion_Descripcion
FROM BAZINGUEANDO_EN_SLQ.Calificaciones CALIF
INNER JOIN gd_esquema.Maestra g
	ON CALIF.Codigo = G.Calificacion_Codigo
	AND G.Calificacion_Codigo IS NOT NULL
INNER JOIN BAZINGUEANDO_EN_SLQ.Publicaciones pub
	on pub.CodPublicacion = g.Publicacion_Cod
Inner join BAZINGUEANDO_EN_SLQ.Usuarios usr
	on g.Cli_Mail = usr.login
where	g.Compra_Fecha is not NULL 
		and g.Calificacion_Codigo is NOT NULL		

--VOLVEMOS A MODIFICAR LA TABLA CALIFICACIONES PARA QUE NO ADMITA NULL IDCOMPRA		
ALTER TABLE BAZINGUEANDO_EN_SLQ.CALIFICACIONES ALTER COLUMN IDCOMPRA INT NOT NULL;

-----INSERT FACTURAS

INSERT INTO BAZINGUEANDO_EN_SLQ.Facturas
	(NroSucursal,
	NroFactura,
	Fecha,
	IdUsuario,
	IdFormaPago,
	IdEstado,
	Total)
select 
	'1' NroSucursal,
	Factura_Nro ,
	Factura_Fecha ,
	(select IdUsuario from BAZINGUEANDO_EN_SLQ.Usuarios where Usuarios.login = g.Publ_Cli_Mail or Usuarios.login=g.Publ_Empresa_Mail),
	(select IdFormaPago from BAZINGUEANDO_EN_SLQ.FormasPago where FormasPago.Descripcion like g.Forma_Pago_Desc), 
	'3' IdEstado,
	Factura_Total  
 from gd_esquema.Maestra g
 where Factura_Nro IS NOT NULL 
 group by Factura_Nro , Factura_Fecha , Factura_Total,g.Publ_Cli_Mail,g.Publ_Empresa_Mail,
 g.Forma_Pago_Desc
 order by Factura_Nro
 
 
------INSERT ITEMS FACTURAS
INSERT INTO BAZINGUEANDO_EN_SLQ.FacturasItems
		(
		IdFactura,
		IdPublicacion,
		Precio,
		Comision,
		CantVendida)
	select IdFactura,
	 IdPublicacion,
	Item_Factura_Monto,
	(Publicaciones.Precio*Visibilidades.PorcentajeVenta) comision,
	 Item_Factura_Cantidad
	from gd_esquema.Maestra g
	inner join BAZINGUEANDO_EN_SLQ.Facturas
	on Facturas.NroFactura=g.Factura_Nro
	inner join BAZINGUEANDO_EN_SLQ.Publicaciones
	on g.Publicacion_Cod =Publicaciones.CodPublicacion
	inner join BAZINGUEANDO_EN_SLQ.Visibilidades
	on Visibilidades.IdVisibilidad = Publicaciones.IdVisibilidad
	where Factura_Nro is not NULL 
	order by Factura_Nro

------------------------------------------------------------
--CREACION DE TRIGGER PARA ACTUALIZAR STOCK DE PUBLICACION--
------------------------------------------------------------
GO
CREATE TRIGGER BAZINGUEANDO_EN_SLQ.TGR_COMPRAS
  ON BAZINGUEANDO_EN_SLQ.COMPRAS
  AFTER INSERT
  AS
	begin
		UPDATE BAZINGUEANDO_EN_SLQ.Publicaciones
		SET Stock = Stock - (SELECT Cantidad FROM inserted)
		WHERE IdPublicacion = (SELECT IdPublicacion FROM inserted)
	end
;
GO

------------------------------------------------------------
--CREACION DE TRIGGER PARA CONTROLAR COMPRAS SIN CALIFICAR--
-- ---------------Y SIN FACTURAR----------------------------
------------------------------------------------------------

CREATE TRIGGER BAZINGUEANDO_EN_SLQ.TGR_COMPRAS_SIN_CALIFICAR_FACTURAR
  ON BAZINGUEANDO_EN_SLQ.COMPRAS
  AFTER INSERT
  AS
BEGIN  
	 DECLARE @USR_COMPRADOR int
	 DECLARE @USR_VENDEDOR int 
	 DECLARE @COMPRAS_SIN_FACTURAR int
	 DECLARE @COMPRAS_SIN_CALIFICAR int
 
 
	DECLARE CURSOR_USR_VENDEDORES CURSOR FOR
	 select Publicaciones.IdUsuario from inserted INNER JOIN Publicaciones
									on inserted.IdPublicacion=Publicaciones.IdPublicacion

	DECLARE CURSOR_USR_COMPRADORES CURSOR FOR
	 select inserted.IdUsrComprador from inserted



	OPEN CURSOR_USR_VENDEDORES


	FETCH NEXT FROM CURSOR_USR_VENDEDORES
	INTO @USR_VENDEDOR
	WHILE @@FETCH_STATUS=0								
	BEGIN
		SET @COMPRAS_SIN_FACTURAR= (select COUNT(*) from BAZINGUEANDO_EN_SLQ.Compras INNER JOIN BAZINGUEANDO_EN_SLQ.Publicaciones
														on Compras.IdPublicacion=Publicaciones.IdPublicacion
														where Publicaciones.IdUsuario=@USR_VENDEDOR and Compras.IdEstadoCompra='2')
		IF @COMPRAS_SIN_FACTURAR >10 
			BEGIN
			BEGIN TRANSACTION
			UPDATE BAZINGUEANDO_EN_SLQ.Publicaciones
			set IdEstado='3' where IdUsuario=@USR_VENDEDOR and IdEstado='2' 
		
			UPDATE BAZINGUEANDO_EN_SLQ.Usuarios
			set idEstado='2' where idUsuario=@USR_VENDEDOR
			
			COMMIT 
			END
			
		FETCH NEXT FROM CURSOR_USR_VENDEDORES
		INTO @USR_VENDEDOR
	END


	OPEN CURSOR_USR_COMPRADORES

	FETCH NEXT FROM CURSOR_USR_COMPRADORES
	INTO @USR_COMPRADOR
	WHILE @@FETCH_STATUS=0								
	BEGIN
		SET @COMPRAS_SIN_CALIFICAR=(select COUNT(*) from BAZINGUEANDO_EN_SLQ.Compras Comp 
									LEFT JOIN BAZINGUEANDO_EN_SLQ.Calificaciones Calif
									on Comp.IdCompra=Calif.IdCompra
									where Calif.IdCalificacion IS NULL
									and Comp.IdUsrComprador=@USR_COMPRADOR)
		
		IF @COMPRAS_SIN_CALIFICAR >5
			BEGIN
			UPDATE BAZINGUEANDO_EN_SLQ.Usuarios
			SET idEstado='4' where idUsuario=@USR_COMPRADOR
			END
		FETCH NEXT FROM CURSOR_USR_COMPRADORES
		INTO @USR_COMPRADOR
	END

	CLOSE CURSOR_USR_COMPRADORES

	CLOSE CURSOR_USR_VENDEDORES

	DEALLOCATE CURSOR_USR_COMPRADORES

	DEALLOCATE CURSOR_USR_VENDEDORES

END

go

------------------------------------------------------------
--CREACION DE TRIGGER PARA ACTUALIZAR REPUTACION--
------------------------------------------------------------

CREATE TRIGGER BAZINGUEANDO_EN_SLQ.TGR_ACTUALIZAR_REPUTACION
  ON BAZINGUEANDO_EN_SLQ.CALIFICACIONES
  AFTER INSERT
  AS
  
  BEGIN
 
 DECLARE @USR_VENDEDOR int 
 DECLARE @CANTIDAD_VENTAS int
 DECLARE @CALIFICACION int 
 
 DECLARE CURSOR_USR_VENDEDORES_A_CALIFICAR CURSOR FOR
 
  select P.IdUsuario, inserted.Calificacion from inserted INNER JOIN BAZINGUEANDO_EN_SLQ.Compras C
		  on inserted.IdCompra = C.IdCompra INNER JOIN BAZINGUEANDO_EN_SLQ.Publicaciones P
		  on C.IdPublicacion=P.IdPublicacion
  
  OPEN CURSOR_USR_VENDEDORES_A_CALIFICAR
  
  FETCH NEXT FROM CURSOR_USR_VENDEDORES_A_CALIFICAR 
  INTO @USR_VENDEDOR, @CALIFICACION
  WHILE @@FETCH_STATUS=0	
  BEGIN
	SET @CANTIDAD_VENTAS= (select COUNT(*) from BAZINGUEANDO_EN_SLQ.Compras C
							INNER JOIN BAZINGUEANDO_EN_SLQ.Calificaciones Calif
							on C.IdCompra=Calif.IdCompra
							INNER JOIN BAZINGUEANDO_EN_SLQ.Publicaciones P
							on C.IdPublicacion=P.IdPublicacion
							where P.IdUsuario=@USR_VENDEDOR)
	
	UPDATE BAZINGUEANDO_EN_SLQ.Usuarios
	SET reputacion=(reputacion+@CALIFICACION)/@CANTIDAD_VENTAS
	where  idUsuario=@USR_VENDEDOR
  
  FETCH NEXT FROM CURSOR_USR_VENDEDORES_A_CALIFICAR 
  INTO @USR_VENDEDOR, @CALIFICACION
  END
  
  CLOSE CURSOR_USR_VENDEDORES_A_CALIFICAR 
  DEALLOCATE CURSOR_USR_VENDEDORES_A_CALIFICAR 
 END
 
 go
---------------------------------
--CREACION DE STORED PROCEDURES--
---------------------------------

--LISTAR COMPRAS A FACTURAR
CREATE PROCEDURE [BAZINGUEANDO_EN_SLQ].[SP_ListarComprasAFacturar]
	@VENDEDOR INT,
	@COMPRA_HASTA INT
AS	
	SELECT	C.IdCompra [CODIGO COMPRA],
			P.CodPublicacion [CODIGO PUBLICACION],
			P.Descripcion DESCRIPCION,
			P.Precio [PRECIO PUBLICACIO],
			P.Precio*V.PorcentajeVenta COMISION
			--V.PrecioPorPublicar [PRECIO POR PUBLICAR]
	FROM BAZINGUEANDO_EN_SLQ.Compras C
	INNER JOIN BAZINGUEANDO_EN_SLQ.Publicaciones P
		ON P.IdPublicacion = C.IdPublicacion
	INNER JOIN BAZINGUEANDO_EN_SLQ.Visibilidades V
		ON V.IdVisibilidad = P.IdVisibilidad
	WHERE	P.IdUsuario = @VENDEDOR
			AND C.IdCompra <= @COMPRA_HASTA
			AND C.IdEstadoCompra = 2
	ORDER BY C.IdCompra
GO
--OBTENER COMPRA DESDE

CREATE PROCEDURE [BAZINGUEANDO_EN_SLQ].[SP_ObtenerCompraDesde]
	@Vendedor INT
AS     
    SELECT TOP 1 IdCompra
    FROM BAZINGUEANDO_EN_SLQ.Compras C
    INNER JOIN BAZINGUEANDO_EN_SLQ.Publicaciones P
		ON P.IdPublicacion = C.IdPublicacion
    WHERE P.IdUsuario = @Vendedor
			AND C.IdEstadoCompra = 2
	ORDER BY C.IdCompra
GO

--OBTENER COMPRAS HASTA
CREATE PROCEDURE [BAZINGUEANDO_EN_SLQ].[SP_ObtenerComprasHasta]
	@Vendedor INT
AS     
    SELECT IdCompra
    FROM BAZINGUEANDO_EN_SLQ.Compras C
    INNER JOIN BAZINGUEANDO_EN_SLQ.Publicaciones P
		ON P.IdPublicacion = C.IdPublicacion
    WHERE P.IdUsuario = @Vendedor
			AND C.IdEstadoCompra = 2
	ORDER BY C.IdCompra

GO
--GENERAR FACTURA
CREATE PROCEDURE [BAZINGUEANDO_EN_SLQ].[SP_GENERAR_FACTURA]
	@VENDEDOR INT,
	@COMPRA_HASTA INT,
	@FECHA DATETIME,
	@FORMA_PAGO INT,
	@NRO_TARJ VARCHAR(20),
	@FECHA_VENC SMALLDATETIME,
	@COD_SEG INT,
	@TITULAR VARCHAR(20)
AS
--------------------------------
--DECLARO VARIABLES TEMPORALES--
--------------------------------	
BEGIN
	DECLARE @SUBTOTAL_VI NUMERIC(15,2),@ID_FACT NUMERIC(18,0)

	------------------------
	--COMIENZO TRANSACCION--
	------------------------
	BEGIN TRANSACTION

	SET @SUBTOTAL_VI = ( SELECT	SUM(V.PrecioPorPublicar) [PRECIO POR PUBLICAR]
						FROM BAZINGUEANDO_EN_SLQ.Compras C
						INNER JOIN BAZINGUEANDO_EN_SLQ.Publicaciones P
							ON P.IdPublicacion = C.IdPublicacion
						INNER JOIN BAZINGUEANDO_EN_SLQ.Visibilidades V
							ON V.IdVisibilidad = P.IdVisibilidad
						WHERE	P.IdUsuario = @VENDEDOR
								AND C.IdCompra <= @COMPRA_HASTA
								AND C.IdEstadoCompra = 2)

	---------------------------------
	--GENERAR ENCABEZADO DE FACTURA--
	---------------------------------
	INSERT INTO BAZINGUEANDO_EN_SLQ.Facturas
	(
		NroSucursal,
		NroFactura,
		Fecha,
		IdUsuario,
		IdFormaPago,
		IdEstado,
		Total
	)
	SELECT	1 NroSucursal,
			--1 FacturaTipo,
			(SELECT MAX(NroFactura) + 1
			FROM BAZINGUEANDO_EN_SLQ.Facturas) NRO_FACTURA,
			@FECHA FECHA,
			@VENDEDOR USUARIO,
			@FORMA_PAGO FORMA_PAGO,
			3 ESTADO,						
			SUM(P.Precio*V.PorcentajeVenta)+@SUBTOTAL_VI TOTAL
			--V.PrecioPorPublicar [PRECIO POR PUBLICAR]
	FROM BAZINGUEANDO_EN_SLQ.Compras C
	INNER JOIN BAZINGUEANDO_EN_SLQ.Publicaciones P
		ON P.IdPublicacion = C.IdPublicacion
	INNER JOIN BAZINGUEANDO_EN_SLQ.Visibilidades V
		ON V.IdVisibilidad = P.IdVisibilidad
	WHERE	P.IdUsuario = @VENDEDOR
			AND C.IdCompra <= @COMPRA_HASTA
			AND C.IdEstadoCompra = 2
	GROUP BY P.IdUsuario

	SET @ID_FACT = SCOPE_IDENTITY()

	-----------------------------
	--GENERAR ITEMS DE FACTURAS--
	-----------------------------
	--INSERTA ITEMS CORRESPONIENTES A LA COMPRA
	INSERT INTO BAZINGUEANDO_EN_SLQ.FacturasItems
	(
		IdFactura,
		IdPublicacion,
		Precio,
		Comision,
		CantVendida
	)
	SELECT	@ID_FACT,
			P.IdPublicacion [ID PUBLICACION],			
			(P.Precio*V.PorcentajeVenta*C.Cantidad) PRECIO,
			P.Precio*V.PorcentajeVenta COMISION,
			C.Cantidad		
	FROM BAZINGUEANDO_EN_SLQ.Compras C
	INNER JOIN BAZINGUEANDO_EN_SLQ.Publicaciones P
		ON P.IdPublicacion = C.IdPublicacion
	INNER JOIN BAZINGUEANDO_EN_SLQ.Visibilidades V
		ON V.IdVisibilidad = P.IdVisibilidad
	WHERE	P.IdUsuario = @VENDEDOR
			AND C.IdCompra <= @COMPRA_HASTA
			AND C.IdEstadoCompra = 2
	ORDER BY C.IdCompra

	--INSERTA ITEMS CORRESPONDIENTES A LA VISIBILIDAD	
	INSERT INTO BAZINGUEANDO_EN_SLQ.FacturasItems
	(
		IdFactura,
		IdPublicacion,
		Precio,
		Comision,
		CantVendida
	)
	SELECT	@ID_FACT,
			P.IdPublicacion [ID PUBLICACION],			
			V.PrecioPorPublicar,--(V.PrecioPorPublicar*DATEDIFF(WEEK,P.FechaInicio,GETDATE())) PRECIO,
			0 COMISION,
			1--DATEDIFF(WEEK,P.FechaInicio,GETDATE()) CANTIDAD
	FROM BAZINGUEANDO_EN_SLQ.Compras C
	INNER JOIN BAZINGUEANDO_EN_SLQ.Publicaciones P
		ON P.IdPublicacion = C.IdPublicacion
	INNER JOIN BAZINGUEANDO_EN_SLQ.Visibilidades V
		ON V.IdVisibilidad = P.IdVisibilidad
	WHERE	P.IdUsuario = @VENDEDOR
			AND C.IdCompra <= @COMPRA_HASTA
			AND C.IdEstadoCompra = 2
	ORDER BY C.IdCompra

	--------------------------------
	--ACTUALIZAR ESTADO DE COMPRAS--
	--------------------------------
	UPDATE BAZINGUEANDO_EN_SLQ.Compras
	SET IdEstadoCompra = 1
	FROM BAZINGUEANDO_EN_SLQ.Compras C
	INNER JOIN BAZINGUEANDO_EN_SLQ.Publicaciones P
		ON P.IdPublicacion = C.IdPublicacion
	INNER JOIN BAZINGUEANDO_EN_SLQ.Visibilidades V
		ON V.IdVisibilidad = P.IdVisibilidad
	WHERE	P.IdUsuario = @VENDEDOR
			AND C.IdCompra <= @COMPRA_HASTA
			AND C.IdEstadoCompra = 2
	---------------------------------------------------------------
	--INSERTO DATOS DE TARJETA SI LA FORMA DE PAGO NO ES EFECTIVO--
	---------------------------------------------------------------
	IF @FORMA_PAGO <> 1
		BEGIN
			INSERT INTO BAZINGUEANDO_EN_SLQ.DatosTarjetas
			(
				IdFactura,
				NroTarjeta,
				FechaVencTarjeta,
				CodigoSeguridad,
				TitularTarjeta
			)
			VALUES
			(
				@ID_FACT,
				CONVERT(NUMERIC(15,0),@NRO_TARJ),
				@FECHA_VENC,
				@COD_SEG,
				@TITULAR
			)
		END

	-----------------------------------
	--FINALIZO TRANSACCION - COMMITEO--
	-----------------------------------
	COMMIT TRANSACTION
END
GO

--INGRESAR CALIFICACIONES
CREATE PROCEDURE BAZINGUEANDO_EN_SLQ.SP_INGRESAR_CALIFICACIONES
	@COMPRA INT,
	@CALIF INT,
	@DETALLE VARCHAR(50)
AS
BEGIN
	DECLARE @CODIGO INT
	
	SET @CODIGO = (SELECT MAX(Codigo) FROM BAZINGUEANDO_EN_SLQ.Calificaciones)+1
	
	INSERT INTO BAZINGUEANDO_EN_SLQ.Calificaciones
	(
		IdCompra,
		Codigo,
		Calificacion,
		Detalle
	)
	VALUES
	(
		@COMPRA,
		@CODIGO,
		@CALIF,
		@DETALLE
	)	
END
GO

--OBTENER COMPRAS A CALIFICAR
CREATE PROCEDURE BAZINGUEANDO_EN_SLQ.SP_COMPRAS_A_CALIFICAR
	@USR INT
AS
	BEGIN		
		
		SELECT	COMP.IdCompra,
				CONVERT(VARCHAR(10),P.CodPublicacion) + ' - ' + P.Descripcion Descripcion
		FROM BAZINGUEANDO_EN_SLQ.Compras COMP
		INNER JOIN BAZINGUEANDO_EN_SLQ.Publicaciones P
			ON COMP.IdPublicacion = P.IdPublicacion
		LEFT JOIN BAZINGUEANDO_EN_SLQ.Calificaciones CALIF
			ON COMP.IdCompra = CALIF.IdCompra		
		WHERE	CALIF.IdCalificacion IS NULL
				AND COMP.IdUsrComprador = @USR
	END
GO


-- SP COMPRAS DE UN USUARIO --
------------------------------
CREATE PROCEDURE BAZINGUEANDO_EN_SLQ.SP_COMPRAS_USUARIO
@Usr int 

AS
 
BEGIN

	select	Comp.Fecha Fecha,
			Pub.CodPublicacion CodigoPublicacion,
			Pub.Descripcion Descripcion,
			Pub.Precio Precio,
			Comp.Cantidad Cantidad,
			Pub.Precio * Comp.Cantidad Total
	from BAZINGUEANDO_EN_SLQ.Compras Comp
	inner join BAZINGUEANDO_EN_SLQ.Usuarios Usrs 
		on Usrs.idUsuario = Comp.IdUsrComprador
	inner join BAZINGUEANDO_EN_SLQ.Publicaciones Pub 
		on Pub.IdPublicacion = Comp.IdPublicacion   
	where IdUsrComprador = @Usr
	order by Comp.Fecha 

END

go


-- SP OFERTAS DE UN USUARIO --
------------------------------
CREATE PROCEDURE BAZINGUEANDO_EN_SLQ.SP_OFERTAS_USUARIO
@Usr int 

AS 

BEGIN

select Ofer.Oferta_Fecha,
Pub.CodPublicacion CodigoPublicacion,
Pub.Descripcion Descripcion,
Ofer.Oferta_Monto MontoOfertado,
CASE
WHEN Ofer.Oferta_Monto=(select TOP 1 Ofer2.Oferta_Monto  from BAZINGUEANDO_EN_SLQ.Ofertas Ofer2 

where Ofer.IdPublicacion=Ofer2.IdPublicacion

order by Oferta_Monto DESC)
THEN 'SI'
ELSE 'NO'
END Gano_Oferta 

from BAZINGUEANDO_EN_SLQ.Ofertas Ofer
inner join BAZINGUEANDO_EN_SLQ.Usuarios Usrs on Usrs.idUsuario = Ofer.IdUsrOfertante
inner join BAZINGUEANDO_EN_SLQ.Publicaciones Pub on Pub.IdPublicacion = Ofer.IdPublicacion   
where IdUsrOfertante = @Usr
order by Pub.CodPublicacion --.Oferta_Fecha

END

go


-- SP CALIFICACIONES REALIZADAS DE UN USUARIO --
------------------------------------------------
CREATE PROCEDURE BAZINGUEANDO_EN_SLQ.SP_CALIFICACIONES_REALIZADAS
@Usr int 

AS

BEGIN
select 
Usuarios.login Vendedor,
Calificacion,
Detalle,
CodPublicacion,
Descripcion



from BAZINGUEANDO_EN_SLQ.Calificaciones Calif
INNER JOIN BAZINGUEANDO_EN_SLQ.Compras on Calif.IdCompra=Compras.IdCompra
INNER JOIN BAZINGUEANDO_EN_SLQ.Publicaciones on Compras.IdPublicacion=Publicaciones.IdPublicacion
INNER JOIN BAZINGUEANDO_EN_SLQ.Usuarios on Publicaciones.IdUsuario =Usuarios.idUsuario 
where Compras.IdUsrComprador=@Usr
END

go


-- SP CALIFICACIONES RECIBIDAS DE UN USUARIO --
------------------------------------------------
CREATE PROCEDURE BAZINGUEANDO_EN_SLQ.SP_CALIFICACIONES_RECIBIDAS
@Usr int 

AS 

BEGIN
select 
U2.login Comprador,
Calificacion,
Detalle,
CodPublicacion,
Descripcion
from BAZINGUEANDO_EN_SLQ.Calificaciones Calif
INNER JOIN BAZINGUEANDO_EN_SLQ.Compras C on Calif.IdCompra=C.IdCompra
INNER JOIN BAZINGUEANDO_EN_SLQ.Usuarios U2 on C.IdUsrComprador=U2.idUsuario
INNER JOIN BAZINGUEANDO_EN_SLQ.Publicaciones P on C.IdPublicacion=P.IdPublicacion

where P.IdUsuario=@Usr

END

go

--SP PREGUNTAS A RESPONDER DEL USUARIO--
----------------------------------------

CREATE PROCEDURE BAZINGUEANDO_EN_SLQ.SP_RESPONDER_PREGUNTAS_USUARIO
@Usr int 
AS
BEGIN
select 
	Pub.Descripcion Publicacion,
	P.Fecha,
	P.IdPregunta IdPregunta,
	P.Descripcion Pregunta,
	U.login Usuario
from BAZINGUEANDO_EN_SLQ.Preguntas P LEFT JOIN BAZINGUEANDO_EN_SLQ.Respuestas R
			on P.IdPregunta=R.IdPregunta INNER JOIN BAZINGUEANDO_EN_SLQ.Usuarios U 
			on P.IdUsuario=U.idUsuario INNER JOIN BAZINGUEANDO_EN_SLQ.Publicaciones Pub
			on P.IdPublicacion= Pub.IdPublicacion
			where Pub.IdUsuario=@Usr and  R.IdRespuesta IS NULL  
END

go


--SP RESPUESTAS DEL USUARIO--
-----------------------------
CREATE PROCEDURE BAZINGUEANDO_EN_SLQ.SP_RESPUESTAS_USUARIO
@Usr int 
AS
BEGIN

select
	Pub.Descripcion Publicacion,
	P.Descripcion Pregunta,
	R.Fecha [Fecha Respuesta],
	R.Descripcion Respuesta
from BAZINGUEANDO_EN_SLQ.Preguntas P 
INNER JOIN BAZINGUEANDO_EN_SLQ.Respuestas R
	on P.IdPregunta=R.IdPregunta 
INNER JOIN BAZINGUEANDO_EN_SLQ.Publicaciones Pub
	on P.IdPublicacion= Pub.IdPublicacion
where Pub.IdUsuario=@Usr

END
GO

--GENERA LA COMPRA DE LA OFERTA GANADORA--

CREATE PROCEDURE BAZINGUEANDO_EN_SLQ.SP_CONVERTIR_OFERTA_EN_COMPRA
	@PUBLICACION INT, 
	@FECHA DATETIME
AS
	BEGIN
		BEGIN TRANSACTION
			DECLARE @COMPRADOR INT, @PRECIO NUMERIC(10,2)
			
			SELECT TOP 1 
					@COMPRADOR = O.IdUsrOfertante,
					@PRECIO = O.Oferta_Monto
			FROM BAZINGUEANDO_EN_SLQ.Publicaciones P
			INNER JOIN BAZINGUEANDO_EN_SLQ.Ofertas O
				ON O.IdPublicacion = P.IDpUBLICACION
			WHERE P.IdPublicacion = @PUBLICACION AND P.IdEstado <> 4
			ORDER BY O.Oferta_Monto DESC

			UPDATE BAZINGUEANDO_EN_SLQ.Publicaciones
			SET Precio = @PRECIO
			WHERE IdPublicacion = @PUBLICACION

			INSERT INTO BAZINGUEANDO_EN_SLQ.Compras
			(IdUsrComprador,IdPublicacion,Fecha,Cantidad,IdEstadoCompra)
			VALUES
			(@COMPRADOR,@PUBLICACION,@FECHA,1,2)
		COMMIT		
	END
GO