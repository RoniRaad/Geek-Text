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

        [HttpGet("id/{id}", Name = "GetUserById")]
        public async Task<User> GetBooksComments(int ISNB)
        {
            return;
        }
    }
}