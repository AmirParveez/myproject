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
            var data = _bll.GetBusStopsByRoute(routeId, "2025-26");
            return Ok(data);
        }
    }
}
