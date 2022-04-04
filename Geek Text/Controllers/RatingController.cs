using Geek_Text.Models;
using Geek_Text.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Geek_Text.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RatingController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly RatingRepository _ratingRepository;

        public RatingController(ILogger<UsersController> logger, RatingRepository ratingRepository)
        {
            _logger = logger;
            _ratingRepository = ratingRepository;
        }

        [HttpGet("isbn/{isbn}", Name = "GetRatingsByISBN")]
        public async Task<IEnumerable<UserRating>> GetRatingsByISBN(string isbn)
        {
            return await _ratingRepository.GetRatingsByISBN(isbn);
        }

        [HttpPost(Name = "CreateRating")]
        public async Task<IActionResult> CreateRating(UserRating userRating)
        {
            if (userRating.Rating < 0 || userRating.Rating > 5)
                return BadRequest("Rating must be between 0 and 5");
            return Ok(await _ratingRepository.AddRating(userRating));
        }

        [HttpGet("AllRatings", Name = "GetAllRatingsSortByRating")]
        public async Task<IEnumerable<UserRating>> GetAllRatingsSorted(string bookIsbn)
        {
            return await _ratingRepository.GetRatingsSortedByRating(bookIsbn);
        }

        [HttpGet("AverageRating", Name = "GetAverageRating")]
        public async Task<float?> GetAverageRating(string bookIsbn)
        {
            return await _ratingRepository.GetAverageRating(bookIsbn);
        }
    }
}