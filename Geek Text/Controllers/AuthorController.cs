using Geek_Text.Models;
using Geek_Text.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Geek_Text.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly ILogger<AuthorController> _logger;
        private readonly AuthorRepository _authorRepository;

        public AuthorController(ILogger<AuthorController> logger, AuthorRepository authorRepository)
        {
            _logger = logger;
            _authorRepository = authorRepository;
        }

        [HttpPost(Name = "Add Author")]
        public async Task<Author> AddAuthor([FromBody] Author author)
        {
            return await _authorRepository.AddAuthor(author);
        }
    }
}