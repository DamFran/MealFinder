using System;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;
using MealFinder.Model;

namespace MealFinder.View
{
    public partial class PanelForm : Form
    {
        private User _currentUser;
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private UserControl currentControl;

        public PanelForm()
        {
            InitializeComponent();

            // MATIKAN scaling WinForms (penyebab UI menciut)
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

            // Load Home default
            OpenChildControl(new Home());

            this.MaximizeBox = false;        // Nonaktifkan maximize
        
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;

           
        }

        public PanelForm(User user) : this()
        {
            _currentUser = user;
            lblUsername.Text = user.Username;
        }

        private void SetButtonHoverStyle(IconButton button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 95, 65);
            button.FlatAppearance.MouseDownBackColor = Color.FromArgb(36, 70, 45);
        }

        private struct RGBColors
        {
            public static Color white = Color.White;
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn == null) return;

            DisableButton();
            currentBtn = (IconButton)senderBtn;

            currentBtn.BackColor = Color.FromArgb(46, 82, 53);
            currentBtn.ForeColor = color;
            currentBtn.TextAlign = ContentAlignment.MiddleCenter;
            currentBtn.IconColor = color;
            currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
            currentBtn.ImageAlign = ContentAlignment.MiddleRight;

            leftBorderBtn.BackColor = color;
            leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
            leftBorderBtn.Visible = true;
            leftBorderBtn.BringToFront();

            iconCurrentChildForm.IconChar = currentBtn.IconChar;
            iconCurrentChildForm.IconColor = color;
        }

        private void DisableButton()
        {
            if (currentBtn == null) return;

            currentBtn.BackColor = Color.FromArgb(46, 82, 53);
            currentBtn.ForeColor = Color.Gainsboro;
            currentBtn.TextAlign = ContentAlignment.MiddleLeft;
            currentBtn.IconColor = Color.Gainsboro;
            currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
        }

        // SPA LOADER (UserControl)
        private void OpenChildControl(UserControl control)
        {
            panelDesktop.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(control);
            lblTitleChildForm.Text = control.Name;
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.white);
            OpenChildControl(new Home());
        }

        private void BtnRecipe_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.white);
<<<<<<< HEAD
            OpenChildControl(new RecipeControl());
=======
            

>>>>>>> 2f3a98c2305290900c3765aec7460b8a0f0f02e4
        }

        private void BtnAboutUs_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.white);
            OpenChildControl(new Team());

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Yakin ingin logout?",
                "Konfirmasi Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                Logout();
            }
        }

        private void Logout()
        {
            _currentUser = null;

            Login login = new Login();
            login.Show();

            this.Close(); // PENTING: jangan Hide
        }
    }
}
