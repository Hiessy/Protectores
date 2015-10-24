CREATE TABLE [dbo].[Usuario]
(
	[Correo] VARCHAR(255) NOT NULL PRIMARY KEY, 
    [Nombre] VARCHAR(255) NOT NULL, 
    [Apellido] VARCHAR(255) NOT NULL, 
    [Organizacion] VARCHAR(255) NULL, 
    [Password] VARCHAR(255) NOT NULL, 
    [Telefono] VARCHAR(255) NOT NULL, 
    [Direccion] VARCHAR(255) NULL, 
    [Perfil] VARCHAR(255) NOT NULL
)


GO

CREATE INDEX [IX_Usuario_Correo] ON [dbo].[Usuario] (Correo)
