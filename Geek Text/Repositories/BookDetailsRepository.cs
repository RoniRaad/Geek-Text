using Dapper;
using Geek_Text.Models;

namespace Geek_Text.Repositories
{
    public class BookDetailsRepository
    {
        private readonly DatabaseContext _context;
        public BookDetailsRepository(DatabaseContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<BookDetails> AddBook(BookDetails bookDetails)
        {
            using (var connection = _context.CreateConnection())
            {
                await connection.QueryAsync<BookDetails>("INSERT INTO BookDetails(ISBN, Name, Description, Price, Author, Genre, Publisher, [Year Published], Sold) VALUES (@ISBN, @Name, @Description, @Price, @Author, @Genre, @Publisher, @YearPublished, @Sold);", bookDetails);
                return bookDetails;
            }
        }

        public async Task<BookDetails> GetByISBN(BookDetails bookDetails)
        {
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryFirstAsync<BookDetails>("SELECT * FROM BookDetails WHERE ISBN=@ISBN;", bookDetails);

            }
        }

        public async Task<IEnumerable<BookDetails>> GetByAuthor(BookDetails bookDetails)
        {
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<BookDetails>("SELECT * FROM BookDetails WHERE Author=@Author;", bookDetails);
            }
        }
       
    }
}
