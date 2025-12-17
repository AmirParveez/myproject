namespace api.Model
{
    public class StudentsModel
    {
        public long AdmissionNo { get; set; }
        public string? StudentName { get; set; }
        public DateTime? DOB { get; set; }
        public string? Gender { get; set; }
        public string? SessionOfAdmission { get; set; }

        public string? FathersName { get; set; }
        public string? FathersQualification { get; set; }
        public string? FathersJob { get; set; }

        public string? MothersName { get; set; }
        public string? MothersQualification { get; set; }
        public string? MothersJob { get; set; }

        public string? PresentAddress { get; set; }
        public string? PerminantAddress { get; set; }

        public string? PhoneNo { get; set; }
        public string? MobileNo { get; set; }

        public string? DistrictName { get; set; }
        public string? City { get; set; }
        public string? Pincode { get; set; }

        public string? SEmail { get; set; }
        public long? Saadhaarcard { get; set; }
        public long? Faadhaarcard { get; set; }
        public long? Maadhaarcard { get; set; }
    }
}
