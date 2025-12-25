using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace MealFinder.Controllers
{
    public class RecipeController : BaseController
    {
        public DataTable GetRecipeByIngredients()
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();

                // contoh dummy query
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT name, description FROM recipes", conn);

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}

