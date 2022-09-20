using Books_spot.DAL;
using Books_spot.Models;
using Microsoft.EntityFrameworkCore;

namespace Books_spot.Services
{
    public class UserService : IUserService
    {
        private readonly BooksSpotDbContext _db;
        public UserService(BooksSpotDbContext db)
        {
            _db = db;
        }
        public IEnumerable<User> GetUsers()
        {
            return _db.Users.ToList();
        }
        
        public User GetUserById(Guid id)
        {
            return _db.Users.FirstOrDefault(x => x.UserId == id);
        }
    }
}
