using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCGroupProject.viewModels
{
    public class RecipeIngredientDetailView
    {
        public int RecipeID { get; set; }
        public string RecipeTitle { get; set; }
        public int PrepTime { get; set; }
        public string Steps { get; set; }
        public int CookTime { get; set; }
        public ICollection<string> IngredientNames { get; set; }
    }
}