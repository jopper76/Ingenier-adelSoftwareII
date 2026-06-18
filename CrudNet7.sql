Create DATABASE CrudNet7
USE CrudNet7



  CREATE TABLE [dbo].[Contacto](
        [Id]            INT IDENTITY(1,1) NOT NULL,
        [Nombre]        NVARCHAR(MAX)     NOT NULL,
        [Telefono]      NVARCHAR(MAX)     NOT NULL,
        [Celular]       NVARCHAR(MAX)     NOT NULL,
        [Email]         NVARCHAR(MAX)     NOT NULL,
        [FechaCreacion] DATETIME2(7)      NOT NULL,
        CONSTRAINT [PK_Contacto] PRIMARY KEY CLUSTERED ([Id] ASC)
  )

SELECT TOP (100) [Id]
	,[Nombre]
	,[Telefono]
	,[Celular]
	,[Email]
	,[FechaCreacion]
From [CrudNET7].[dbo].[Contacto]