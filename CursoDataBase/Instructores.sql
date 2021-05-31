CREATE TABLE [dbo].[Instructores]
(
	[IdInstructor] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Nombre] NVARCHAR(50) NULL, 
    [Apellido] NVARCHAR(50) NULL, 
    [Descripción] NVARCHAR(MAX) NOT NULL, 
    [IdPais] INT NOT NULL,
    CONSTRAINT [FK_Instructores_Pais] FOREIGN KEY ([IdPais]) REFERENCES [Paises]([IdPais])

)
