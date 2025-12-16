using Microsoft.AspNetCore.Mvc;
using api.BLL;
using api.Models;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly UserLoginBLL _userBLL;

        public UserLoginController(UserLoginBLL userBLL)
        {
            _userBLL = userBLL;
        }

        // GET api/UserLogin/login?username=admin&password=123456
        [HttpGet("login")]
        public IActionResult Login([FromQuery] string username, [FromQuery] string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return BadRequest(new { message = "Username and password required" });

            var user = _userBLL.GetUser(username, password);

            if (user == null)
                return BadRequest(new { message = "Invalid username or password" });

            return Ok(new
            {
                status = "success",
                userId = user.UserId,
                username = user.Username
            });
        }
    }
}
