using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MealFinder.Models;
using System.Data;
using System.Data.SqlClient;

namespace MealFinder.Controllers
{
    public class IngredientController : BaseController
    {
        public DataTable GetAll()
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT id, name, stock FROM ingredients", conn);

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void Add(Ingredient ingredient)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();

                string q = @"INSERT INTO ingredients (name, stock)
                             VALUES (@n,@s)";

                SqlCommand cmd = new SqlCommand(q, conn);
                cmd.Parameters.AddWithValue("@n", ingredient.Name);
                cmd.Parameters.AddWithValue("@s", ingredient.Stock);

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM ingredients WHERE id=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}

