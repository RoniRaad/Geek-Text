using Dapper;
using Geek_Text.Models;

namespace Geek_Text.Repositories
{
    public class UserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext dbContext)
        {
            _context = dbContext;
        }


        public async Task<User> GetUser(User user)
        {
            using (var connection = _context.CreateConnection())
            {
                if (user.Email is null)
                    return await connection.QuerySingleOrDefaultAsync<User>("SELECT * FROM users WHERE Id=@Id;", new { Id = user.Id });

                return await connection.QueryFirstAsync<User>("SELECT * FROM users WHERE Email=@Email;", new { Email = user.Email });

            }
        }

       
        public async Task<User> CreateUser(User user) {
           
            using (var connection = _context.CreateConnection())
            {

                if (user.Name is null & user.Address is null)
                {
                    await connection.QueryAsync("INSERT INTO users(Email, PasswordHash) VALUES (@Email, @PasswordHash);",
                              new { PasswordHash = user.PasswordHash, Email = user.Email });
                    
                }
                else if (user.Name is null)
                {
                    await connection.QueryAsync("INSERT INTO users(Email, PasswordHash, Address) VALUES (@Email, @PasswordHash, @Address);",
                          new { Address = user.Address, PasswordHash = user.PasswordHash, Email = user.Email });
                    
                }
                else if (user.Address is null)
                {
                    await connection.QueryAsync("INSERT INTO users(Email, PasswordHash, Name) VALUES (@Email, @PasswordHash, @Name);",
                      new { PasswordHash = user.PasswordHash, Name = user.Name, Email = user.Email });
                    
                }
                else
                {
                    await connection.QueryAsync("INSERT INTO users(Email, PasswordHash, Name, Address) VALUES (@Email, @PasswordHash, @Name, @Address);",
                          new { Address = user.Address, PasswordHash = user.PasswordHash, Name = user.Name, Email = user.Email });
                    
                }

                return user;
            }
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<User>("SELECT * FROM users;");
            }
        }



        public async Task<User> Put(User user) 
        {
            using (var connection = _context.CreateConnection())
            {

                if (user.Name is null & user.Address is null)
                {
                    await connection.QuerySingleOrDefaultAsync<User>("UPDATE users SET PasswordHash = @PasswordHash WHERE  Email = @Email", user );
                }
                else if (user.Name is null)
                {
                    await connection.QuerySingleOrDefaultAsync<User>("UPDATE users SET Address = @Address, PasswordHash = @PasswordHash WHERE  Email = @Email", user );
                }
                else if (user.Address is null)
                {
                    await connection.QuerySingleOrDefaultAsync<User>("UPDATE users SET PasswordHash = @PasswordHash, Name = @Name WHERE  Email = @Email", user );
                }
                else
                {
                    await connection.QuerySingleOrDefaultAsync<User>("UPDATE users SET Address = @Address, PasswordHash = @PasswordHash, Name = @Name WHERE  Email = @Email", user);
                }

                return user;
            }
        }
    }
}
