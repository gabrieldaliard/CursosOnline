CREATE TABLE [dbo].[Usuarios]
(
	[IdUsuario] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Email] NVARCHAR(50) NULL, 
    [FechaInscripcion] DATETIME NULL DEFAULT getDate(), 
    [UltimoAcceso] DATETIME NULL, 
    [Nombre] NVARCHAR(50) NULL, 
    [Apellido] NVARCHAR(50) NULL, 
    [IdPais] INT NULL, 
    [Contraseña] NCHAR(10) NULL, 
    CONSTRAINT [FK_Usuarios_Pais] FOREIGN KEY ([IdPais]) REFERENCES [Paises]([IdPais])
)
