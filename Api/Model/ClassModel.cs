namespace api.Models
{
    public class ClassesModel
    {
        public int ClassID { get; set; }
        public string ClassName { get; set; } = string.Empty;
        public string Current_Session { get; set; } = string.Empty;
        public int SessionID { get; set; }
        public int SubDepartmentID { get; set; }
    }
}
