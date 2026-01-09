using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealFinder.Database
{
    public class UserDB
    {
        public static bool Login(string username, string password)
        {
            using (SQLiteConnection conn = Db.GetConnection())
            {
                conn.Open();

                string sql = @"SELECT COUNT(*) FROM Users 
                       WHERE Username=@u AND Password=@p";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.Parameters.AddWithValue("@p", password);

                    int count = System.Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public static void Register(string username, string email, string password)
        {
            using (SQLiteConnection conn = Db.GetConnection())
            {
                conn.Open();

                string sql = @"INSERT INTO Users 
                       (Username, Email, Password) 
                       VALUES (@u,@e,@p)";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.Parameters.AddWithValue("@e", email);
                    cmd.Parameters.AddWithValue("@p", password);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}