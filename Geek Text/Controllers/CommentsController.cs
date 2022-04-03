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

        [HttpPost(Name = "CreateComments")]
        public async Task<UserComment> CreateComment(UserComment userComment)
        {
            return await _commentRepository.AddComment(userComment);
        }

        [HttpGet("isbn/{isbn}", Name = "GetComments")]
        public async Task<IEnumerable<UserComment>> GetComments(string isbn)
        {
            return await _commentRepository.GetComments(isbn);
        }
    }
}