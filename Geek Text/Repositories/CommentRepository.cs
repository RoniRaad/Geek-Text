using Dapper;
using Geek_Text.Models;

namespace Geek_Text.Repositories
{
    public class CommentRepository
    {
        private readonly DatabaseContext _context;
        public CommentRepository(DatabaseContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<IEnumerable<UserComment>> GetComments(UserComment userComment)
        {
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<UserComment>("SELECT * FROM BookComments WHERE UserId=@UserId;", new { UserId = userComment.UserId });
            }
        }

        public async Task<UserComment> AddComment(UserComment userComment)
        {
            using (var connection = _context.CreateConnection())
            {
                 await connection.QueryAsync<UserComment>("INSERT INTO BookComments(Comment, Created, UserId) VALUES (@Comment, @Created, @UserId)", userComment);
            }

            return userComment;
        }
    }
}
