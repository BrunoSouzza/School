using Microsoft.AspNetCore.Mvc;

namespace School.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        public List<User> _users = new List<User>
        {
            new User { Name = "Bruno", Email = "bruno@gmail.com"},
            new User { Name = "Carlo", Email = "carlo@gmail.com"},
        };

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_users);
        }
    }

    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
