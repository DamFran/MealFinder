namespace MealFinder.View
{
    partial class Recipe
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.dgvIngredients = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnAddIngredient = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2GradientPanel2 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.btnHapusResep = new Guna.UI2.WinForms.Guna2Button();
            this.btnTambahResep = new Guna.UI2.WinForms.Guna2Button();
            this.dgvRecipes = new System.Windows.Forms.DataGridView();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2GradientPanel3 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.picRecipe = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2GradientPanel4 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.txtNote = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnMasak = new Guna.UI2.WinForms.Guna2Button();
            this.txtDescription = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblRecipeName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredients)).BeginInit();
            this.guna2GradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecipes)).BeginInit();
            this.guna2GradientPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picRecipe)).BeginInit();
            this.guna2GradientPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BackColor = System.Drawing.Color.Gainsboro;
            this.guna2GradientPanel1.Controls.Add(this.dgvIngredients);
            this.guna2GradientPanel1.Controls.Add(this.btnAddIngredient);
            this.guna2GradientPanel1.Controls.Add(this.guna2HtmlLabel1);
            this.guna2GradientPanel1.Location = new System.Drawing.Point(17, 16);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(400, 570);
            this.guna2GradientPanel1.TabIndex = 0;
            // 
            // dgvIngredients
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvIngredients.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIngredients.BackgroundColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIngredients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvIngredients.ColumnHeadersHeight = 15;
            this.dgvIngredients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIngredients.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvIngredients.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvIngredients.Location = new System.Drawing.Point(3, 36);
            this.dgvIngredients.Name = "dgvIngredients";
            this.dgvIngredients.RowHeadersVisible = false;
            this.dgvIngredients.RowHeadersWidth = 51;
            this.dgvIngredients.Size = new System.Drawing.Size(394, 495);
            this.dgvIngredients.TabIndex = 2;
            this.dgvIngredients.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvIngredients.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvIngredients.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvIngredients.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvIngredients.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvIngredients.ThemeStyle.BackColor = System.Drawing.Color.Gainsboro;
            this.dgvIngredients.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvIngredients.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvIngredients.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvIngredients.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvIngredients.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvIngredients.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvIngredients.ThemeStyle.HeaderStyle.Height = 15;
            this.dgvIngredients.ThemeStyle.ReadOnly = false;
            this.dgvIngredients.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvIngredients.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvIngredients.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvIngredients.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvIngredients.ThemeStyle.RowsStyle.Height = 22;
            this.dgvIngredients.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvIngredients.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // btnAddIngredient
            // 
            this.btnAddIngredient.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddIngredient.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddIngredient.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddIngredient.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddIngredient.FillColor = System.Drawing.Color.Silver;
            this.btnAddIngredient.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddIngredient.ForeColor = System.Drawing.Color.Black;
            this.btnAddIngredient.Location = new System.Drawing.Point(3, 537);
            this.btnAddIngredient.Name = "btnAddIngredient";
            this.btnAddIngredient.Size = new System.Drawing.Size(394, 30);
            this.btnAddIngredient.TabIndex = 1;
            this.btnAddIngredient.Text = "Tambah Bahan";
            this.btnAddIngredient.Click += new System.EventHandler(this.btnAddIngredient_Click);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.AutoSize = false;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Silver;
            this.guna2HtmlLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(0, 0);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(400, 30);
            this.guna2HtmlLabel1.TabIndex = 0;
            this.guna2HtmlLabel1.Text = "Bahan Dapur";
            this.guna2HtmlLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2GradientPanel2
            // 
            this.guna2GradientPanel2.BackColor = System.Drawing.Color.Gainsboro;
            this.guna2GradientPanel2.Controls.Add(this.btnHapusResep);
            this.guna2GradientPanel2.Controls.Add(this.btnTambahResep);
            this.guna2GradientPanel2.Controls.Add(this.dgvRecipes);
            this.guna2GradientPanel2.Controls.Add(this.guna2HtmlLabel2);
            this.guna2GradientPanel2.Location = new System.Drawing.Point(425, 16);
            this.guna2GradientPanel2.Name = "guna2GradientPanel2";
            this.guna2GradientPanel2.Size = new System.Drawing.Size(200, 570);
            this.guna2GradientPanel2.TabIndex = 1;
            // 
            // btnHapusResep
            // 
            this.btnHapusResep.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHapusResep.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHapusResep.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHapusResep.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHapusResep.FillColor = System.Drawing.Color.Silver;
            this.btnHapusResep.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHapusResep.ForeColor = System.Drawing.Color.Black;
            this.btnHapusResep.Location = new System.Drawing.Point(3, 501);
            this.btnHapusResep.Name = "btnHapusResep";
            this.btnHapusResep.Size = new System.Drawing.Size(194, 30);
            this.btnHapusResep.TabIndex = 6;
            this.btnHapusResep.Text = "Hapus Resep";
            this.btnHapusResep.Click += new System.EventHandler(this.btnHapusResep_Click);
            // 
            // btnTambahResep
            // 
            this.btnTambahResep.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTambahResep.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTambahResep.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTambahResep.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTambahResep.FillColor = System.Drawing.Color.Silver;
            this.btnTambahResep.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTambahResep.ForeColor = System.Drawing.Color.Black;
            this.btnTambahResep.Location = new System.Drawing.Point(3, 537);
            this.btnTambahResep.Name = "btnTambahResep";
            this.btnTambahResep.Size = new System.Drawing.Size(194, 30);
            this.btnTambahResep.TabIndex = 5;
            this.btnTambahResep.Text = "Tambah Resep";
            this.btnTambahResep.Click += new System.EventHandler(this.btnTambahResep_Click);
            // 
            // dgvRecipes
            // 
            this.dgvRecipes.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvRecipes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecipes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecipes.Location = new System.Drawing.Point(3, 36);
            this.dgvRecipes.Name = "dgvRecipes";
            this.dgvRecipes.RowHeadersWidth = 51;
            this.dgvRecipes.Size = new System.Drawing.Size(194, 459);
            this.dgvRecipes.TabIndex = 1;
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.AutoSize = false;
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Silver;
            this.guna2HtmlLabel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(0, 0);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(200, 30);
            this.guna2HtmlLabel2.TabIndex = 0;
            this.guna2HtmlLabel2.Text = "Resep";
            this.guna2HtmlLabel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guna2GradientPanel3
            // 
            this.guna2GradientPanel3.BackColor = System.Drawing.Color.Gainsboro;
            this.guna2GradientPanel3.Controls.Add(this.picRecipe);
            this.guna2GradientPanel3.Location = new System.Drawing.Point(633, 16);
            this.guna2GradientPanel3.Name = "guna2GradientPanel3";
            this.guna2GradientPanel3.Size = new System.Drawing.Size(300, 267);
            this.guna2GradientPanel3.TabIndex = 2;
            // 
            // picRecipe
            // 
            this.picRecipe.FillColor = System.Drawing.Color.Gainsboro;
            this.picRecipe.ImageRotate = 0F;
            this.picRecipe.Location = new System.Drawing.Point(3, 3);
            this.picRecipe.Name = "picRecipe";
            this.picRecipe.Size = new System.Drawing.Size(294, 261);
            this.picRecipe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picRecipe.TabIndex = 0;
            this.picRecipe.TabStop = false;
            this.picRecipe.Click += new System.EventHandler(this.picRecipe_Click);
            // 
            // guna2GradientPanel4
            // 
            this.guna2GradientPanel4.BackColor = System.Drawing.Color.Gainsboro;
            this.guna2GradientPanel4.Controls.Add(this.txtNote);
            this.guna2GradientPanel4.Controls.Add(this.btnMasak);
            this.guna2GradientPanel4.Controls.Add(this.txtDescription);
            this.guna2GradientPanel4.Controls.Add(this.lblRecipeName);
            this.guna2GradientPanel4.Location = new System.Drawing.Point(633, 289);
            this.guna2GradientPanel4.Name = "guna2GradientPanel4";
            this.guna2GradientPanel4.Size = new System.Drawing.Size(300, 297);
            this.guna2GradientPanel4.TabIndex = 3;
            // 
            // txtNote
            // 
            this.txtNote.BackColor = System.Drawing.Color.Gainsboro;
            this.txtNote.BorderThickness = 0;
            this.txtNote.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNote.DefaultText = "";
            this.txtNote.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNote.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNote.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNote.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNote.FillColor = System.Drawing.Color.Gainsboro;
            this.txtNote.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNote.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNote.ForeColor = System.Drawing.Color.Black;
            this.txtNote.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNote.Location = new System.Drawing.Point(3, 112);
            this.txtNote.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.PlaceholderText = "";
            this.txtNote.ReadOnly = true;
            this.txtNote.SelectedText = "";
            this.txtNote.Size = new System.Drawing.Size(294, 146);
            this.txtNote.TabIndex = 4;
            // 
            // btnMasak
            // 
            this.btnMasak.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnMasak.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnMasak.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnMasak.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnMasak.FillColor = System.Drawing.Color.Silver;
            this.btnMasak.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMasak.ForeColor = System.Drawing.Color.Black;
            this.btnMasak.Location = new System.Drawing.Point(4, 264);
            this.btnMasak.Name = "btnMasak";
            this.btnMasak.Size = new System.Drawing.Size(292, 30);
            this.btnMasak.TabIndex = 3;
            this.btnMasak.Text = "Masak Resep";
            this.btnMasak.Click += new System.EventHandler(this.btnMasak_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.Gainsboro;
            this.txtDescription.BorderThickness = 0;
            this.txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescription.DefaultText = "";
            this.txtDescription.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDescription.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDescription.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDescription.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDescription.FillColor = System.Drawing.Color.Gainsboro;
            this.txtDescription.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDescription.ForeColor = System.Drawing.Color.Black;
            this.txtDescription.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDescription.Location = new System.Drawing.Point(3, 36);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PlaceholderText = "";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.SelectedText = "";
            this.txtDescription.Size = new System.Drawing.Size(294, 68);
            this.txtDescription.TabIndex = 1;
            // 
            // lblRecipeName
            // 
            this.lblRecipeName.AutoSize = false;
            this.lblRecipeName.BackColor = System.Drawing.Color.Silver;
            this.lblRecipeName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRecipeName.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecipeName.Location = new System.Drawing.Point(0, 0);
            this.lblRecipeName.Name = "lblRecipeName";
            this.lblRecipeName.Size = new System.Drawing.Size(300, 30);
            this.lblRecipeName.TabIndex = 0;
            this.lblRecipeName.Text = "Detail Resep";
            this.lblRecipeName.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Recipe
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(70)))), ((int)(((byte)(44)))));
            this.Controls.Add(this.guna2GradientPanel4);
            this.Controls.Add(this.guna2GradientPanel3);
            this.Controls.Add(this.guna2GradientPanel2);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Name = "Recipe";
            this.Size = new System.Drawing.Size(950, 603);
            this.guna2GradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredients)).EndInit();
            this.guna2GradientPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecipes)).EndInit();
            this.guna2GradientPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picRecipe)).EndInit();
            this.guna2GradientPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel2;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel3;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel4;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblRecipeName;
        private Guna.UI2.WinForms.Guna2Button btnAddIngredient;
        private System.Windows.Forms.DataGridView dgvRecipes;
        private Guna.UI2.WinForms.Guna2PictureBox picRecipe;
        private Guna.UI2.WinForms.Guna2TextBox txtDescription;
        private Guna.UI2.WinForms.Guna2DataGridView dgvIngredients;
        private Guna.UI2.WinForms.Guna2Button btnMasak;
        private Guna.UI2.WinForms.Guna2TextBox txtNote;
        private Guna.UI2.WinForms.Guna2Button btnTambahResep;
        private Guna.UI2.WinForms.Guna2Button btnHapusResep;
    }
}
