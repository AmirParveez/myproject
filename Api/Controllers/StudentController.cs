using api.BLL;
using api.Model;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/student")]
    public class StudentController : ControllerBase
    {
        private readonly StudentBLL _bll;

        public StudentController(StudentBLL bll)
        {
            _bll = bll;
        }

        [HttpPost("add")]
        public IActionResult AddStudent([FromBody] AddStudentApiModel model)
        {
            if (model == null)
                return BadRequest("Invalid student data");

            int result = _bll.AddStudent(model);

            if (result > 0)
                return Ok(new
                {
                    success = true,
                    message = "Student added successfully"
                });

            return BadRequest(new
            {
                success = false,
                message = "Student insert failed"
            });
        }
    }
}
