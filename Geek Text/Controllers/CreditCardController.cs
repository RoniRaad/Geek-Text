using Geek_Text.Models;
using Geek_Text.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Geek_Text.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreditCardController : ControllerBase
    {
        private readonly ILogger<CreditCardController> _logger;
        private readonly CreditCardRepository _creditcardRepository;
        
        public CreditCardController(ILogger<CreditCardController> logger, CreditCardRepository creditcardRepository)
        {
            _logger = logger;
            _creditcardRepository = creditcardRepository;
        }

        [HttpPost(Name = "CreateCreditCard")]
        public async Task<CreditCard> CreateCreditCard([FromBody] CreditCard creditcard)
        {
            return await _creditcardRepository.CreateCreditCard(creditcard);
        }

        [HttpGet("id/{id}", Name = "GetCreditCardsByUsersId")]
        public async Task<IEnumerable<CreditCard>> GetCreditCardsByUsersId(int id)
        {
            return await _creditcardRepository.GetCreditCardsByUsersId(id);
        }

    

    }
}
