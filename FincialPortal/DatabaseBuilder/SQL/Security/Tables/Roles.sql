﻿CREATE TABLE [Security].[Roles](
	[Id] [int] IDENTITY NOT NULL,
	[Name] [nvarchar](max) NOT NULL)
GO

ALTER TABLE [Security].[Roles]

ADD CONSTRAINT [PK_Security.Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
GO

AUTOPROC All [Security].[Roles]
GO