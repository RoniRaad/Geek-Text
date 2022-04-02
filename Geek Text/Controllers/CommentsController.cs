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

        [HttpGet("isbn/isbn", Name = "GetCommentsByISBN")]
        public async Task<IEnumerable<UserComment>> GetCommentByISBN(string ISBN)
        {
            return await _commentRepository.GetCommentsByISBN(ISBN);
        }

        [HttpPost(Name = "CreateComments")]
        public async Task<UserComment> CreateRating(UserComment userComment)
        {
            return await _commentRepository.AddComment(userComment);
        }

        [HttpPost(Name = "GetComments")]
        public async Task<IEnumerable<UserComment>> GetRating(string bookIsbn)
        {
            return await _commentRepository.GetComments(bookIsbn);
        }
    }
}