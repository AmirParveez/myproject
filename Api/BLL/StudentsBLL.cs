using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using api.Helpers;
using api.Models;

namespace api.BLL
{
    public class StudentsBLL
    {
        private readonly SqlHelper _sql;

        public StudentsBLL(SqlHelper sql)
        {
            _sql = sql;
        }

        public List<StudentModel> GetStudents(long classId, long sectionId)
        {
            string query = @"
                SELECT 
                    s.StudentName,
                    s.PhoneNo
                FROM Students s
                INNER JOIN StudentInfo si
                    ON si.StudentID = s.StudentID
                WHERE 
                    si.ClassID = @ClassID
                    AND si.SectionID = @SectionID
                    AND si.IsDischarged = 0
                ORDER BY s.StudentName;
            ";

            SqlParameter[] parameters =
            {
                new SqlParameter("@ClassID", classId),
                new SqlParameter("@SectionID", sectionId)
            };

            DataTable dt = _sql.ExecuteDataTable(query, parameters);

            List<StudentModel> list = new List<StudentModel>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new StudentModel
                {
                    StudentName = row["StudentName"].ToString()!,
                    PhoneNo = row["PhoneNo"].ToString()!
                });
            }

            return list;
        }
    }
}
