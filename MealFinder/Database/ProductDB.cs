using MealFinder.Model;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static int GetStockByName(string name, SQLiteConnection conn, SQLiteTransaction trans)
        {
            string sql = "SELECT ProductStock FROM Products WHERE ProductName=@n";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn, trans);
            cmd.Parameters.AddWithValue("@n", name);

            object result = cmd.ExecuteScalar();
            if (result == null || result == DBNull.Value)
                return 0;

            return Convert.ToInt32(result);
        }


        public static void ReduceStockByName(string name, int qty, SQLiteConnection conn, SQLiteTransaction trans)
        {
            string sql = @"
        UPDATE Products
        SET ProductStock = CASE 
            WHEN ProductStock - @qty < 0 THEN 0
            ELSE ProductStock - @qty
        END
        WHERE ProductName = @name";

            SQLiteCommand cmd = new SQLiteCommand(sql, conn, trans);
            cmd.Parameters.AddWithValue("@qty", qty);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.ExecuteNonQuery();
        }

    }
}
