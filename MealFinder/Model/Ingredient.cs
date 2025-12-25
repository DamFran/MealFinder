using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealFinder.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Name) && Stock >= 0;
        }
    }
}
