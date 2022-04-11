CREATE TABLE [dbo].[creditcards]
(
	[Id] INT NOT NULL IDENTITY(0,1) PRIMARY KEY,
    [CardNumber] NVARCHAR(16) NOT NULL, 
    [ExpirationYear] VARCHAR(4) NOT NULL, 
    [CVVNumber] VARCHAR(3) NOT NULL, 
    [UserID] INT NOT NULL, 
    
    

)
