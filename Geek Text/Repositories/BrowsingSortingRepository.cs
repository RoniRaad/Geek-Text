using Dapper;
using Geek_Text.Models;

namespace Geek_Text.Repositories
{
    public class BrowsingSortingRepository
    {

        private readonly DatabaseContext _context;
        private readonly RatingRepository _ratingRepository;
        private readonly BookDetailsRepository _bookDetailsRepository;

        public BrowsingSortingRepository(DatabaseContext dbContext, RatingRepository ratingRepository, BookDetailsRepository bookDetailsRepository)
        {
            _context = dbContext;
            _ratingRepository = ratingRepository;
            _bookDetailsRepository = bookDetailsRepository; 

        }

        public async Task<IEnumerable<BookDetails?>> GetByGenre(string genre)
        {
            using (var connection = _context.CreateConnection())
            {
                var results = await connection.QueryAsync<BookDetails>("SELECT * FROM BookDetails WHERE Genre=@Genre;", new {Genre = genre});

                return results;
            }
        }

        public async Task<IEnumerable<BookDetails?>> GetByTopSellers()
        {
            using (var connection = _context.CreateConnection())
            {
                var results = await connection.QueryAsync<BookDetails>("SELECT TOP 10 * FROM BookDetails ORDER BY Sold DESC;" );

                return results;
            }
        }

        public async Task<IEnumerable<BookDetails?>> GetByOffset(int Offset,int Rows)
        {
            using (var connection = _context.CreateConnection())
            {
                var results = await connection.QueryAsync<BookDetails>("SELECT * FROM BookDetails ORDER BY Name ASC OFFSET @Offset ROWS FETCH NEXT @Rows ROWS ONLY;", new {Offset = Offset, Rows = Rows });

                return results;
            }
        }

        public async Task<IEnumerable<BookDetails?>> GetByRating(int rating)
        {
            using (var connection = _context.CreateConnection())

            {
                var results = await connection.QueryAsync<BookDetails>("SELECT ISBN FROM BookDetails ;");
                var books = new List<BookDetails>();
                foreach (var item in results)
                {
                    if (await _ratingRepository.GetAverageRating(item.ISBN) >= rating)
                        books.Add(item);

                }
                return books;
            }
        }


    }
}

