using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GCGroupProject.DAL;
using GCGroupProject.Models;
using PagedList;
using GCGroupProject.viewModels;

namespace GCGroupProject.Controllers
{
    public class RecipeController : Controller
    {
        private RecipeContext db = new RecipeContext();

        // GET: Recipe
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.MealTypeSortParm = String.IsNullOrEmpty(sortOrder) ? "meal_desc" : "";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var recipes = from r in db.Recipes
                          select r;
            if (!String.IsNullOrEmpty(searchString))
            {
                recipes = from r in db.Recipes
                          where r.RecipeTitle.ToUpper() == (searchString).ToUpper()
                          select r;
            }
            switch (sortOrder)
            {
                case "name_desc":
                    recipes = recipes.OrderByDescending(r => r.RecipeTitle);
                    break;
                case "meal_desc":
                    recipes = recipes.OrderByDescending(r => r.MealType);
                    break;
                default:
                    recipes = recipes.OrderBy(r => r.RecipeTitle);
                    break;
            }
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(recipes.ToPagedList(pageNumber, pageSize));
        }

        // GET: Recipe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            RecipeIngredientDetailView recipeDetails = new RecipeIngredientDetailView();
            recipeDetails.RecipeTitle = recipe.RecipeTitle;
            recipeDetails.RecipeID = recipe.RecipeID;
            recipeDetails.MealType = recipe.MealType;
            recipeDetails.Steps = recipe.Steps;
            recipeDetails.PrepTime = recipe.PrepTime;
            recipeDetails.CookTime = recipe.CookTime;
            recipeDetails.Servings = recipe.Servings;
            
            recipeDetails.IngredientNames = from i in db.Ingredients
                                             join ri in db.RecipeIngredients
                                             on i.IngredientID equals ri.IngredientID
                                             join r in db.Recipes
                                             on ri.RecipeID equals r.RecipeID
                                             where r.RecipeID == (int)id
                                             orderby i.IngredientName
                                             select new IngredientAmount{IngredientID=i.IngredientID,IngredientName=i.IngredientName,Amount=ri.Amount};
            
            if (recipeDetails == null)
            {
                return HttpNotFound();
            }
            return View(recipeDetails);
        }

        // GET: Recipe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recipe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecipeID,RecipeTitle,Steps,PrepTime,CookTime,Servings,MealType")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                db.Recipes.Add(recipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recipe);
        }

        // GET: Recipe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            PopulateIngredientsDropdown();
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // POST: Recipe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecipeID,RecipeTitle,Steps,PrepTime,CookTime,Servings,MealType")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recipe);
        }

        // GET: Recipe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // POST: Recipe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recipe recipe = db.Recipes.Find(id);
            db.Recipes.Remove(recipe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET: EditIngredients
        public ActionResult EditIngredientsView(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            PopulateIngredientsDropdown();
            var ingredientAmounts=from i in db.Ingredients
                                             join ri in db.RecipeIngredients
                                             on i.IngredientID equals ri.IngredientID
                                             join r in db.Recipes
                                             on ri.RecipeID equals r.RecipeID
                                             where r.RecipeID == (int)id
                                             orderby i.IngredientName
                                             select new IngredientAmount{IngredientID=i.IngredientID,IngredientName=i.IngredientName,Amount=ri.Amount};
            return View(ingredientAmounts);
        }

        //prepare ingredient dropdown list
        public void PopulateIngredientsDropdown()
        {
            var ingredientListing = new List<string>();
            var ingredientQuery = (from i in db.Ingredients
                                  orderby i.IngredientName
                                  select i.IngredientName);
            ingredientListing.AddRange(ingredientQuery);
            ViewBag.SelectListIngredient = new SelectList(ingredientListing);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public void PopulateIngredientDropdown()
        {
            var ingredientListing = new List<string>();
            var ingredientQuery = from i in db.Ingredients
                                  orderby i.IngredientName
                                  select i.IngredientName;
            ingredientListing.AddRange(ingredientQuery);
            ViewBag.SelectListIngredient = new SelectList(ingredientListing);
        }
    }
}
