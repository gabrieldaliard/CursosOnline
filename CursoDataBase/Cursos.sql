CREATE TABLE [dbo].[Cursos]
(
	[IdCurso] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Titulo] VARCHAR(100) NOT NULL, 
    [idInstructor] INT NOT NULL, 
    [FechaCreacion] DATETIME NULL DEFAULT getDate(), 
    [FechaModificacion] DATETIME NULL DEFAULT getDate(), 
    [Interesados] INT NULL DEFAULT 0, 
    [Estudiantes] INT NULL DEFAULT 0, 
    [IdEstado] INT NOT NULL DEFAULT 1, 
    [Destacado] BIT NOT NULL DEFAULT 0 ,
    CONSTRAINT [FK_Cursos_Instructores] FOREIGN KEY ([idInstructor]) REFERENCES [Instructores]([IdInstructor]),
    CONSTRAINT [FK_Cursos_Estados] FOREIGN KEY ([IdEstado]) REFERENCES [Estados]([IdEstado])
)
