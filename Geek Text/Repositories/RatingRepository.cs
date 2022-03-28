using Dapper;
using Geek_Text.Models;

namespace Geek_Text.Repositories
{
    public class RatingRepository
    {
        private readonly DatabaseContext _context;
        public RatingRepository(DatabaseContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<IEnumerable<UserRating>> GetRatingsByISBN(string ISBN)
        {
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<UserRating>("SELECT * FROM BookRating WHERE BookISBN=@BookId;", new { BookId = ISBN }); 
            }
        }

        public async Task<UserRating> AddRating(UserRating userRating)
        {
            using (var connection = _context.CreateConnection())
            {
                await connection.QueryAsync<UserRating>("INSERT INTO BookRating(Rating, BookISBN, Created, UserId) VALUES (@Rating, @BookISBN, default, @UserId)", userRating);
            }

            return userRating;
        }
    }
}
