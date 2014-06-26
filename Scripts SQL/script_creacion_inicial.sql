
/*Eliminar Tablas Existentes
DROP TABLE TIPOSPUBLICACIONES
DROP TABLE DatosTarjetas
DROP TABLE TiposPersonas
DROP TABLE Usuarios
DROP TABLE Visibilidades
DROP TABLE Estados

DROP TABLE UsuariosRoles
DROP TABLE FACTURASITEMS
DROP TABLE FACTURAS
DROP TABLE HISTORIALES
DROP TABLE RESPUESTAS
DROP TABLE PREGUNTAS
DROP TABLE PUBLICACIONESRUBROS
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
	Descripcion NVARCHAR(255) NULL
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
	--Precio NUMERIC(10,2) NOT NULL,
	--IdEstado INT NOT NULL,
	CONSTRAINT PK_Compras PRIMARY KEY (IdCompra),
	CONSTRAINT FK_Compras_Usuarios FOREIGN KEY (IdUsrComprador) REFERENCES Usuarios(IdUsuario),
	CONSTRAINT FK_Compras_Publicaciones FOREIGN KEY (IdPublicacion) REFERENCES Publicaciones(IdPublicacion),
)

CREATE TABLE Ofertas
(
	IdOferta INT IDENTITY (1,1) NOT NULL,
	IdPublicacion INT NOT NULL,
	IdUsrOfertante INT NOT NULL,
	Oferta_Fecha DATETIME,
	Oferta_Monto NUMERIC(18,2),
	CONSTRAINT PK_Ofertas PRIMARY KEY (IdOferta),
	CONSTRAINT FK_Ofertas_Usuarios FOREIGN KEY (IdUsrOfertante) REFERENCES Usuarios(idUsuario),
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
	Comision NUMERIC(18,2) NOT NULL,
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

Commit transaction
go
create trigger TRIGGER_CLIENTES_USUARIOS
  on Usuarios
  for insert
  as
  INSERT INTO Clientes
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
	Group by Cli_Dni,Cli_Nombre,Cli_Apeliido,Cli_Mail,Cli_Dom_Calle,Cli_Nro_Calle,Cli_Piso,Cli_Depto,Cli_Cod_Postal,Cli_Fecha_Nac,inserted.idUsuario,idEstado
	order by Cli_Apeliido 

go
	
create trigger TRIGGER_EMPRESAS_USUARIOS
  on Usuarios
  for insert
  as
  INSERT INTO Empresas
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
		'3' IdEstado
	FROM gd_esquema.Maestra,inserted
	WHERE Publ_Empresa_Mail=inserted.login
	group by Publ_Empresa_Cuit,Publ_Empresa_Razon_Social,
	Publ_Empresa_Fecha_Creacion,Publ_Empresa_Mail,
	Publ_Empresa_Dom_Calle,Publ_Empresa_Nro_Calle,
	Publ_Cli_Piso,Publ_Empresa_Depto,
	Publ_Empresa_Cod_Postal,
	inserted.idUsuario,idEstado

	order by Publ_Empresa_Razon_Social
go
;
/*
DROP TRIGGER TRIGGER_CLIENTES_USUARIOS
DROP TRIGGER TRIGGER_EMPRESAS_USUARIOS
*/
--------Carga de Datos iniciales

INSERT TiposPersonas
(Descripcion) VALUES ('Fisica'),('Juridica')

INSERT FormasPago 
(Descripcion) VALUES ('Efectivo'),('Tarjeta de Credito'),('Tarjeta de Debito')

INSERT TiposPublicaciones
(Descripcion) VALUES ('Compra Inmediata'),('Subasta')

INSERT TiposDocumentos 
(Descripcion) VALUES ('DNI'),('LE'),('LC')

INSERT Estados
(Descripcion) VALUES ('Habilitado'),('Deshabilitado'),('Inicial'),('Borrador'),('Publicada'),('Pausada'),('Finalizada')

INSERT Funcionalidades
(Descripcion) VALUES  
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

INSERT Roles
(Nombre,IdEstado) VALUES ('Cliente','1')  ,('Empresa','1'),('Administrativo','1')


INSERT RolesFuncionalidades
(IdRol,IdFuncionalidad)
select
'3',IdFuncionalidad 
from Funcionalidades

INSERT Usuarios
(idTipoPersona,
login,
password,
fallos,
reputacion,
idEstado)
VALUES('1','admin','12345678','0','0','3')  

INSERT UsuariosRoles
(IdRol,IdUsuario) VALUES (3,1)



