using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MealFinder.Models;
using System.Data.SqlClient;

namespace MealFinder.Controllers
{
    public class AuthController : BaseController
    {
        public bool Login(string username, string password)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();

                string query = @"SELECT COUNT(*) 
                                 FROM users 
                                 WHERE username=@u AND password=@p";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);

                int result = (int)cmd.ExecuteScalar();
                return result > 0;
            }
        }

        public void Register(User user)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();

                string query = @"INSERT INTO users
                                 (name, username, email, password)
                                 VALUES (@n,@u,@e,@p)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@n", user.Name);
                cmd.Parameters.AddWithValue("@u", user.Username);
                cmd.Parameters.AddWithValue("@e", user.Email);
                cmd.Parameters.AddWithValue("@p", user.Password);

                cmd.ExecuteNonQuery();
            }
        }
    }
}


