using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealFinder.Models
{
        public class Ingredient
        {
            public int IngredientID { get; set; }
            public string IngredientName { get; set; }
            public string IngredientQuantity { get; set; }
            public int RecipeID { get; set; }
        }
    }

