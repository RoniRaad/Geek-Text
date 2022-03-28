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
            }
        }
    }
}
