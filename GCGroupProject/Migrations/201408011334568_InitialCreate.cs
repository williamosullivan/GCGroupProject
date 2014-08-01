namespace GCGroupProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ingredient",
                c => new
                    {
                        IngredientID = c.Int(nullable: false, identity: true),
                        IngredientName = c.String(),
                    })
                .PrimaryKey(t => t.IngredientID);
            
            CreateTable(
                "dbo.RecipeIngredient",
                c => new
                    {
                        IngredientID = c.Int(nullable: false),
                        RecipeID = c.Int(nullable: false),
                        Amount = c.String(),
                    })
                .PrimaryKey(t => new { t.IngredientID, t.RecipeID })
                .ForeignKey("dbo.Ingredient", t => t.IngredientID, cascadeDelete: true)
                .ForeignKey("dbo.Recipe", t => t.RecipeID, cascadeDelete: true)
                .Index(t => t.IngredientID)
                .Index(t => t.RecipeID);
            
            CreateTable(
                "dbo.Recipe",
                c => new
                    {
                        RecipeID = c.Int(nullable: false, identity: true),
                        RecipeTitle = c.String(),
                        Steps = c.String(),
                        PrepTime = c.Int(nullable: false),
                        CookTime = c.Int(nullable: false),
                        Servings = c.Int(nullable: false),
                        MealType = c.String(),
                    })
                .PrimaryKey(t => t.RecipeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeIngredient", "RecipeID", "dbo.Recipe");
            DropForeignKey("dbo.RecipeIngredient", "IngredientID", "dbo.Ingredient");
            DropIndex("dbo.RecipeIngredient", new[] { "RecipeID" });
            DropIndex("dbo.RecipeIngredient", new[] { "IngredientID" });
            DropTable("dbo.Recipe");
            DropTable("dbo.RecipeIngredient");
            DropTable("dbo.Ingredient");
        }
    }
}
