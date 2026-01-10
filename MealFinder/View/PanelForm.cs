using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private Form currentChildForm;

        public PanelForm()
        {
            InitializeComponent();

            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);


            SetButtonHoverStyle(BtnHome);
            SetButtonHoverStyle(BtnRecipe);
            SetButtonHoverStyle(BtnAboutUs);
        }

        public PanelForm(User user) : this()
        {
            _currentUser = user;

            // Contoh: tampilkan username / role
            lblUsername.Text = user.Username;

            // Contoh: role admin
            if (user.Role != "admin")
            {
                BtnRecipe.Visible = false; // contoh menu admin
            }
        }

        private void SetButtonHoverStyle(IconButton button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;

            // Warna hover (lebih soft, tidak terlalu terang)
            button.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 95, 65);

            // Warna saat ditekan
            button.FlatAppearance.MouseDownBackColor = Color.FromArgb(36, 70, 45);
        }

        private struct RGBColors
        {
            public static Color white = Color.FromArgb(255, 255, 255);
            
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(46, 82, 53);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //Current Child Form Icon
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
            }
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(46, 82, 53);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitleChildForm.Text = childForm.Name;
        }
        private void BtnHome_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.white);
            OpenChildForm(new Home());
        }

        private void BtnRecipe_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.white);
            OpenChildForm(new Recipe());
        }

        private void BtnAboutUs_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.white);
            OpenChildForm(new Team());
        }

       
    }
}
