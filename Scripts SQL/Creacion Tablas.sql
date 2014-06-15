
/*Eliminar Tablas Existentes
DROP TABLE UsuariosRoles
DROP TABLE FACTURASITEMS
DROP TABLE FACTURAS
DROP TABLE HISTORIALES
DROP TABLE RESPUESTAS
DROP TABLE PREGUNTAS
DROP TABLE PUBLICACIONESRUBROS
DROP TABLE TIPOSPUBLICACIONES
DROP TABLE Clientes
DROP TABLE Empresas
DROP TABLE RolesFuncionalidades
DROP TABLE Funcionalidades
DROP TABLE Roles
DROP TABLE TiposDocumentos
DROP TABLE CALIFICACIONES
DROP TABLE COMPRAS
DROP TABLE FORMASPAGO
DROP TABLE RUBROS
DROP TABLE PUBLICACIONES
DROP TABLE Ofertas
DROP TABLE DatosTarjetas
DROP TABLE Usuarios
DROP TABLE Visibilidades
DROP TABLE Estados
DROP TABLE TiposPersonas

*/

begin transaction

CREATE TABLE Estados
(
	idEstado INT IDENTITY(1,1) NOT NULL,
	Descripcion NVARCHAR(255) NOT NULL,
	CONSTRAINT PK_Estados PRIMARY KEY (idEstado ASC) on [PRIMARY]
)

CREATE TABLE Funcionalidades
(
	idFuncionalidad INT IDENTITY(1,1) NOT NULL,
	Descripcion VARCHAR(20) NULL
	CONSTRAINT PK_Funcionalidades PRIMARY KEY (idFuncionalidad ASC) ON [PRIMARY]
)

CREATE TABLE Roles
(
	IdRol INT IDENTITY(1,1) NOT NULL,
	Nombre VARCHAR(20) NOT NULL,
	IdEstado INT NOT NULL,
	CONSTRAINT PK_Roles PRIMARY KEY (idRol ASC) ON [PRIMARY],
	CONSTRAINT FK_RolesEstados FOREIGN KEY (idEstado) REFERENCES Estados(idEstado)
)


CREATE TABLE RolesFuncionalidades
(
	IdRol INT NOT NULL,
	IdFuncionalidad INT NOT NULL,
	CONSTRAINT FK_RolesFuncionalidades_Roles FOREIGN KEY (IdRol) REFERENCES Roles(IdRol),
	CONSTRAINT FK_RolesFuncionalidades_Funcionalidades FOREIGN KEY (IdFuncionalidad) REFERENCES Funcionalidades(IdFuncionalidad)
)

CREATE TABLE TiposPersonas
(
	idTipoPersona INT IDENTITY(1,1) NOT NULL,
	Descripcion VARCHAR(20) NOT NULL,
	CONSTRAINT PK_TiposPersonas PRIMARY KEY CLUSTERED (idTipoPersona ASC) ON [PRIMARY]
)

CREATE TABLE Usuarios
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
	CONSTRAINT FK_Usuarios_TiposPersonas FOREIGN KEY (idTipoPersona) REFERENCES TiposPersonas(idTipoPersona),
	CONSTRAINT FK_Usuarios_Estados FOREIGN KEY (IdEstado) REFERENCES Estados(IdEstado)
)

CREATE TABLE Rubros
(
	IdRubro INT IDENTITY(1,1) NOT NULL,
	Descripcion NVARCHAR(255) NOT NULL,
	CONSTRAINT PK_Rubros PRIMARY KEY (idRubro)
)

CREATE TABLE UsuariosRoles
(
	IdUsuario INT NOT NULL,
	IdRol INT NOT NULL,
	CONSTRAINT FK_UsuariosRoles_Usuarios FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario),
	CONSTRAINT FK_UsuariosRoles_Roles FOREIGN KEY (IdRol) REFERENCES Roles(IdRol)
)

CREATE TABLE TiposDocumentos
(
	IdTipoDocumento INT IDENTITY(1,1) NOT NULL,
	Descripcion VARCHAR(10) NOT NULL,
	CONSTRAINT PK_TiposDocumentos PRIMARY KEY (IdTipoDocumento)
)

CREATE TABLE Clientes
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
	CONSTRAINT FK_Clientes_TiposDocumentos FOREIGN KEY (IdTipoDoc) REFERENCES TiposDocumentos(IdTipoDocumento),
	CONSTRAINT FK_Clientes_Usuarios FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario),
	CONSTRAINT FK_Clientes_Estados FOREIGN KEY (IdEstado) REFERENCES Estados(IdEstado)
)

CREATE TABLE Empresas
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
	CONSTRAINT FK_Empresas_Usuarios FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario),
	CONSTRAINT FK_Empresas_Estados FOREIGN KEY (IdEstado) REFERENCES Estados(IdEstado)
)

