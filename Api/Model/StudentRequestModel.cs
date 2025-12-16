namespace api.Models
{
    public class StudentRequestModel
    {
        public StudentsModel Student { get; set; } = new StudentsModel();
        public StudentInfoModel StudentInfo { get; set; } = new StudentInfoModel();
    }
}
