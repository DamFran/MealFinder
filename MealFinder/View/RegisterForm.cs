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
using MealFinder.Controller;

namespace MealFinder.View
{
    public partial class RegisterForm : Form
    {
        public string RegisteredUsername { get; private set; }

        public RegisterForm()
        {
            InitializeComponent();


            this.MaximizeBox = false;        // Nonaktifkan maximize
            this.MinimizeBox = false;        // (opsional) Nonaktifkan minimize
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Default hidden
            txtPassword.UseSystemPasswordChar = true;
            txtConfirm.UseSystemPasswordChar = true;

            // Icon awal
            btnTogglePassword.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
            btnToggleConfirm.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;

            btnTogglePassword.IconColor = Color.Gray;
            btnToggleConfirm.IconColor = Color.Gray;

            btnTogglePassword.FlatStyle = FlatStyle.Flat;
            btnToggleConfirm.FlatStyle = FlatStyle.Flat;

            btnTogglePassword.FlatAppearance.BorderSize = 0;
            btnToggleConfirm.FlatAppearance.BorderSize = 0;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegistBtn_Click(object sender, EventArgs e)
        {
            string result = AuthController.Register(
                txtName.Text.Trim(),
                txtUsername.Text.Trim(),
                txtEmail.Text.Trim(),
                txtPassword.Text.Trim(),
                txtConfirm.Text.Trim()
);

            if (result == "OK")
            {
                MessageBox.Show("Register berhasil!");

                RegisteredUsername = txtUsername.Text.Trim(); // ⬅️ SIMPAN USERNAME
                this.DialogResult = DialogResult.OK;           // ⬅️ KIRIM STATUS KE LOGIN
                this.Close();
            }

            else
            {
                MessageBox.Show(result);
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

        private void btnToggleConfirm_Click(object sender, EventArgs e)
        {
            bool hidden = txtConfirm.UseSystemPasswordChar;

            txtConfirm.UseSystemPasswordChar = !hidden;
            btnToggleConfirm.IconChar = hidden
                ? FontAwesome.Sharp.IconChar.Eye
                : FontAwesome.Sharp.IconChar.EyeSlash;
        }
    }
}
