using api.BLL;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/busstops")]
    public class BusStopController : ControllerBase
    {
        private readonly BusStopBLL _bll;

        public BusStopController(BusStopBLL bll)
        {
            _bll = bll;
        }

        [HttpGet("byroute/{routeId}")]
        public IActionResult GetBusStopsByRoute(int routeId)
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

                var data = _bll.GetBusStopsByRoute(routeId, currentSession);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
