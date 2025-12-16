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
            var data = _bll.GetRoutes("2025-26");
            return Ok(data);
        }
    }
}
