CREATE TABLE [dbo].[UsuariosCursos]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [IdCurso] INT NOT NULL, 
    [IdUsuario] INT NOT NULL,
    CONSTRAINT [FK_UsuariosCursos_Curso] FOREIGN KEY ([IdCurso]) REFERENCES [Cursos]([IdCurso]),
    CONSTRAINT [FK_UsuariosCursos_Usuario] FOREIGN KEY ([IdUsuario]) REFERENCES [Usuarios]([IdUsuario])
)
