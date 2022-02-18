using Geek_Text.Models;
using Geek_Text.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Geek_Text.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly UserRepository _userRepository;

        public UsersController(ILogger<UsersController> logger, UserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpGet("id/{id}", Name = "GetUserById")]
        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetUser(new User { Id = id });
        }

        [HttpGet("email/{email}", Name = "GetUserByEmail")]
        public async Task<User> GetUserByEmail(string email)
        {
            return await _userRepository.GetUser(new User { Email = email });
        }
    }
}