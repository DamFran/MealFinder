using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MealFinder.Database;
using MealFinder.Model;

namespace MealFinder.View
{
    public partial class RecipeControl : UserControl
    {
        private List<Product> products;
        private List<Recipe> recipes;

        private ProductContext productContext;
        private RecipeContext recipeContext;
        private IngredientContext ingredientContext;

        public RecipeControl()
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
        }

        // ================= SETUP GRID =================
        private void SetupIngredientGrid()
        {
            dgvIngredients.AllowUserToAddRows = false;
            dgvIngredients.RowHeadersVisible = false;
            dgvIngredients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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
                FillWeight = 70
            });

            dgvIngredients.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Quantity",
                HeaderText = "Jumlah",
                FillWeight = 30
            });

            dgvIngredients.CellEndEdit += dgvIngredients_CellEndEdit;
            dgvIngredients.EditingControlShowing += dgvIngredients_EditingControlShowing;
        }

        private void SetupRecipeGrid()
        {
            dgvRecipes.AllowUserToAddRows = false;
            dgvRecipes.RowHeadersVisible = false;
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
                HeaderText = "Recipe",
                FillWeight = 40
            });

            dgvRecipes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Description",
                HeaderText = "Deskripsi",
                FillWeight = 60
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
                    ""
                );
            }
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
            FilterRecipes();
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
                bool canMake = true;

                foreach (var ing in ingredients)
                {
                    if (!selectedIngredients.ContainsKey(ing.IngredientName))
                    {
                        canMake = false;
                        break;
                    }

                    if (!int.TryParse(ing.IngredientQuantity, out int requiredQty))
                    {
                        canMake = false;
                        break;
                    }

                    if (selectedIngredients[ing.IngredientName] < requiredQty)
                    {
                        canMake = false;
                        break;
                    }
                }

                if (canMake)
                {
                    dgvRecipes.Rows.Add(
                        recipe.RecipeID,
                        recipe.RecipeName,
                        recipe.Description
                    );
                }
            }
        }

        // ================= IMAGE =================
        private Recipe GetSelectedRecipe()
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
        }

        private void picRecipe_Click(object sender, EventArgs e)
        {
            ShowRecipeImage();
        }

        private void ShowRecipeImage()
        {
            Recipe recipe = GetSelectedRecipe();
            if (recipe == null) return;

            if (string.IsNullOrWhiteSpace(recipe.ImagePath))
            {
                picRecipe.Image = null;
                return;
            }

            string fullPath = Path.Combine(
                Application.StartupPath,
                recipe.ImagePath.Replace("/", "\\")
            );

            if (!File.Exists(fullPath))
            {
                MessageBox.Show("Gambar tidak ditemukan:\n" + fullPath);
                return;
            }

            picRecipe.Image?.Dispose();
            picRecipe.Image = Image.FromFile(fullPath);
            
        }
       }
    }

