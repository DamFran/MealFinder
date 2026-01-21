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
        public History()
        {
            InitializeComponent();
        }



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
