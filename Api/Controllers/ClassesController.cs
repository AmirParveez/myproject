using Microsoft.AspNetCore.Mvc;
using api.BLL;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly ClassesBLL _classesBLL;

        public ClassesController(ClassesBLL classesBLL)
        {
            _classesBLL = classesBLL;
        }

        [HttpGet]
        public IActionResult GetClasses()
        {
            try
            {
                // 🔥 GET SESSION FROM LOGIN
                string? currentSession =
                    HttpContext.Session.GetString("Current_Session");

                if (string.IsNullOrEmpty(currentSession))
                {
                    return Unauthorized(new
                    {
                        message = "Session expired. Please login again."
                    });
                }

                var result = _classesBLL.GetClasses(currentSession);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
