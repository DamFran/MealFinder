using MealFinder.Database;
using MealFinder.Helper;
using MealFinder.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MealFinder.View
{
    public partial class HapusResepControl : UserControl
    {
        private RecipeContext recipeContext;

        public HapusResepControl()
        {
            InitializeComponent();

            recipeContext = new RecipeContext();

            SetupGrid();
            LoadRecipes();
        }

        // ================= SETUP GRID =================
        private void SetupGrid()
        {
            dgvRecipes.AllowUserToAddRows = false;
            dgvRecipes.AllowUserToDeleteRows = false;
            dgvRecipes.ReadOnly = true; // 🔥 INI PENTING
            dgvRecipes.RowHeadersVisible = false;
            dgvRecipes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRecipes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRecipes.MultiSelect = false;

            dgvRecipes.Columns.Clear();

            dgvRecipes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "RecipeID",
                Visible = false,
                ReadOnly = true
            });

            dgvRecipes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "RecipeName",
                HeaderText = "Nama Resep",
                ReadOnly = true
            });

            dgvRecipes.SelectionChanged += dgvRecipes_SelectionChanged;

        }
        private void dgvRecipes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRecipes.CurrentRow == null)
                return;

            ShowImage();
        }



        // ================= LOAD DATA =================
        private void LoadRecipes()
        {
            dgvRecipes.Rows.Clear();

            foreach (var r in recipeContext.GetAll())
            {
                dgvRecipes.Rows.Add(r.RecipeID, r.RecipeName);
            }

            // 🔥 AUTO SELECT ROW PERTAMA
            if (dgvRecipes.Rows.Count > 0)
            {
                dgvRecipes.Rows[0].Selected = true;
                dgvRecipes.CurrentCell = dgvRecipes.Rows[0].Cells["RecipeName"];
                ShowImage();
            }
        }


        private void dgvRecipes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // klik header
            ShowImage();
        }

        // ================= GET SELECTED =================
        private MealFinder.Model.Recipe GetSelectedRecipe()
        {
            if (dgvRecipes.CurrentRow == null)
                return null;

            int id = Convert.ToInt32(
                dgvRecipes.CurrentRow.Cells["RecipeID"].Value
            );

            return recipeContext.GetById(id);
        }

        // ================= IMAGE =================
        private void ShowImage()
        {
            var recipe = GetSelectedRecipe();
            if (recipe == null) return;

            if (string.IsNullOrWhiteSpace(recipe.ImagePath))
            {
                picPreview.Image = null;
                return;
            }

            string projectRoot = Path.GetFullPath(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..")
            );

            string fullPath = Path.Combine(
                projectRoot,
                recipe.ImagePath.Replace("/", "\\")
            );

            if (!File.Exists(fullPath))
            {
                picPreview.Image = null;
                return;
            }

            // 🔥 RELEASE IMAGE SEBELUM LOAD BARU
            picPreview.Image?.Dispose();
            picPreview.Image = null;

            // 🔥 COPY FILE KE MEMORY (ANTI LOCK)
            byte[] imageBytes = File.ReadAllBytes(fullPath);
            using (var ms = new MemoryStream(imageBytes))
            {
                picPreview.Image = Image.FromStream(ms);
            }

            picPreview.SizeMode = PictureBoxSizeMode.Zoom;
        }


        // ================= DELETE =================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var recipe = GetSelectedRecipe();
            if (recipe == null)
            {
                MessageBox.Show("Pilih resep terlebih dahulu!");
                return;
            }

            var confirm = MessageBox.Show(
                $"Yakin ingin menghapus resep \"{recipe.RecipeName}\"?",
                "Konfirmasi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                // 1. Hapus ingredients
                IngredientContext.DeleteByRecipe(recipe.RecipeID);

                // 2. Hapus recipe
                recipeContext.Delete(recipe.RecipeID);

                // 3. Hapus gambar
                DeleteImage(recipe.ImagePath);

                MessageBox.Show("Resep berhasil dihapus!");

                // reset UI
                picPreview.Image?.Dispose();
                picPreview.Image = null;

                // reload data
                LoadRecipes();


                // refresh RecipeControl
                RefreshRecipeControl();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menghapus:\n" + ex.Message);
            }
        }

        private void DeleteImage(string relativePath)
        {
            if (string.IsNullOrWhiteSpace(relativePath))
                return;

            string projectRoot = Path.GetFullPath(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..")
            );

            string fullPath = Path.Combine(
                projectRoot,
                relativePath.Replace("/", "\\")
            );

            if (File.Exists(fullPath))
                File.Delete(fullPath);
        }



        private void btnBack_Click(object sender, EventArgs e)
        {

            PanelForm mainForm = this.FindForm() as PanelForm;
            if (mainForm != null)
            {
                mainForm.OpenRecipeControl();

                if (mainForm.RecipeControl != null)
                    mainForm.RecipeControl.ReloadBahanDapur();
                mainForm.RecipeControl.ReloadRecipes();
            }

        }
        private void RefreshRecipeControl()
        {
            PanelForm mainForm = this.FindForm() as PanelForm;
            if (mainForm?.RecipeControl != null)
            {
                mainForm.RecipeControl.ReloadRecipes();
                mainForm.RecipeControl.ReloadBahanDapur();
            }
        }
        public void ReloadRecipes()
        {
            LoadRecipes();

            picPreview.Image?.Dispose();
            picPreview.Image = null;
        }
    }
}