using MealFinder.Database.MealFinder.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace MealFinder.Database
{
    public class Db
    {
        public static SQLiteConnection GetConnection()
        {
            // Pastikan folder Database ada
            string directory = Path.GetDirectoryName(DbConfig.DbFile);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Buat file database jika belum ada
            if (!File.Exists(DbConfig.DbFile))
            {
                SQLiteConnection.CreateFile(DbConfig.DbFile);
            }

            return new SQLiteConnection(DbConfig.ConnectionString);
        }

        public static void Initialize()
        {
            try
            {
                using (SQLiteConnection conn = GetConnection())
                {
                    conn.Open();

                    string sql = @"
                    CREATE TABLE IF NOT EXISTS Users (
                        UserID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username TEXT NOT NULL,
                        EMAIL TEXT NOT NULL UNIQUE,
                        Password TEXT NOT NULL
                    );
                    
                    CREATE TABLE IF NOT EXISTS Products (
                        ProductID INTEGER PRIMARY KEY AUTOINCREMENT,
                        ProductName TEXT NOT NULL,
                        ProductStock INTEGER DEFAULT 0,
                        ProductPrice REAL DEFAULT 0.0
                    );
                    
                    CREATE TABLE IF NOT EXISTS Recipes (
                        RecipeID INTEGER PRIMARY KEY AUTOINCREMENT,
                        RecipeName TEXT NOT NULL,
                        Description TEXT
                    );
                    
                    CREATE TABLE IF NOT EXISTS Ingredients (
                        IngredientID INTEGER PRIMARY KEY AUTOINCREMENT,
                        IngredientName TEXT NOT NULL,
                        Quantity TEXT,
                        RecipeID INTEGER,
                        FOREIGN KEY (RecipeID) REFERENCES Recipes(RecipeID) ON DELETE CASCADE
                    );
                    ";

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error initializing database: {ex.Message}", ex);
            }
        }
    }
}

