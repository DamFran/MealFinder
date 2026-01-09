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
            public static void Insert(User user)
            {
                using (DbContext db = new DbContext())
                {
                    string sql = @"INSERT INTO Users 
                               (Username, Email, Password)
                               VALUES (@u,@e,@p)";

                    SQLiteCommand cmd = new SQLiteCommand(sql, db.Conn);
                    cmd.Parameters.AddWithValue("@u", user.Username);
                    cmd.Parameters.AddWithValue("@e", user.Email);
                    cmd.Parameters.AddWithValue("@p", user.Password);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }