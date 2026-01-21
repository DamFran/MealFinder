using MealFinder.Database;
using MealFinder.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MealFinder.View
{
    public partial class History : UserControl
    {
        private List<Model.Riwayat> histories;

        public History()
        {
            InitializeComponent();

            SetupGrid();
            ApplyRoleAccess();
            LoadHistory();

            this.Load += History_Load;
        }

        private void History_Load(object sender, EventArgs e)
        {
            ApplyRoleAccess();
            LoadHistory();
        }

        // ================= ROLE ACCESS =================
        private void ApplyRoleAccess()
        {
            // HANYA USER BOLEH LIHAT
            bool isUser =
                Session.CurrentUser?.Role?
                    .Trim()
                    .Equals("user", StringComparison.OrdinalIgnoreCase) == true;

            if (!isUser)
            {
                this.Visible = false;
                return;
            }
        }

        // ================= SETUP GRID =================
        private void SetupGrid()
        {
            dgvHistory.Dock = DockStyle.Fill;
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.RowHeadersVisible = false;
            dgvHistory.ReadOnly = true;
            dgvHistory.ScrollBars = ScrollBars.Both;

            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistory.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvHistory.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvHistory.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvHistory.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            dgvHistory.Columns.Clear();

            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "HistoryID",
                Visible = false
            });

            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "RecipeName",
                HeaderText = "Resep",
                FillWeight = 60
            });

            dgvHistory.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CreatedAt",
                HeaderText = "Tanggal",
                FillWeight = 40
            });
        }

        // ================= LOAD DATA =================
        private void LoadHistory()
        {
            if (Session.CurrentUser == null)
                return;

            // 🔥 HANYA HISTORY USER LOGIN
            histories = HistoryDB.GetByUser(Session.CurrentUser.UserID);

            dgvHistory.Rows.Clear();

            foreach (var h in histories)
            {
                dgvHistory.Rows.Add(
                    h.HistoryID,
                    h.RecipeName,
                    h.CreatedAt.ToString("dd MMM yyyy HH:mm")
                );
            }
        }

        public void ReloadHistory()
        {
            LoadHistory();
        }


        // ================= BACK =================
        private void btnBack_Click(object sender, EventArgs e)
        {
            PanelForm mainForm = this.FindForm() as PanelForm;
            if (mainForm != null)
            {
                mainForm.OpenRecipeControl();

                if (mainForm.RecipeControl != null)
                    mainForm.RecipeControl.ReloadBahanDapur();
            }
        }
    }
}