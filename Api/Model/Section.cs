namespace api.Models
{
    public class Section
    {
        public long SectionID { get; set; }
        public string? SectionName { get; set; }
        public long? ClassID { get; set; }        // nullable because table allows NULL
        public string? ClassName { get; set; }
        public long? SessionID { get; set; }     // nullable because table allows NULL
        public string? CurrentSession { get; set; }
    }
}
