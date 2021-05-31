CREATE TABLE [dbo].[PreguntasFreq]
(
	[IdPregunta] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Pregunta] NVARCHAR(MAX) NULL, 
    [Respuesta] NVARCHAR(MAX) NULL, 

)
