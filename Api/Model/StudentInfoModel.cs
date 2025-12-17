namespace api.Model
{
    public class StudentInfoModel
    {
        public string? Current_Session { get; set; }
        public long SessionID { get; set; }
        public long ClassID { get; set; }
        public long SectionID { get; set; }
        public long RollNo { get; set; }
        public string? BusStop { get; set; }
        public string? BusRoute { get; set; }
    }
}
