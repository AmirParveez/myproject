using Microsoft.AspNetCore.Mvc;
using api.BLL;

namespace api.Controllers   // <<< VERY IMPORTANT
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
        public IActionResult GetClasses([FromQuery] string? session = null)
        {
            try
            {
                var result = _classesBLL.GetClasses(session);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
