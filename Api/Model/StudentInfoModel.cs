namespace api.Models
{
    public class StudentInfoModel
    {
        public long StudentInfoID { get; set; }
        public long? StudentId { get; set; }
        public long? AdmissionNo { get; set; }
        public string? Current_Session { get; set; }
        public long? SessionID { get; set; }
        public long? ClassID { get; set; }
        public long? SectionID { get; set; }
        public long? RollNo { get; set; }
        public long? RouteID { get; set; }
        public long? StreamID { get; set; }
        public string? FeeBookNo { get; set; }
        public string? BusFeeBookNo { get; set; }
        public string? Remarks { get; set; }
        public string? BoardNo { get; set; }
        public string? Optional { get; set; }
        public string? PrePrimaryBoardNo { get; set; }
        public DateTime? PrePrimaryDate { get; set; }
        public string? PrimaryBoardNo { get; set; }
        public DateTime? PrimaryDate { get; set; }
        public string? MiddleBoardNo { get; set; }
        public DateTime? MiddleDate { get; set; }
        public string? HighBoardNo { get; set; }
        public DateTime? HighDate { get; set; }
        public string? HigherBoardNo { get; set; }
        public DateTime? HigherDate { get; set; }
        public byte[]? Photo { get; set; }
        public string? PhotoPath { get; set; }
        public string? BusRoute { get; set; }
        public long? OptionalID { get; set; }
        public string? BusStop { get; set; }
        public long? BusStopID { get; set; }
        public int? IsDischarged { get; set; }
        public string? DSession { get; set; }
        public DateTime? DDate { get; set; }
        public string? DRemarks { get; set; }
        public string? DBy { get; set; }
        public long? FDIDFK { get; set; }
        public string? SiblingID { get; set; }
        public int? SiblingType { get; set; }
        public string? FatherPhoto { get; set; }
        public string? MotherPhoto { get; set; }
        public long? CampusIDFK { get; set; }
        public DateTime? WithdrawnOn { get; set; }
        public string? WithdrawnBy { get; set; }
        public decimal? BusFee { get; set; }
        public long? studentrebate { get; set; }
        public string? WithdrawnNarration { get; set; }
        public long? FeeCategoryID { get; set; }
    }
}
