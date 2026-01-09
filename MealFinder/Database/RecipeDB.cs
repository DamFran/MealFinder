using MealFinder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace MealFinder.Database
{
    public class RecipeDB
    {
        public static void Add(string name, string desc)
        {
            using (SQLiteConnection conn = Db.GetConnection())
            {
                conn.Open();

                string sql = "INSERT INTO Recipes (RecipeName, Description) VALUES (@n,@d)";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@n", name);
                    cmd.Parameters.AddWithValue("@d", desc);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<Recipe> GetAll()
        {
            List<Recipe> list = new List<Recipe>();

            using (SQLiteConnection conn = Db.GetConnection())
            {
                conn.Open();

                using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Recipes", conn))
                using (SQLiteDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        Recipe r = new Recipe();
                        r.RecipeID = rd.GetInt32(0);
                        r.RecipeName = rd.GetString(1);
                        r.Description = rd.GetString(2);
                        list.Add(r);
                    }
                }
            }
            return list;
        }
    }
}
