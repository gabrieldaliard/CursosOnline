CREATE TABLE [dbo].[Cursos]
(
	[IdCurso] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Titulo] VARCHAR(100) NOT NULL, 
    [idInstructor] INT NOT NULL, 
    [FechaCreacion] DATETIME NULL DEFAULT getDate(), 
    [FechaModificacion] DATETIME NULL DEFAULT getDate(), 
    [Interesados] INT NULL DEFAULT 0, 
    [Estudiantes] INT NULL DEFAULT 0, 
    [IdEstado] BIT NOT NULL DEFAULT 0, 
    [Destacado] BIT NOT NULL DEFAULT 0 ,
    [LinkVideo] NVARCHAR(MAX) NULL, 
    CONSTRAINT [FK_Cursos_Instructores] FOREIGN KEY ([idInstructor]) REFERENCES [Instructores]([IdInstructor]),
)
