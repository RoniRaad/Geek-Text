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

        [HttpGet("isbn/isbn", Name = "GetRatingsByISBN")]
        public async Task<IEnumerable<UserRating>> GetUserById(string ISBN)
        {
            return await _ratingRepository.GetRatingsByISBN(ISBN);
        }

        [HttpPost(Name = "CreateRating")]
        public async Task<UserRating> CreateRating(UserRating userRating)
        {
            return await _ratingRepository.AddRating(userRating);
        }
    }
}