using MealFinder.Database;
using MealFinder.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MealFinder.Models;

namespace MealFinder.Controllers
{
    public class ProductController
    {
        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection conn = DbConfig.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM products";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    products.Add(new Product
                    {
                        Id = (int)reader["id"],
                        Name = reader["name"].ToString(),
                        Price = (int)reader["price"],
                        Stock = (int)reader["stock"]
                    });
                }
            }

            return products;
        }
    }
}

