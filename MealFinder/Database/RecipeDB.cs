using MealFinder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Microsoft.Data.Sqlite;

namespace MealFinder.Database
{
    public class RecipeContext
    {
        public static void Insert(Recipe r)
        {
            using (DbContext db = new DbContext())
            {
                string sql = @"INSERT INTO Recipes 
                               (RecipeName, Description)
                               VALUES (@n,@d)";

                SQLiteCommand cmd = new SQLiteCommand(sql, db.Conn);
                cmd.Parameters.AddWithValue("@n", r.RecipeName);
                cmd.Parameters.AddWithValue("@d", r.Description);
                cmd.ExecuteNonQuery();
            }
        }

        public static List<Recipe> GetAll()
        {
            List<Recipe> list = new List<Recipe>();

            using (DbContext db = new DbContext())
            {
                SQLiteCommand cmd =
                    new SQLiteCommand("SELECT * FROM Recipes", db.Conn);

                SQLiteDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    Recipe r = new Recipe();
                    r.RecipeID = rd.GetInt32(0);
                    r.RecipeName = rd.GetString(1);
                    r.Description = rd.GetString(2);
                    list.Add(r);
                }
            }
            return list;
        }
    }
}