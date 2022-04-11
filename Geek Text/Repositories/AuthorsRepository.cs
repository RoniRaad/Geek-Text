using Dapper;
using Geek_Text.Models;

namespace Geek_Text.Repositories
{
    public class AuthorsRepository
    {
        private readonly DatabaseContext _context;
        public AuthorsRepository(DatabaseContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<Author> AddAuthor(Author author)
        {
            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QueryFirstAsync<int>("INSERT INTO Authors(FirstName, LastName, Biography, Publisher) OUTPUT Inserted.ID VALUES (@FirstName, @LastName, @Biography, @Publisher);", author);
                author.ID = id;
                return author;
            }
        }

        public async Task<IEnumerable<Author>> GetByLastName(Author author)
        {
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<Author>("SELECT * FROM Authors WHERE LastName=@LastName;", author);
            }
        }

    }
}
