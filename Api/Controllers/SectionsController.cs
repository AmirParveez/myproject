using api.BLL;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionsController : ControllerBase
    {
        private readonly SectionsBLL _sectionsBLL;

        public SectionsController(SectionsBLL sectionsBLL)
        {
            _sectionsBLL = sectionsBLL;
        }

        /// <summary>
        /// Get sections by ClassID
        /// GET: api/sections?classid=10191
        /// </summary>
        [HttpGet]
        public IActionResult GetSections([FromQuery] long classid)
        {
            if (classid <= 0)
                return BadRequest(new { message = "Invalid ClassID." });

            try
            {
                var sections = _sectionsBLL.GetSectionsByClassID(classid);

                if (sections == null || sections.Count == 0)
                    return NotFound(new { message = "No sections found." });

                return Ok(sections);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Internal server error.",
                    error = ex.Message
                });
            }
        }
    }
}
