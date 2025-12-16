using Microsoft.Data.SqlClient;
using System.Data;
using api.Helpers;

public class StudentBLL
{
    private readonly SqlHelper _sql;

    public StudentBLL(SqlHelper sql)
    {
        _sql = sql;
    }

    public long InsertStudent(StudentsModel s)
    {
        string query = @"
        INSERT INTO Students
        (
            AdmissionNo, StudentName, DOB, Gender, SessionOfAdmission,
            FathersName, FathersQualification, FathersJob,
            MothersName, MothersQualification, MothersJob,
            PresentAddress, PerminantAddress,
            PhoneNo, MobileNo, DistrictName, City, Pincode,
            SEmail, Saadhaarcard, Faadhaarcard, Maadhaarcard,
            IsActive
        )
        VALUES
        (
            @AdmissionNo, @StudentName, @DOB, @Gender, @SessionOfAdmission,
            @FathersName, @FathersQualification, @FathersJob,
            @MothersName, @MothersQualification, @MothersJob,
            @PresentAddress, @PerminantAddress,
            @PhoneNo, @MobileNo, @DistrictName, @City, @Pincode,
            @SEmail, @Saadhaarcard, @Faadhaarcard, @Maadhaarcard,
            1
        );
        SELECT SCOPE_IDENTITY();";

        return Convert.ToInt64(_sql.ExecuteScalar(query, new[]
        {
            new SqlParameter("@AdmissionNo", s.AdmissionNo),
            new SqlParameter("@StudentName", s.StudentName),
            new SqlParameter("@DOB", (object?)s.DOB ?? DBNull.Value),
            new SqlParameter("@Gender", s.Gender),
            new SqlParameter("@SessionOfAdmission", s.SessionOfAdmission),

            new SqlParameter("@FathersName", s.FathersName),
            new SqlParameter("@FathersQualification", s.FathersQualification),
            new SqlParameter("@FathersJob", s.FathersJob),

            new SqlParameter("@MothersName", s.MothersName),
            new SqlParameter("@MothersQualification", s.MothersQualification),
            new SqlParameter("@MothersJob", s.MothersJob),

            new SqlParameter("@PresentAddress", s.PresentAddress),
            new SqlParameter("@PerminantAddress", s.PerminantAddress),

            new SqlParameter("@PhoneNo", s.PhoneNo),
            new SqlParameter("@MobileNo", s.MobileNo),
            new SqlParameter("@DistrictName", s.DistrictName),
            new SqlParameter("@City", s.City),
            new SqlParameter("@Pincode", s.Pincode),

            new SqlParameter("@SEmail", s.SEmail),
            new SqlParameter("@Saadhaarcard", (object?)s.Saadhaarcard ?? DBNull.Value),
            new SqlParameter("@Faadhaarcard", (object?)s.Faadhaarcard ?? DBNull.Value),
            new SqlParameter("@Maadhaarcard", (object?)s.Maadhaarcard ?? DBNull.Value)
        }));
    }

    public void InsertStudentInfo(long studentId, StudentInfoModel i)
    {
        string query = @"
        INSERT INTO StudentInfo
        (
            StudentId, AdmissionNo, Current_Session, SessionID,
            ClassID, SectionID, RollNo, BusStop, BusRoute
        )
        VALUES
        (
            @StudentId, @AdmissionNo, @Current_Session, @SessionID,
            @ClassID, @SectionID, @RollNo, @BusStop, @BusRoute
        )";

        _sql.ExecuteNonQuery(query, new[]
        {
            new SqlParameter("@StudentId", studentId),
            new SqlParameter("@AdmissionNo", studentId), // OR student.AdmissionNo
            new SqlParameter("@Current_Session", i.Current_Session),
            new SqlParameter("@SessionID", i.SessionID),
            new SqlParameter("@ClassID", i.ClassID),
            new SqlParameter("@SectionID", i.SectionID),
            new SqlParameter("@RollNo", i.RollNo),
            new SqlParameter("@BusStop", i.BusStop),
            new SqlParameter("@BusRoute", i.BusRoute)
        });
    }
}
