using EventManagement.Models;

namespace EventManagement.Services {
    public class UserService : IUserService {
        private static List<User> Users = new List<User> {
            new User
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Jones",
                Email = "hi@gmail.com",
                CreatedAt = new DateTime(2026, 2, 10, 1, 1, 1),
            }
        };

        public User CreateUser(User input) {
            User newUser = new User {
                Id = Guid.NewGuid(),
                FirstName = input.FirstName,
                LastName = input.LastName,
                Email = input.Email,
                CreatedAt = input.CreatedAt,
            };
            Users.Add(newUser);
            return newUser;
        }

        public User? GetUser(Guid id) {
            var _user = Users.FirstOrDefault(s => s.Id == id);
            return _user;
        }

        public List<User> GetUsers() {
            return Users;
        }
    }
}
