using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GCGroupProject.Models
{
    public class Recipe
    {
        [Key]
        public int RecipeID { get; set; }
        public string RecipeTitle { get; set; }
        public string Steps { get; set; }
        public int PrepTime { get; set; }
        public int CookTime { get; set; }
        public int Servings { get; set; }
        public int MealTypeID { get; set; }

        public virtual ICollection<RecipeIngredient> RecipeIngedients { get; set; }
        public virtual MealType MealType { get; set; }
    }
}