using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace GCGroupProject.Models
{
    public class RecipeIngredient
    {
        [Key, Column(Order = 0)]
        public int IngredientID { get; set; }
        [Key, Column(Order = 1)]
        public int RecipeID { get; set; }
        public string Amount { get; set; }

        public virtual Ingredient Ingredient { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
