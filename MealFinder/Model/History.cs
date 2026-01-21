using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealFinder.Model
{
    public class Riwayat
    {
        public int HistoryID { get; set; }
        public int UserID { get; set; }
        public int RecipeID { get; set; }
        public string RecipeName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
