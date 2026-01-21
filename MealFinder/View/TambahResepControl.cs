using MealFinder.Database;
using MealFinder.Model;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MealFinder.View
{
    public partial class TambahResepControl : UserControl
    {
        string selectedImage = "";

        public TambahResepControl()
        {
            InitializeComponent();
            LoadBahan();
        }

        // ================== LOAD BAHAN ==================
        private void LoadBahan()
        {
            dgvIngredients.Columns.Clear();

            var colBahan = new DataGridViewComboBoxColumn()
            {
                HeaderText = "Bahan",
                Name = "IngredientName",
                DataSource = ProductContext.GetAllNames(),
                FlatStyle = FlatStyle.Flat
            };

            dgvIngredients.Columns.Add(colBahan);
            dgvIngredients.Columns.Add("IngredientQty", "Jumlah");
            dgvIngredients.AllowUserToAddRows = true;
            dgvIngredients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ================== BROWSE IMAGE ==================
        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image|*.jpg;*.jpeg;*.png";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedImage = ofd.FileName;

                    using (var bmpTemp = new Bitmap(ofd.FileName))
                    {
                        picPreview.Image = new Bitmap(bmpTemp);
                    }

                    picPreview.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        // ================== SIMPAN ==================
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRecipeName.Text))
            {
                MessageBox.Show("Nama resep wajib!");
                return;
            }

            if (string.IsNullOrEmpty(selectedImage) || !File.Exists(selectedImage))
            {
                MessageBox.Show("Pilih gambar terlebih dahulu!");
                return;
            }

            using (DbContext db = new DbContext())
            using (var trans = db.Conn.BeginTransaction())
            {
                try
                {
                    // ROOT PROJECT
                    string projectRoot = Path.GetFullPath(
                        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..")
                    );

                    string imgFolder = Path.Combine(projectRoot, "Images");
                    string imgName = Path.GetFileName(selectedImage);
                    string imgPath = Path.Combine(imgFolder, imgName);

                    if (!Directory.Exists(imgFolder))
                        Directory.CreateDirectory(imgFolder);

                    if (!File.Exists(imgPath))
                        File.Copy(selectedImage, imgPath, true);

                    // INSERT RECIPE
                    MealFinder.Model.Recipe r = new MealFinder.Model.Recipe

                    {
                        RecipeName = txtRecipeName.Text.Trim(),
                        Description = txtDescription.Text.Trim(),
                        ImagePath = "Images/" + imgName
                    };

                    int recipeId = RecipeContext.Insert(r, db.Conn, trans);

                    // INSERT INGREDIENT
                    foreach (DataGridViewRow row in dgvIngredients.Rows)
                    {
                        if (row.IsNewRow) continue;

                        if (row.Cells["IngredientName"].Value == null) continue;

                        string bahan = row.Cells["IngredientName"].Value.ToString();
                        string qty = row.Cells["IngredientQty"].Value?.ToString();

                        MealFinder.Model.Ingredient i = new MealFinder.Model.Ingredient

                        {
                            IngredientName = bahan,
                            IngredientQuantity = string.IsNullOrWhiteSpace(qty) ? "-" : qty,
                            RecipeID = recipeId
                        };

                        IngredientContext.Insert(i: i, db.Conn, trans);
                    }

                    trans.Commit();
                    MessageBox.Show("Resep berhasil ditambahkan!");

                    ClearForm();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show("Gagal menyimpan:\n" + ex.Message);
                }
            }
        }

        // ================== CLEAR ==================
        private void ClearForm()
        {
            txtRecipeName.Clear();
            txtDescription.Clear();
            picPreview.Image = null;
            dgvIngredients.Rows.Clear();
            selectedImage = "";
        }

        // ================== CANCEL ==================
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
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
    }
}