CREATE TABLE Visibilidades
(
	IdVisibilidad INT IDENTITY(1,1) NOT NULL,
	Codigo NUMERIC(18) NOT NULL,
	Descripcion NVARCHAR(255) NOT NULL,
	Duracion NUMERIC(18) NOT NULL,
	PrecioPorPublicar NUMERIC(18,2) NOT NULL,
	PorcentajeVenta NUMERIC(18,2) NOT NULL,
	IdEstado INT NOT NULL,
	CONSTRAINT PK_Visibilidades PRIMARY KEY (idVisibilidad),
	CONSTRAINT FK_Visibilidades_Estados FOREIGN KEY (IdEstado) REFERENCES Estados(IdEstado)
	
)

CREATE TABLE TiposPublicaciones
(	
	IdTipoPublicacion INT IDENTITY(1,1) NOT NULL,
	Descripcion NVARCHAR(255) NOT NULL,
	CONSTRAINT PK_TiposPublicaciones PRIMARY KEY (IdTipoPublicacion)
)

CREATE TABLE Publicaciones
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
	CONSTRAINT PK_Publicaciones PRIMARY KEY (IdPublicacion),
	CONSTRAINT FK_Publicaciones_Usuarios FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario),
	CONSTRAINT FK_Publicaciones_TipoPublicaciones FOREIGN KEY (IdTipoPublicacion) REFERENCES TiposPublicaciones(IdTipoPublicacion),
	CONSTRAINT FK_Publicaciones_Visibilidad FOREIGN KEY (IdVisibilidad) REFERENCES Visibilidades(IdVisibilidad),
	CONSTRAINT FK_Publicaciones_Estados FOREIGN KEY (IdEstado) REFERENCES Estados(IdEstado),
	CONSTRAINT FK_Publicaciones_Rubros FOREIGN KEY (IdRubro) REFERENCES Rubros(IdRubro)
)

CREATE TABLE PublicacionesRubros
(
	IdPublicacion INT NOT NULL,
	IdRubro INT NOT NULL,
	CONSTRAINT FK_PublicacionesRubros_Publicaciones FOREIGN KEY (IdPublicacion) REFERENCES Publicaciones(IdPublicacion),
	CONSTRAINT FK_PublicacionesRubros_Rubros FOREIGN KEY (IdRubro) REFERENCES Rubros(IdRubro)
)

CREATE TABLE Preguntas
(
	IdPregunta INT IDENTITY(1,1) NOT NULL,
	IdPublicacion INT NOT NULL,
	IdUsuario INT NOT NULL,
	Descripcion VARCHAR(50) NULL,
	Fecha DATETIME NOT NULL,
	CONSTRAINT PK_Preguntas PRIMARY KEY (IdPregunta),
	CONSTRAINT FK_Preguntas_Publicaciones FOREIGN KEY (IdPublicacion) REFERENCES Publicaciones(IdPublicacion),
	CONSTRAINT FK_Preguntas_Usuario FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario)
)

CREATE TABLE Respuestas
(
	IdRespuesta INT IDENTITY(1,1) NOT NULL,
	IdPregunta INT NOT NULL,
	--IdPublicacion INT NOT NULL,
	--IdUsuario INT NOT NULL,
	Descripcion VARCHAR(50) NULL,
	Fecha DATETIME NOT NULL,
	CONSTRAINT PK_Respuestas PRIMARY KEY (IdRespuesta),
	CONSTRAINT FK_Respuestas_Preguntas FOREIGN KEY (IdPregunta) REFERENCES Preguntas(IdPregunta)
	--CONSTRAINT FK_Respuestas_Publicaciones FOREIGN KEY (IdPublicacion) REFERENCES Publicaciones(IdPublicacion),
	--CONSTRAINT FK_Respuestas_Usuario FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario)
)


CREATE TABLE Compras
(
	IdCompra INT IDENTITY(1,1) NOT NULL,
	IdUsrComprador INT NOT NULL,
	IdPublicacion INT NOT NULL,
	Fecha DATETIME,
	Cantidad NUMERIC (18),
	Precio NUMERIC(10,2) NOT NULL,
	IdEstado INT NOT NULL,
	CONSTRAINT PK_Compras PRIMARY KEY (IdCompra),
	CONSTRAINT FK_Compras_Usuarios FOREIGN KEY (IdUsrComprador) REFERENCES Usuarios(IdUsuario),
	CONSTRAINT FK_Compras_Publicaciones FOREIGN KEY (IdPublicacion) REFERENCES Publicaciones(IdPublicacion),
	CONSTRAINT FK_Compras_Estados FOREIGN KEY (IdEstado) REFERENCES Estados(IdEstado)
)
CREATE TABLE Ofertas
(
	IdOferta INT IDENTITY (1,1) NOT NULL,
	IdPublicacion INT NOT NULL,
	IdUsuario INT NOT NULL,
	Oferta_Fecha DATETIME,
	Oferta_Monto NUMERIC(18,2),
	CONSTRAINT PK_Ofertas PRIMARY KEY (IdOferta),
	CONSTRAINT FK_Ofertas_Usuarios FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario),
	CONSTRAINT FK_Ofertas_Publicaciones FOREIGN KEY (IdPublicacion) REFERENCES Publicaciones(IdPublicacion)
	
)	

