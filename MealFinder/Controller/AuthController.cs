using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MealFinder.Database;
using MealFinder.Model;

namespace MealFinder.Controller
{
    public class AuthController
    {
        public static string Register(
            string name,
            string username,
            string email,
            string password,
            string confirm)
        {
            if (password != confirm)
                return "Password tidak sama";

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
                return "Semua field wajib diisi";

            User user = new User
            {
                Name = name,
                Username = username,
                Email = email,
                Password = password
            };

            bool success = UserContext.Register(user);

            return success ? "OK" : "Username atau Email sudah terdaftar";
        }


        public static User Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
                return null;

            return UserContext.Login(username, password);
        }
    }
}
