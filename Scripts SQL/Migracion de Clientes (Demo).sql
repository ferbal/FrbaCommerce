INSERT INTO Clientes 
	(Nombre,
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
	FechaNacimiento
	)
	SELECT 
			CAST(Cli_Nombre AS VARCHAR(20)),
			CAST(Cli_Apeliido AS VARCHAR(20)),
			Cli_Dni,
			NULL CUIL,
			1 idTipoDocumento,
			CAST(Cli_Mail AS VARCHAR(25)),
			'1111-1111' Telefono,
			CAST(Cli_Dom_Calle + CAST(Cli_Nro_Calle AS VARCHAR(10)) AS VARCHAR(20)) Domicilio,
			Cli_Piso,
			CAST(Cli_Depto AS VARCHAR(1)),
			'Inicial' Localidad,
			CAST(Cli_Cod_Postal AS INT),
			Cli_Fecha_Nac
	FROM gd_esquema.Maestra
	WHERE Cli_Nombre is not null