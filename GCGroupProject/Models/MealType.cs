using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCGroupProject.Models
{
    public class MealType
    {
        public int MealTypeID { get; set; }
        public string MealTypeName { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}