CREATE TABLE Calificaciones
(
	IdCalificacion INT IDENTITY(1,1) NOT NULL,
	IdCompra INT NOT NULL,
	Codigo NUMERIC(18) NOT NULL,
	Calificacion NUMERIC(18) NOT NULL,
	Detalle NVARCHAR(255) NULL,
	CONSTRAINT PK_Calificaciones PRIMARY KEY (IdCalificacion),
	CONSTRAINT FK_Calificaciones_Compras FOREIGN KEY (IdCompra) REFERENCES Compras(IdCompra)
)

CREATE TABLE Historiales
(
	IdHistorial INT IDENTITY(1,1) NOT NULL,
	IdUsuario INT NOT NULL,
	IdTabla INT NOT NULL,
	IdNumero INT NOT NULL,
	FechaAlta DATE NOT NULL,
	CONSTRAINT PK_Historiales PRIMARY KEY (IdHistorial),
	CONSTRAINT FK_Historiales_Usuarios FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario)
)

CREATE TABLE FormasPago
(
	IdFormaPago INT IDENTITY (1,1) NOT NULL,
	Descripcion NVARCHAR(255) NULL,
	CONSTRAINT PK_FormasPago PRIMARY KEY (IdFormaPago)
)

CREATE TABLE Facturas
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
	CONSTRAINT FK_Facturas_Usuarios FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario),
	CONSTRAINT FK_Facturas_FormasPago FOREIGN KEY (IdFormaPago) REFERENCES FormasPago(IdFormaPago),
	CONSTRAINT FK_Facturas_Estados FOREIGN KEY (IdEstado) REFERENCES Estados(IdEstado)
)

CREATE TABLE FacturasItems
(
	IdFacturaItem INT IDENTITY(1,1) NOT NULL,
	IdFactura INT NOT NULL,
	IdPublicacion INT NOT NULL,
	Precio NUMERIC(18,2) NOT NULL,
	Comision NUMERIC(5,2) NOT NULL,
	CantVendida NUMERIC(18) NOT NULL,
	CONSTRAINT PK_FacturasItems PRIMARY KEY (IdFacturaItem),
	CONSTRAINT FK_FacturasItems_Facturas FOREIGN KEY (IdFactura) REFERENCES Facturas(IdFactura)
)
CREATE TABLE DatosTarjetas
(
	IdFactura INT NOT NULL,
	NroTarjeta NUMERIC(18,0) NULL,
	FechaVencTarjeta DATETIME NULL,
	CodigoSeguridad INT NULL,
	TitularTarjeta VARCHAR(30) NULL,
	CONSTRAINT FK_DatosTarjetas_Facturas FOREIGN KEY (IdFactura) REFERENCES Facturas(IdFactura)
)	

--Carga de Datos

INSERT TiposPersonas
(Descripcion) VALUES ('Cliente'),('Empresa')

INSERT FormasPago 
(Descripcion) VALUES ('Efectivo'),('Tarjeta de Credito'),('Tarjeta de Debito')

INSERT TiposPublicaciones
(Descripcion) VALUES ('Compra Inmediata'),('Subasta')

INSERT TiposDocumentos 
(Descripcion) VALUES ('DNI'),('LE'),('LC')

INSERT Estados
(Descripcion) VALUES ('Habilitado'),('Deshabilitado'),('Inicial'),('Borrador'),('Publicada'),('Pausada'),('Finalizada')

INSERT Roles
(Nombre,IdEstado) VALUES ('Cliente',1),('Administrador',1),('Empresa',1)

Insert into Funcionalidades
	(Descripcion) 
VALUES 
	('ABM de Cliente'),
    ('ABM de Empresa'),
    ('ABM de Rol'),
    ('ABM de Rubro'),
    ('ABM visibilidad'),
    ('Calificar al Vend'),
    ('Comprar/Ofertar'),
    ('Editar Publicación'),
    ('Facturar Publi'),
    ('Generar Publicación'),
    ('Gestión de Preg'),
    ('Historial del cli'),
    ('Listado Estadístico')
    
Insert into RolesFuncionalidades
	(IdRol,IdFuncionalidad)
	Select	2,
			idFuncionalidad 
	From Funcionalidades
	
Insert into Visibilidades
(Codigo,Descripcion,Duracion,PrecioPorPublicar,PorcentajeVenta,IdEstado)
Values
(1,'Visibilidad Test',30,100,0.5,1)

Insert into Rubros
(Descripcion) values('Test1'),('Test2')	
;
Commit transaction