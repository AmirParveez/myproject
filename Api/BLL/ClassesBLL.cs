using Microsoft.Data.SqlClient;
using api.Helpers;
using api.Models;
using System.Data;

namespace api.BLL
{
    public class ClassesBLL
    {
        private readonly SqlHelper _sql;

        public ClassesBLL(SqlHelper sql)
        {
            _sql = sql;
        }

        public List<ClassesModel> GetClasses(string session)
        {
            string query = @"SELECT ClassID, ClassName, Current_Session, SessionID, SubDepartmentID 
                             FROM Classes
                             WHERE Current_Session = @session";

            var param = new SqlParameter[]
            {
                new SqlParameter("@session", session)
            };

            DataTable dt = _sql.ExecuteDataTable(query, param);

            List<ClassesModel> list = new();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new ClassesModel
                {
                    ClassID = Convert.ToInt32(dr["ClassID"]),
                    ClassName = dr["ClassName"].ToString() ?? "",
                    Current_Session = dr["Current_Session"].ToString() ?? "",
                    SessionID = Convert.ToInt32(dr["SessionID"]),
                    SubDepartmentID = Convert.ToInt32(dr["SubDepartmentID"])
                });
            }

            return list;
        }
    }
}
