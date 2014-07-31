using GCGroupProject.Models;
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
        public int Servings { get; set; }
        public string MealType { get; set; }
        public IEnumerable<IngredientAmount> IngredientNames { get; set; }
    }
}