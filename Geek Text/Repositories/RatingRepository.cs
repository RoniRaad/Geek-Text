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
    }
}
