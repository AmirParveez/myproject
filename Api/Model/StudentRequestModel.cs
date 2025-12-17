namespace api.Model
{
    public class StudentRequestModel
    {
        public StudentsModel Student { get; set; } = new();
        public StudentInfoModel StudentInfo { get; set; } = new();
    }
}
