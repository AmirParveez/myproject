using api.BLL;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/transport")]
    public class TransportController : ControllerBase
    {
        private readonly TransportBLL _bll;

        public TransportController(TransportBLL bll)
        {
            _bll = bll;
        }

        [HttpGet("routes")]
        public IActionResult GetRoutes()
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

                var data = _bll.GetRoutes(currentSession);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
