using MealFinder.Database;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;


namespace MealFinder.View
{
    public partial class TambahBahanControl : UserControl
    {
        private List<string> allBahan = new List<string>();

        public TambahBahanControl()
        {
            InitializeComponent();

            // WAJIB: DropDown (bukan DropDownList)
            cbBahan.DropDownStyle = ComboBoxStyle.DropDown;

            // JANGAN pakai AutoComplete WinForms (GUNA2 TIDAK SUPPORT)
            LoadBahan();

            // Event search manual
            cbBahan.TextChanged += cbBahan_TextChanged;

            this.AutoScaleMode = AutoScaleMode.None; // 🔥 FIX POTONG
            this.Dock = DockStyle.Fill;
        }

        // ================= LOAD DATA =================
        private void LoadBahan()
        {
            allBahan.Clear();
            cbBahan.Items.Clear();

            using (DbContext db = new DbContext())
            {
                string sql = "SELECT ProductName FROM Products ORDER BY ProductName";
                SQLiteCommand cmd = new SQLiteCommand(sql, db.Conn);
                SQLiteDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    allBahan.Add(reader["ProductName"].ToString());
                }
            }

            cbBahan.Items.AddRange(allBahan.ToArray());
        }

        // ================= SEARCH REALTIME (GUNA SAFE) =================
        private void cbBahan_TextChanged(object sender, EventArgs e)
        {
            string keyword = cbBahan.Text.ToLower();

            cbBahan.Items.Clear();

            foreach (var item in allBahan)
            {
                if (item.ToLower().Contains(keyword))
                    cbBahan.Items.Add(item);
            }

            cbBahan.DroppedDown = true;
            cbBahan.SelectionStart = cbBahan.Text.Length;
        }

        // ================= BUTTON TAMBAH =================
        private void TambahBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbBahan.Text))
            {
                MessageBox.Show("Nama bahan tidak boleh kosong!");
                return;
            }

            if (!int.TryParse(txtStok.Text, out int stok) || stok <= 0)
            {
                MessageBox.Show("Stok harus berupa angka lebih dari 0!");
                return;
            }

            using (DbContext db = new DbContext())
            {
                int productId = GetOrCreateProduct(db, cbBahan.Text);
                UpdateStock(db, productId, stok);
            }

            MessageBox.Show("Bahan berhasil ditambahkan ke dapur ✅");
            txtStok.Clear();
            cbBahan.Text = "";
            LoadBahan();
        }

        // ================= DB LOGIC =================
        private int GetOrCreateProduct(DbContext db, string productName)
        {
            string checkSql = "SELECT ProductID FROM Products WHERE ProductName=@name";
            SQLiteCommand cmd = new SQLiteCommand(checkSql, db.Conn);
            cmd.Parameters.AddWithValue("@name", productName);

            object result = cmd.ExecuteScalar();
            if (result != null)
                return Convert.ToInt32(result);

            string insertSql = @"
                INSERT INTO Products (ProductName, ProductStock, ProductPrice)
                VALUES (@name, 0, 0);
                SELECT last_insert_rowid();";

            cmd = new SQLiteCommand(insertSql, db.Conn);
            cmd.Parameters.AddWithValue("@name", productName);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private void UpdateStock(DbContext db, int productId, int stokBaru)
        {
            string getStockSql = "SELECT ProductStock FROM Products WHERE ProductID=@id";
            SQLiteCommand cmd = new SQLiteCommand(getStockSql, db.Conn);
            cmd.Parameters.AddWithValue("@id", productId);

            object result = cmd.ExecuteScalar();
            int stokLama = result != DBNull.Value ? Convert.ToInt32(result) : 0;

            string updateSql = "UPDATE Products SET ProductStock=@stok WHERE ProductID=@id";
            cmd = new SQLiteCommand(updateSql, db.Conn);
            cmd.Parameters.AddWithValue("@stok", stokLama + stokBaru);
            cmd.Parameters.AddWithValue("@id", productId);
            cmd.ExecuteNonQuery();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            PanelForm mainForm = this.FindForm() as PanelForm;
            if (mainForm != null)
            {
                mainForm.OpenRecipeControl();

                if (mainForm.RecipeControl != null)
                    mainForm.RecipeControl.ReloadBahanDapur();
            }

        }
    }
}
