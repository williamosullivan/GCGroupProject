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
            //=================================================================================
            var recipes = new List<Recipe>
            {
                new Recipe{RecipeID = 1, RecipeTitle = "Cake", PrepTime = 20,
                    Steps = "1. Preheat the oven to 350 degrees. 2. Put the cake mix, eggs, milk, and cooking oil into a mixing bowl. 3. Mix for six minutes. 4. Put it into two cake pans. 5. Place the two cake pans into the oven and cook for twenty-five minutes. 6. Take the two cooking pans out of the oven and let them cool for ten minutes. 7. Frost and enjoy", 
                    CookTime = 25, Servings = 8, MealType = "Dessert"},
                new Recipe{RecipeID = 2, RecipeTitle = "French Fries", PrepTime = 10,
                    Steps = "1. Put two cups of cooking oil int a pot and bring the cooking oil to a boil. 2. Cut six white potatoes into medium size wedges. 3. Add the wedges into the boiling oil. 4. Cook for twelve minutes.", 
                    CookTime = 15, Servings = 2, MealType = "Snack"}, 
                new Recipe{RecipeID = 3, RecipeTitle = "Hamburgers", PrepTime = 5,
                    Steps = "1. Take one pound of hamburger and break it into four equal parts. 2. Put a frying pan on the stove with a low flame. 3. Cook one side of the hamburger for seven. 4. Turn the hamburger over and cook the other side for seven more minutes. Enjoy!", 
                    CookTime = 20, Servings = 4, MealType = "Lunch"}, 
                new Recipe{RecipeID = 4, RecipeTitle = "Pancakes", PrepTime = 10,
                    Steps = "1. Mix the pancake mix, milk, eggs, and cooking oil in a large bowl. 2. Mix the ingredients together for two minutes. 3. Put a frying pan on the stove with a low flame. 4. Put the mix into the frying pan. 5. Cook one side of the pancake for two minutes, then turn the pancake over and cook that side for two minutes.", 
                    CookTime = 15, Servings = 1, MealType = "Breakfast"}, 
                new Recipe{RecipeID = 5, RecipeTitle = "Spaghetti", PrepTime = 3,
                    Steps = "1. Bring a pot of water to a boil. 2. Take one pound of spaghetti and put it in the pot of boiling water. 3. Let boil for twelve minutes. 4. Take spaghetti out of the boiling water and let cool for five minutes. 5. Add spaghetti sauce.", 
                    CookTime = 12, Servings = 3, MealType = "Dinner"}
            };

            recipes.ForEach(s => context.Recipes.Add(s));
            context.SaveChanges();
            //=================================================================================
            var ingredients = new List<Ingredient>
            {
                new Ingredient{IngredientID = 1, IngredientName = "American Cheese"},
                new Ingredient{IngredientID = 2, IngredientName = "Cake Frosting"},
                new Ingredient{IngredientID = 3, IngredientName = "Cake Mix"},
                new Ingredient{IngredientID = 4, IngredientName = "Cooking Oil"},
                new Ingredient{IngredientID = 5, IngredientName = "Eggs"},
                new Ingredient{IngredientID = 6, IngredientName = "Hamburger"},
                new Ingredient{IngredientID = 7, IngredientName = "Ketchup"},
                new Ingredient{IngredientID = 8, IngredientName = "Milk"},
                new Ingredient{IngredientID = 9, IngredientName = "Pancake Mix"},
                new Ingredient{IngredientID = 10, IngredientName = "Salt"},
                new Ingredient{IngredientID = 11, IngredientName = "Spaghetti"},
                new Ingredient{IngredientID = 12, IngredientName = "Sugar"},
                new Ingredient{IngredientID = 13, IngredientName = "Tomato Sauce"},
                new Ingredient{IngredientID = 14, IngredientName = "White Potatoes"}
            };

            ingredients.ForEach(s => context.Ingredients.Add(s));
            context.SaveChanges();
            //=================================================================================
            var recipeIngredients = new List<RecipeIngredient>
            {
                new RecipeIngredient{RecipeID = 1, IngredientID = 2, Amount = "2 Cups"},
                new RecipeIngredient{RecipeID = 1, IngredientID = 3, Amount = "2 - 8 oz Boxes"},
                new RecipeIngredient{RecipeID = 1, IngredientID = 4, Amount = "3 Tablespoons"},
                new RecipeIngredient{RecipeID = 1, IngredientID = 5, Amount = "2"},
                new RecipeIngredient{RecipeID = 1, IngredientID = 8, Amount = "1 Cup"},
                new RecipeIngredient{RecipeID = 2, IngredientID = 4, Amount = "2 Cups"},
                new RecipeIngredient{RecipeID = 2, IngredientID = 14, Amount = "6"},
                new RecipeIngredient{RecipeID = 3, IngredientID = 6, Amount = "1 Pound"},
                new RecipeIngredient{RecipeID = 4, IngredientID = 4, Amount = "3 Tablespoons"},
                new RecipeIngredient{RecipeID = 4, IngredientID = 5, Amount = "2"},
                new RecipeIngredient{RecipeID = 4, IngredientID = 8, Amount = "1 Cup"},
                new RecipeIngredient{RecipeID = 4, IngredientID = 9, Amount = "1 - 8 oz Box"},
                new RecipeIngredient{RecipeID = 5, IngredientID = 11, Amount = "1 Pound"},
                new RecipeIngredient{RecipeID = 5, IngredientID = 13, Amount = "1 Cup"}
            };

            recipeIngredients.ForEach(s => context.RecipeIngredients.Add(s));
            context.SaveChanges();
            //=================================================================================
        }
    }
}