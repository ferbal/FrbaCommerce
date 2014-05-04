
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
DROP TABLE TIPOSCOMPRAS
DROP TABLE Usuarios
DROP TABLE Visibilidades
DROP TABLE Estados
DROP TABLE Tablas
*/

CREATE TABLE Estados
(
	idEstado INT IDENTITY(1,1) NOT NULL,
	Descripcion VARCHAR(20) NOT NULL,
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

CREATE TABLE Tablas
(
	idTabla INT IDENTITY(1,1) NOT NULL,
	Descripcion VARCHAR(20) NOT NULL,
	CONSTRAINT PK_TiposUsuarios PRIMARY KEY (idTabla)
)

CREATE TABLE Usuarios
(
	idUsuario INT IDENTITY(1,1) NOT NULL,
	idTabla INT NULL,
	idNumeroTabla INT NOT NULL,
	login VARCHAR(10) NOT NULL,
	password VARCHAR(50) NULL,
	fallos INT NULL,
	idEstado INT NULL,
	CONSTRAINT PK_Usuarios PRIMARY KEY CLUSTERED (idUsuario ASC) ON [PRIMARY],
	CONSTRAINT FK_Usuarios_Tablas FOREIGN KEY (idTabla) REFERENCES Tablas(idTabla),
	CONSTRAINT FK_Usuarios_Estados FOREIGN KEY (IdEstado) REFERENCES Estados(IdEstado)
)

CREATE TABLE Rubros
(
	IdRubro INT IDENTITY(1,1) NOT NULL,
	Codigo INT NOT NULL,
	Descripcion VARCHAR(20) NOT NULL,
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
	Nombre VARCHAR(20) NULL,
	Apellido VARCHAR(20) NULL,
	NroDocumento NUMERIC(15,0) NULL,
	CUIL VARCHAR(11) NULL,
	IdTipoDoc INT NULL,
	Mail VARCHAR(25) NULL,
	Telefono VARCHAR(15) NOT NULL,
	Calle VARCHAR(20) NULL,
	PisoNro INT NULL,
	Depto VARCHAR(1) NULL,
	Localidad VARCHAR(20) NULL,
	CodigoPostal INT NULL,
	FechaNacimiento DATE NOT NULL,
	CONSTRAINT PK_Clientes PRIMARY KEY (idCliente),
	CONSTRAINT FK_Clientes_TiposDocumentos FOREIGN KEY (IdTipoDoc) REFERENCES TiposDocumentos(IdTipoDocumento)
)

CREATE TABLE Empresas
(
	IdEmpresa INT IDENTITY(1,1) NOT NULL,
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
	CONSTRAINT PK_Empresas PRIMARY KEY (idEmpresa)
)

CREATE TABLE Visibilidades
(
	IdVisibilidad INT IDENTITY(1,1) NOT NULL,
	Codigo INT NOT NULL,
	Descripcion VARCHAR(20) NOT NULL,
	PrecioPorPublicar NUMERIC(15,2) NOT NULL,
	PorcentajeVenta NUMERIC(4,2) NOT NULL,
	CONSTRAINT PK_Visibilidades PRIMARY KEY (idVisibilidad)
)

CREATE TABLE TiposPublicaciones
(	
	IdTipoPublicacion INT IDENTITY(1,1) NOT NULL,
	Descripcion VARCHAR(20) NOT NULL,
	CONSTRAINT PK_TiposPublicaciones PRIMARY KEY (IdTipoPublicacion)
)

CREATE TABLE Publicaciones
(
	IdPublicacion INT IDENTITY (1,1) NOT NULL,
	IdTipoPublicacion INT NOT NULL,
	IdVisibilidad INT NOT NULL,
	Valor NUMERIC(15,2) NOT NULL,
	IdEstado INT NOT NULL,
	FechaInicio DATE NOT NULL,
	FechaFin DATE NOT NULL,
	--CodigoPublicacion (Consecutivo entre publicaciones sean o no del mismo vendedor) es el idPublicacion.
	Descripcion VARCHAR(20) NULL,
	Stock INT NOT NULL,
	Precio NUMERIC (15,2) NOT NULL,
	IdUsuario INT NOT NULL,
	PermiteRealizarPreguntas BIT NOT NULL DEFAULT(1),
	CONSTRAINT PK_Publicaciones PRIMARY KEY (IdPublicacion),
	CONSTRAINT FK_Publicaciones_Usuarios FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario),
	CONSTRAINT FK_Publicaciones_Visibilidad FOREIGN KEY (IdVisibilidad) REFERENCES Visibilidades(IdVisibilidad),
	CONSTRAINT FK_Publicaciones_Estados FOREIGN KEY (IdEstado) REFERENCES Estados(IdEstado)
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

CREATE TABLE TiposCompras
(
	IdTipoCompra INT IDENTITY(1,1) NOT NULL,
	Descripcion VARCHAR(20) NOT NULL,
	CONSTRAINT PK_TiposCompras PRIMARY KEY (IdTipoCompra)
)

CREATE TABLE Compras
(
	IdCompra INT IDENTITY(1,1) NOT NULL,
	IdTipoCompra INT NOT NULL,
	IdUsrComprador INT NOT NULL,
	IdPublicacion INT NOT NULL,
	Precio NUMERIC(10,2) NOT NULL,
	IdEstado INT NOT NULL,
	CONSTRAINT PK_Compras PRIMARY KEY (IdCompra),
	CONSTRAINT FK_Compras_TipoCompra FOREIGN KEY (IdTipoCompra) REFERENCES TiposCompras(IdTipoCompra),
	CONSTRAINT FK_Compras_Usuarios FOREIGN KEY (IdUsrComprador) REFERENCES Usuarios(IdUsuario),
	CONSTRAINT FK_Compras_Publicaciones FOREIGN KEY (IdPublicacion) REFERENCES Publicaciones(IdPublicacion),
	CONSTRAINT FK_Compras_Estados FOREIGN KEY (IdEstado) REFERENCES Estados(IdEstado)
)

CREATE TABLE Calificaciones
(
	IdCalificacion INT IDENTITY(1,1) NOT NULL,
	IdCompra INT NOT NULL,
	Calificacion INT NOT NULL,
	Detalle VARCHAR(30) NULL,
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
	Descripcion VARCHAR(20) NULL,
	CONSTRAINT PK_FormasPago PRIMARY KEY (IdFormaPago)
)

CREATE TABLE Facturas
(
	IdFactura INT IDENTITY(1,1) NOT NULL,
	NroSucursal INT NOT NULL,
	NroFactura NUMERIC(15,0) NOT NULL,
	Fecha DATE NOT NULL,
	IdUsuario INT NOT NULL,
	IdFormaPago INT NOT NULL,
	IdEstado INT NOT NULL,
	NroTarjeta NUMERIC(18,0) NULL,
	FechaVencTarjeta DATETIME NULL,
	CodigoSeguridad INT NULL,
	TitularTarjeta VARCHAR(30) NULL,
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
	Precio NUMERIC(15,2) NOT NULL,
	Comision NUMERIC(5,2) NOT NULL,
	CantVendida INT NOT NULL,
	CONSTRAINT PK_FacturasItems PRIMARY KEY (IdFacturaItem),
	CONSTRAINT FK_FacturasItems_Facturas FOREIGN KEY (IdFactura) REFERENCES Facturas(IdFactura)
)


--Carga de Datos

INSERT Tablas 
(Descripcion) VALUES ('Cliente'),('Empresa')

INSERT FormasPago 
(Descripcion) VALUES ('Efectivo'),('Tarjeta de Credito'),('Tarjeta de Debito')

INSERT INTO Estados
(Descripcion) VALUES ('Inicial'),('Apagado')

INSERT TiposPublicaciones
(Descripcion) VALUES ('Compra Inmediata'),('Subasta')

INSERT TiposDocumentos 
(Descripcion) VALUES ('DNI'),('LE'),('LC')

INSERT Estados
(Descripcion) VALUES ('Inicial'),('Borrador'),('Activo'),('Pausado'),('Finalizado'),('Suspendido')

