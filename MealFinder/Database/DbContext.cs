using MealFinder.Model;
using MealFinder.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace MealFinder.Database
{
    public class DbContext : IDisposable
    {
        private SQLiteConnection _conn;

        public SQLiteConnection Conn => _conn;

        public DbContext()
        {
            try
            {
                string projectDir = Path.GetFullPath(
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..")
                );

                string dbPath = Path.Combine(projectDir, "Database");
                string dbName = Path.Combine(dbPath, "MealFinder.db");

                if (!Directory.Exists(dbPath))
                    Directory.CreateDirectory(dbPath);

                string cs =
                    $"Data Source={dbName};Version=3;Busy Timeout=5000;";

                _conn = new SQLiteConnection(cs);
                _conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DB Error");
            }
        }

        // ================= INIT DB (CALL ONCE) =================
        public static void InitializeDatabase()
        {
            using (var db = new DbContext())
            using (var cmd = new SQLiteCommand(db.Conn))
            {
                // USERS
                cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Users (
                    UserID INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Username TEXT NOT NULL,
                    Email TEXT UNIQUE NOT NULL,
                    Password TEXT NOT NULL,
                    Role TEXT NOT NULL
                );";
                cmd.ExecuteNonQuery();

                // DEFAULT ADMIN (ONLY ONCE)
                cmd.CommandText = @"
                INSERT INTO Users (Name, Username, Email, Password, Role)
                SELECT 'Administrator', 'admin', 'admin@admin.com', 'admin123', 'admin'
                WHERE NOT EXISTS (
                    SELECT 1 FROM Users WHERE Role = 'admin'
                );";
                cmd.ExecuteNonQuery();

                // PRODUCTS
                cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Products (
                    ProductID INTEGER PRIMARY KEY AUTOINCREMENT,
                    ProductName TEXT NOT NULL,
                    ProductStock INTEGER,
                    ProductPrice REAL
                );";
                cmd.ExecuteNonQuery();

                // RECIPES
                cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Recipes (
                    RecipeID INTEGER PRIMARY KEY AUTOINCREMENT,
                    RecipeName TEXT NOT NULL,
                    Description TEXT
                );";
                cmd.ExecuteNonQuery();

                // INGREDIENTS
                cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Ingredients (
                    IngredientID INTEGER PRIMARY KEY AUTOINCREMENT,
                    IngredientName TEXT NOT NULL,
                    IngredientQuantity TEXT,
                    RecipeID INTEGER NOT NULL
                );";
                cmd.ExecuteNonQuery();

                // HISTORY
                cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS History (
                    HistoryID INTEGER PRIMARY KEY AUTOINCREMENT,
                    UserID INTEGER,
                    RecipeID INTEGER,
                    RecipeName TEXT,
                    CreatedAt TEXT
                );";
                cmd.ExecuteNonQuery();
            }
        }

        // ================= DISPOSE =================
        public void Dispose()
        {
            if (_conn != null)
            {
                _conn.Close();
                _conn.Dispose();
                _conn = null;
            }
        }
    }
}

