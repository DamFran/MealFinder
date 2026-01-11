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
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();

            lblDeskripsi.AutoSize = true;
            lblDeskripsi.MaximumSize = new Size(300, 0); // Atur lebar maksimum
            lblDeskripsi.Text = "MealFinder adalah aplikasi mencari resep berdasarkan bahan yang tersedia oleh pengguna";
        }
    }
}
