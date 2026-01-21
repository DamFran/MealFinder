using System;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;
using MealFinder.Model;
using MealFinder.Helper;

namespace MealFinder.View
{
    public partial class PanelForm : Form
    {
        private User _currentUser;
        private IconButton currentBtn;
        private Panel leftBorderBtn;

        // 🔥 SIMPAN INSTANCE CONTROL
        private Home homeControl;
        private Recipe recipeControl;
        private TambahBahanControl tambahBahanControl;
        private TambahResepControl tambahResepControl;

        private Team teamControl;

        public PanelForm()
        {
            InitializeComponent();

            FileHelper.EnsureImagesCopied();
            this.AutoScaleMode = AutoScaleMode.None;

            panelDesktop.Dock = DockStyle.Fill;
            panelDesktop.Padding = new Padding(0);
            panelDesktop.Margin = new Padding(0);

            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);

            SetButtonHoverStyle(BtnHome);
            SetButtonHoverStyle(BtnRecipe);
            SetButtonHoverStyle(BtnAboutUs);

            OpenHome();

            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public PanelForm(User user) : this()
        {
            _currentUser = user;
            lblUsername.Text = user.Username;
        }

        // ================= OPEN CONTROL =================

        private void OpenHome()
        {
            panelDesktop.Controls.Clear();

            if (homeControl == null)
                homeControl = new Home();

            homeControl.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(homeControl);
            lblTitleChildForm.Text = "Home";
        }

        public void OpenRecipeControl()
        {
            panelDesktop.Controls.Clear();

            if (recipeControl == null)
                recipeControl = new Recipe();

            recipeControl.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(recipeControl);
            lblTitleChildForm.Text = "Recipe";
        }

        public void OpenTambahBahan()
        {
            panelDesktop.Controls.Clear();

            if (tambahBahanControl == null)
                tambahBahanControl = new TambahBahanControl();

            tambahBahanControl.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(tambahBahanControl);
            lblTitleChildForm.Text = "Tambah Bahan";
        }
        public void OpenTambahResep()
        {
            panelDesktop.Controls.Clear();

            if (tambahResepControl == null)
                tambahResepControl = new TambahResepControl();

            tambahResepControl.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(tambahResepControl);
            lblTitleChildForm.Text = "Tambah Resep";
        }


        public void OpenTeam()
        {
            panelDesktop.Controls.Clear();

            if (teamControl == null)
                teamControl = new Team();

            teamControl.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(teamControl);
            lblTitleChildForm.Text = "About Us";
        }

        // 🔥 AKSES RECIPE DARI CONTROL LAIN
        public Recipe RecipeControl => recipeControl;

        // ================= MENU =================

        private void BtnHome_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.White);
            OpenHome();
        }

        private void BtnRecipe_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.White);
            OpenRecipeControl();
        }

        private void BtnAboutUs_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.White);
            OpenTeam();
        }

        // ================= UI STYLE =================

        private void SetButtonHoverStyle(IconButton button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 95, 65);
            button.FlatAppearance.MouseDownBackColor = Color.FromArgb(36, 70, 45);
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn == null) return;

            DisableButton();
            currentBtn = (IconButton)senderBtn;

            currentBtn.BackColor = Color.FromArgb(46, 82, 53);
            currentBtn.ForeColor = color;
            currentBtn.IconColor = color;
        }

        private void DisableButton()
        {
            if (currentBtn == null) return;

            currentBtn.BackColor = Color.FromArgb(46, 82, 53);
            currentBtn.ForeColor = Color.Gainsboro;
            currentBtn.IconColor = Color.Gainsboro;
        }

        // ================= LOGOUT =================

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Yakin ingin logout?",
                "Konfirmasi Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
                Logout();
        }

        private void Logout()
        {
            _currentUser = null;
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
