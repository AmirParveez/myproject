namespace api.Model
{
    public class AddStudentApiModel
    {
        public string? StudentName { get; set; }
        public DateTime? DOB { get; set; }
        public DateTime? DOA { get; set; }
        public string? AdmissionNo { get; set; }
        public string? Gender { get; set; }

        public string? DistrictID { get; set; }
        public string? DistrictName { get; set; }
        public string? Aadhaar { get; set; }

        public string? StudentCatID { get; set; }
        public string? StudentCatName { get; set; }

        public string? PinNo { get; set; }
        public string? PhotoPath { get; set; }

        public string? ClassID { get; set; }
        public string? SectionID { get; set; }
        public string? Session { get; set; }
        public string? RollNo { get; set; }

        public string? PresentAddress { get; set; }
        public string? PermanentAddress { get; set; }

        public string? FatherName { get; set; }
        public string? MontherName { get; set; }

        public string? MobileFather { get; set; }
        public string? MobileMother { get; set; }
        public string? LandLineNo { get; set; }

        public string? FatherQualification { get; set; }
        public string? MotherQualification { get; set; }

        public string? FatherIcome { get; set; }
        public string? MotherIcome { get; set; }

        public string? FatherOccupation { get; set; }
        public string? MotherOccupation { get; set; }

        public string? FatherPhoto { get; set; }
        public string? MotherPhoto { get; set; }

        public string? Remarks { get; set; }
        public string? SEmail { get; set; }
        public string? AcademicNo { get; set; }

        public string? GuardianName { get; set; }
        public string? GuardianPhoneNo { get; set; }
        public string? GuardianQualification { get; set; }
        public string? GuardialAccupation { get; set; }
    }
}
