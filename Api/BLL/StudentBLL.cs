using api.Helpers;
using api.Model;
using Microsoft.Data.SqlClient;

namespace api.BLL
{
    public class StudentBLL
    {
        private readonly SqlHelper _sql;

        public StudentBLL(SqlHelper sql)
        {
            _sql = sql;
        }

        public int AddStudent(AddStudentApiModel m)
        {
            SqlParameter[] p =
            {
                new("@StudentName", m.StudentName),
                new("@DOB", m.DOB),
                new("@DOA", m.DOA),
                new("@AdmissionNo", m.AdmissionNo),
                new("@Gender", m.Gender),

                new("@DistrictID", m.DistrictID),
                new("@DistrictName", m.DistrictName),
                new("@Aadhaar", m.Aadhaar),

                new("@StudentCatID", m.StudentCatID),
                new("@StudentCatName", m.StudentCatName),

                new("@PinNo", m.PinNo),
                new("@PhotoPath", m.PhotoPath),

                new("@ClassID", m.ClassID),
                new("@SectionID", m.SectionID),
                new("@Session", m.Session),
                new("@RollNo", m.RollNo),

                new("@PresentAddress", m.PresentAddress),
                new("@PermanentAddress", m.PermanentAddress),

                new("@FatherName", m.FatherName),
                new("@MontherName", m.MontherName),

                new("@MobileFather", m.MobileFather),
                new("@MobileMother", m.MobileMother),
                new("@LandLineNo", m.LandLineNo),

                new("@FatherQualification", m.FatherQualification),
                new("@MotherQualification", m.MotherQualification),

                new("@FatherIcome", m.FatherIcome),
                new("@MotherIcome", m.MotherIcome),

                new("@FatherOccupation", m.FatherOccupation),
                new("@MotherOccupation", m.MotherOccupation),

                new("@FatherPhoto", m.FatherPhoto),
                new("@MotherPhoto", m.MotherPhoto),

                new("@Remarks", m.Remarks),
                new("@SEmail", m.SEmail),
                new("@AcademicNo", m.AcademicNo),

                new("@GuardianName", m.GuardianName),
                new("@GuardianPhoneNo", m.GuardianPhoneNo),
                new("@GuardianQualification", m.GuardianQualification),
                new("@GuardialAccupation", m.GuardialAccupation)
            };

            return _sql.ExecuteNonQuery("AddstudentAPI", p);
        }
    }
}
