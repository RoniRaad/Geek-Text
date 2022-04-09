CREATE TABLE [dbo].[users]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Email] VARCHAR(25) NOT NULL,
	[PasswordHash] VARCHAR(255) NOT NULL,
	[Name] VARCHAR(25),
	[Address] VARCHAR(100), 
    
)
