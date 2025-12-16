public class StudentInsertRequest
{
    public StudentsModel ?Student { get; set; }
    public StudentInfoModel ?StudentInfo { get; set; }

    public IFormFile ?StudentPhoto { get; set; }
    public IFormFile ?FatherPhoto { get; set; }
    public IFormFile ?MotherPhoto { get; set; }
}
