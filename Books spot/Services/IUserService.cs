using Books_spot.Models;

namespace Books_spot.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User GetUserById(Guid id);
    }
}
