using MealFinder.Model;
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
                user.Role = "User";

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
                string sql = @"SELECT UserID, Name, Username, Email, Password, Role 
                               FROM Users 
                               WHERE Username=@u AND Password=@p";

                SQLiteCommand cmd = new SQLiteCommand(sql, db.Conn);
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);

                SQLiteDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    return new User
                    {
                        UserID = rd.GetInt32(0),
                        Name = rd.GetString(1),
                        Username = rd.GetString(2),
                        Email = rd.GetString(3),
                        Password = rd.GetString(4),
                        Role = rd.GetString(5)
                    };
                }
            }
            return null;
        }
    }
}