--------MIGRACION---------------------------------------------------------------------------------------

INSERT INTO Visibilidades
(Codigo,
Descripcion,
Duracion,
PrecioPorPublicar,
PorcentajeVenta,
IdEstado)
select Publicacion_Visibilidad_Cod,
 Publicacion_Visibilidad_Desc,DATEDIFF(DD, Publicacion_Fecha,Publicacion_Fecha_Venc), 
 Publicacion_Visibilidad_Precio, 
 Publicacion_Visibilidad_Porcentaje,
 '1' IdEstado
 from gd_esquema.Maestra
 group by Publicacion_Visibilidad_Cod,Publicacion_Visibilidad_Desc,DATEDIFF(DD, Publicacion_Fecha,Publicacion_Fecha_Venc),
  Publicacion_Visibilidad_Precio, 
 Publicacion_Visibilidad_Porcentaje
order by Publicacion_Visibilidad_Cod


--Reputacion Clientes (divide por Operaciones realizadas? aunque no esten calificadas? )
/*select AVG(Calificacion_Cant_Estrellas)Reputacion
from gd_esquema.Maestra 
where Compra_Fecha is not NULL and Calificacion_Cant_Estrellas is not NULL and Publ_Cli_Dni is not NULL
group by Publ_Cli_Dni
*/
--INSERT RUBROS
INSERT INTO Rubros
(Descripcion)
select Publicacion_Rubro_Descripcion from gd_esquema.Maestra group by Publicacion_Rubro_Descripcion order by Publicacion_Rubro_Descripcion



--INSERT USUARIOS CLIENTE
INSERT INTO Usuarios
  (idTipoPersona,
  login,
  password,
  fallos,
  reputacion,
  idEstado)
  select '1' idTipoPersona,
		Cli_Mail,
		'12345678'password,
		'0'fallos,
		/*(select AVG(Calificacion_Cant_Estrellas)
         from gd_esquema.Maestra 
		 where Compra_Fecha is not NULL and Calificacion_Cant_Estrellas is not NULL and 
		 Publ_Cli_Dni=Cli_Dni
		 group by Publ_Cli_Dni)reputacion,*/
		 '0' reputacion,
		'3'idEstado
		from gd_esquema.Maestra
		where Cli_Dni is not null
		group by Cli_Dni,Cli_Mail,Cli_Apeliido
		order by Cli_Apeliido
		
--INSERT USUARIOS EMPRESA
INSERT INTO Usuarios
  (idTipoPersona,
  login,
  password,
  fallos,
  reputacion,
  idEstado)
  select '2' idTipoPersona,
		Publ_Empresa_Mail,
		'12345678'password,
		'0'fallos,
		/*(select AVG(Calificacion_Cant_Estrellas)
         from gd_esquema.Maestra 
		 where Compra_Fecha is not NULL and Calificacion_Cant_Estrellas is not NULL and 
		 Publ_Cli_Dni=Cli_Dni
		 group by Publ_Cli_Dni)reputacion,*/
		 '0' reputacion,
		'3'idEstado
		from gd_esquema.Maestra
		where Publ_Empresa_Cuit is not null
		group by Publ_Empresa_Cuit,Publ_Empresa_Mail,Publ_Empresa_Razon_Social
		order by Publ_Empresa_Razon_Social
			
--------------------------------
--INSERT PUBLICACIONES

INSERT INTO Publicaciones
(CodPublicacion,
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
PermiteRealizarPreguntas)

select Publicacion_Cod,
(select TiposPublicaciones.IdTipoPublicacion  from TiposPublicaciones where Publicacion_Tipo like TiposPublicaciones.Descripcion) tipo,
(select Visibilidades.IdVisibilidad from Visibilidades where  Publicacion_Visibilidad_Cod =Visibilidades.Codigo) IdVisibilidad,
(select Estados.idEstado from Estados where Publicacion_Estado like Estados.Descripcion)IdEstado,
Publicacion_Fecha,
Publicacion_Fecha_Venc,
Publicacion_Descripcion,
Publicacion_Stock,
Publicacion_Precio,

(select Rubros.IdRubro from Rubros where Publicacion_Rubro_Descripcion like Rubros.Descripcion)IdRubro ,
(select Usuarios.idUsuario from Usuarios where (Publ_Empresa_Mail like Usuarios.login or Publ_Cli_Mail like Usuarios.login))IdUsuario,
'1' PermiteRealizarPreguntas
from gd_esquema.Maestra 

