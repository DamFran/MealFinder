using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MealFinder.Model;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace MealFinder.Database
{
    public class DbContext : IDisposable
    {
        private SQLiteConnection _conn;

        public SQLiteConnection Conn
        {
            get { return _conn ?? (_conn = GetOpenConnection()); }
        }

        private SQLiteConnection GetOpenConnection()
        {
            SQLiteConnection conn = null;

            try
            {
                string projectDir = Path.GetFullPath(
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..")
                );

                string dbPath = Path.Combine(projectDir, "Database");
                string dbName = Path.Combine(dbPath, "MealFinder.db");

                if (!Directory.Exists(dbPath))
                {
                    Directory.CreateDirectory(dbPath);
                }

                string connectionString = $"Data Source={dbName};Version=3;";

                conn = new SQLiteConnection(connectionString);
                conn.Open();

                CreateTables(conn);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DB Error");
            }

            return conn;
        }


        // ================= CREATE TABLE =================
        private void CreateTables(SQLiteConnection conn)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(conn))
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

                // ================= DEFAULT ADMIN =================
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
                    RecipeID INTEGER NOT NULL,
                    FOREIGN KEY (RecipeID) REFERENCES Recipes(RecipeID)
                );";
                cmd.ExecuteNonQuery();
            }
        }

        // ================= DISPOSE =================
        public void Dispose()
        {
            if (_conn != null)
            {
                try
                {
                    if (_conn.State != ConnectionState.Closed)
                        _conn.Close();
                }
                finally
                {
                    _conn.Dispose();
                }
            }

            GC.SuppressFinalize(this);
        }
    }
}

