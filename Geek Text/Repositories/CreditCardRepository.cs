using Dapper;
using Geek_Text.Models;

namespace Geek_Text.Repositories
{
    public class CreditCardRepository
    {
        private readonly DatabaseContext _context;

        public CreditCardRepository(DatabaseContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<CreditCard> CreateCreditCard(CreditCard creditcard)
        {

            using (var connection = _context.CreateConnection())
            {

                 await connection.QueryAsync("INSERT INTO creditcards(CardNumber, UserId, ExpirationYear, CVVNumber) VALUES (@CardNumber, @UserId, @ExpirationYear, @CVVNumber);",
                          new { UserId = creditcard.UserId, CardNumber = creditcard.CardNumber, ExpirationYear = creditcard.ExpirationYear, CVVNumber = creditcard.CVVNumber});
                
                return creditcard;
            }
        }
        
        

        public async Task<IEnumerable<CreditCard>> GetCreditCardsByUsersId(int userId)
        {
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<CreditCard>("SELECT * FROM creditcards WHERE UserId=@userId;", new { UserId = userId});

            }
        }


    }
}
