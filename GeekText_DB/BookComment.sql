﻿CREATE TABLE [dbo].[BookComment]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Comment VARCHAR(255) NOT NULL,
	Created TIMESTAMP NOT NULL,
	UserId INT NOT NULL,
	BookISBN INT NOT NULL
)