using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Models;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private static List<User> users = new List<User>();

        // GET all users
        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(users);
        }

        // GET user by ID
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound("User not found");

            return Ok(user);
        }

        // POST add user
        [HttpPost]
        public IActionResult AddUser(User user)
        {
            user.Id = users.Count + 1;
            users.Add(user);
            return Ok(user);
        }

        // PUT update user
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User updatedUser)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound("User not found");

            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;

            return Ok(user);
        }

        // DELETE user
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound("User not found");

            users.Remove(user);
            return Ok("User deleted successfully");
        }
    }
}