using Microsoft.Data.SqlClient;
using api.Helpers;
using api.Models;
using System.Data;

namespace api.BLL
{
    public class TransportBLL
    {
        private readonly SqlHelper _sql;

        public TransportBLL(SqlHelper sql)
        {
            _sql = sql;
        }

        public List<TransportModel> GetRoutes(string session)
        {
            string query = @"SELECT RouteID, RouteName, Current_Session, IsDeleted
                             FROM transport
                             WHERE Current_Session = @session AND IsDeleted = 0";

            var param = new SqlParameter[]
            {
                new SqlParameter("@session", session)
            };

            DataTable dt = _sql.ExecuteDataTable(query, param);

            List<TransportModel> list = new();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new TransportModel
                {
                    RouteID = Convert.ToInt32(dr["RouteID"]),
                    RouteName = dr["RouteName"].ToString() ?? "",
                    Current_Session = dr["Current_Session"].ToString() ?? "",
                    IsDeleted = Convert.ToBoolean(dr["IsDeleted"])
                });
            }

            return list;
        }
    }
}
