using MealFinder.Model;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealFinder.Database
{
    public class UserContext
    {
        // ================= REGISTER =================
        public static bool Register(User user)
        {
            using (DbContext db = new DbContext())
            {
                string checkSql = @"SELECT COUNT(*) FROM Users 
                            WHERE Username=@u OR Email=@e";

                SQLiteCommand check = new SQLiteCommand(checkSql, db.Conn);
                check.Parameters.AddWithValue("@u", user.Username);
                check.Parameters.AddWithValue("@e", user.Email);

                long count = (long)check.ExecuteScalar();
                if (count > 0)
                    return false;

                // DEFAULT ROLE
                user.Role = "user";

                string sql = @"INSERT INTO Users 
                      (Name, Username, Email, Password, Role)
                      VALUES (@n,@u,@e,@p,@r)";

                SQLiteCommand cmd = new SQLiteCommand(sql, db.Conn);
                cmd.Parameters.AddWithValue("@n", user.Name);
                cmd.Parameters.AddWithValue("@u", user.Username);
                cmd.Parameters.AddWithValue("@e", user.Email);
                cmd.Parameters.AddWithValue("@p", user.Password);
                cmd.Parameters.AddWithValue("@r", user.Role);
                cmd.ExecuteNonQuery();

                return true;
            }
        }


        // ================= LOGIN =================
        public static User Login(string username, string password)
        {
            using (DbContext db = new DbContext())
            {
                string sql = @"SELECT * FROM Users 
                               WHERE Username=@e AND Password=@p";

                SQLiteCommand cmd = new SQLiteCommand(sql, db.Conn);
                cmd.Parameters.AddWithValue("@e", username);
                cmd.Parameters.AddWithValue("@p", password);

                SQLiteDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    return new User
                    {
                        UserID = rd.GetInt32(0),
                        Username = rd.GetString(1),
                        Email = rd.GetString(2),
                        Password = rd.GetString(3)
                    };
                }
            }
            return null;
        }
    }
}
