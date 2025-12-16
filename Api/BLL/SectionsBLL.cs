using api.Helpers;
using api.Models;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace api.BLL
{
    public class SectionsBLL
    {
        private readonly SqlHelper _sqlHelper;

        public SectionsBLL(SqlHelper sqlHelper)
        {
            _sqlHelper = sqlHelper;
        }

        public List<Section> GetSectionsByClassID(long classID)
        {
            var dt = _sqlHelper.ExecuteDataTable(
                "SELECT SectionID, SectionName, ClassId, ClassName, SessionId, Current_Session FROM Sections WHERE ClassId=@classid",
                new SqlParameter[] { new SqlParameter("@classid", classID) }
            );

            var sections = new List<Section>();

            foreach (DataRow row in dt.Rows)
            {
                sections.Add(new Section
                {
                    SectionID = row["SectionID"] != DBNull.Value ? Convert.ToInt64(row["SectionID"]) : 0,
                    SectionName = row["SectionName"] != DBNull.Value ? row["SectionName"].ToString() : null,
                    ClassID = row["ClassId"] != DBNull.Value ? Convert.ToInt64(row["ClassId"]) : null,
                    ClassName = row["ClassName"] != DBNull.Value ? row["ClassName"].ToString() : null,
                    SessionID = row["SessionId"] != DBNull.Value ? Convert.ToInt64(row["SessionId"]) : null,
                    CurrentSession = row["Current_Session"] != DBNull.Value ? row["Current_Session"].ToString() : null
                });
            }

            return sections;
        }
    }
}
