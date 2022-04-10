CREATE TABLE [dbo].[shopping_cart]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[UserId] INT NOT NULL,
	[BookIsbns] Text NOT NULL,
	
)
