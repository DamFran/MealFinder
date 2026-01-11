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
        public void Insert(Recipe recipe)
        {
            using (DbContext db = new DbContext())
            using (SQLiteCommand cmd = new SQLiteCommand(
                @"INSERT INTO Recipe 
          (RecipeName, Description, ImagePath)
          VALUES (@name, @desc, @img)", db.Conn))
            {
                cmd.Parameters.AddWithValue("@name", recipe.RecipeName);
                cmd.Parameters.AddWithValue("@desc", recipe.Description);
                cmd.Parameters.AddWithValue("@img", recipe.ImagePath);
                cmd.ExecuteNonQuery();
            }
        }


        public List<Recipe> GetAll()
        {
            List<Recipe> list = new List<Recipe>();

            using (DbContext db = new DbContext())
            using (SQLiteCommand cmd = new SQLiteCommand(
                "SELECT * FROM Recipe", db.Conn))
            using (SQLiteDataReader rd = cmd.ExecuteReader())
            {
                while (rd.Read())
                {
                    Recipe r = new Recipe();
                    r.RecipeID = Convert.ToInt32(rd["RecipeID"]);
                    r.RecipeName = rd["RecipeName"].ToString();
                    r.Description = rd["Description"].ToString();
                    r.ImagePath = rd["ImagePath"].ToString();

                    list.Add(r);
                }
            }

            return list;
        }

        public Recipe GetById(int id)
        {
            Recipe recipe = null;

            using (DbContext db = new DbContext())
            using (SQLiteCommand cmd = new SQLiteCommand(
                "SELECT * FROM Recipe WHERE RecipeID = @id",
                db.Conn))
            {
                cmd.Parameters.AddWithValue("@id", id);

                using (SQLiteDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        recipe = new Recipe();
                        recipe.RecipeID = Convert.ToInt32(rd["RecipeID"]);
                        recipe.RecipeName = rd["RecipeName"].ToString();
                        recipe.Description = rd["Description"].ToString();
                        recipe.ImagePath = rd["ImagePath"].ToString();
                    }
                }
            }

            return recipe;
        }
    }
}