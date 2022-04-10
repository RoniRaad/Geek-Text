using Dapper;
using Geek_Text.Interface;
using Geek_Text.Models;


namespace Geek_Text.Repositories
{
    public class ShoppingCartRepositories : IShoppingCartRepositories
    {
        private readonly DatabaseContext _context;

        public ShoppingCartRepositories(DatabaseContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<ShoppingCart> GetAsync(int userId)
        {
            using var connection = _context.CreateConnection();
            var a = await connection.QuerySingleOrDefaultAsync<ShoppingCart>($"select * from dbo.Shopping_cart WHERE UserId = @UserId" ,new { UserId = userId });
            return a;
        }

        public async Task<string> GetBooks(int userId)
        {
            var shoppingCart = await GetAsync(userId);
            return shoppingCart.BookIsbns;
          
        }

        public async Task<ShoppingCart> Create(int userId, string name)
        {
            using var connection = _context.CreateConnection();
            connection.Open();
            return await connection.QuerySingleOrDefaultAsync<ShoppingCart>($"INSERT INTO dbo.Shopping_cart (UserId, BookIsbns) " +
                                                                            $"VALUES( @UserId,'')" ,new { UserId = userId });

        }
       
         public async Task<ShoppingCart> AddBook(int userId, string bookIsbn)
        {
            var shoppingCart = await GetAsync(userId);
            var bookIsbns = shoppingCart.BookIsbns + bookIsbn + ",";


            using var connection = _context.CreateConnection();
            connection.Open();
            return await connection.QuerySingleOrDefaultAsync<ShoppingCart>($"UPDATE dbo.Shopping_cart " +
                                                                            $"SET BookIsbns = @BookIsbns " +
                                                                            $"WHERE UserId = @UserId ", new { UserId = userId, BookIsbns = bookIsbns });

        }

        public async Task<ShoppingCart> DeleteBook(int userId, string bookIsbn)
        {
            
            var shoppingCart = await GetAsync(userId);
            var bookIsbns = shoppingCart.BookIsbns.Replace(bookIsbn + ",", "");
            

            using var connection = _context.CreateConnection();
            connection.Open();
            return await connection.QuerySingleOrDefaultAsync<ShoppingCart>($"UPDATE dbo.Shopping_cart " +
                                                                            $"SET BookIsbns = @BookIsbns " +  
                                                                            $"WHERE UserId = @UserId ", new { UserId = userId, BookIsbns = bookIsbns});
                                                                            

        }
    }
}
