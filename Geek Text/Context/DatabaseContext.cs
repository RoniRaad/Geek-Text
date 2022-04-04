using Dapper;
using Geek_Text.Models;
using System.Data;
using System.Data.SqlClient;

namespace Geek_Text
{
    public class DatabaseContext
    {
        private readonly DatabaseConfig _databaseConfig;

        public DatabaseContext(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_databaseConfig.ConnectionString);

        public async void SeedDatabase()
        {
            using (var connection = this.CreateConnection())
            {
                await connection.QueryAsync("TRUNCATE TABLE users;");
                await connection.QueryAsync("TRUNCATE TABLE BookComment;");
                await connection.QueryAsync("TRUNCATE TABLE BookRating;");
                await connection.QueryAsync("INSERT INTO users(Email, PasswordHash, Name, [Home Address]) VALUES ('test@test.com', 'injbdeftnijdb', 'Test Name', 'Test Address');");
                await connection.QueryAsync("TRUNCATE TABLE DBO.Authors;");
                await connection.QueryAsync("TRUNCATE TABLE DBO.BookDetails;");
                await connection.QueryAsync("TRUNCATE TABLE dbo.bookdetails;");
                await connection.QueryAsync("INSERT INTO dbo.bookdetails(ISBN, Name, Description, Price,Author,Genre,Publisher, [Year Published], Sold) VALUES ('5627890', 'Book', 'Test Description',9.99 , 'Jk Rowling', 'Horror' , 'Test Publisher' , '2010' , 1000);");
                await connection.QueryAsync("INSERT INTO dbo.bookdetails(ISBN, Name, Description, Price,Author,Genre,Publisher, [Year Published], Sold) VALUES ('5267890', 'Cook', 'Test Description',9.99 , 'Jk Rowling', 'Horror' , 'Test Publisher' , '2010' , 10000);");
                await connection.QueryAsync("INSERT INTO dbo.bookdetails(ISBN, Name, Description, Price,Author,Genre,Publisher, [Year Published], Sold) VALUES ('5637890', 'Dook', 'Test Description',9.99 , 'Jk Rowling', 'Horror' , 'Test Publisher' , '2010' , 100000);");
                await connection.QueryAsync("INSERT INTO dbo.bookdetails(ISBN, Name, Description, Price,Author,Genre,Publisher, [Year Published], Sold) VALUES ('5567890', 'Eook', 'Test Description',9.99 , 'Jk Rowling', 'Horror' , 'Test Publisher' , '2010' , 1000000);");
                await connection.QueryAsync("INSERT INTO dbo.bookdetails(ISBN, Name, Description, Price,Author,Genre,Publisher, [Year Published], Sold) VALUES ('5667890', 'Fook', 'Test Description',9.99 , 'Jk Rowling', 'Horror' , 'Test Publisher' , '2010' , 1000000000);");
            }
        }
    }
}
