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
        private readonly AuthorsRepository _authorsRepository;

        public BookDetailsController(ILogger<BookDetailsController> logger, BookDetailsRepository bookDetailsRepository, AuthorsRepository authorsRepository)
        {
            _logger = logger;
            _bookDetailsRepository = bookDetailsRepository;
            _authorsRepository = authorsRepository;
        }

        [HttpPost(Name = "Add Book")]
        public async Task<BookDetails> Add([FromBody] BookDetails bookDetails)
        {
            return await _bookDetailsRepository.AddBook(bookDetails);
        }
        
        [HttpGet("ISBN", Name = "GetByISBN")]
        public async Task<BookDetails> GetByISBN(string isbn)
        {
            return await _bookDetailsRepository.GetByISBN(new BookDetails { ISBN = isbn });
        }

        [HttpGet("Author", Name = "GetByAuthorLastName")]
        public async Task<IEnumerable<BookDetails>> GetByAuthor(string lastName)
        {
            var books = new List<BookDetails>();
            var authors = await _authorsRepository.GetByLastName(new Author { LastName = lastName });
            foreach(var author in authors)
            {
               var relevantBooks = await _bookDetailsRepository.GetByAuthor(new BookDetails { Author = author.ID });
                
                foreach(var book in relevantBooks)
                {
                    books.Add(book);
                }
            }
            return books;
        }

    }
}