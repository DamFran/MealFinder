using MealFinder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace MealFinder.Database
{
        public class ProductDB
        {
        public static void Add(string name, int stock, double price)
        {
            using (SQLiteConnection conn = Db.GetConnection())
            {
                conn.Open();

                string sql = @"INSERT INTO Products 
                       (ProductName, ProductStock, ProductPrice)
                       VALUES (@n,@s,@p)";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@n", name);
                    cmd.Parameters.AddWithValue("@s", stock);
                    cmd.Parameters.AddWithValue("@p", price);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<Product> GetAll()
        {
            List<Product> list = new List<Product>();

            using (SQLiteConnection conn = Db.GetConnection())
            {
                conn.Open();

                using (SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM Products", conn))
                using (SQLiteDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        Product p = new Product();
                        p.ProductID = rd.GetInt32(0);
                        p.ProductName = rd.GetString(1);
                        p.ProductStock = rd.IsDBNull(2) ? 0 : rd.GetInt32(2);
                        p.ProductPrice = rd.IsDBNull(3) ? 0 : rd.GetDouble(3);
                        list.Add(p);
                    }
                }
            }
            return list;
        }

    }
}
