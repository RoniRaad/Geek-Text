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

        [HttpGet(Name = "GetUsers")]
        public async Task<IEnumerable <User>> GetUsers()
        {
            return await _userRepository.GetUsers();
        }


        [HttpGet("email/{email}", Name = "GetUserByEmail")]
        public async Task<User> GetUserByEmail(string email)
        {
            return await _userRepository.GetUser(new User { Email = email });
        }


        [HttpPost(Name = "CreateUser")]
        public async Task<User> CreateUserByEmail([FromBody] User user)
       {
            return await _userRepository.CreateUser(user);
           
        }


        [HttpPut(Name = "UpdateUser")]
        public async Task<User> Put([FromBody] User user)
        {
            return await _userRepository.Put(user);
        }



    }
}