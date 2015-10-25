CREATE TABLE [dbo].[Usuario] (
    [ProtectorId]  INT           NOT NULL,
    [Nombre]       VARCHAR (255) NOT NULL,
    [Apellido]     VARCHAR (255) NOT NULL,
    [Organizacion] VARCHAR (255) NULL,
    [Correo]       VARCHAR (255) NOT NULL,
    [Password]     VARCHAR (255) NOT NULL,
    [Telefono]     VARCHAR (255) NULL,
    [Direccion]    VARCHAR (255) NULL,
    [Perfil]       VARCHAR (255) NOT NULL,
    PRIMARY KEY CLUSTERED ([ProtectorId] ASC),
    UNIQUE NONCLUSTERED ([Correo] ASC)
);

CREATE TABLE [dbo].[TipoAnimal] (
    [ProtectorId] INT           NOT NULL,
    [Tipo]        VARCHAR (255) NOT NULL,
    FOREIGN KEY ([ProtectorId]) REFERENCES [dbo].[Usuario] ([ProtectorId])
);

CREATE TABLE [dbo].[Pedido] (
    [ProtectorId] INT      NOT NULL,
    [FechaHora]   DATETIME NOT NULL,
    [Latitud]     REAL     NOT NULL,
    [Longitud]    REAL     NOT NULL,
    FOREIGN KEY ([ProtectorId]) REFERENCES [dbo].[Usuario] ([ProtectorId])
);

CREATE TABLE [dbo].[Direccion] (
    [ProtectorId] INT  NOT NULL,
    [Latitud]     REAL NOT NULL,
    [Longitud]    REAL NOT NULL,
    FOREIGN KEY ([ProtectorId]) REFERENCES [dbo].[Usuario] ([ProtectorId])
);

CREATE TABLE [dbo].[AdopcionAnimal]
(
	[ProtectorId] INT NOT NULL FOREIGN KEY REFERENCES Usuario(ProtectorId), 
    [Nombre] VARCHAR(255) NOT NULL, 
    [Especie] VARCHAR(255) NOT NULL
)
