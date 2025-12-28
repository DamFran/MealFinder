using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace MealFinder.Database
{
    public class Db
    {
        private SqlConnection GetConnection()
        {
            return new SqlConnection(DbConfig.ConnectionString);
        }

        public DataTable GetData(string query, SqlParameter[] param = null)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (param != null)
                        cmd.Parameters.AddRange(param);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public int Execute(string query, SqlParameter[] param = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (param != null)
                        cmd.Parameters.AddRange(param);

                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

