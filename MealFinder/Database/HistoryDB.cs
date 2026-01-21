using MealFinder.View;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MealFinder.Model;

namespace MealFinder.Database
{
    public class HistoryDB
    {
        // ================= ADD HISTORY =================
        public static void AddHistory(
        int userId,
        int recipeId,
        string recipeName,
        SQLiteConnection conn,
        SQLiteTransaction trans)
        {
            string sql = @"INSERT INTO History
                   (UserID, RecipeID, RecipeName, CreatedAt)
                   VALUES (@u,@r,@n,@c)";

            using (var cmd = new SQLiteCommand(sql, conn, trans))
            {
                cmd.Parameters.AddWithValue("@u", userId);
                cmd.Parameters.AddWithValue("@r", recipeId);
                cmd.Parameters.AddWithValue("@n", recipeName);
                cmd.Parameters.AddWithValue("@c",
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                cmd.ExecuteNonQuery();
            }
        }

        // ================= GET ALL HISTORY =================
        public static List<Riwayat> GetAll()
        {
            List<Riwayat> list = new List<Riwayat>();

            using (DbContext db = new DbContext())
            {
                string sql = @"SELECT * FROM History 
                               ORDER BY CreatedAt DESC";

                SQLiteCommand cmd = new SQLiteCommand(sql, db.Conn);
                SQLiteDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    list.Add(new Riwayat
                    {
                        HistoryID = Convert.ToInt32(rd["HistoryID"]),
                        UserID = Convert.ToInt32(rd["UserID"]),
                        RecipeID = Convert.ToInt32(rd["RecipeID"]),
                        RecipeName = rd["RecipeName"].ToString(),
                        CreatedAt = DateTime.Parse(rd["CreatedAt"].ToString())
                    });
                }
            }

            return list;
        }

        // ================= GET HISTORY BY USER =================
        public static List<Riwayat> GetByUser(int userId)
        {
            List<Riwayat> list = new List<Riwayat>();

            using (DbContext db = new DbContext())
            {
                string sql = @"SELECT * FROM History
                       WHERE UserID = @u
                       ORDER BY CreatedAt DESC";

                SQLiteCommand cmd = new SQLiteCommand(sql, db.Conn);
                cmd.Parameters.AddWithValue("@u", userId);

                SQLiteDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    list.Add(new Riwayat
                    {
                        HistoryID = Convert.ToInt32(rd["HistoryID"]),
                        UserID = Convert.ToInt32(rd["UserID"]),
                        RecipeID = Convert.ToInt32(rd["RecipeID"]),
                        RecipeName = rd["RecipeName"].ToString(),
                        CreatedAt = DateTime.Parse(rd["CreatedAt"].ToString())
                    });
                }
            }
            return list;
        }


        // ================= DELETE HISTORY =================
        public static void Delete(int historyId)
        {
            using (DbContext db = new DbContext())
            {
                string sql = "DELETE FROM History WHERE HistoryID=@id";

                SQLiteCommand cmd = new SQLiteCommand(sql, db.Conn);
                cmd.Parameters.AddWithValue("@id", historyId);

                cmd.ExecuteNonQuery();
            }
        }
    }
}