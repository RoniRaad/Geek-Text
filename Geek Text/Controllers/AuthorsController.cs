using Geek_Text.Models;
using Geek_Text.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Geek_Text.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly ILogger<AuthorsController> _logger;
        private readonly AuthorsRepository _authorRepository;

        public AuthorsController(ILogger<AuthorsController> logger, AuthorsRepository authorRepository)
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