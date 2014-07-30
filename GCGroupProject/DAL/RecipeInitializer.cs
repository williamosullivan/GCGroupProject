using GCGroupProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCGroupProject.DAL
{
    public class RecipeInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<RecipeContext>
    {
        protected override void Seed(RecipeContext context)
        {
            var recipes = new List<Recipe>
            {
                new Recipe{RecipeID = 1, RecipeTitle = "Something", PrepTime = 10, Steps = "Cook it", CookTime = 15, Servings = 5}
            };
            recipes.ForEach(s => context.Recipes.Add(s));
            context.SaveChanges();

            var ingredients = new List<Ingredient>
            {
                new Ingredient{IngedientID = 1, IngredientName = "Salt"}
            };
            ingredients.ForEach(s => context.Ingredients.Add(s));
            context.SaveChanges();

            var recipeIngredients = new List<RecipeIngredient>
            {
                new RecipeIngredient{RecipeID = 1, IngredientID = 1, Amount = "Alot"}
            };
            recipeIngredients.ForEach(s => context.RecipeIngredients.Add(s));
            context.SaveChanges();

            var mealTypes = new List<MealType>
            {
                new MealType{MealTypeID = 1, MealTypeName = "Breakfast"}
            };
            mealTypes.ForEach(s => context.MealTypes.Add(s));
            context.SaveChanges();
        }
    }
}