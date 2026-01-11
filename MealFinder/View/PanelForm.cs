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

            lblUsername.MaximumSize = new Size(panelTop.Width, 0);
        }

        public PanelForm(User user) : this()
        {
            _currentUser = user;
            lblUsername.Text = user.Username;

            if (user.Role != "admin")
            {
                BtnRecipe.Visible = false;
            }
            else
            {
                BtnRecipe.Visible = true;
            }
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
            
        }

        private void BtnAboutUs_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.white);
            
        }

      
    }
}
