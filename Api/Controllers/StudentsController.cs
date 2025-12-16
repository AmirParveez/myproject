using Microsoft.AspNetCore.Mvc;
using api.BLL;
using api.Models;
using System.Collections.Generic;

namespace api.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentsBLL _bll;

        public StudentsController(StudentsBLL bll)
        {
            _bll = bll;
        }

        // GET: api/students?classId=10191&sectionId=12
        [HttpGet]
        public IActionResult GetStudents([FromQuery] long classId, [FromQuery] long sectionId)
        {
            if (classId <= 0 || sectionId <= 0)
                return BadRequest("Invalid class or section ID.");

            try
            {
                List<StudentModel> students = _bll.GetStudents(classId, sectionId);

                if (students == null || students.Count == 0)
                    return NotFound("No students found for this class and section.");

                return Ok(students);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
