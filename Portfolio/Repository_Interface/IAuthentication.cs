using Portfolio.Models;

namespace Portfolio.Repository_Interface
{
    public interface IAuthentication
    {
        Task<User> Login(string username, string password);
        Task<User> Add(User user);

        Task<User?> GetUserByUsername(string username);
        Task UpdateUser(User user);

        Task<User> GetUserByEmail(string email);
    }
}
