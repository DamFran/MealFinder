using MealFinder.Controller;
using MealFinder.Model;
using MealFinder.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MealFinder.Helper;

namespace MealFinder.View
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();


            this.MaximizeBox = false;        // Nonaktifkan maximize
            this.MinimizeBox = false;        // (opsional) Nonaktifkan minimize
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;

            txtPassword.UseSystemPasswordChar = true;

            // Icon default = eye slash
            btnTogglePassword.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            btnTogglePassword.IconColor = Color.Gray;
            btnTogglePassword.FlatStyle = FlatStyle.Flat;
            btnTogglePassword.FlatAppearance.BorderSize = 0;
            btnTogglePassword.Cursor = Cursors.Hand;
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

            if (registerForm.ShowDialog() == DialogResult.OK)
            {
                txtUsername.Text = registerForm.RegisteredUsername;
                txtPassword.Focus();
            }
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string result = AuthController.Login(
        txtUsername.Text.Trim(),
        txtPassword.Text.Trim(),
        out User user
    );

            if (result == "OK")
            {
                // 🔥 INI BARIS PALING PENTING
                Session.CurrentUser = user;

                MessageBox.Show(
                    $"Login berhasil!",
                    "Sukses",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                PanelForm panel = new PanelForm(user);
                panel.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(
                    result,
                    "Login gagal",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void btnTogglePassword_Click(object sender, EventArgs e)
        {
            bool hidden = txtPassword.UseSystemPasswordChar;

            txtPassword.UseSystemPasswordChar = !hidden;

            btnTogglePassword.IconChar = hidden
                ? FontAwesome.Sharp.IconChar.Eye
                : FontAwesome.Sharp.IconChar.EyeSlash;
        }
    }
}
