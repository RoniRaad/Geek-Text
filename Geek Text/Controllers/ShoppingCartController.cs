using Geek_Text.Interface;
using Geek_Text.Models;
using Geek_Text.Request;
using Microsoft.AspNetCore.Mvc;

namespace Geek_Text.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartRepositories _IShoppingCartRepositories;

        public ShoppingCartController (IShoppingCartRepositories shoppingCartRepository)
        {
            _IShoppingCartRepositories = shoppingCartRepository;
        }

        [HttpGet(Name = "GetBooks/")]
        public async Task<string> GetAsync(int userId)
        {
            var Books = await _IShoppingCartRepositories.GetBooks(userId);
            return Books;
        }

        [HttpPost(Name = "Create/")]
        public async Task<IActionResult> Create([FromBody] CreateShoppingCartRequest request)
        {
            var shoppingCart =  await _IShoppingCartRepositories.Create(request.UserId, request.Name);
            return Ok(shoppingCart); 
        }

        
        [HttpPut(Name = "AddBook/")]
        public async Task<IActionResult> AddBook([FromBody] UpdateShoppingCartRequest request)
        {
            var shoppingCart = await _IShoppingCartRepositories.AddBook(request.UserId, request.BookIsbn);
            return Ok(shoppingCart);
        }

        //need to check
        [HttpDelete(Name = "DeleteBook/")]
        public async Task<IActionResult> DeleteBook([FromBody] RemoveShoppingCartRequesr request)
        {
            var shoppingCart = await _IShoppingCartRepositories.DeleteBook(request.UserId, request.Name);
            return Ok(shoppingCart);
        }

    }
}
