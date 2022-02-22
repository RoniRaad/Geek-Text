using Geek_Text.Models;
using Geek_Text.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Geek_Text.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookDetailsController : ControllerBase
    {
        private readonly ILogger<BookDetailsController> _logger;
        private readonly BookDetailsRepository _bookDetailsRepository;

        public BookDetailsController(ILogger<BookDetailsController> logger, BookDetailsRepository bookDetailsRepository)
        {
            _logger = logger;
            _bookDetailsRepository = bookDetailsRepository;
        }

        [HttpPost(Name = "Add Book")]
        public async Task<BookDetails> Add([FromBody] BookDetails bookDetails)
        {
            return await _bookDetailsRepository.AddBook(bookDetails);
        }
        
        [HttpGet("ISBN/{ISBN}", Name = "GetByISBN")]
        public async Task<BookDetails> GetByISBN(string isbn)
        {
            return await _bookDetailsRepository.GetByISBN(new BookDetails { ISBN = isbn });
        }

        [HttpGet("Author/{Author}", Name = "GetByAuthor")]
        public async Task<IEnumerable<BookDetails>> GetByAuthor(string author)
        {
            return await _bookDetailsRepository.GetByAuthor(new BookDetails { Author = author });
        }

    }
}