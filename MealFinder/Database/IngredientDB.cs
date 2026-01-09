using MealFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Microsoft.Data.Sqlite;

namespace MealFinder.Database
{
    public class IngredientContext
    {
        public static void Insert(Ingredient i)
        {
            using (DbContext db = new DbContext())
            {
                string sql = @"INSERT INTO Ingredients
                               (IngredientName, IngredientQuantity, RecipeID)
                               VALUES (@n,@q,@r)";

                SQLiteCommand cmd = new SQLiteCommand(sql, db.Conn);
                cmd.Parameters.AddWithValue("@n", i.IngredientName);
                cmd.Parameters.AddWithValue("@q", i.IngredientQuantity);
                cmd.Parameters.AddWithValue("@r", i.RecipeID);
                cmd.ExecuteNonQuery();
            }
        }

        public static List<Ingredient> GetByRecipe(int recipeId)
        {
            List<Ingredient> list = new List<Ingredient>();

            using (DbContext db = new DbContext())
            {
                string sql = "SELECT * FROM Ingredients WHERE RecipeID=@id";
                SQLiteCommand cmd = new SQLiteCommand(sql, db.Conn);
                cmd.Parameters.AddWithValue("@id", recipeId);

                SQLiteDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    Ingredient i = new Ingredient();
                    i.IngredientID = rd.GetInt32(0);
                    i.IngredientName = rd.GetString(1);
                    i.IngredientQuantity = rd.IsDBNull(2) ? "" : rd.GetString(2);
                    i.RecipeID = rd.GetInt32(3);
                    list.Add(i);
                }
            }
            return list;
        }

        public static void DeleteByRecipe(int recipeId)
        {
            using (DbContext db = new DbContext())
            {
                string sql = "DELETE FROM Ingredients WHERE RecipeID=@id";
                SQLiteCommand cmd = new SQLiteCommand(sql, db.Conn);
                cmd.Parameters.AddWithValue("@id", recipeId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}