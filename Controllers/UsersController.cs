using Microsoft.AspNetCore.Mvc;
using EventManagement.Models;
using EventManagement.Services;

namespace EventManagement.Controllers {

    [ApiController]
    [Route("api/users")]

    public class UsersController : ControllerBase {

        private readonly IUserService _userService;
        
        public UsersController() {
            _userService = new UserService();
        }

        [HttpGet]
        public ActionResult <List<User>> GetUsers() {
            return Ok(_userService.GetUsers());
        }

        [HttpGet("id:guid")]
        public ActionResult <List<User>> GetUser(Guid id) {
            var _user = _userService.GetUser(id);
            if (_user == null) return NotFound();
            return Ok(_user);
        }

        [HttpPost]
        public ActionResult <User> CreateUser(User input) {
            var newUser = _userService.CreateUser(input);
            return CreatedAtAction(nameof(CreateUser), newUser.Id, newUser);
        }
    }

}
