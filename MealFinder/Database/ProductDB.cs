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
    public class ProductContext
    {
        public static void Insert(Product p)
        {
            using (DbContext db = new DbContext())
            {
                string sql = @"INSERT INTO Products 
                               (ProductName, ProductStock, ProductPrice)
                               VALUES (@n,@s,@p)";

                SQLiteCommand cmd = new SQLiteCommand(sql, db.Conn);
                cmd.Parameters.AddWithValue("@n", p.ProductName);
                cmd.Parameters.AddWithValue("@s", p.ProductStock);
                cmd.Parameters.AddWithValue("@p", p.ProductPrice);
                cmd.ExecuteNonQuery();
            }
        }

        public static List<Product> GetAll()
        {
            List<Product> list = new List<Product>();

            using (DbContext db = new DbContext())
            {
                string sql = "SELECT * FROM Products";
                SQLiteCommand cmd = new SQLiteCommand(sql, db.Conn);
                SQLiteDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    Product p = new Product();
                    p.ProductID = rd.GetInt32(0);
                    p.ProductName = rd.GetString(1);
                    p.ProductStock = rd.GetInt32(2);
                    p.ProductPrice = rd.GetDouble(3);
                    list.Add(p);
                }
            }
            return list;
        }
    }
}
