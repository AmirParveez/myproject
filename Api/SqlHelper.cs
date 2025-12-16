using Microsoft.Data.SqlClient;
using System.Data;

namespace api.Helpers
{
    public class SqlHelper
    {
        private readonly string _conn;

        public string ConnectionString => _conn;

        public SqlHelper(string connectionString)
        {
            _conn = connectionString;
        }

        // ================= Execute DataTable =================
        public DataTable ExecuteDataTable(string query, SqlParameter[]? parameters = null)
        {
            using SqlConnection con = new SqlConnection(_conn);
            using SqlCommand cmd = new SqlCommand(query, con);

            if (parameters != null)
                cmd.Parameters.AddRange(parameters);

            using SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // ================= Execute NonQuery =================
        public int ExecuteNonQuery(string query, SqlParameter[]? parameters = null)
        {
            using SqlConnection con = new SqlConnection(_conn);
            using SqlCommand cmd = new SqlCommand(query, con);

            if (parameters != null)
                cmd.Parameters.AddRange(parameters);

            con.Open();
            return cmd.ExecuteNonQuery();
        }

        // ================= Execute Scalar =================
        public object ExecuteScalar(string query, SqlParameter[]? parameters = null)
        {
            using SqlConnection con = new SqlConnection(_conn);
            using SqlCommand cmd = new SqlCommand(query, con);

            if (parameters != null)
                cmd.Parameters.AddRange(parameters);

            con.Open();
            return cmd.ExecuteScalar();
        }
    }
}
