using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MealFinder.Database;
using MealFinder.Model;

using System.Text.RegularExpressions;


namespace MealFinder.Controller
{
    public class AuthController
    {
        // ================= REGISTER =================
        public static string Register(
            string name,
            string username,
            string email,
            string password,
            string confirm)
        {
            // 1. Field kosong
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirm))
                return "Semua field wajib diisi";

            // 2. Name
            if (name.Trim().Length < 3)
                return "Name minimal 3 karakter";

            // 3. Username
            if (username.Trim().Length < 4)
                return "Username minimal 4 karakter";

            if (username.Contains(" "))
                return "Username tidak boleh mengandung spasi";

            // 4. Email
            if (!IsValidEmail(email))
                return "Email harus valid dan mengandung '@'";

            // 5. Password
            if (!IsStrongPassword(password))
                return "Password minimal 8 karakter,\n" +
                       "mengandung huruf besar, huruf kecil, dan angka";

            // 6. Konfirmasi password
            if (password != confirm)
                return "Password dan konfirmasi password tidak sama";

            // 7. Buat object User
            User user = new User
            {
                Name = name.Trim(),
                Username = username.Trim(),
                Email = email.Trim(),
                Password = password,
                Role = "User" // 🔥 DEFAULT ROLE
            };

            bool success = UserContext.Register(user);

            return success
                ? "OK"
                : "Username atau Email sudah terdaftar";
        }

        // ================= LOGIN =================
        public static string Login(
            string username,
            string password,
            out User user)
        {
            user = null;

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
                return "Username dan Password wajib diisi";

            user = UserContext.Login(
                username.Trim(),
                password.Trim()
            );

            if (user == null)
                return "Username atau Password salah";

            // 🔐 Safety check (kalau role kosong)
            if (string.IsNullOrEmpty(user.Role))
                user.Role = "User";

            return "OK";
        }

        // ================= VALIDATION HELPER =================
        private static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(
                email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$"
            );
        }

        private static bool IsStrongPassword(string password)
        {
            if (password.Length < 8) return false;

            bool hasUpper = false;
            bool hasLower = false;
            bool hasDigit = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpper = true;
                else if (char.IsLower(c)) hasLower = true;
                else if (char.IsDigit(c)) hasDigit = true;
            }

            return hasUpper && hasLower && hasDigit;
        }
    }
}