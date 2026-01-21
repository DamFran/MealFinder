using MealFinder.Database;
using MealFinder.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MealFinder.Helper;

namespace MealFinder.View
{
    public partial class Recipe : UserControl
    {
        private List<Product> products;
        private List<Model.Recipe> recipes;

        private ProductContext productContext;
        private RecipeContext recipeContext;
        private IngredientContext ingredientContext;

        public Recipe()
        {
            InitializeComponent();


            picRecipe.SizeMode = PictureBoxSizeMode.Zoom;


            // INIT CONTEXT
            productContext = new ProductContext();
            recipeContext = new RecipeContext();
            ingredientContext = new IngredientContext();

            SetupIngredientGrid();
            SetupRecipeGrid();

            LoadProducts();
            LoadRecipes();

            this.Load += Recipe_Load;
        }

        private void Recipe_Load(object sender, EventArgs e)
        {
            ApplyRoleAccess();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            if (this.Visible)
                ApplyRoleAccess();
        }


        private void ApplyRoleAccess()
        {
            bool isAdmin = Permission.IsAdmin;

            btnTambahResep.Visible = isAdmin;
            btnHapusResep.Visible = isAdmin;
        }


        // ================= SETUP GRID =================
        private void SetupIngredientGrid()
        {
            dgvIngredients.AllowUserToAddRows = false;
            dgvIngredients.RowHeadersVisible = false;
            dgvIngredients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvIngredients.EnableHeadersVisualStyles = false;
            dgvIngredients.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvIngredients.ColumnHeadersHeight = 32;

            dgvIngredients.ColumnHeadersDefaultCellStyle.BackColor = Color.Gainsboro;
            dgvIngredients.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvIngredients.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvIngredients.Columns.Clear();

            dgvIngredients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProductID",
                Visible = false
            });

