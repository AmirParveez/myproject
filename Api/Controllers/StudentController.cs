using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

[Route("api/student")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly StudentBLL _bll;

    public StudentController(StudentBLL bll)
    {
        _bll = bll;
    }

    [HttpPost("insert")]
    public IActionResult InsertStudent([FromForm] StudentInsertRequest req)
    {
        var student = req.Student;
        var info = req.StudentInfo;

        long studentId = _bll.InsertStudent(student);
        _bll.InsertStudentInfo(studentId, info);

        // TODO: Save photos if required

        return Ok(new
        {
            message = "Student inserted successfully",
            studentId
        });
    }
}
