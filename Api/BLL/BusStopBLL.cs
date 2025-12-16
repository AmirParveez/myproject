using Microsoft.Data.SqlClient;
using api.Helpers;
using api.Models;
using System.Data;

namespace api.BLL
{
    public class BusStopBLL
    {
        private readonly SqlHelper _sql;

        public BusStopBLL(SqlHelper sql)
        {
            _sql = sql;
        }

        public List<BusStopModel> GetBusStopsByRoute(int routeId, string session)
        {
            string query = @"SELECT BusStopID, BusStop, BusRate, RouteID, Current_Session
                             FROM BusStops
                             WHERE RouteID = @routeId
                               AND Current_Session = @session";

            var param = new SqlParameter[]
            {
                new SqlParameter("@routeId", routeId),
                new SqlParameter("@session", session)
            };

            DataTable dt = _sql.ExecuteDataTable(query, param);

            List<BusStopModel> list = new();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new BusStopModel
                {
                    BusStopID = Convert.ToInt32(dr["BusStopID"]),
                    BusStop = dr["BusStop"].ToString() ?? "",
                    BusRate = Convert.ToDecimal(dr["BusRate"]),
                    RouteID = Convert.ToInt32(dr["RouteID"]),
                    Current_Session = dr["Current_Session"].ToString() ?? ""
                });
            }

            return list;
        }
    }
}
