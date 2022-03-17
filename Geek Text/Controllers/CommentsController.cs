using Geek_Text.Models;
using Geek_Text.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Geek_Text.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly CommentRepository _commentRepository;

        public CommentsController(ILogger<UsersController> logger, CommentRepository commentRepository)
        {
            _logger = logger;
            _commentRepository = commentRepository;
        }

        [HttpGet("isbn/isbn", Name = "GetRatingsByISBN")]
        public async Task<IEnumerable<UserComment>> GetCommentByISBN(string ISBN)
        {
            return await _commentRepository.GetCommentsByISBN(ISBN);
        }

        [HttpPost(Name = "CreateRating")]
        public async Task<UserComment> CreateRating(UserComment userComment)
        {
            return await _commentRepository.AddComment(userComment);
        }
    }
}