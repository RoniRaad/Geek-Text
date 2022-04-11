
using Geek_Text.Models;
using Geek_Text.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Geek_Text.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrowsingSortingController : ControllerBase
    {
        private readonly BrowsingSortingRepository _browsingSortingRepository;

        public BrowsingSortingController (BrowsingSortingRepository browsingSortingRepository)
        {
            _browsingSortingRepository = browsingSortingRepository;
        }

        [HttpGet("Genre",Name = "GetByGenre")]

        public async Task<IEnumerable<BookDetails?>> GetByGenre(string Genre)
        {
           var browsing = await _browsingSortingRepository.GetByGenre(Genre);
            return browsing;
        }
        
        [HttpGet("TopSellers", Name = "TopSellers")]
        
        public async Task<IEnumerable<BookDetails?>> GetByTopSellers()
        {
            var browsing = await _browsingSortingRepository.GetByTopSellers();
            return browsing;
        }

        [HttpGet("Offset", Name = "OffsetBy")]

        public async Task<IEnumerable<BookDetails?>> GetByTopSellers(int Offset,int Rows)
        {
            var browsing = await _browsingSortingRepository.GetByOffset(Offset,Rows);
            return browsing;
        }

        [HttpGet("MinimumRating", Name = "MinimumRating")]

        public async Task<IEnumerable<BookDetails?>> GetbyRating(int rating)
        {
            var browsing = await _browsingSortingRepository.GetByRating(rating);
            return browsing;
        }

    }
}
