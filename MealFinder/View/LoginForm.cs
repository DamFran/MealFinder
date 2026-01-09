using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MealFinder.View;

namespace MealFinder.View
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {

            InitializeComponent();


            this.MaximizeBox = false;        // Nonaktifkan maximize
            this.MinimizeBox = false;        // (opsional) Nonaktifkan minimize
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
            this.Hide(); // atau this.Close();
        }
    }
}
