using Geek_Text.Models;

namespace Geek_Text.Interface

{
    public interface IShoppingCartRepositories
    {
        Task<ShoppingCart> GetAsync(int userId);
        Task<ShoppingCart> Create(int userId, string name);
        Task<string> GetBooks(int userId);
        Task<ShoppingCart> AddBook(int userId, string bookIsbn);
        Task<ShoppingCart> DeleteBook(int userId, string bookIsbn);
    }
}
