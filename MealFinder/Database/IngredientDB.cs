using MealFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace MealFinder.Database
{
    namespace MealFinder.Database
    {
        public class IngredientDB
        {
            public static void Add(string name, string qty, int recipeId)
            {
                using (SQLiteConnection conn = Db.GetConnection())
                {
                    conn.Open();

                    string sql = @"INSERT INTO Ingredients 
                               (IngredientName, Quantity, RecipeID)
                               VALUES (@n,@q,@r)";

                    using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@n", name);
                        cmd.Parameters.AddWithValue("@q", qty);
                        cmd.Parameters.AddWithValue("@r", recipeId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            public static List<Ingredient> GetByRecipe(int recipeId)
            {
                List<Ingredient> list = new List<Ingredient>();

                using (SQLiteConnection conn = Db.GetConnection())
                {
                    conn.Open();

                    using (SQLiteCommand cmd =
                        new SQLiteCommand("SELECT * FROM Ingredients WHERE RecipeID=@id", conn))
                    {
                        cmd.Parameters.AddWithValue("@id", recipeId);

                        using (SQLiteDataReader rd = cmd.ExecuteReader())
                        {
                            while (rd.Read())
                            {
                                Ingredient i = new Ingredient();
                                i.IngredientID = rd.GetInt32(0);
                                i.IngredientName = rd.GetString(1);
                                i.IngredientQuantity = rd.GetString(2);
                                i.RecipeID = rd.GetInt32(3);
                                list.Add(i);
                            }
                        }
                    }
                }
                return list;
            }
        }
    }
}
