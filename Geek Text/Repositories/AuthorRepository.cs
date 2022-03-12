using Dapper;
using Geek_Text.Models;

namespace Geek_Text.Repositories
{
    public class AuthorRepository
    {
        private readonly DatabaseContext _context;
        public AuthorRepository(DatabaseContext dbContext, AuthorRepository authorRepository)
        {
            _context = dbContext;
        }

        public async Task<Author> AddAuthor(Author author)
        {
            using (var connection = _context.CreateConnection())
            {
                await connection.QueryAsync<Author>("INSERT INTO Author(FirstName, LastName, Biograhpy, Publisher, ID) VALUES (@FirstName, @LastName, @Biography, @Publisher, @ID);", author);
                return author;
            }
        }

        public async Task<Author> GetByLastName(Author author)
        {
            using (var connection = _context.CreateConnection())
            {
                await connection.QueryAsync<Author>("SELECT * FROM Author WHERE LastName=@LastName,", author);
                return author;
            }
        }

    }
}