group by Publicacion_Cod,Publicacion_Tipo,Publicacion_Visibilidad_Cod,Publicacion_Estado,
Publicacion_Fecha,Publicacion_Fecha_Venc,Publicacion_Descripcion,Publicacion_Stock,
Publicacion_Precio,
Publicacion_Rubro_Descripcion,Publ_Empresa_Mail,Publ_Cli_Mail
order by Publicacion_Cod


------ INSERT COMPRAS

INSERT INTO Compras
(IdUsrComprador,
IdPublicacion,
Fecha,
Cantidad)
select
(select Usuarios.idUsuario from Usuarios where Cli_Mail like Usuarios.login),
(select Publicaciones.IdPublicacion from Publicaciones where g.Publicacion_Cod = Publicaciones.CodPublicacion),
--g.Publicacion_Stock,
g.Compra_Fecha,
g.Compra_Cantidad
--select Publicacion_Cod,Publicacion_Stock,Cli_Dni,Oferta_Fecha ,Compra_Fecha,Compra_Cantidad,g.Calificacion_Codigo
from gd_esquema.Maestra g
where g.Compra_Fecha is not NULL and g.Calificacion_Codigo is NULL
order by g.Publicacion_Cod


---INSERT OFERTAS

INSERT INTO Ofertas
(IdPublicacion,
IdUsrOfertante,
Oferta_Fecha,
Oferta_Monto)
select
(select Publicaciones.IdPublicacion from Publicaciones where Publicacion_Cod = Publicaciones.CodPublicacion)IdPublicacion,
(select Usuarios.idUsuario from Usuarios where (Cli_Mail like Usuarios.login))IdUsr,
Oferta_Fecha,
Oferta_Monto
--select Publicacion_Cod,Oferta_Fecha,Oferta_Monto, Calificacion_Codigo
from gd_esquema.Maestra
where Oferta_Fecha is NOT NULL
order by Publicacion_Cod, Oferta_Monto

---INSERT CALIFICACIONES

-- Tenemos problemas con las compras que se realizaron con el mismo usuario, 
--misma publicacion y misma fecha de compra.

INSERT INTO Calificaciones
(IdCompra,
Codigo,
Calificacion,
Detalle)
select 
comp.IdCompra,--,pub.IdPublicacion,Publicacion_Cod,usr.idUsuario,Oferta_Fecha,
--(select IddCompra from Compras where Compras.Fecha=g.Compra_Fecha and Compras.IdPublicacion = (select IdPublicacion from Publicaciones where g.Publicacion_Cod= Publicaciones.CodPublicacion) ), 
Calificacion_Codigo,
Calificacion_Cant_Estrellas,
Calificacion_Descripcion
--SELECT COMP.*,PUB.*
from gd_esquema.Maestra g
inner join Publicaciones pub
on pub.CodPublicacion = g.Publicacion_Cod
inner join Usuarios usr
on g.Cli_Mail = usr.login
inner join Compras comp
	on comp.IdPublicacion = pub.IdPublicacion
    and comp.idUsrComprador = usr.idUsuario
	AND COMP.Fecha = G.Compra_Fecha
	
	

where g.Compra_Fecha is not NULL and g.Calificacion_Codigo is NOT NULL
group by comp.IdCompra,--pub.IdPublicacion,Publicacion_Cod,usr.idUsuario,Oferta_Fecha,
Calificacion_Codigo,	
Calificacion_Cant_Estrellas,
Calificacion_Descripcion

order by Calificacion_Codigo



-----INSERT FACTURAS

INSERT INTO Facturas
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
 (select IdUsuario from Usuarios where Usuarios.login = g.Publ_Cli_Mail or Usuarios.login=g.Publ_Empresa_Mail),
 (select IdFormaPago from FormasPago where FormasPago.Descripcion like g.Forma_Pago_Desc), 
 '3' IdEstado,
 Factura_Total  

 from gd_esquema.Maestra g


 where Factura_Nro IS NOT NULL 
 group by Factura_Nro , Factura_Fecha , Factura_Total,g.Publ_Cli_Mail,g.Publ_Empresa_Mail,
 g.Forma_Pago_Desc
  
 order by Factura_Nro
 
 
------INSERT ITEMS FACTURAS
INSERT INTO FacturasItems
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
inner join Facturas
on Facturas.NroFactura=g.Factura_Nro
inner join Publicaciones
on g.Publicacion_Cod =Publicaciones.CodPublicacion
inner join Visibilidades
on Visibilidades.IdVisibilidad = Publicaciones.IdVisibilidad
where Factura_Nro is not NULL 

order by Factura_Nro
