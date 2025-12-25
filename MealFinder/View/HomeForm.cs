using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace MealFinder.View
{
    public partial class HomeForm : Form
    {
        private IconButton currentButton;
        private Panel leftBorderBtn;
            


        public HomeForm()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(10, 60);
            panelMenu.Controls.Add(leftBorderBtn);

        }

        private struct RGBColors
        {

            public static Color color1 = Color.FromArgb(17, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);




        }

        private void ActivateButton(object senderBtn, Color color) {

            if (senderBtn != null) { 
            
                DisableButton();
            currentButton=(IconButton)senderBtn;
                currentButton.BackColor = Color.FromArgb(15, 40, 84);
                currentButton.ForeColor = color;
                currentButton.TextAlign = ContentAlignment.MiddleCenter;
                currentButton.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentButton.ImageAlign = ContentAlignment.MiddleRight;

                //left border 

                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0,currentButton.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
            }

        }

        private void DisableButton()
        {

            if (currentButton != null) {

                currentButton.BackColor = Color.FromArgb(20, 35, 89);
                currentButton.ForeColor = Color.Gainsboro;
                currentButton.TextAlign= ContentAlignment.MiddleLeft;
                currentButton.IconColor = Color.Gainsboro;
                currentButton.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentButton.ImageAlign= ContentAlignment.MiddleLeft;

                

            }

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
        }

        private void btnRecipe_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
        }

        private void btnContact_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