            dgvIngredients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ProductName",
                HeaderText = "Bahan",
                ReadOnly = true,
                FillWeight = 50
            });

            dgvIngredients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Stock",
                HeaderText = "Stock",
                ReadOnly = true,
                FillWeight = 25
            });

            dgvIngredients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Quantity",
                HeaderText = "Jumlah",
                FillWeight = 25,
                MinimumWidth = 80
            });

            dgvIngredients.CellValueChanged += dgvIngredients_CellValueChanged;
            dgvIngredients.CurrentCellDirtyStateChanged += dgvIngredients_CurrentCellDirtyStateChanged;
            dgvIngredients.EditingControlShowing += dgvIngredients_EditingControlShowing;
        }


        private void SetupRecipeGrid()
        {
            dgvRecipes.AllowUserToAddRows = false;
            dgvRecipes.RowHeadersVisible = false;
            dgvRecipes.ColumnHeadersVisible = false;
            dgvRecipes.ReadOnly = true;
            dgvRecipes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvRecipes.Columns.Clear();

            dgvRecipes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "RecipeID",
                Visible = false
            });

            dgvRecipes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "RecipeName",
                HeaderText = "Resep",
                FillWeight = 100
            });

            dgvRecipes.CellClick += dgvRecipes_CellClick;
        }


        // ================= LOAD DATA =================
        private void LoadProducts()
        {
            products = ProductContext.GetAll();
            dgvIngredients.Rows.Clear();

            foreach (var p in products)
            {
                dgvIngredients.Rows.Add(
                    p.ProductID,
                    p.ProductName,
                    p.ProductStock, // ✅ STOK ASLI
                    0               // jumlah yang mau dipakai
                );
            }
        }

        public void ReloadBahanDapur()
        {
            LoadProducts();
            FilterRecipes(); // optional, supaya recipe langsung update
        }


        private void LoadRecipes()
        {
            recipes = recipeContext.GetAll();
        }

        // ================= VALIDASI ANGKA =================
        private void dgvIngredients_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvIngredients.CurrentCell.ColumnIndex ==
                dgvIngredients.Columns["Quantity"].Index)
            {
                if (e.Control is TextBox tb)
                {
                    tb.KeyPress -= NumberOnly_KeyPress;
                    tb.KeyPress += NumberOnly_KeyPress;
                }
            }
        }

        private void NumberOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        // ================= FILTER =================
        private void dgvIngredients_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvIngredients.Columns[e.ColumnIndex].Name == "Quantity")
            {
                var cell = dgvIngredients.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (cell.Value == null || cell.Value.ToString() == "")
                    cell.Value = 0;
            }
        }

        private Dictionary<string, int> GetSelectedIngredients()
        {
            Dictionary<string, int> selected = new Dictionary<string, int>();

            foreach (DataGridViewRow row in dgvIngredients.Rows)
            {
                if (row.Cells["Quantity"].Value == null)
                    continue;

                if (!int.TryParse(row.Cells["Quantity"].Value.ToString(), out int qty))
                    continue;

                if (qty <= 0)
                    continue;

                string name = row.Cells["ProductName"].Value.ToString();
                selected[name] = qty;
            }

            return selected;
        }

        private void FilterRecipes()
        {
            var selectedIngredients = GetSelectedIngredients();
            dgvRecipes.Rows.Clear();

            if (selectedIngredients.Count == 0)
                return;

            foreach (var recipe in recipes)
            {
                var ingredients = IngredientContext.GetByRecipe(recipe.RecipeID);

                bool match = false;

                foreach (var ing in ingredients)
                {
                    if (selectedIngredients.ContainsKey(ing.IngredientName))
                    {
                        match = true;
                        break;
                    }
                }

                if (match)
                {
                    dgvRecipes.Rows.Add(
                        recipe.RecipeID,
                        recipe.RecipeName,
                        recipe.Description
                    );
                }
            }
        }



        private void dgvIngredients_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvIngredients.IsCurrentCellDirty)
                dgvIngredients.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvIngredients_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvIngredients.Columns[e.ColumnIndex].Name == "Quantity")
            {
                FilterRecipes();
            }
        }


        // ================= IMAGE =================
        private Model.Recipe GetSelectedRecipe()
        {
            if (dgvRecipes.CurrentRow == null)
                return null;

            int recipeId = Convert.ToInt32(
                dgvRecipes.CurrentRow.Cells["RecipeID"].Value
            );

            return recipeContext.GetById(recipeId);
        }

        private void dgvRecipes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowRecipeImage();
            ShowRecipeDetail();
        }

        private void picRecipe_Click(object sender, EventArgs e)
        {
            ShowRecipeImage();
        }

        private void ShowRecipeImage()
        {
            Model.Recipe recipe = GetSelectedRecipe();
            if (recipe == null) return;

            if (string.IsNullOrWhiteSpace(recipe.ImagePath))
            {
                picRecipe.Image = null;
                return;
            }

            // Ambil folder project (naik dari bin/Debug)
            string projectRoot = Path.GetFullPath(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..")
            );

            string fullPath = Path.Combine(
                projectRoot,
                recipe.ImagePath.Replace("/", "\\")
            );

            if (!File.Exists(fullPath))
            {
                MessageBox.Show("Gambar tidak ditemukan:\n" + fullPath);
                return;
            }

            picRecipe.Image?.Dispose();
            picRecipe.Image = null;

            byte[] imgBytes = File.ReadAllBytes(fullPath);
            using (var ms = new MemoryStream(imgBytes))
            {
                picRecipe.Image = Image.FromStream(ms);
            }

            picRecipe.SizeMode = PictureBoxSizeMode.Zoom;

        }

        // === SHOW RECIPE ===
        private void ShowRecipeDetail()
        {
            var recipe = GetSelectedRecipe();
            if (recipe == null)
            {
                txtDescription.Clear();
                txtNote.Clear();
                return;
            }

            txtDescription.Text = recipe.Description;

            var selected = GetSelectedIngredients();
            var ingredients = IngredientContext.GetByRecipe(recipe.RecipeID);

            List<string> missing = new List<string>();

            foreach (var ing in ingredients)
            {
                if (!selected.ContainsKey(ing.IngredientName))
                    missing.Add(ing.IngredientName);
            }

            if (missing.Count > 0)
            {
                txtNote.Text =
                    "Note:\r" +
                    "Bahan belum lengkap.\r\r\n" +
                    "Bahan Yang Kurang:\r\n- " +
                    string.Join("\r\n- ", missing);
                txtNote.ForeColor = Color.DarkRed;
            }
            else
            {
                txtNote.Text =
                    "Note:\r" +
                    "Semua bahan sudah lengkap ✔";
                txtNote.ForeColor = Color.DarkGreen;
            }
        }



        private bool IsRecipeComplete(Model.Recipe recipe, out List<string> missing)
        {
            missing = new List<string>();

            var selected = GetSelectedIngredients();
            var ingredients = IngredientContext.GetByRecipe(recipe.RecipeID);

            foreach (var ing in ingredients)
            {
                if (!selected.ContainsKey(ing.IngredientName))
                {
                    missing.Add(ing.IngredientName);
                }
            }

            return missing.Count == 0;
        }



        private void btnAddIngredient_Click(object sender, EventArgs e)
        {
            PanelForm mainForm = this.FindForm() as PanelForm;
            if (mainForm != null)
            {
                mainForm.OpenTambahBahan();
            }
        }

        private void btnMasak_Click(object sender, EventArgs e)
        {
            MasakResep();
        }
        private void MasakResep()
        {

            var recipe = GetSelectedRecipe();
            if (recipe == null)
            {
                MessageBox.Show("Pilih resep dulu!");
                return;
            }

            if (!IsRecipeComplete(recipe, out var missing))
            {
                MessageBox.Show(
                    "Bahan belum lengkap!\nKurang:\n- " +
                    string.Join("\n- ", missing),
                    "Tidak bisa memasak",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            var selected = GetSelectedIngredients();
            if (selected.Count == 0)
            {
                MessageBox.Show("Isi jumlah bahan dulu!");
                return;
            }

            using (DbContext db = new DbContext())
            using (var trans = db.Conn.BeginTransaction())
            {
                try
                {
                    // VALIDASI STOK
                    foreach (var item in selected)
                    {
                        int stok = ProductContext.GetStockByName(
                            item.Key,
                            db.Conn,
                            trans
                        );

                        if (stok < item.Value)
                        {
                            throw new Exception(
                                $"Stok {item.Key} tidak cukup!\nStok: {stok}, Dibutuhkan: {item.Value}");
                        }
                    }

                    HistoryDB.AddHistory(
                        Session.CurrentUser.UserID,   // 🔥 USER YANG LOGIN
                        recipe.RecipeID,
                        recipe.RecipeName,
                        db.Conn,
                        trans
                     );

                    // POTONG STOK
                    foreach (var item in selected)
                    {
                        ProductContext.ReduceStockByName(
                            item.Key,
                            item.Value,
                            db.Conn,
                            trans
                        );
                    }

                    trans.Commit();

                    
                    MessageBox.Show("Resep berhasil dimasak!");
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Gagal memasak:\n" + ex.Message);
                }
            }

            ReloadBahanDapur();
            FilterRecipes();
        }

        private void btnTambahResep_Click(object sender, EventArgs e)
        {
            if (!Permission.IsAdmin)
            {
                MessageBox.Show("Akses ditolak!");
                return;
            }

            (FindForm() as PanelForm)?.OpenTambahResep();
        }
        public void ReloadRecipes()
        {
            // Ambil ulang dari database
            recipes = recipeContext.GetAll();

            // Biarkan RecipeControl yang memutuskan mau ngapain
            FilterRecipes();
        }

        private void btnHapusResep_Click(object sender, EventArgs e)
        {
            if (!Permission.IsAdmin)
            {
                MessageBox.Show("Akses ditolak!");
                return;
            }

            (FindForm() as PanelForm)?.OpenHapusResep();
        }
        public void ReleaseImage()
        {
            picRecipe.Image?.Dispose();
            picRecipe.Image = null;
        }
    }
}




