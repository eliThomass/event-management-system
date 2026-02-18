using EventManagement.Models;

namespace EventManagement.Services {
    public interface IUserService {
        List<User> GetUsers();
        User? GetUser(Guid id);
        User CreateUser(User input);
    }
}
