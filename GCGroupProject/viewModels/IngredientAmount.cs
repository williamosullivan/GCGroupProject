using GCGroupProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCGroupProject.viewModels
{
    public class IngredientAmount
    {
        public string Amount { get; set; }
        public int IngredientID { get; set; }
        public string IngredientName { get; set; }
    }
}