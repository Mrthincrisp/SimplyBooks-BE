using SimplyBooks.Models;
namespace SimplyBooks.Interface
{
    public interface IUserService
    {
        Task<User> UpdateUser(int id, User user);
    }
}
